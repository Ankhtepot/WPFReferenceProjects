using GridViewRef.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

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
            var gridView = control.MainListView.View as System.Windows.Controls.GridView;
            int count = 0;
            gridView.Columns.Clear();
            foreach (var col in dataMatrix.Columns)
            {
                var gridViewColumn = new GridViewColumn { Header = "IM" };
                var dataTemplate = new DataTemplate();

                var gridFactory = new FrameworkElementFactory(typeof(Grid));
                var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));

                dataTemplate.VisualTree = gridFactory;

                var newBinding = new Binding($"[{count}]");
                textBlockFactory.SetBinding(TextBlock.TextProperty, newBinding);
                textBlockFactory.SetValue(ForegroundProperty, new SolidColorBrush(Colors.Red));
                textBlockFactory.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Stretch);

                gridFactory.SetValue(WidthProperty, double.NaN);
                gridFactory.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
                gridFactory.AppendChild(textBlockFactory);

                var newHeader = new GridViewColumnHeader();
                newHeader.Content = col;
                newHeader.Width = double.NaN;

                gridViewColumn.CellTemplate = dataTemplate;
                gridViewColumn.Header = newHeader;
                gridViewColumn.Width = double.NaN;
                gridViewColumn.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Stretch);

                gridView.Columns.Add(gridViewColumn);
               
                count++;
            }
        }

        public ListViewExtension()
        {
            InitializeComponent();
        }
    }
}
