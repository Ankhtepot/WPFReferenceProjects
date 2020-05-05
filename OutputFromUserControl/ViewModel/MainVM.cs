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

        private string nameOutput;

        public string NameOutput {
            get { return nameOutput; }
            set {
                nameOutput = value;
                OnPropertyChanged(nameof(NameOutput));
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
