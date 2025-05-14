using dentistry.Model;
using dentistry.View;
using Microsoft.EntityFrameworkCore;
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

namespace dentistry.PageF
{
    /// <summary>
    /// Логика взаимодействия для AddOrModPage.xaml
    /// </summary>
    public partial class AddOrModPage : Page
    {
        public AddOrModPage()
        {
            InitializeComponent();

            using (var context = new DbDentistryContext())
            {
                DataInfo.ItemsSource = context.Services.Include(s => s.ServicesType).ToList();
            }
        }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            new AMSer().Show();
            var mainWindow = Window.GetWindow(this);
            if (mainWindow != null)
            {
                mainWindow.Close();
            }
        }

        private void ModB_Click(object sender, RoutedEventArgs e)
        {
            var item = DataInfo.SelectedItems;
            if (item.Count < 1)
            {
                MessageBox.Show("Выберете услугу");
                return;
            }
            if (item.Count > 1)
            {
                MessageBox.Show("Выберете только одну услугу");
                return;
            }

            new AMSer((Service)item[0]).Show();
            var mainWindow = Window.GetWindow(this);
            if (mainWindow != null)
            {
                mainWindow.Close();
            }

        }
    }
}
