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
            set { columnCount = value < 1 ? 1 : value; generateGridData(RowCount, ColumnCount); OnPropertyChanged(); }
        }

        private int rowCount;
        public int RowCount
        {
            get { return rowCount; }
            set { rowCount = value < 1 ? 1 : value; generateGridData(RowCount, ColumnCount); OnPropertyChanged(); }
        }

        public MainVM()
        {
            ColumnCount = 5;
            RowCount = 5;
            //generateGridData(5,5);
            Title = "Dynamic generation of Grid, with dynamic components generation.";
        }

        private void generateGridData(int rowCount = 1, int columnCount = 1)
        {
            GridData = new DataMatrix();
            rowCount = rowCount.Clamp(1,1000);
            columnCount = columnCount.Clamp(1,20);

            var lines = new List<List<string>>();
            var columnConfigs = new List<ColumnConfig>();

            for (int i = 0; i < rowCount; i++)
            {
                var line = new List<string>();
                for (int j = 0; j < columnCount; j++)
                {
                    line.Add($"Line: {i + 1} Column: {j + 1}");

                    if (i == 0)
                    {
                        columnConfigs.Add(new ColumnConfig(EnumUtils.RandomValueOf<ItemType>()));
                    }
                }
                lines.Add(line);
            }

            GridData = new DataMatrix { Lines = lines, ColumnConfigurations = columnConfigs};
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
