using Prism.Commands;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ItemsAsGridLine.View.Controls
{
    /// <summary>
    /// Interaction logic for IntegerUpDown.xaml
    /// </summary>
    public partial class IntegerUpDown : UserControl
    {
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(IntegerUpDown), new PropertyMetadata(0, ValueChanged));

        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (IntegerUpDown)d;
            var newValue = (int)e.NewValue;

            if(control != null)
            {
                control.Value = newValue;
            }
        }

        public DelegateCommand UpValueCommand { get; set; }
        public DelegateCommand DownValueCommand { get; set; }

        public IntegerUpDown()
        {
            InitializeComponent();
            UpValueCommand = new DelegateCommand(UpValue);
            DownValueCommand = new DelegateCommand(DownValue);

            TopContainer.DataContext = this;
        }

        public void UpValue()
        {            
            Value += 1;
        }

        public void DownValue()
        {
            Value -= 1;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
