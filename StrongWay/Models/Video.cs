namespace StrongWay.Models
{
    /// <summary>
    /// Prepare a video file to be used
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Exercise's Difficulty
        /// </summary>
        public enum Difficulty
        {
            None = 0,
            Beginner,
            Intermediate,
            Advanced
        }

        /// <summary>
        /// Muscle Group that the exercise focuses
        /// </summary>
        public enum MuscleGroup
        {
            None = 0,

            // Arms
            Arms,
            Arms_Biceps,
            Arms_Triceps,
            Arms_Forearm,

            // Back
            Back,
            Back_Lats,
            Back_Traps,
            Back_LowerBack,
            Back_Upperback,

            // Chest
            Chest,

            // Legs
            Legs,
            Legs_Calves,
            Legs_Quads,

            // Shoulders
            Shoulders
        }

        /// <summary>
        /// Video source path
        /// </summary>
        public string Source { get; private set; } = string.Empty;
        /// <summary>
        /// Video name
        /// </summary>
        public string Name { get; private set; } = string.Empty;
        /// <summary>
        /// Video thumbnail
        /// </summary>
        public string Thumbnail { get; private set; } = string.Empty;
        /// <summary>
        /// Video exercise difficulty
        /// </summary>
        public Difficulty Exercise_Difficulty { get; private set; } = Difficulty.None;
        /// <summary>
        /// Video exercise muscle group focused
        /// </summary>
        public MuscleGroup Muscle_Group { get; private set; } = MuscleGroup.None;

        /// <summary>
        /// Instantiate a video object
        /// </summary>
        /// <param name="name">Video name</param>
        /// <param name="thumbnail">Video thumbnail</param>
        /// <param name="exerciseDifficulty">Video exercise difficulty</param>
        /// <param name="muscleGroup">Video exercise muscle group focused</param>
        public Video(string source, string name, string thumbnail, Difficulty exerciseDifficulty, MuscleGroup muscleGroup)
        {
            Source = source;
            Name = name;
            Thumbnail = thumbnail;
            Exercise_Difficulty = exerciseDifficulty;
            Muscle_Group = muscleGroup;
        }
    }
}
