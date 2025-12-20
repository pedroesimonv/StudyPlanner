namespace StudyPlannerWinForms.Models;

internal class Subject
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public string Course { get; set; } = "1º"; // "1º" o "2º"
    public int Priority { get; set; } = 3;     // 1 alta - 5 baja
    public DateTime? ExamDate { get; set; }    // opcional
    public int TargetDeepMinutes { get; set; }
    public int TargetLightMinutes { get; set; }
    public int TargetActivityMinutes { get; set; }
    public bool Active { get; set; } = true;

    //
    public string CurrentTopic { get; set; } = "";
    public string CurrentCheckpoint { get; set; } = "";

    //
    public List<SubjectActivity> Activities { get; set; } = new();

}