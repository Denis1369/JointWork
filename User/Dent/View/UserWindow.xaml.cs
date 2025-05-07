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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private List<News> allNews = new List<News>();
        private List<Service> allServices = new List<Service>();

        public UserWindow()
        {
            InitializeComponent();
            LoadNews();
            LoadServices();
           

        }

        

        private void LoadNews()
        {
            using (var db = new DbDentistry1Context())
            {
                allNews = db.News.OrderByDescending(n => n.DatePublish).ToList();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Appointment modalWindow = new Appointment();
            modalWindow.Owner = this;
            modalWindow.ShowDialog();
        }

        private void LoadServices()
        {
            using (var db = new DbDentistry1Context())
            {
                allServices = db.Services.ToList();
                UpdateServicesList(allServices);
            }
        }

        private void UpdateServicesList(List<Service> services)
        {
            if (ListService != null)
                ListService.Items.Clear();
            foreach (var i in services)
            {
                ListService.Items.Add(new UserControl1(i));
            }
        }

        

        
        

        private void servicesBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        

    }
}
