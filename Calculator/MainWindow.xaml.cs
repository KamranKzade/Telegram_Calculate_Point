using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Calculator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }


    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;


        switch (btn?.Name)
        {
            case "menubar":
            case "history":
            case "mc":
            case "ms":
            case "mr":
            case "mplus":
            case "mminus":
            case "mvur":
                MessageBox.Show("will be generated in the future", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                break;
            
            case "C":
            case "CE":
                txtbox.Text = 0.ToString();
                break;
            case "Clear":
                txtbox.Text = txtbox.Text.Remove(txtbox.Text.Length - 1);
                break;
            
            case "Faiz":
                if (txtbox.Text == string.Empty)
                {
                    MessageBox.Show("Reqem daxil edin", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
                txtbox.Text = (double.Parse(txtbox.Text.ToString()) / 100).ToString();
                break;
            
            case "tersine_cevirme":
                if (txtbox.Text == string.Empty)
                {
                    MessageBox.Show("Reqem daxil edin", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
                txtbox.Text = (1 / double.Parse(txtbox.Text.ToString())).ToString();
                break;
            
            case "quvvet":
                if (txtbox.Text == string.Empty)
                {
                    MessageBox.Show("Reqem daxil edin", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
                txtbox.Text = Math.Pow(double.Parse(txtbox.Text.ToString()), 2).ToString();
                break;
            
            case "kok":
                if (txtbox.Text == string.Empty)
                {
                    MessageBox.Show("Reqem daxil edin", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
                txtbox.Text = Math.Sqrt(double.Parse(txtbox.Text.ToString())).ToString();
                break;
            
            case "plusAndMinus":
                if (txtbox.Text == string.Empty)
                {
                    MessageBox.Show("Reqem daxil edin", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
                txtbox.Text = (-1 * (double.Parse(txtbox.Text.ToString()))).ToString();
                break;
            
            
            default:
                txtbox.Text += btn?.Content.ToString();
                break;
        }
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        try
        {
            txtbox.Text = new DataTable().Compute(txtbox.Text, null).ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            txtbox.Text = string.Empty;
        }
    }
}
