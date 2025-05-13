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
    }
}
