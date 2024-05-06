using System.Windows;
using System.Windows.Media.Animation;

namespace ButtonAnimationExample
{
    public partial class MainWindow : Window
    {
        private readonly Storyboard _storyboardButtonShow;
        private readonly Storyboard _storyboardButtonHide;

        public MainWindow()
        {
            InitializeComponent();

            _storyboardButtonShow = (Storyboard) FindResource("StoryboardButtonShow");
            _storyboardButtonHide = (Storyboard) FindResource("StoryboardButtonHide");
        }

        private void TriggerButton_Click(object sender, RoutedEventArgs e)
        {
            _storyboardButtonShow.Begin(targetButton);
            _storyboardButtonHide.Begin(TriggerButton);
        }

        private void TargetButton_OnClick(object sender, RoutedEventArgs e)
        {
            _storyboardButtonHide.Begin(targetButton);
            _storyboardButtonShow.Begin(TriggerButton);
        }
    }
}