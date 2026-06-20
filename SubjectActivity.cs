using System;

namespace StudyPlannerWinForms.Models; // Añadimos .Models

public class SubjectActivity
{
    public string Title { get; set; } = "";
    public DateTime? DueDate { get; set; }
}