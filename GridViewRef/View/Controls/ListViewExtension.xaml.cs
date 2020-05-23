using GridViewRef.Model;
using System.Windows.Interactivity;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Behaviours;

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

            control.MainListView.ItemsSource = dataMatrix.Rows;
            System.Windows.Controls.GridView gridView = control.MainListView.View as System.Windows.Controls.GridView;
            int count = 0;
            gridView.Columns.Clear();
            foreach (var col in dataMatrix.Columns)
            {
                GridViewColumn gridViewVolumn = new GridViewColumn { Header = "IM" };
                DataTemplate dataTemplate = new DataTemplate();

                FrameworkElementFactory gridFrameworkFactory = new FrameworkElementFactory(typeof(Grid));
                dataTemplate.VisualTree = gridFrameworkFactory;
                FrameworkElementFactory textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));

                Binding newBinding = new Binding($"[{count}]");
                textBlockFactory.SetBinding(TextBlock.TextProperty, newBinding);
                textBlockFactory.SetValue(TextBlock.ForegroundProperty, new SolidColorBrush(Colors.Red));

                gridFrameworkFactory.AppendChild(textBlockFactory);

                gridViewVolumn.CellTemplate = dataTemplate;
                gridViewVolumn.Header = col;

                gridView.Columns.Add(gridViewVolumn);
               
                count++;
            }

            correctColumnWidths(control);
        }

        public static void correctColumnWidths(ListViewExtension control)
        {
            var mainListView = control.MainListView;

            double remainingSpace = mainListView.ActualWidth;

            var view = mainListView.View as System.Windows.Controls.GridView;

            var lastColumnIndex = view.Columns.Count - 1;

            if (remainingSpace > 0)
            {
                for (int i = 0; i < view.Columns.Count; i++)
                {
                    if (i != lastColumnIndex)
                    {
                        remainingSpace -= view.Columns[i].ActualWidth;
                    }

                    view.Columns[i].Width = remainingSpace;
                }

                //Leave 15 px free for scrollbar
                remainingSpace -= 15;

                view.Columns[lastColumnIndex].Width = remainingSpace;
            }
        }

        public ListViewExtension()
        {
            InitializeComponent();
        }
    }
}
