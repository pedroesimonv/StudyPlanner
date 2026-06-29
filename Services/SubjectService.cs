using System;
using System.Linq;
using StudyPlannerWinForms.Models;

namespace StudyPlannerWinForms.Services;

internal class SubjectService
{
    /// <summary>
    /// Guarda una asignatura en el sistema (Crea una nueva o actualiza la existente).
    /// Devuelve el ID de la asignatura editada o creada.
    /// </summary>
    public Guid SaveSubject(AppData data, Guid? editingId, Subject sourceData, out string statusMessage)
    {
        Subject? existing = null;
        if (editingId.HasValue)
            existing = data.Subjects.FirstOrDefault(x => x.Id == editingId.Value);

        if (existing == null)
        {
            // Forzamos un nuevo ID si es una creación limpia
            sourceData.Id = Guid.NewGuid();
            data.Subjects.Add(sourceData);
            statusMessage = "Asignatura creada exitosamente.";
            return sourceData.Id;
        }
        else
        {
            // Copia de propiedades a la entidad existente
            existing.Name = sourceData.Name;
            existing.Course = sourceData.Course;
            existing.Priority = sourceData.Priority;
            existing.ExamDate = sourceData.ExamDate;
            existing.TargetDeepMinutes = sourceData.TargetDeepMinutes;
            existing.TargetLightMinutes = sourceData.TargetLightMinutes;
            existing.TargetActivityMinutes = sourceData.TargetActivityMinutes;
            existing.Active = sourceData.Active;
            existing.CurrentTopic = sourceData.CurrentTopic;
            existing.CurrentCheckpoint = sourceData.CurrentCheckpoint;
            existing.Activities = sourceData.Activities;

            statusMessage = "Asignatura actualizada exitosamente.";
            return existing.Id;
        }
    }

    /// <summary>
    /// Elimina una asignatura de la lista del sistema.
    /// </summary>
    public bool DeleteSubject(AppData data, Subject? subject, out string statusMessage)
    {
        if (subject == null)
        {
            statusMessage = "Debe seleccionar una asignatura para proceder con la eliminación.";
            return false;
        }

        data.Subjects.Remove(subject);
        statusMessage = "Asignatura eliminada del sistema.";
        return true;
    }
}