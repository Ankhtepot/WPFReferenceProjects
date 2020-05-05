using ListViewRef.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace ListViewRef.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string mainTitle;

        public string MainTitle {
            get { return mainTitle; }
            set { mainTitle = value; OnPropertyChanged(nameof(MainTitle)); }
        }

        private string nestedSelectedItem;

        public string NestedSelectedItem {
            get { return nestedSelectedItem; }
            set 
            {
                nestedSelectedItem = value;
                MessageBox.Show("NestedSelectedItem: " + nestedSelectedItem);
                OnPropertyChanged(nameof(NestedSelectedItem)); 
            }
        }

        private string outterSelectedItem;

        public string OutterSelectedItem {
            get { return outterSelectedItem; }
            set 
            {
                outterSelectedItem = value;
                MessageBox.Show("OutterSelectedItem: " + OutterSelectedItem);
                OnPropertyChanged(nameof(OutterSelectedItem)); 
            }
        }

        public ObservableCollection<ClassWithObsList> SourceCollection { get; set; }

        public MainVM()
        {
            MainTitle = "Title of the Grid";

            SourceCollection = new ObservableCollection<ClassWithObsList> {
                new ClassWithObsList("First Title", new ObservableCollection<string> { "First", "Second"}),
                new ClassWithObsList("Second Title", new ObservableCollection<string> { "Third", "Fourth"}),
                new ClassWithObsList("Third Title", new ObservableCollection<string> { "Fifth", "Sixth"}),
            };
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
