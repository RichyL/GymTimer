namespace TimingService
{
    // All the code in this file is included in all platforms.
    public class Routine
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public int IntroTime { get; set; }

        List<Routine> routines { get; set;}

        public string RoutineFileName { get; set; }

        /// <summary>
        /// TODO: implement this
        /// </summary>
        public string Summary { get;  }
    }

    public class Round
    {
        public int ExerciseTime { get; set; }
        public int RestTime { get; set; }
    }
}