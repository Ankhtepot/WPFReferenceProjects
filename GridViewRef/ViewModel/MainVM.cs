using GridViewRef.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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


        private DataMatrix sourceCollection;

        public DataMatrix SourceCollection
        {
            get => sourceCollection;
            set { sourceCollection = value; OnPropertyChanged(); }
        }

        private int columnCount;

        public int ColumnCount
        {
            get { return columnCount; }
            set { columnCount = value < 1 ? 1 : value; CreateTable();  OnPropertyChanged(); }
        }

        private int rowCount;

        public int RowCount
        {
            get { return rowCount; }
            set { rowCount = value < 1 ? 1 : value; CreateTable(); OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            Title = "Dynamic creation of a table with ViewList and GridView.";

            RowCount = ColumnCount = 1;

            CreateTable();
        }

        private DataMatrix generateData()
        {
            List<object[]> rows = new List<object[]>();
            for (int i = 0; i < RowCount; i++)
            {
                var line = new object[ColumnCount];
                for (int j = 0; j < ColumnCount; j++)
                {
                    line[j] = ($"Data Entry Line: {i+1} Entry: {j+1}");
                }
                rows.Add(line);
            }

            List<string> columns = new List<string>();
            for (int i = 0; i < ColumnCount; i++)
            {
                columns.Add($"Column {i + 1}");
            }
            return new DataMatrix() { Columns = columns, Rows = rows };
        }

        public void CreateTable()
        {
            SourceCollection = generateData();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
