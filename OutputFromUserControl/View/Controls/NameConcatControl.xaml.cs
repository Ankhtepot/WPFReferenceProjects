using System.Windows;
using System.Windows.Controls;

namespace OutputFromUserControl.View.Controls
{
    /// <summary>
    /// Interaction logic for NameConcatControl.xaml
    /// </summary>
    public partial class NameConcatControl : UserControl
    {
        public string NameInput {
            get { return (string)GetValue(NameInputProperty); }
            set { SetValue(NameInputProperty, value); }
        }

        public static string defaultNameInput = "NameInput";
        public static readonly DependencyProperty NameInputProperty =
            DependencyProperty.Register("NameInput", typeof(string), typeof(NameConcatControl), new PropertyMetadata(defaultNameInput, SetNameOutput));


        public string SurnameInput {
            get { return (string)GetValue(SurnameInputProperty); }
            set { SetValue(SurnameInputProperty, value); }
        }

        public static string defaultSurnameInput = "Surname Input";
        public static readonly DependencyProperty SurnameInputProperty =
            DependencyProperty.Register("SurnameInput", typeof(string), typeof(NameConcatControl), new PropertyMetadata(defaultSurnameInput, SetNameOutput));


        public string NameOutput {
            get { return (string)GetValue(NameOutputProperty); }
            set { SetValue(NameOutputProperty, value); }
        }

        public static string defaultNameOutput = "Name Output";
        public static readonly DependencyProperty NameOutputProperty =
            DependencyProperty.Register("NameOutput", typeof(string), typeof(NameConcatControl), new PropertyMetadata(defaultNameOutput));


        private static void SetNameOutput(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NameConcatControl control = (NameConcatControl)d;

            string nameInput = "";
            string surnameInput = "";

            if(e.Property.Name == "NameInput")
            {
                string newValue = (string)e.NewValue;
                nameInput = string.IsNullOrEmpty(newValue) ? "" : newValue;
            }
            else
            {
                nameInput = string.IsNullOrEmpty(control.NameInputTextBlock.Text)
                ? ""
                : control.NameInputTextBlock.Text;
            }

            if(e.Property.Name == "SurnameInput")
            {
                string newValue = (string)e.NewValue;
                surnameInput = string.IsNullOrEmpty(newValue) ? "" : newValue;
            }
            else
            {
                surnameInput = string.IsNullOrEmpty(control.SurnameInputTextBlock.Text)
                ? ""
                : control.SurnameInputTextBlock.Text;
            }

            string fullName = $"{nameInput} {surnameInput}";

            control.OutputNameTextBlock.Text = fullName;
        }

        public NameConcatControl()
        {
            InitializeComponent();
        }
    }
}
