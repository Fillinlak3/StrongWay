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
}