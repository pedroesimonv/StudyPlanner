using System;
using System.Collections.Generic;
using System.Linq;
using StudyPlannerWinForms.Models;

namespace StudyPlannerWinForms.Services; // O tu namespace principal si no tienes carpeta Services

internal class PlanGenerator
{
    // Usamos una Tupla para devolver dos cosas: si tuvo éxito y un mensaje.
    public (bool Success, string Message) GeneratePlan(AppData data)
    {
        var today = DateTime.Today;

        // 1. Borrado inteligente
        data.Plan.RemoveAll(s => s.Date >= today && !s.Completed);

        var subjects = data.Subjects.Where(x => x.Active).ToList();
        if (subjects.Count == 0)
            return (false, "No hay asignaturas activas.");

        // 2. Filtrado de huecos
        var blocks = data.TimeBlocks
            .Where(b => b.Date >= today && !data.Plan.Any(p => p.Date == b.Date && p.Start == b.Start))
            .OrderBy(b => b.Date.Date)
            .ThenBy(b => b.Start)
            .ToList();

        if (blocks.Count == 0)
            return (false, "No hay huecos de estudio disponibles de hoy en adelante.");

        // 3. Recálculo de minutos
        var deepRemaining = subjects.ToDictionary(
            s => s.Id,
            s => Math.Max(0, s.TargetDeepMinutes - data.Plan.Where(p => p.SubjectId == s.Id && p.Type == BlockType.Profundo).Sum(p => p.DurationMinutes))
        );

        var lightRemaining = subjects.ToDictionary(
            s => s.Id,
            s => Math.Max(0, s.TargetLightMinutes - data.Plan.Where(p => p.SubjectId == s.Id && p.Type == BlockType.Ligero).Sum(p => p.DurationMinutes))
        );

        var actRemaining = subjects.ToDictionary(
            s => s.Id,
            s => Math.Max(0, s.TargetActivityMinutes - data.Plan.Where(p => p.SubjectId == s.Id && p.Type == BlockType.Actividades).Sum(p => p.DurationMinutes))
        );

        if (deepRemaining.Values.Sum() == 0) foreach (var id in deepRemaining.Keys.ToList()) deepRemaining[id] = 30;
        if (lightRemaining.Values.Sum() == 0) foreach (var id in lightRemaining.Keys.ToList()) lightRemaining[id] = 30;

        int plannedActBlocks = 0;
        int maxActBlocks = 2;

        foreach (var b in blocks)
        {
            int duration = b.DurationMinutes;
            var preferredType = duration >= 50 ? BlockType.Profundo : BlockType.Ligero;

            bool shouldUseActivities = duration >= 40 && plannedActBlocks < maxActBlocks && actRemaining.Values.Sum() > 0;

            Guid chosenSubjectId;
            BlockType finalType;

            if (shouldUseActivities)
            {
                finalType = BlockType.Actividades;
                chosenSubjectId = PickSubjectByRemainingWeighted(actRemaining, subjects);
                plannedActBlocks++;
                actRemaining[chosenSubjectId] = Math.Max(0, actRemaining[chosenSubjectId] - duration);
            }
            else if (preferredType == BlockType.Profundo)
            {
                finalType = BlockType.Profundo;
                chosenSubjectId = PickSubjectByRemainingWeighted(deepRemaining, subjects);
                deepRemaining[chosenSubjectId] = Math.Max(0, deepRemaining[chosenSubjectId] - duration);
            }
            else
            {
                finalType = BlockType.Ligero;
                chosenSubjectId = PickSubjectByRemainingWeighted(lightRemaining, subjects);
                lightRemaining[chosenSubjectId] = Math.Max(0, lightRemaining[chosenSubjectId] - duration);
            }

            var strategy = finalType switch
            {
                BlockType.Profundo => "Ejercicios + corrección (sin distracciones)",
                BlockType.Ligero => "Flashcards + repaso activo",
                BlockType.Actividades => "Actividad evaluable / entrega",
                _ => ""
            };

            var chosenSub = subjects.First(x => x.Id == chosenSubjectId);
            data.Plan.Add(new StudySession
            {
                Date = b.Date.Date,
                Start = b.Start,
                End = b.End,
                SubjectId = chosenSubjectId,
                Type = finalType,
                Strategy = strategy,
                Notes = "",
                Topic = chosenSub.CurrentTopic,
                Checkpoint = chosenSub.CurrentCheckpoint,
                Completed = false
            });
        }

        return (true, "Planning generado correctamente.");
    }

    private Guid PickSubjectByRemainingWeighted(Dictionary<Guid, int> remainingBySubject, List<Subject> activeSubjects)
    {
        if (remainingBySubject.Values.All(v => v <= 0))
            return activeSubjects[0].Id;

        Guid bestId = activeSubjects[0].Id;
        double bestScore = double.MinValue;

        foreach (var sub in activeSubjects)
        {
            remainingBySubject.TryGetValue(sub.Id, out int rem);
            if (rem <= 0) continue;

            double score = rem * SubjectWeight(sub);

            if (score > bestScore)
            {
                bestScore = score;
                bestId = sub.Id;
            }
        }

        if (bestScore == double.MinValue)
            return activeSubjects[0].Id;

        return bestId;
    }

    private double PriorityWeight(int priority)
    {
        priority = Math.Clamp(priority, 1, 5);
        return 2.25 - (priority * 0.25);
    }

    private double ExamWeight(DateTime? examDate)
    {
        if (examDate == null) return 1.0;

        var days = (examDate.Value.Date - DateTime.Today).TotalDays;
        if (days < 0) days = 0;

        const double window = 28.0;
        var urgency = Math.Clamp((window - days) / window, 0.0, 1.0);

        return 1.0 + urgency;
    }

    private double SubjectWeight(Subject s)
    {
        return PriorityWeight(s.Priority) * ExamWeight(s.ExamDate);
    }
}