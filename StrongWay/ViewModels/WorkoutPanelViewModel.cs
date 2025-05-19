using StrongWay.Views.Controls;
using System.Diagnostics;
using Difficulty = StrongWay.Models.Video.Difficulty;
using MuscleGroup = StrongWay.Models.Video.MuscleGroup;

namespace StrongWay.ViewModels
{
    public class WorkoutPanelViewModel : ViewModelBase
    {
        private Services.VideoPlayer VideoPlayer { get; init; }

        public static readonly string UnfocusedColor = "#b3a0ff";
        public static readonly string FocusedColor = "#e2f163";

        private Color beginnerBtnColor = Color.FromArgb(FocusedColor);
        public Color BeginnerBtnColor
        {
            get { return beginnerBtnColor; }
            set { beginnerBtnColor = value; OnPropertyChanged(); }
        }

        private Color intermediateBtnColor = Color.FromArgb(UnfocusedColor);
        public Color IntermediateBtnColor
        {
            get { return intermediateBtnColor; }
            set { intermediateBtnColor = value; OnPropertyChanged(); }
        }

        private Color advancedBtnColor = Color.FromArgb(UnfocusedColor);
        public Color AdvancedBtnColor
        {
            get { return advancedBtnColor; }
            set { advancedBtnColor = value; OnPropertyChanged(); }
        }

        private bool beginnerBoxesVisibility = true;
        public bool BeginnerBoxesVisibility
        {
            get { return beginnerBoxesVisibility; }
            set { beginnerBoxesVisibility = value; OnPropertyChanged(); }
        }

        private bool intermediateBoxesVisibility = false;
        public bool IntermediateBoxesVisibility
        {
            get { return intermediateBoxesVisibility; }
            set { intermediateBoxesVisibility = value; OnPropertyChanged(); }
        }

        private bool advancedBoxesVisibility = false;
        public bool AdvancedBoxesVisibility
        {
            get { return advancedBoxesVisibility; }
            set { advancedBoxesVisibility = value; OnPropertyChanged(); }
        }

        public List<DisplayBox> BeginnerBoxes;

        public List<DisplayBox> IntermediateBoxes;

        public List<DisplayBox> AdvancedBoxes;

        public RelayCommand BeginnerBTN_PressedCommand { get; init; }
        public RelayCommand IntermediateBTN_PressedCommand { get; init; }
        public RelayCommand AdvancedBTN_PressedCommand { get; init; }

        public WorkoutPanelViewModel(Services.VideoPlayer videoPlayer)
        {
            VideoPlayer = videoPlayer;

            BeginnerBTN_PressedCommand = new RelayCommand(DisplayBeginnerBoxes);
            IntermediateBTN_PressedCommand = new RelayCommand(DisplayIntermediateBoxes);
            AdvancedBTN_PressedCommand = new RelayCommand(DisplayAdvancedBoxes);

            BeginnerBoxes = new List<DisplayBox>();
            IntermediateBoxes = new List<DisplayBox>();
            AdvancedBoxes = new List<DisplayBox>();

            InitializeBoxes();
        }

        private void InitializeBoxes()
        {
            GetVideosBy(Difficulty.Beginner);
            GetVideosBy(Difficulty.Intermediate);
            GetVideosBy(Difficulty.Advanced);
        }

        private void GetVideosBy(Difficulty difficulty)
        {
            /*
                For each difficulty create display boxes for every muscle group included in that exercise difficulty.
                Append to the corresponding list of elements based on the difficulty to be displayed on the selected
                difficulty button. (Ex: Beginner button selected -> Beginner Box of beginner displayboxes will be shown)
             */

            var videos = VideoPlayer.GetBy(difficulty);
            List<DisplayBox> boxes = new List<DisplayBox>(); 

            foreach (MuscleGroup muscleGroup in Enum.GetValues(typeof(MuscleGroup)))
            {
                // Skip the none.
                if (muscleGroup == MuscleGroup.None) continue;

                // Select the exercises based on muscle group.
                var exercises = videos.Where(x => x.Muscle_Group == muscleGroup).ToList();

                // If no exercise, skip it.
                if (exercises.Count == 0) continue;

                DisplayBox displayBox = new DisplayBox(exercises);
                boxes.Add(displayBox);
            }

            switch (difficulty)
            {
                case Difficulty.Beginner:
                    BeginnerBoxes = boxes;
                    break;
                case Difficulty.Intermediate:
                    IntermediateBoxes = boxes;
                    break;
                case Difficulty.Advanced:
                    AdvancedBoxes = boxes;
                    break;
                default:
                    break;
            }
        }

        private void FocusButton(Difficulty difficulty)
        {
            BeginnerBtnColor = Color.FromArgb(UnfocusedColor);
            IntermediateBtnColor = Color.FromArgb(UnfocusedColor);
            AdvancedBtnColor = Color.FromArgb(UnfocusedColor);

            BeginnerBoxesVisibility = false;
            IntermediateBoxesVisibility = false;
            AdvancedBoxesVisibility = false;

            switch (difficulty)
            {
                case Difficulty.Beginner:
                    BeginnerBtnColor = Color.FromArgb(FocusedColor);
                    BeginnerBoxesVisibility = true;
                    break;
                case Difficulty.Intermediate:
                    IntermediateBtnColor = Color.FromArgb(FocusedColor);
                    IntermediateBoxesVisibility = true;
                    break;
                case Difficulty.Advanced:
                    AdvancedBtnColor = Color.FromArgb(FocusedColor);
                    AdvancedBoxesVisibility = true;
                    break;
                default:
                    break;
            }
        }

        private void DisplayBeginnerBoxes(object? parameter = null)
        {
            FocusButton(Difficulty.Beginner);
        }

        private void DisplayIntermediateBoxes(object? parameter = null)
        {
            FocusButton(Difficulty.Intermediate);
        }

        private void DisplayAdvancedBoxes(object? parameter = null)
        {
            FocusButton(Difficulty.Advanced);
        }
    }
}
