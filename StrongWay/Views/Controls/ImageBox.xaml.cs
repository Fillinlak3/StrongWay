using Services.Logging;
using System.Diagnostics;

namespace StrongWay.Views.Controls;

public partial class ImageBox : ContentView
{
	public ImageBox()
	{
		InitializeComponent();
    }

    // 1. Exercise Thumbnail Image Source
    public static readonly BindableProperty VideoThumbnailSourceProperty =
        BindableProperty.Create(nameof(VideoThumbnailSource), typeof(string), typeof(ImageBox), default(string));

    public string VideoThumbnailSource
    {
        get => (string)GetValue(VideoThumbnailSourceProperty);
        set => SetValue(VideoThumbnailSourceProperty, value);
    }

    // 2. Exercise Name
    public static readonly BindableProperty ExerciseNameProperty =
        BindableProperty.Create(nameof(ExerciseName), typeof(string), typeof(ImageBox), default(string));

    public string ExerciseName
    {
        get => (string)GetValue(ExerciseNameProperty);
        set => SetValue(ExerciseNameProperty, value);
    }

    // 3. Exercise Training Time
    public static readonly BindableProperty TrainingTimeProperty =
        BindableProperty.Create(nameof(TrainingTime), typeof(string), typeof(ImageBox), default(string));

    public string TrainingTime
    {
        get => (string)GetValue(TrainingTimeProperty);
        set => SetValue(TrainingTimeProperty, value);
    }

    // 4. Exercise Burned Calories
    public static readonly BindableProperty BurnedCaloriesProperty =
        BindableProperty.Create(nameof(BurnedCalories), typeof(string), typeof(ImageBox), default(string));

    public string BurnedCalories
    {
        get => (string)GetValue(BurnedCaloriesProperty);
        set => SetValue(BurnedCaloriesProperty, value);
    }

    public Models.Video? Video_Exercise;
    public event EventHandler<Models.Video>? VideoClickedEvent;
    private void SendVideoToOverlay(object sender, TappedEventArgs e)
    {
        if (Video_Exercise is null)
        {
            Logger.LogFatal("ImageBox", "Cannot send an null video object to overlay.");
            throw new ArgumentNullException($"Video object is null: {nameof(Video_Exercise)}");
        }

        Logger.LogInfo("ImageBox", $"Sent to video-overlay: {Video_Exercise.Name}");
        VideoClickedEvent?.Invoke(this, Video_Exercise);
    }
}