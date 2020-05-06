using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OutputFromUserControl.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private string nameInput;

        public string NameInput {
            get { return nameInput; }
            set 
            {
                nameInput = value;
                OnPropertyChanged(nameof(NameInput));
            }
        }

        private string surnameInput;

        public string SurnameInput {
            get { return surnameInput; }
            set {
                surnameInput = value;
                OnPropertyChanged(nameof(SurnameInput));
            }
        }

        private string fullName;

        public string FullName {
            get { return fullName; }
            set {
                fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
