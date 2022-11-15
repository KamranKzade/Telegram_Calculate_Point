using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Paint;

public partial class MainWindow : Window
{
    // public List<Brush> ColorsList { get; set; }

    public Brush SelectedColor { get; set; }

    public List<Brush> ColorsList { get; set; }



    public MainWindow()
    {
        InitializeComponent();
        AddComboboxSize();

      
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

