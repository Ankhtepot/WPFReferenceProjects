namespace AnglePickerControl.View
{
    using ViewModel;

    /// <summary>
    /// Interaction logic for AnglePickerWindow.xaml
    /// </summary>
    public partial class AnglePickerWindow
    {
        public AnglePickerWindow()
        {
            InitializeComponent();

            TopContainer.DataContext = new MainVm();
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
