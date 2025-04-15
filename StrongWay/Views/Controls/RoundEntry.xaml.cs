namespace StrongWay.Views.Controls;

public partial class RoundEntry : ContentView
{
	public RoundEntry()
	{
		InitializeComponent();
        BindingContext = this;
    }

    // 1. Text
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(Entry), default(string), BindingMode.TwoWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    // 2. Placeholder
    public static readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(Entry), default(string));

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    // 3. BorderBackground
    public static readonly BindableProperty BorderBackgroundProperty =
        BindableProperty.Create(nameof(BorderBackground), typeof(Color), typeof(Entry), Colors.Transparent);

    // 4. IsPassword
    public static readonly BindableProperty IsPasswordProperty =
    BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(Entry), false);

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public Color BorderBackground
    {
        get => (Color)GetValue(BorderBackgroundProperty);
        set => SetValue(BorderBackgroundProperty, value);
    }
}