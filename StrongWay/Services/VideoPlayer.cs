using Newtonsoft.Json;
using StrongWay.Models;

namespace StrongWay.Services
{
    public class VideoPlayer
    {
        public List<Video> Videos { get; private set; } = new();

        /// <summary>
        /// Returns true if there are videos loaded
        /// </summary>
        public bool IsInitialized => Videos.Count > 0;

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
            var assembly = typeof(VideoPlayer).Assembly;

            // Formatul este: NAMESPACE.FOLDER.FILENAME
            using var stream = assembly.GetManifestResourceStream("StrongWay.Resources.Data.videos_metadata.json")
                ?? throw new Exception("Embedded videos_metadata.json file not found.");

            using var reader = new StreamReader(stream);
            string json = await reader.ReadToEndAsync();

            Videos = JsonConvert.DeserializeObject<List<Video>>(json)!;
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
