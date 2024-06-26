﻿namespace AnglePickerControl.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Prism.Commands;

    public class MainVm : INotifyPropertyChanged
    {
        private double _angle;

        public double Angle
        {
            get => _angle;
            set
            {
                _angle = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand RiseAngleCommand { get; }
        public DelegateCommand LowerAngleCommand { get; }

        public MainVm()
        {
            Angle = 0.0;

            RiseAngleCommand = new DelegateCommand(RiseAngle);
            LowerAngleCommand = new DelegateCommand(LowerAngle);
        }

        private void RiseAngle()
        {
            Angle = Angle + 1.0 >= 359.0 ? 0.0 : Angle + 1.0;
        }

        private void LowerAngle()
        {
            Angle = Angle - 1.0 < 0.0 ? 359.0 : Angle - 1.0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
