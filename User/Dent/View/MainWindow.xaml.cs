using Dent.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Dent.View;
using MaterialDesignThemes.Wpf;

namespace Dent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Service> allService = new List<Service>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadServicesTypes()
        {
            using (var db = new DbDentistry1Context())
            {
                allService = db.Services.ToList();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            LoadServicesTypes();
        }

        private void ServicesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (allService == null)
                allService = new List<Service>();
            else
                allService.Clear();

            if (sender is Button button)
            {
                string btn_content = button.Content.ToString();

                using (var db = new DbDentistry1Context())
                {
                    var service_types = db.ServicesTypes.ToList();

                    var service_type_current = service_types.FirstOrDefault(st =>
                        st.ServicesTypeTitle.Equals(btn_content, StringComparison.OrdinalIgnoreCase));

                    if (service_type_current != null)
                    {
                        int service_type_id = service_type_current.ServicesTypeId;

                        var services = db.Services
                            .Where(s => s.ServicesTypeId == service_type_id)
                            .Include(s => s.ServicesType) // Добавляем загрузку связанных данных
                            .ToList();

                        allService.AddRange(services);
                    }
                }
            }

            // Сразу обновляем отображение
            MainFrame.Navigate(new ServicePage1(allService));
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

        private void mainBtn_Click(object sender, RoutedEventArgs e)
        {

            NewsWindow newsWindow = new NewsWindow();
            newsWindow.Show();
            this.Close();
        }

        private void servicesBtn_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ServicePage1(allService));
        }
    }
}