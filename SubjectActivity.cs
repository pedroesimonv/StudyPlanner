using System;

namespace StudyPlannerWinForms.Models; // Añadimos .Models y usamos el punto y coma

public class SubjectActivity
{
    public string Title { get; set; } = "";
    public DateTime? DueDate { get; set; }
}