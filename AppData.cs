using System.Collections.Generic;

namespace StudyPlannerWinForms.Models
{
    internal class AppData
    {
        public List<Subject> Subjects { get; } = new();
        public List<TimeBlock> TimeBlocks { get; } = new();
        public List<StudySession> Plan { get; } = new();
    }
}