using AsyncFeedWithSpinner.ViewModel;
using System.Windows;

namespace AsyncFeedWithSpinner.View
{
    /// <summary>
    /// Interaction logic for AsyncFeedWithSpinner.xaml
    /// </summary>
    public partial class AsyncFeedWithSpinner : Window
    {
        MainVM MainVM;
        public AsyncFeedWithSpinner()
        {
            InitializeComponent();
            MainVM = new MainVM();
            container.DataContext = MainVM;
        }
    }
}
