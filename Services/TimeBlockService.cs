using System;
using System.Collections.Generic;
using System.Linq;
using StudyPlannerWinForms.Models;

namespace StudyPlannerWinForms.Services;

internal class TimeBlockService
{
    //método estático auxiliar para las horas
    private static TimeSpan TS(int h, int m) => new TimeSpan(h, m, 0);

    /// <summary>
    /// Valida si un bloque de tiempo es coherente y no se solapa con los ya existentes.
    /// </summary>
    public bool IsBlockValid(TimeBlock b, TimeBlock? editing, List<TimeBlock> existingBlocks, out string message)
    {
        message = "";

        if (b.End <= b.Start)
        {
            message = "Inconsistencia temporal: La hora de finalización debe ser posterior a la de inicio.";
            return false;
        }
        if (b.DurationMinutes < 15)
        {
            message = "La duración mínima permitida para un bloque de estudio es de 15 minutos.";
            return false;
        }

        // Algoritmo de validación de solapamiento temporal.
        foreach (var other in existingBlocks)
        {
            if (editing != null && ReferenceEquals(other, editing)) continue;
            if (other.Date.Date != b.Date.Date) continue;

            bool overlap = b.Start < other.End && other.Start < b.End;
            if (overlap)
            {
                message = "Se ha detectado un conflicto: Este bloque se solapa con otro registro existente en la misma fecha.";
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Devuelve la plantilla de horas recomendadas según el tipo de turno laboral.
    /// </summary>
    public List<(TimeSpan start, TimeSpan end)> TemplateForShift(WeekAutoBlocksDialog.ShiftType shift)
    {
        return shift switch
        {
            WeekAutoBlocksDialog.ShiftType.Manana => new List<(TimeSpan, TimeSpan)>
            {
                (TS(16,00), TS(18,00)),
                (TS(18,15), TS(20,00)),
            },
            WeekAutoBlocksDialog.ShiftType.Tarde => new List<(TimeSpan, TimeSpan)>
            {
                (TS(09,30), TS(11,30)),
                (TS(11,35), TS(12,00)),
            },
            WeekAutoBlocksDialog.ShiftType.Libre0 => new List<(TimeSpan, TimeSpan)>(),
            WeekAutoBlocksDialog.ShiftType.Libre1 => new List<(TimeSpan, TimeSpan)>
            {
                (TS(10,00), TS(12,00)),
            },
            WeekAutoBlocksDialog.ShiftType.Libre2 => new List<(TimeSpan, TimeSpan)>
            {
                (TS(10,00), TS(12,00)),
                (TS(16,00), TS(18,00)),
            },
            _ => new List<(TimeSpan, TimeSpan)>()
        };
    }

    /// <summary>
    /// Genera de forma automatizada los bloques de la semana evaluando restricciones de solapamiento.
    /// </summary>
    public void GenerateWeekBlocks(AppData data, DateTime monday, Dictionary<DayOfWeek, WeekAutoBlocksDialog.ShiftType> shifts, bool replaceWeek)
    {
        var weekStart = monday.Date;
        var weekEndExclusive = weekStart.AddDays(7);

        if (replaceWeek)
        {
            data.TimeBlocks.RemoveAll(b => b.Date.Date >= weekStart && b.Date.Date < weekEndExclusive);
        }

        for (int i = 0; i < 7; i++)
        {
            var day = weekStart.AddDays(i);
            var shift = shifts[day.DayOfWeek];
            var slots = TemplateForShift(shift);

            foreach (var (start, end) in slots)
            {
                var block = new TimeBlock
                {
                    Date = day.Date,
                    Start = start,
                    End = end
                };

                // Reutiliza la validación interna del servicio pasándole la lista del AppData
                if (!IsBlockValid(block, editing: null, data.TimeBlocks, out _))
                    continue;

                data.TimeBlocks.Add(block);
            }
        }

        // Ordenamiento cronológico de la colección.
        data.TimeBlocks.Sort((a, b) =>
        {
            int c = a.Date.Date.CompareTo(b.Date.Date);
            if (c != 0) return c;
            return a.Start.CompareTo(b.Start);
        });
    }
}