namespace StrongWay.Views.Controls;

public partial class RoundButton : ContentView
{
	public RoundButton()
	{
		InitializeComponent();

        BindingContext = this;
	}

    // 1. Text
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(Entry), "Button", BindingMode.OneWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    // 2. BorderBackground
    public static readonly BindableProperty BorderBackgroundProperty =
        BindableProperty.Create(nameof(BorderBackground), typeof(Color), typeof(Border), Color.FromArgb("#323232"));

    public Color BorderBackground
    {
        get => (Color)GetValue(BorderBackgroundProperty);
        set => SetValue(BorderBackgroundProperty, value);
    }

    // 2. StrokeColor
    public static readonly BindableProperty StrokeColorProperty =
        BindableProperty.Create(nameof(StrokeColor), typeof(Color), typeof(Border), Colors.White);

    public Color StrokeColor
    {
        get => (Color)GetValue(StrokeColorProperty);
        set => SetValue(StrokeColorProperty, value);
    }
}