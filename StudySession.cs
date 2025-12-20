namespace StudyPlannerWinForms.Models
{
    public enum BlockType
    { Profundo, Ligero, Actividades }

    internal class StudySession
    {
        public DateTime Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public Guid SubjectId { get; set; }
        public BlockType Type { get; set; }
        public string Strategy { get; set; } = "";
        public string Notes { get; set; } = "";

        public int DurationMinutes =>
            (int)(End - Start).TotalMinutes;

        //

        public string Topic { get; set; } = "";
        public string Checkpoint { get; set; } = "";
        public bool Completed { get; set; } = false;

    }
}