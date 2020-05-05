using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ListViewRef.Model
{
    public class ClassWithObsList : INotifyPropertyChanged
    {
        private string title;

        public string Title {
            get { return title; }
            set {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public ObservableCollection<string> Strings { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ClassWithObsList(string title, ObservableCollection<string> strings)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
