using dentistry.Model;
using dentistry.PageF;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace dentistry.View
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {

        public Main()
        {
            InitializeComponent();
            MainFrame.Navigate(new AddNewsPage());
        }

        private void AddNB_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddNewsPage());

        }

        private void AddSB_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddOrModPage());
        }

        private void AddEB_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EditingPage());
        }
    }
}
