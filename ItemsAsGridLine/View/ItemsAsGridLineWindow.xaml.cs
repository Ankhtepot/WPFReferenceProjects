using ItemsAsGridLine.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ItemsAsGridLine.View
{
    /// <summary>
    /// Interaction logic for ItemsAsGridLineWindow.xaml
    /// </summary>
    public partial class ItemsAsGridLineWindow : Window
    {
        public MainVM MainVM;
        public ItemsAsGridLineWindow()
        {
            InitializeComponent();
            MainVM = new MainVM();
            TopContainer.DataContext = MainVM;
        }
    }
}
