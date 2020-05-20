using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GridView.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }


        private ObservableCollection<ObservableCollection<string>> SourceCollection;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            Title = "Grid View displaying Observable Collection of Observable Collections of strings.";

            SourceCollection = generateData();
        }

        private ObservableCollection<ObservableCollection<string>> generateData()
        {
            ObservableCollection<ObservableCollection<string>> result = new ObservableCollection<ObservableCollection<string>>();
            for (int i = 0; i < 5; i++)
            {
                var line = new ObservableCollection<string>();
                for (int j = 0; j < 10; j++)
                {
                    line.Add($"Data Entry Line: {i} Entry: {j}");
                }
                result.Add(line);
            }
            return result;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
