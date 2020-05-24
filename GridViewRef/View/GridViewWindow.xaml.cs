using GridView.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
