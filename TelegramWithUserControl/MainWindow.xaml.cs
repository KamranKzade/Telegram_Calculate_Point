using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TelegramWithUserControl.UserControls;

namespace TelegramWithUserControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserControl1 userControl = new UserControl1();
            userControl.Title_Name.Content = "Qara Qarayev";
            userControl.txtblok_1.Text = "Oyuna gelirsen qaqa?";
            userControl.txtblok_2.Text = "Yox qaqa";
            userControl.txtblok3.Text = "Oldu";
            TalkinGrid.Children.Add(userControl);


        }

        private void StackPanel_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            UserControl1 userControl = new UserControl1();
            userControl.Title_Name.Content = "Qurban";
            userControl.txtblok_1.Text = "Salam Kamran necesen?";
            userControl.txtblok_2.Text = "Chox sagol sen necesen";
            TalkinGrid.Children.Add(userControl);
        }

        private void StackPanel_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            UserControl1 userControl = new UserControl1();
            userControl.Title_Name.Content = "Messi";
            userControl.txtblok_1.Text = "Ele bilki nese deyib";
            userControl.txtblok_2.Text = "I don't know";
            userControl.txtblok3.Text = "Come to PSJ";
            TalkinGrid.Children.Add(userControl);
        }

        private void StackPanel_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            UserControl1 userControl = new UserControl1();
            userControl.Title_Name.Content = "Ronaldo";
            userControl.txtblok_1.Text = "SIUUU";
            userControl.txtblok_2.Text = "Sagol";
            userControl.txtblok3.Text = "Ən boyuk ManU...";
            TalkinGrid.Children.Add(userControl);
        }

    }
}
