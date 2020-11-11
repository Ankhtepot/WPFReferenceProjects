using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ButtonRadioGroup.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<string> nameSource;
        public List<string> NameSource
        {
            get { return nameSource; }
            set { nameSource = value; OnPropertyChanged(); }
        }

        public MainVM()
        {
            NameSource = new List<string>() { "Button 1", "Button 2", "Button 3" };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
