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

    // 3. StrokeColor
    public static readonly BindableProperty StrokeColorProperty =
        BindableProperty.Create(nameof(StrokeColor), typeof(Color), typeof(Border), Colors.White);

    public Color StrokeColor
    {
        get => (Color)GetValue(StrokeColorProperty);
        set => SetValue(StrokeColorProperty, value);
    }

    // 4. FontSize
    public static readonly BindableProperty TextFontSizeProperty =
        BindableProperty.Create(nameof(TextFontSize), typeof(double), typeof(RoundButton), 14.0);

    public double TextFontSize
    {
        get => (double)GetValue(TextFontSizeProperty);
        set => SetValue(TextFontSizeProperty, value);
    }

    // 5. FontWeight (FontAttributes)
    public static readonly BindableProperty TextFontAttributesProperty =
        BindableProperty.Create(nameof(TextFontAttributes), typeof(FontAttributes), typeof(RoundButton), FontAttributes.None);

    public FontAttributes TextFontAttributes
    {
        get => (FontAttributes)GetValue(TextFontAttributesProperty);
        set => SetValue(TextFontAttributesProperty, value);
    }

    // 2. TextColor
    public static readonly BindableProperty TextForegroundColorProperty =
        BindableProperty.Create(nameof(TextForegroundColor), typeof(Color), typeof(RoundButton), Color.FromArgb("#FFFFFF"));

    public Color TextForegroundColor
    {
        get => (Color)GetValue(TextForegroundColorProperty);
        set => SetValue(TextForegroundColorProperty, value);
    }
}