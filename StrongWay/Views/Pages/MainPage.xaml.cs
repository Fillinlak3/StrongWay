using Services.Logging;
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
            Logger.Log("MainPage", "Object created.");

            BindingContext = this;
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

            Logger.Log("MainPage", "Gathered videos, page initialized. Opening WorkoutPanel.");
            BodyContent.Content = new Panels.WorkoutPanel(_videoPlayer);

            /* 
                Bind the event for every ImageBox that is sending through DisplayBox and WorkoutPanel to MainPage.
                Everytime when the user presses an ImageBox in the WorkoutPanel, the event will be caught here
                And also here will open the OverlayView for the Video that is received from the ImageBox.
                The video will be played in the overlay, and under it will have the video description and details.
             */
            (BodyContent.Content as Panels.WorkoutPanel)!.VideoClickedEvent += (s, video) =>
            {
                Logger.LogInfo("MainPage", $"Video to open: {video.Name}");
                //OverlayView.IsVisible = true;
            };
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
            Logger.Log("MainPage", $"Focusing: {classID}.");
        }
    }
}
