namespace StudyPlannerWinForms.Models
{
    public class TimeBlock
    {
        public DateTime Date { get; set; }       // solo día
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public int DurationMinutes =>
            (int)(End - Start).TotalMinutes;
    }
}