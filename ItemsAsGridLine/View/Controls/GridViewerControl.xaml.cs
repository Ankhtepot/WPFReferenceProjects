using ItemsAsGridLine.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ItemsAsGridLine.View.Controls
{
    /// <summary>
    /// Interaction logic for GridViewerControl.xaml
    /// </summary>
    public partial class GridViewerControl : UserControl
    {
        private static readonly DataMatrix DEFAULT_LINE = new DataMatrix
        {
            Lines = new List<List<string>>() { new List<string>() { "" } },
            ColumnConfigurations = new List<ColumnConfig>() { new ColumnConfig() }
        };

        public DataMatrix LineSource
        {
            get { return (DataMatrix)GetValue(LineSourceProperty); }
            set { SetValue(LineSourceProperty, value); }
        }
        public static readonly DependencyProperty LineSourceProperty =
            DependencyProperty.Register("LineSource", typeof(DataMatrix), typeof(GridViewerControl), new PropertyMetadata(DEFAULT_LINE, LineSourceChanged));

        private static void LineSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (GridViewerControl)d;
            var newValue = (DataMatrix)e.NewValue;

            if (control == null || newValue == null)
            {
                return;
            }

            var topContainer = control.TopContainer as Border;
            topContainer.Child = null;

            //var actualWidthBinding = new Binding("ActualWidth");
            //actualWidthBinding.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Window), 1);

            var mainGrid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };

            //mainGrid.SetBinding(WidthProperty, actualWidthBinding);

            for (int i = 0; i < newValue.Lines.Count; i++) // Line
            {
                UIElement newControl;
                
                mainGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                for (int j = 0; j < newValue.Lines[i].Count; j++) // Column
                {
                    mainGrid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        //Width = GridLength.Auto,
                        MaxWidth = 300d,
                        MinWidth = 150d
                    });

                    newControl = ResolveNewElement(newValue.ColumnConfigurations[j], newValue.Lines[i][j]);
                    Grid.SetColumn(newControl, j);
                    Grid.SetRow(newControl, i);

                    var frame = new Rectangle()
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 1,
                        Fill = Brushes.Transparent
                    };
                    
                    Grid.SetColumn(frame, j);
                    Grid.SetRow(frame, i);

                    mainGrid.Children.Add(frame);
                    mainGrid.Children.Add(newControl);
                }
            }

            topContainer.Child = mainGrid;
        }

        private static UIElement ResolveNewElement(ColumnConfig columnConfig, string content)
        {
            switch(columnConfig.ItemType)
            {
                case Enums.ItemType.Text:
                    {
                        var newTextblock = new TextBlock()
                        {
                            Text = $"TextBlock: {content}",
                            Margin = new Thickness(5)
                        };
                        return newTextblock;
                    };
                case Enums.ItemType.TextArea:
                    {
                        var newTextBox = new TextBox()
                        {
                            Text = $"TextBox: {content}",
                            Margin = new Thickness(5)
                        };
                        return newTextBox;
                    };
                case Enums.ItemType.Checkbox:
                    {
                        var newCheckbox = new CheckBox() 
                        {
                            IsChecked = content == "true" ? true : false,
                            Margin = new Thickness(5)
                        };
                        return newCheckbox;
                    };
                case Enums.ItemType.ComboBox:
                    {
                        var newComboBox = new ComboBox()
                        {
                            Text = content,
                            Margin = new Thickness(5)
                        };
                        return newComboBox;
                    };
                default: return null;
            }
        }

        public GridViewerControl()
        {
            InitializeComponent();
        }
    }
}
