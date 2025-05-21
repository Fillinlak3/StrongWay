using Newtonsoft.Json;
using StrongWay.Models;
using Difficulty = StrongWay.Models.Video.Difficulty;

namespace StrongWay.Services
{
    public class VideoPlayer
    {
        public List<Video> Videos { get; init; }

        /// <summary>
        /// Returns true if there are videos loaded
        /// </summary>
        public bool IsInitialized => Videos.Count > 0;

        /// <summary>
        /// Default constructor
        /// </summary>
        public VideoPlayer()
        {
            Videos = new List<Video>();
        }

        /// <summary>
        /// Call this before anything else.
        /// </summary>
        public async Task InitAsync()
        {
            await LoadVideosAsync();
        }

        /// <summary>
        /// Load video informations from metadata file.
        /// </summary>
        /// <exception cref="Exception">If embedded json file not found</exception>
        public async Task LoadVideosAsync()
        {
            foreach (Difficulty difficulty in Enum.GetValues(typeof(Difficulty)))
            {
                // Skip the none phase.
                if (difficulty == Difficulty.None) continue;

                string json = await GetEmbeddedJsonManifestBy(difficulty);

                // If returns empty, skip it
                if (string.IsNullOrWhiteSpace(json)) continue;
                Videos.AddRange(JsonConvert.DeserializeObject<List<Video>>(json)!);
            }
        }

        /// <summary>
        /// Get embedded json file based on Difficulty in a string output.
        /// </summary>
        /// <param name="difficulty">Exercise Difficulty</param>
        /// <returns>A json string</returns>
        /// <exception cref="Exception">If embedded resource not found</exception>
        private async Task<string> GetEmbeddedJsonManifestBy(Difficulty difficulty)
        {
            var assembly = typeof(VideoPlayer).Assembly;

            string file_prefix = difficulty.ToString().ToLower();
            string filename = $"{file_prefix}_videos_metadata.json";
            // Format is: NAMESPACE.FOLDER.FILENAME
            using var stream = assembly.GetManifestResourceStream($"StrongWay.Resources.Data.{filename}")
                ?? throw new Exception($"Embedded {filename} file not found.");

            using var reader = new StreamReader(stream);
            string json = await reader.ReadToEndAsync();
            return json;
        }

        /// <summary>
        /// Get a list of Video objects filtered by difficulty and optionally by muscle group.
        /// </summary>
        /// <param name="difficulty">Required difficulty level</param>
        /// <param name="muscleGroup">Optional muscle group (default: None = no filter)</param>
        /// <returns>Filtered IEnumerable of Video objects</returns>
        public IEnumerable<Video> GetBy(Video.Difficulty difficulty, Video.MuscleGroup muscleGroup = Video.MuscleGroup.None) =>
            Videos.Where(v => v.Exercise_Difficulty == difficulty &&
                             // If is none, skip the muscle group       Otherwise, also select based on muscle group
                             (muscleGroup == Video.MuscleGroup.None || v.Muscle_Group == muscleGroup));

    }
}
