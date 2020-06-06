using System.ComponentModel;

namespace SimpleUserControl.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private string textBoxText;

        public string TextBoxText {
            get { return textBoxText; }
            set 
            {
                textBoxText = value; 
                OnPropertyChanged(nameof(TextBoxText)); 
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
