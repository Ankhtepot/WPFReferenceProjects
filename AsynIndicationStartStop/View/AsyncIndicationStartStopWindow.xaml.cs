using AsynIndicationStartStop.ViewModel;
using System.Windows;

namespace AsynIndicationStartStop.View
{    
    /// <summary>
    /// Interaction logic for AsyncIndicationStartStopWindow.xaml
    /// </summary>
    public partial class AsyncIndicationStartStopWindow : Window
    {
        public MainVM MainVM;

        public AsyncIndicationStartStopWindow()
        {
            InitializeComponent();
            MainVM = new MainVM();
            container.DataContext = MainVM;
        }
    }
}
