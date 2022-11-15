using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint;

public partial class MainWindow : Window
{
     public List<System.Windows.Media.Colors> ColorsList { get; set; } = new List<System.Windows.Media.Colors>();

    Point point1, point2;



    public MainWindow()
    {
        InitializeComponent();
        AddComboboxSize();


       //foreach (var item in combo_border.Items)
       //{
       //    if(item is System.Windows.Media.Colors brush)
       //        ColorsList.Add(brush);
       //}

    }



    private void mypoint_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        point1.X = e.GetPosition(this).X;
        point1.Y = e.GetPosition(this).Y;
    }

    private void mypoint_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        point2.X = e.GetPosition(this).X;
        point2.Y = e.GetPosition(this).Y;

        mypoint.Children.Clear();
        if (rectangle_rbt.IsChecked == true)
        {
            var type = combo_border.Items.GetType();

            Rectangle rectangle = new()
            {
                Height = Math.Abs(point1.Y - point2.Y),
                Width = Math.Abs(point1.X - point2.X),
                Fill = new SolidColorBrush(Colors.Red),
                Stroke = new SolidColorBrush(Colors.Beige),
                StrokeThickness = double.Parse(combo_borderSize.Text),
            };
            mypoint.Children.Add(rectangle);

            
            // Canvas.SetTop(rectangle, Math.Abs(point1.Y - point2.Y) + 5);
            // Canvas.SetLeft(rectangle, Math.Abs(point1.X - point2.X) +5);
        }

        else if (ellipse_rbt.IsChecked == true)
        {
            Ellipse ellipse = new()
            {
                Height = Math.Abs(point1.Y - point2.Y),
                Width = Math.Abs(point1.X - point2.X),
                Fill = new SolidColorBrush(Colors.Red),
                Stroke = new SolidColorBrush(Colors.Beige),
                StrokeThickness = double.Parse(combo_borderSize.Text),
            };
            mypoint.Children.Add(ellipse);
            // Canvas.SetTop(ellipse, Math.Abs(point1.Y - point2.Y) + 5);
            // Canvas.SetLeft(ellipse, Math.Abs(point1.X - point2.X) + 5);
        }
    }








    private void AddComboboxSize()
    {
        for (int i = 8; i <= 72; i++)
        {
            if (i % 2 == 0)
                combo_borderSize.Items.Add(i);
        }
        combo_borderSize.SelectedIndex = 0;
    }
}

