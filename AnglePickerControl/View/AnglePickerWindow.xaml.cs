using System.Windows;

namespace AnglePickerControl.View
{
    using AnglePickerControl.ViewModel;

    /// <summary>
    /// Interaction logic for AnglePickerWindow.xaml
    /// </summary>
    public partial class AnglePickerWindow : Window
    {
        private MainVM mainVM;

        public AnglePickerWindow()
        {
            InitializeComponent();

            mainVM = new MainVM();

            TopContainer.DataContext = mainVM;
        }

        /// <summary>
        /// Just demonstration of binding to OnAngleChange event.
        /// </summary>
        /// <param name="newAngle"></param>
        private void MainAnglePicker_OnOnAngleChanged(double newAngle)
        {
            
        }
    }
}
