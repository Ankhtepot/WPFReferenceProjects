using ButtonRadioGroup.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ButtonRadioGroup.View
{
    /// <summary>
    /// Interaction logic for ButtonRadioGroupWindow.xaml
    /// </summary>
    public partial class ButtonRadioGroupWindow : Window
    {
        private MainVM VM;

        public ButtonRadioGroupWindow()
        {
            InitializeComponent();
            VM = new MainVM();
            TopContainer.DataContext = VM;
        }

        private void ButtonListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = (ListBox)sender;
            Console.WriteLine($"SelectedItem index = {list.SelectedIndex} and its Content={e.AddedItems[0]}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonListBox.SelectedIndex = int.Parse((string)((Button)sender).Tag);
        }
    }
}
