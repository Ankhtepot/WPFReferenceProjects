using ItemsAsGridLine.Extensions;
using ItemsAsGridLine.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static ItemsAsGridLine.Model.Enums;

namespace ItemsAsGridLine.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }


        private DataMatrix gridData;
        public DataMatrix GridData
        {
            get { return gridData; }
            set { gridData = value; OnPropertyChanged(); }
        }

        private int columnCount;
        public int ColumnCount
        {
            get { return columnCount; }
            set 
            {
                columnCount = value.Clamp(1, 100); 
                generateGridData(); 
                OnPropertyChanged(); 
            }
        }

        private int rowCount;
        public int RowCount
        {
            get { return rowCount; }
            set 
            {
                rowCount = value.Clamp(1, 1000);
                generateGridData();
                OnPropertyChanged(); 
            }
        }

        public MainVM()
        {
            ColumnCount =  5;
            RowCount = 5;
            Title = "Dynamic generation of Grid, with dynamic components generation.";
        }

        private void generateGridData()
        {
            GridData = new DataMatrix();

            var lines = new List<List<string>>();
            var columnConfigs = new List<ColumnConfig>();

            for (int i = 0; i < RowCount; i++)
            {
                var line = new List<string>();
                for (int j = 0; j < ColumnCount; j++)
                {
                    line.Add($"Line: {i + 1} Column: {j + 1}");

                    if (i == 0)
                    {
                        columnConfigs.Add(new ColumnConfig(EnumUtils.RandomValueOf<ItemType>()));
                    }
                }
                lines.Add(line);
            }

            GridData = new DataMatrix { Lines = lines, ColumnConfigurations = columnConfigs };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
