using dentistry.Model;
using Microsoft.EntityFrameworkCore;
using MaterialDesignThemes.Wpf;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace dentistry.PageF
{
    public partial class AddOrModPage : Page
    {
        public SnackbarMessageQueue SnackbarMessageQueue { get; }

        public AddOrModPage()
        {
            InitializeComponent();
            SnackbarMessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(3));
            DataContext = this;
            LoadServices();
        }

        private void LoadServices()
        {
            using var ctx = new DbDentistryContext();
            DataInfo.ItemsSource = ctx.Services.Include(s => s.ServicesType).ToList();
        }

        private async void AddB_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AMSerControl();
            var result = await DialogHost.Show(dialog, "RootDialog");
            if (result is string msg && !string.IsNullOrEmpty(msg))
                SnackbarMessageQueue.Enqueue(msg);
            LoadServices();
        }

        private async void ModB_Click(object sender, RoutedEventArgs e)
        {
            if (DataInfo.SelectedItem is not Service svc)
            {
                SnackbarMessageQueue.Enqueue("Выберите услугу");
                return;
            }
            var dialog = new AMSerControl(svc);
            var result = await DialogHost.Show(dialog, "RootDialog");
            if (result is string msg && !string.IsNullOrEmpty(msg))
                SnackbarMessageQueue.Enqueue(msg);
            LoadServices();
        }
    }
}
