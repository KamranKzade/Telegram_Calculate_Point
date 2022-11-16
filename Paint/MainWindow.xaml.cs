using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint;

public partial class MainWindow : Window
{
    public Color Backcolor { get; set; }
    public Color Bordercolor { get; set; }


    Polygon polygon = new();
    Ellipse ellipse;
    Rectangle rectangle;
    Point point1, point2;


    public MainWindow()
    {
        InitializeComponent();
        AddComboboxSize();

    }

    public List<double> PointY { get; set; } = new();
    public List<double> PointX { get; set; } = new();

    PointCollection points = new PointCollection();
    Point PolyPoint = new();

    private void mypoint_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        point1.X = e.GetPosition(this).X;
        point1.Y = e.GetPosition(this).Y;


        if (polygon_rbt.IsChecked == true)
        {
            PolyPoint = e.GetPosition(this);


            PolyPoint.X = e.GetPosition(this).X;
            PolyPoint.Y = e.GetPosition(this).Y - ((window.Height - 10) / 5);

            points.Add(PolyPoint);

            PointX.Add(PolyPoint.X);
            PointY.Add(PolyPoint.Y);

            
        }
    }

    private void mypoint_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        point2.X = e.GetPosition(this).X;
        point2.Y = e.GetPosition(this).Y;

        var point = new Point(point1.X > point2.X ? point2.X : point1.X, point1.Y < point2.Y ? point1.Y : point2.Y);

        if (rectangle_rbt.IsChecked == true)
        {
            var type = combo_border.Items.GetType();

            rectangle = new()
            {
                Height = Math.Abs(point1.Y - point2.Y),
                Width = Math.Abs(point1.X - point2.X),
                Fill = new SolidColorBrush(Backcolor),
                Stroke = new SolidColorBrush(Bordercolor),
                StrokeThickness = double.Parse(combo_borderSize.Text),
            };


            mypoint.Children.Add(rectangle);
            Canvas.SetTop(rectangle, point.Y - (window.Height - 10) / 5);
            Canvas.SetLeft(rectangle, point.X);
        }

        else if (ellipse_rbt.IsChecked == true)
        {
            ellipse = new()
            {
                Height = Math.Abs(point1.Y - point2.Y),
                Width = Math.Abs(point1.X - point2.X),
                Fill = new SolidColorBrush(Backcolor),
                Stroke = new SolidColorBrush(Bordercolor),
                StrokeThickness = double.Parse(combo_borderSize.Text)
            };

            mypoint.Children.Add(ellipse);
            Canvas.SetTop(ellipse, point.Y - (window.Height - 10) / 5);
            Canvas.SetLeft(ellipse, point.X);
        }
        else if (polygon_rbt.IsChecked == true)
        {
            //MessageBox.Show("Gelecekde tamamlanacaq", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            var maxX = PointX.Max();
            var maXY = PointY.Max();

            polygon = new()
            {
                Points = points,
                Height = maXY,
                Width = maxX,
                Fill = new SolidColorBrush(Backcolor),
                Stroke = new SolidColorBrush(Bordercolor),
                StrokeThickness = double.Parse(combo_borderSize.Text)
            };

            var minX = PointX.Min();
            var minY = PointY.Min();

            mypoint.Children.Add(polygon);
            Canvas.SetTop(polygon, minX);
            Canvas.SetLeft(polygon, minY);
        }
        //
        //else
        //    MessageBox.Show("Zehmet olmasa Fiqurlardan Birini Secin", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
    }



    private void Combo_backgroud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        => Backcolor = (Color)(Combo_backgroud.SelectedItem as PropertyInfo)!.GetValue(null, null)!;

    private void combo_border_SelectionChanged(object sender, SelectionChangedEventArgs e)
        => Bordercolor = (Color)(combo_border.SelectedItem as PropertyInfo)!.GetValue(null, null)!;

    private void ClickRadioButton(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(@"Əvvəlcədən məlumat vermek isterdik ki,
Rəng secimlerini dəyişməsəz,
Default rəng seçiləcək", "Validation", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        mypoint.Children.Clear();
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