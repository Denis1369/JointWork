using dentistry.Model;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dentistry.PageF
{
    /// <summary>
    /// Логика взаимодействия для AddNewsPage.xaml
    /// </summary>
    public partial class AddNewsPage : Page
    {
        byte[] ImageBytes;
        public ObservableCollection<News> NewsItems { get; } = new();
        public AddNewsPage()
        {
            InitializeComponent();
            LoadNews();
            DataContext = this; // Привязка к самой странице
        }

        private void LoadNews()
        {
            try
            {
                using var context = new DbDentistryContext();
                var newsList = context.News
                    .AsNoTracking()
                    .OrderByDescending(n => n.DatePublish)
                    .ToList();

                NewsItems.Clear();
                foreach (var news in newsList)
                {
                    NewsItems.Add(news);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки новостей: {ex.Message}");
            }
        }

        private void SaveNews_Click(object sender, RoutedEventArgs e)
        {
            using var context = new DbDentistryContext();
            foreach (var news in NewsItems)
            {
                context.Entry(news).State = news.NewsId == 0
                    ? EntityState.Added
                    : EntityState.Modified;
            }
            context.SaveChanges();
            ShowSnackbar("Изменения сохранены");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            var imageBytes = ImageBytes; // Берём первое изображение

            string status = News.AddNews(
                TitleT.Text,
                DescT.Text,
                imageBytes // Передаём массив байтов
            );


            if (status == "Успешно сохранено")
            {
                ShowSnackbar(status);
                TitleT.Text = "";
                DescT.Text = "";
                ImageBytes = [];
            }
            else 
            {
                ShowSnackbar(status );
            }
        }

        private void SelectImg_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Images|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tiff;*.webp"
            };

            if (dialog.ShowDialog() == true)
            {
                foreach (var fileName in dialog.FileNames)
                {
                    var fileInfo = new FileInfo(fileName);
                    var imageBytes = File.ReadAllBytes(fileName);
                    ImageBytes = imageBytes;
                }
            }
        }

        private async void ShowSnackbar(string message)
        {
            await HideCurrentSnackbar();

            MessTextBlock.Text = message;

            CustomSnackbar.Visibility = Visibility.Visible;
            ((Storyboard)Resources["ShowAnimation"]).Begin();

            await Task.Delay(2000);
            await HideCurrentSnackbar();
        }

        private async Task HideCurrentSnackbar()
        {
            if (CustomSnackbar.Visibility != Visibility.Visible) return;

            ((Storyboard)Resources["HideAnimation"]).Begin();
            await Task.Delay(300);
            CustomSnackbar.Visibility = Visibility.Collapsed;
        }

        private void SwitchView_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                bool isAddView = btn.Tag.ToString() == "Add";
                GridAddNews.Visibility = isAddView ? Visibility.Visible : Visibility.Collapsed;
                GridViewNews.Visibility = isAddView ? Visibility.Collapsed : Visibility.Visible;

                if (!isAddView) NewsDataGrid.Items.Refresh();
                LoadNews();
                NewsDataGrid.ItemsSource = NewsItems;
            }
        }
    }
}
