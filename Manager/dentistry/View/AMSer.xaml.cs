using dentistry.Model;
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

namespace dentistry.View
{
    /// <summary>
    /// Логика взаимодействия для AMSer.xaml
    /// </summary>
    public partial class AMSer : Window
    {
        protected Service? _service;

        public AMSer()
        {
            InitializeComponent();
            Title = "Создание";
            Load();
        }
        public AMSer(Service service)
        {
            InitializeComponent();
            Load();
            _service = service;
            TitleT.Text = service.ServicesTitle;
            DescT.Text = service.ServicesDesc;
            PriceT.Text = service.ServicesPrice.ToString();
            TypeC.SelectedIndex = (int)service.ServicesTypeId - 1;
            Title = "Изменение";
            AddB.Content = "Сохранить";
        }

        private void Load()
        {
            using (var context = new DbDentistryContext())
            {
                foreach (var item in context.ServicesTypes.ToList())
                {
                    TypeC.Items.Add(item.ServicesTypeTitle);
                }
            }
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            new Main().Show();
            Close();
        }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            if (_service == null)
            {
                MessageBox.Show(Service.AddService(TitleT.Text, DescT.Text, PriceT.Text, TypeC.SelectedIndex + 1));
            }
            else
            {
                MessageBox.Show(Service.ModService(_service.ServicesId, TitleT.Text, DescT.Text, PriceT.Text, TypeC.SelectedIndex + 1));
            }
        }
    }
}
