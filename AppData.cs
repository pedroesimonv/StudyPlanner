namespace StudyPlannerWinForms.Models
{
    internal class AppData
    {
        public List<Subject> Subjects { get; set; } = new();
        public List<TimeBlock> TimeBlocks { get; set; } = new();
        public List<StudySession> Plan { get; set; } = new();
    }
}