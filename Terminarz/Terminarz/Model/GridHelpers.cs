﻿using System.Windows;
using System.Windows.Controls;

namespace Terminarz.Model;

public static class GridHelpers
{
    public static readonly DependencyProperty RowCountProperty = DependencyProperty.RegisterAttached("RowCount", typeof(int), typeof(GridHelpers), new PropertyMetadata(-1, RowCountChanged));

    public static int GetRowCount(DependencyObject obj)
    {
        return (int)obj.GetValue(RowCountProperty);
    }

    public static void SetRowCount(DependencyObject obj, int value)
    {
        obj.SetValue(RowCountProperty, value);
    }

    private static void RowCountChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        if (!(obj is Grid grid) || (int)e.NewValue < 0)
            return;

        grid.RowDefinitions.Clear();
        for (int i = 0; i < (int)e.NewValue; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition());
        }
    }

    public static readonly DependencyProperty ColumnCountProperty =
        DependencyProperty.RegisterAttached("ColumnCount", typeof(int), typeof(GridHelpers),
            new PropertyMetadata(-1, ColumnCountChanged));

    public static int GetColumnCount(DependencyObject obj)
    {
        return (int)obj.GetValue(ColumnCountProperty);
    }

    public static void SetColumnCount(DependencyObject obj, int value)
    {
        obj.SetValue(ColumnCountProperty, value);
    }

    private static void ColumnCountChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        if (!(obj is Grid grid) || (int)e.NewValue < 0)
            return;

        grid.ColumnDefinitions.Clear();
        for (int i = 0; i < (int)e.NewValue; i++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
        }
    }
}