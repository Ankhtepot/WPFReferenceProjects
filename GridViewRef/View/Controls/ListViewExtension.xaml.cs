using GridViewRef.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GridViewRef.View.Controls
{
    /// <summary>
    /// Interaction logic for ListViewExtension.xaml
    /// </summary>
    public partial class ListViewExtension : UserControl
    {
        public DataMatrix MatrixSource
        {
            get { return (DataMatrix)GetValue(MatrixSourceProperty); }
            set { SetValue(MatrixSourceProperty, value); }
        }

        public static readonly DependencyProperty MatrixSourceProperty =
            DependencyProperty.Register("MatrixSource", typeof(DataMatrix), typeof(ListViewExtension), new PropertyMetadata(OnMatrixSourceChanged));

        private static void OnMatrixSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListViewExtension control = d as ListViewExtension;

            if (control.MainListView == null)
            {
                return;
            }

            DataMatrix dataMatrix = e.NewValue as DataMatrix;

            control.MainListView.ItemsSource = dataMatrix;
            System.Windows.Controls.GridView gridView = control.MainListView.View as System.Windows.Controls.GridView;
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

        public ListViewExtension()
        {
            InitializeComponent();
        }
    }
}
