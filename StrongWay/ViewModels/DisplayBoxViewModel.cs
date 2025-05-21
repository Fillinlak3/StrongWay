using Services.Logging;

namespace StrongWay.ViewModels
{
    public class DisplayBoxViewModel : ViewModelBase
    {
        List<Models.Video> VideoExercises { get; init; }

        private string muscleGroup = string.Empty;
		public string MuscleGroup
		{
			get { return muscleGroup; }
			set { muscleGroup = value; OnPropertyChanged(); }
		}

        #region Video_1_Properties
        private string video_1_ThumbnailSource = string.Empty;
        public string Video_1_ThumbnailSource
        {
            get { return video_1_ThumbnailSource; }
            set { video_1_ThumbnailSource = value; OnPropertyChanged(); }
        }

        private string video_1_ExerciseName = string.Empty;
        public string Video_1_ExerciseName
        {
            get { return video_1_ExerciseName; }
            set { video_1_ExerciseName = value; OnPropertyChanged(); }
        }

        private string video_1_TrainingTime = string.Empty;
        public string Video_1_TrainingTime
        {
            get { return video_1_TrainingTime; }
            set { video_1_TrainingTime = value; OnPropertyChanged(); }
        }

        private string video_1_BurnedCalories = string.Empty;
        public string Video_1_BurnedCalories
        {
            get { return video_1_BurnedCalories; }
            set { video_1_BurnedCalories = value; OnPropertyChanged(); }
        }
        #endregion

        #region Video_2_Properties
        private string video_2_ThumbnailSource = string.Empty;
        public string Video_2_ThumbnailSource
        {
            get { return video_2_ThumbnailSource; }
            set { video_2_ThumbnailSource = value; OnPropertyChanged(); }
        }

        private string video_2_ExerciseName = string.Empty;
        public string Video_2_ExerciseName
        {
            get { return video_2_ExerciseName; }
            set { video_2_ExerciseName = value; OnPropertyChanged(); }
        }

        private string video_2_TrainingTime = string.Empty;
        public string Video_2_TrainingTime
        {
            get { return video_2_TrainingTime; }
            set { video_2_TrainingTime = value; OnPropertyChanged(); }
        }

        private string video_2_BurnedCalories = string.Empty;
        public string Video_2_BurnedCalories
        {
            get { return video_2_BurnedCalories; }
            set { video_2_BurnedCalories = value; OnPropertyChanged(); }
        }
        #endregion

        public DisplayBoxViewModel(List<Models.Video> videoExercises)
		{
            VideoExercises = videoExercises;

            InitializeDisplayBox();
            InitializeImageBoxes();
        }

        private void InitializeDisplayBox()
        {
            if (VideoExercises == null || VideoExercises.Count == 0)
            {
                string message = $"List must contain at least 1 element. {nameof(VideoExercises)}";
                Logger.LogFatal("DisplayBoxViewModel", message);
                throw new ArgumentException(message);
            }

            MuscleGroup = VideoExercises[0].Muscle_Group.ToString().Replace("_", " - ");
        }

        public static (T First, T Second) GetTwoRandomDistinct<T>(List<T> list)
        {
            if (list == null || list.Count < 2)
                throw new ArgumentException("List must contain at least 2 elements.", nameof(list));

            var random = new Random();

            int index1 = random.Next(list.Count);
            int index2;

            do
            {
                index2 = random.Next(list.Count);
            } while (index2 == index1);

            return (list[index1], list[index2]);
        }

        private void InitializeImageBoxes()
        {
            if (VideoExercises == null || VideoExercises.Count < 2)
            {
                string message = $"List must contain at least 2 elements. {nameof(VideoExercises)}";
                Logger.LogFatal("DisplayBoxViewModel", message);
                throw new ArgumentException(message);
            }

            //var (video1, video2) = GetTwoRandomDistinct(VideoExercises);
            var video1 = VideoExercises[0];
            var video2 = VideoExercises[1];

            Video_1_ThumbnailSource = video1.Thumbnail;
            Video_1_ExerciseName = video1.Name;
            Video_1_TrainingTime = "12 Min";
            Video_1_BurnedCalories = "120 KCal";

            Video_2_ThumbnailSource = video2.Thumbnail;
            Video_2_ExerciseName = video2.Name;
            Video_2_TrainingTime = "12 Min";
            Video_2_BurnedCalories = "120 KCal";
        }
    }
}
