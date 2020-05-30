using GridView.ViewModel;
using System.Windows;

namespace GridView.View
{
    /// <summary>
    /// Interaction logic for GridViewComponentWindow.xaml
    /// </summary>
    public partial class GridViewComponentWindow : Window
    {
        private MainVM MainVM;

        public GridViewComponentWindow()
        {
            InitializeComponent();
            MainVM = new MainVM();
            TopContainer.DataContext = MainVM;
        }
    }
}
