using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GridViewRef.Model
{
    public class ListViewExtension : UserControl
    {


        public DataMatrix MatrixSource
        {
            get { return (DataMatrix)GetValue(MatrixSourceProperty); }
            set { SetValue(MatrixSourceProperty, value); }
        }

        public static readonly DependencyProperty MatrixSourceProperty =
            DependencyProperty.Register("MatrixSource", typeof(DataMatrix), typeof(ListViewExtension), new PropertyMetadata(OnMatrixSourceChanged));



        //public static readonly DependencyProperty MatrixSourceProperty =
        //    DependencyProperty.RegisterAttached("MatrixSource",
        //    typeof(DataMatrix), typeof(ListViewExtension),
        //        new FrameworkPropertyMetadata(null,
        //            new PropertyChangedCallback(OnMatrixSourceChanged)));

        //public static DataMatrix GetMatrixSource(DependencyObject d)
        //{
        //    return (DataMatrix)d.GetValue(MatrixSourceProperty);
        //}

        //public static void SetMatrixSource(DependencyObject d, DataMatrix value)
        //{
        //    d.SetValue(MatrixSourceProperty, value);
        //}

        private static void OnMatrixSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListView listView = d as ListView;
            DataMatrix dataMatrix = e.NewValue as DataMatrix;

            listView.ItemsSource = dataMatrix;
            System.Windows.Controls.GridView gridView = listView.View as System.Windows.Controls.GridView;
            int count = 0;
            gridView.Columns.Clear();
            foreach (var col in dataMatrix.Columns)
            {
                gridView.Columns.Add(
                    new GridViewColumn
                    {
                        Header = col.Name,
                        DisplayMemberBinding = new Binding($"[{count}]")
                    });
                count++;
            }
        }
    }
}
