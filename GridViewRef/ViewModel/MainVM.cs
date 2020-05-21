using GridViewRef.Commands;
using GridViewRef.Model;
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
        private int batchNo = 0;

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
            set { columnCount = value < 1 ? 1 : value; OnPropertyChanged(); }
        }

        private int rowCount;

        public int RowCount
        {
            get { return rowCount; }
            set { rowCount = value < 1 ? 1 : value; OnPropertyChanged(); }
        }



        public FetchNextDataBatchCommand FetchNextDataBatchCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            Title = "Dynamic creation of a table with ViewList and GridView.";
            FetchNextDataBatchCommand = new FetchNextDataBatchCommand(this);

            FetchNextDataBatch();

            RowCount = ColumnCount = 1;
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

            List<MatrixColumn> columns = new List<MatrixColumn>();
            for (int i = 0; i < ColumnCount; i++)
            {
                columns.Add(new MatrixColumn() {Name = $"Column {i+1}", StringFormat = String.Format("{0}", i)});
            }
            return new DataMatrix() { Columns = columns, Rows = rows };
        }

        public void FetchNextDataBatch()
        {
            SourceCollection = generateData();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
