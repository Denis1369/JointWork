using Dent.Model;
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
using System.Windows.Shapes;

namespace Dent.View
{
    /// <summary>
    /// Логика взаимодействия для NewsWindow.xaml
    /// </summary>
    public partial class NewsWindow : Window
    {
        private List<News> allNews = new List<News>();
        public NewsWindow()
        {
            InitializeComponent();
            LoadNews();
        }

        private void LoadNews()
        {
            using (var db = new DbDentistry1Context())
            {
                allNews = db.News.ToList();
                UpdateGoodsList(allNews);
            }
        }

        private void UpdateGoodsList(List<News> news)
        {
            ListNews.Items.Clear();
            foreach (var i in news)
            {
                ListNews.Items.Add(new NewsControl(i));
            }
        }
        private void reviewBtn_Click(object sender, RoutedEventArgs e)
        {

            MainFrame.Navigate(new AddReviews());

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Appointment modalWindow = new Appointment();
            modalWindow.Owner = this;
            modalWindow.ShowDialog();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void mainBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is AddReviews)
            {
                MainFrame.Content = null;
            }

        }
    }
}
