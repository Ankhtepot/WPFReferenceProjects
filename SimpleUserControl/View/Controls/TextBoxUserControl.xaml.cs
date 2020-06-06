using System.Windows;
using System.Windows.Controls;

namespace SimpleUserControl.View.Controls
{
    /// <summary>
    /// Interaction logic for TextBoxUserControl.xaml
    /// </summary>
    public partial class TextBoxUserControl : UserControl
    {
        private static string defaultString = "Here you will see text changing";

        public string UCTextTop {
            get { return (string)GetValue(UCTextTopProperty); }
            set { SetValue(UCTextTopProperty, value); }
        }

        public static readonly DependencyProperty UCTextTopProperty =
            DependencyProperty.Register("UCTextTop", typeof(string), typeof(TextBoxUserControl), new PropertyMetadata(defaultString, SetTopText));

        public string UCTextBottom {
            get { return (string)GetValue(UCTextBottomProperty); }
            set { SetValue(UCTextBottomProperty, value); }
        }

        public static readonly DependencyProperty UCTextBottomProperty =
            DependencyProperty.Register("UCTextBottom", typeof(string), typeof(TextBoxUserControl), new PropertyMetadata(defaultString, SetBottomText));

        private static void SetTopText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBoxUserControl control = (TextBoxUserControl)d;
            string newValue = (string)e.NewValue;

            if (control != null)
            {
                control.UCTopTextBlock.Text = string.IsNullOrEmpty(newValue)
                    ? (string)e.OldValue
                    : newValue;
            }
        }

        private static void SetBottomText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBoxUserControl control = (TextBoxUserControl)d;
            string newValue = (string)e.NewValue;

            if (control != null)
            {
                control.UCBottomTextBlock.Text = string.IsNullOrEmpty(newValue) 
                    ? (string)e.OldValue 
                    : newValue.ToUpper();
            }
        }

        public TextBoxUserControl()
        {
            InitializeComponent();
        }
    }
}
