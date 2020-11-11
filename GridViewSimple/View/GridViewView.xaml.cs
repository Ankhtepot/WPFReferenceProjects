using System.Windows;

namespace GridViewSimple.View
{
    using GridViewSimple.ViewModel;

    /// <summary>
    /// Interaction logic for GridViewView.xaml
    /// </summary>
    public partial class GridViewView : Window
    {
        private GridViewVM context;

        public GridViewView()
        {
            InitializeComponent();

            context = new GridViewVM();

            TopContainer.DataContext = context;
        }
    }
}
