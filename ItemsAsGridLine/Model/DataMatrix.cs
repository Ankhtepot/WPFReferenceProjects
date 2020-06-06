using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ItemsAsGridLine.Model
{
    public class DataMatrix : INotifyPropertyChanged
    {
        private List<List<string>> lines;
        public List<List<string>> Lines
        {
            get { return lines; }
            set { lines = value; OnPropertyChanged(); }
        }

        private List<ColumnConfig> columnConfigurations;

        public List<ColumnConfig> ColumnConfigurations
        {
            get { return columnConfigurations; }
            set { columnConfigurations = value; OnPropertyChanged(); }
        }

        public DataMatrix() : this(new List<List<string>>() 
        {
            new List<string>() { "" } },
            new List<ColumnConfig>() { new ColumnConfig() })
        {}

        public DataMatrix(List<List<string>> lines, List<ColumnConfig> columnConfigurations)
        {
            Lines = lines ?? throw new ArgumentNullException(nameof(lines));
            ColumnConfigurations = columnConfigurations ?? throw new ArgumentNullException(nameof(columnConfigurations));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
