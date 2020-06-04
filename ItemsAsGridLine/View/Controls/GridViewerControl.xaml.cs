using ItemsAsGridLine.Model;
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

            var mainGrid = control.MainGrid;

            //var columnDefinition1 = new ColumnDefinition();
            //var columnDefinition2 = new ColumnDefinition();
            //columnDefinition1.Width = new GridLength(200);
            //columnDefinition2.Width = new GridLength(200);

            //mainGrid.ColumnDefinitions.Add(columnDefinition1);
            //mainGrid.ColumnDefinitions.Add(columnDefinition2);
            //mainGrid.ShowGridLines = true;

            //var textBlock1 = new TextBlock();
            //textBlock1.Text = "testtest";
            //var textBlock2 = new TextBlock();
            //textBlock2.Text = "testtest";
            //Grid.SetRow(textBlock1, 0);
            //Grid.SetColumn(textBlock1, 0);
            //Grid.SetRow(textBlock2, 0);
            //Grid.SetColumn(textBlock2, 1);

            //mainGrid.Children.Add(textBlock1);
            //mainGrid.Children.Add(textBlock2);

            for (int i = 0; i < newValue.Lines.Count; i++) // Line
            {
                UIElement newControl;
                mainGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                for (int j = 0; j < newValue.Lines[i].Count; j++) // Column
                {
                    //var columnDefinition = new ColumnDefinition
                    mainGrid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = GridLength.Auto,
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
