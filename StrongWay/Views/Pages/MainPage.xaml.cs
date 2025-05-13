using StrongWay.Services;
using System.Diagnostics;

namespace StrongWay.Views.Pages
{
    public partial class MainPage : ContentPage
    {
        public static readonly string UnfocusedColor = "#b3a0ff";
        public static readonly string FocusedColor = "#e2f163";
        private VideoPlayer _videoPlayer;

        public MainPage(VideoPlayer videoPlayer)
        {
            InitializeComponent();

            _videoPlayer = videoPlayer;
        }

        private async void ContentPage_Initialize(object sender, EventArgs e)
        {
            /*
                Checks if there are videos loaded already.
                Skips initializing over and over again.
             */
            if(_videoPlayer.IsInitialized == false)
                await _videoPlayer.InitAsync();

            foreach (var item in _videoPlayer.Videos)
                Debug.WriteLine(item.Name);

            BodyContent.Content = new Panels.WorkoutPanel(_videoPlayer);
        }

        void UnfocusAllBodyButtons()
        {
            WorkoutImage.Source = "barbell.svg";
            WorkoutLabel.TextColor = Color.FromArgb(UnfocusedColor);

            ProgressImage.Source = "clipboard.svg";
            ProgressLabel.TextColor = Color.FromArgb(UnfocusedColor);

            NutritionImage.Source = "nutrition.svg";
            NutritionLabel.TextColor = Color.FromArgb(UnfocusedColor);

            CommunityImage.Source = "community.svg";
            CommunityLabel.TextColor = Color.FromArgb(UnfocusedColor);
        }

        void FocusBodyButtonByClassId(string classID)
        {
            UnfocusAllBodyButtons();

            switch (classID)
            {
                case "Workout":
                    WorkoutImage.Source = "barbell_focused.svg";
                    WorkoutLabel.TextColor = Color.FromArgb(FocusedColor);
                    break;
                case "Progress":
                    ProgressImage.Source = "clipboard_focused.svg";
                    ProgressLabel.TextColor = Color.FromArgb(FocusedColor);
                    break;
                case "Nutrition":
                    NutritionImage.Source = "nutrition_focused.svg";
                    NutritionLabel.TextColor = Color.FromArgb(FocusedColor);
                    break;
                case "Community":
                    CommunityImage.Source = "community_focused.svg";
                    CommunityLabel.TextColor = Color.FromArgb(FocusedColor);
                    break;
                default:
                    break;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            if (sender is not VisualElement tappedElement)
                return;

            string classID = tappedElement.ClassId;
            FocusBodyButtonByClassId(classID);
            Debug.WriteLine(classID);
        }
    }
}
