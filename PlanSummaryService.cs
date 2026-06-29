using System;
using System.Collections.Generic;
using System.Linq;
using StudyPlannerWinForms.Models;

namespace StudyPlannerWinForms.Services;

internal class PlanSummaryService
{
    public class SubjectSummaryRow
    {
        public string SubjectName { get; set; } = "";
        public string TargetDla { get; set; } = "";
        public string PlannedDla { get; set; } = "";
    }

    public class SummaryResult
    {
        public List<SubjectSummaryRow> Rows { get; set; } = new();
        public List<string> Warnings { get; set; } = new();
    }

    /// <summary>
    /// Calcula las métricas de estudio y analiza las alertas de entregas próximas o vencidas.
    /// </summary>
    public SummaryResult CalculateSummary(AppData data)
    {
        var result = new SummaryResult();
        var activeSubjects = data.Subjects.Where(s => s.Active).ToList();

        // Agrupación mediante LINQ para calcular los totales de planificación.
        var minutesBySubject = data.Plan
            .GroupBy(p => p.SubjectId)
            .ToDictionary(
                g => g.Key,
                g => new
                {
                    Deep = g.Where(x => x.Type == BlockType.Profundo).Sum(x => x.DurationMinutes),
                    Light = g.Where(x => x.Type == BlockType.Ligero).Sum(x => x.DurationMinutes),
                    Act = g.Where(x => x.Type == BlockType.Actividades).Sum(x => x.DurationMinutes),
                });

        // Evaluación de discrepancias entre objetivos establecidos y minutos planificados.
        foreach (var s in activeSubjects)
        {
            minutesBySubject.TryGetValue(s.Id, out var planned);

            int pDeep = planned?.Deep ?? 0;
            int pLight = planned?.Light ?? 0;
            int pAct = planned?.Act ?? 0;

            int tDeep = s.TargetDeepMinutes;
            int tLight = s.TargetLightMinutes;
            int tAct = s.TargetActivityMinutes;

            result.Rows.Add(new SubjectSummaryRow
            {
                SubjectName = s.Name,
                TargetDla = FormatDla(tDeep, tLight, tAct),
                PlannedDla = FormatDla(pDeep, pLight, pAct)
            });

            if (tDeep > 0 && pDeep < tDeep)
                result.Warnings.Add($"Faltan {tDeep - pDeep} min PROFUNDO en {s.Name}");

            if (tLight > 0 && pLight < tLight)
                result.Warnings.Add($"Faltan {tLight - pLight} min LIGERO en {s.Name}");

            if (tAct > 0 && pAct < tAct)
                result.Warnings.Add($"Faltan {tAct - pAct} min ACTIVIDADES en {s.Name}");
        }

        var today = DateTime.Today;

        // Análisis predictivo de entregas inminentes (ventana de 7 días).
        var limit = today.AddDays(7);
        var upcoming = data.Subjects
            .Where(s => s.Active)
            .SelectMany(s => s.Activities.Select(a => new { Subject = s, Act = a }))
            .Where(x => !string.IsNullOrWhiteSpace(x.Act.Title))
            .Where(x => x.Act.DueDate.HasValue)
            .Select(x => new
            {
                x.Subject.Name,
                Title = x.Act.Title.Trim(),
                Due = x.Act.DueDate!.Value.Date
            })
            .Where(x => x.Due >= today && x.Due <= limit)
            .OrderBy(x => x.Due)
            .ThenBy(x => x.Name)
            .ToList();

        if (upcoming.Count > 0)
        {
            result.Warnings.Add("");
            result.Warnings.Add("📌 Entregas próximas (7 días):");

            foreach (var u in upcoming)
            {
                var daysLeft = (u.Due - today).Days;
                var dText = daysLeft == 0 ? "HOY" : $"en {daysLeft} día(s)";
                result.Warnings.Add($"- {u.Name}: {u.Title} → {u.Due:dd/MM/yyyy} ({dText})");
            }
        }

        // Detección retrospectiva de entregas vencidas.
        var overdue = data.Subjects
            .Where(s => s.Active)
            .SelectMany(s => s.Activities.Select(a => new { Subject = s, Act = a }))
            .Where(x => !string.IsNullOrWhiteSpace(x.Act.Title))
            .Where(x => x.Act.DueDate.HasValue)
            .Select(x => new
            {
                x.Subject.Name,
                Title = x.Act.Title.Trim(),
                Due = x.Act.DueDate!.Value.Date
            })
            .Where(x => x.Due < today)
            .OrderByDescending(x => x.Due)
            .ThenBy(x => x.Name)
            .ToList();

        if (overdue.Count > 0)
        {
            result.Warnings.Add("");
            result.Warnings.Add("⚠️ Entregas vencidas:");

            foreach (var o in overdue)
            {
                var daysLate = (today - o.Due).Days;
                result.Warnings.Add($"- {o.Name}: {o.Title} → {o.Due:dd/MM/yyyy} (hace {daysLate} día(s))");
            }
        }

        if (data.Plan.Count == 0)
            result.Warnings.Insert(0, "El sistema no contiene registros de planificación generados.");

        return result;
    }

    private static string FormatDla(int deep, int light, int act)
    {
        int total = deep + light + act;
        return $"D:{deep} L:{light} A:{act} (T:{total})";
    }
}