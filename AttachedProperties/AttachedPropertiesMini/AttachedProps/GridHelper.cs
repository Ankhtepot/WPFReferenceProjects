namespace AttachedProps;

using System.Windows;
using System.Windows.Controls;

public static class GridHelper
{
    public static readonly DependencyProperty ColumnSpanProperty =
        DependencyProperty.RegisterAttached(
            "ColumnSpan", typeof(int), typeof(GridHelper),
            new PropertyMetadata(1, OnColumnSpanChanged));

    public static int GetColumnSpan(DependencyObject obj)
    {
        return (int)obj.GetValue(ColumnSpanProperty);
    }

    public static void SetColumnSpan(DependencyObject obj, int value)
    {
        obj.SetValue(ColumnSpanProperty, value);
    }

    private static void OnColumnSpanChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is UIElement element and FrameworkElement)
        {
            Grid.SetColumnSpan(element, (int)e.NewValue);
        }
    }
}