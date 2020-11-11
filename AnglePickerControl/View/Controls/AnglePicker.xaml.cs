namespace AnglePickerControl.View.Controls
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Media;
    using AnglePickerControl.Annotations;
    using System;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for AnglePicker.xaml
    /// </summary>
    public partial class AnglePicker : UserControl, INotifyPropertyChanged
    {
        private Point center = new Point(50,50);

        private double reverseAngle;

        public double ReverseAngle
        {
            get => reverseAngle;
            set
            {
                reverseAngle = value;
                OnPropertyChanged();
            }
        }

        public double Angle
        {
            get => (double)GetValue(AngleProperty);
            set => SetValue(AngleProperty, value);
        }
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(AnglePicker), new PropertyMetadata(0d, AngleChanged));

        public Brush BackgroundOuter
        {
            get => (Brush)GetValue(BackgroundOuterProperty);
            set => SetValue(BackgroundOuterProperty, value);
        }
        public static readonly DependencyProperty BackgroundOuterProperty =
            DependencyProperty.Register("BackgroundOuter", typeof(Brush), typeof(AnglePicker), new PropertyMetadata(Brushes.Transparent));

        public Brush BackgroundInner
        {
            get => (Brush)GetValue(BackgroundInnerProperty);
            set => SetValue(BackgroundInnerProperty, value);
        }
        public static readonly DependencyProperty BackgroundInnerProperty =
            DependencyProperty.Register("BackgroundInner", typeof(Brush), typeof(AnglePicker), new PropertyMetadata(Brushes.Transparent));

        public Brush StrokeCircle
        {
            get => (Brush)GetValue(StrokeCircleProperty);
            set => SetValue(StrokeCircleProperty, value);
        }
        public static readonly DependencyProperty StrokeCircleProperty =
            DependencyProperty.Register("StrokeCircle", typeof(Brush), typeof(AnglePicker), new PropertyMetadata(Brushes.Black));

        public Brush StrokeAngleLine
        {
            get => (Brush)GetValue(StrokeAngleLineProperty);
            set => SetValue(StrokeAngleLineProperty, value);
        }
        public static readonly DependencyProperty StrokeAngleLineProperty =
            DependencyProperty.Register("StrokeAngleLine", typeof(Brush), typeof(AnglePicker), new PropertyMetadata(Brushes.Black));

        private static void AngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AnglePicker control && e.NewValue is double newValue)
            {
                control.Angle = newValue;
                control.ReverseAngle = 360 - newValue;
                control.OnAngleChanged?.Invoke(newValue);
            }
        }

        public AnglePicker()
        {
            InitializeComponent();

            TopContainer.DataContext = this;

            Angle = 0d;
        }

        public event Action<double> OnAngleChanged;

        private void AnglePickerEllipse_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            SetAngleOnMouseAction(e.GetPosition(OuterEllipse));
        }

        private double CountAngle(Point clickedPoint)
        {
            double deltaX = clickedPoint.X - center.X;
            double deltaY = center.Y - clickedPoint.Y;
            double result = Math.Atan2(deltaY, deltaX) * 180 / Math.PI;
            return result < 0 ? (360d + result) : result;
        }

        private void OuterEllipse_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                SetAngleOnMouseAction(e.GetPosition(OuterEllipse));
            }
        }

        private void SetAngleOnMouseAction(Point clickedPoint)
        {
            Angle = CountAngle(clickedPoint);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
