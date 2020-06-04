﻿using ItemsAsGridLine.ViewModel;
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
