using Dent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dent.View
{
    /// <summary>
    /// Логика взаимодействия для ServicePage1.xaml
    /// </summary>
    public partial class ServicePage1 : Page
    {
        private List<Service> allService = new List<Service>();
        public ServicePage1(List<Service> allServices)
        {
            InitializeComponent();
            this.allService = allServices ?? new List<Service>();
            UpdateList(this.allService);
        }
        private void LoadServicesTypes()
        {
            ApplySearchFilters();
        }
        private void UpdateList(List<Service> services)
        {
            if (ListService != null)
                ListService.Items.Clear();
            foreach (var service in services)
            {
                ListService.Items.Add(new UserControl1(service));
            }
        }
        private void ApplySearchFilters()
        {
            if (allService == null) return;

            var filteredGoods = allService.AsEnumerable();
            var search = search_tb.Text;
            if (!string.IsNullOrWhiteSpace(search))
            {
                filteredGoods = filteredGoods.Where(g =>
                    g.ServicesTitle != null && g.ServicesTitle.Contains(search, StringComparison.OrdinalIgnoreCase));
            }
            var sort = (sort_cb.SelectedItem as ComboBoxItem).Content.ToString();
            switch (sort)
            {
                case "По названию (А-Я)":
                    filteredGoods = filteredGoods.OrderBy(g => g.ServicesTitle);
                    break;
                case "По названию (Я-А)":
                    filteredGoods = filteredGoods.OrderByDescending(g => g.ServicesTitle);
                    break;
                case "По цене (возрастание)":
                    filteredGoods = filteredGoods.OrderBy(g => g.ServicesPrice);
                    break;
                case "По цене (убывание)":
                    filteredGoods = filteredGoods.OrderByDescending(g => g.ServicesType);
                    break;
            }
            UpdateList(filteredGoods.ToList());
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplySearchFilters();
        }

        private void sort_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplySearchFilters();
        }
    }
}
