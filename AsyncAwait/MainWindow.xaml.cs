using System.Threading.Tasks;
using System.Windows;
using System;

namespace AsyncAwait
{ //   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int MainWindowWidth = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            ColorBlock.Margin = new Thickness(0, 0, (int)ColorBlockWrapper.ActualWidth - (int)ColorBlock.Width, 0);

            StatusTextBlock.Text = "...working...";
            await MoveBlockAsync(3);
            StatusTextBlock.Text = "Process finished";
        }

        private async Task MoveBlockAsync(int lines)
        {
            int startLeftPos = (int)ColorBlockWrapper.ActualWidth - (int)ColorBlock.Width;
            int topMargin = 0;
            int bottomMargin = 200;

            for (int i = 0; i < lines; i++)
            {
                for (int w = startLeftPos; w > -startLeftPos; w -= 5)
                {
                    ChangeImageMargin(new Thickness(0, topMargin, w, bottomMargin));
                    await Task.Delay(1);
                }

                topMargin += 20;
                bottomMargin -= 20;
            }
        }

        private void ChangeImageMargin(Thickness newMargin)
        {
            ColorBlock.Margin = new Thickness(newMargin.Left, newMargin.Top, newMargin.Right, newMargin.Bottom);
        }

        public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainWindowWidth = (int)e.NewSize.Width;
            Thickness newMargin = ColorBlock.Margin;
            newMargin.Right = (int)ColorBlockWrapper.ActualWidth - ColorBlock.Width;
            ColorBlock.Margin = newMargin;
        }
    }
}
