using Dent.Model;
using MaterialDesignThemes.Wpf;
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
        private List<ServicesType> servicesTypes;
        private List<Review> allReview = new List<Review>();

        public UserWindow()
        {
            InitializeComponent();
            LoadTypes();
            LoadNews();
            LoadServices();
            LoadReviews();
            servicesType_cb.SelectionChanged += servicesType_cb_SelectionChanged;

        }

        private void LoadTypes()
        {
            using (var db = new DbDentistry1Context())
            {
                try
                {
                    servicesTypes = db.ServicesTypes.ToList();

                    var allServicesItem = new ServicesType
                    {
                        ServicesTypeId = 0,
                        ServicesTypeTitle = "Все услуги"
                    };
                    servicesTypes.Insert(0, allServicesItem);

                    servicesType_cb.ItemsSource = servicesTypes;
                    servicesType_cb.DisplayMemberPath = "ServicesTypeTitle";
                    servicesType_cb.SelectedValuePath = "ServicesTypeId";
                    servicesType_cb.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке типов услуг: {ex.Message}");
                }
            }
        }

        private void LoadNews()
        {
            using (var db = new DbDentistry1Context())
            {
                allNews = db.News.OrderByDescending(n => n.DatePublish).Where(g => g.NewsStatus == "Публикация")
                    .ToList();
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

        private void ApplySearchFilters()
        {
            if (allServices == null) return;

            var filteredGoods = allServices.AsEnumerable();
            var search = search_tb.Text;
            if (!string.IsNullOrWhiteSpace(search))
            {
                filteredGoods = filteredGoods.Where(g =>
                    g.ServicesTitle != null && g.ServicesTitle.Contains(search, StringComparison.OrdinalIgnoreCase));
            }
            if (servicesType_cb.SelectedValue != null &&
        int.TryParse(servicesType_cb.SelectedValue.ToString(), out int selectedTypeId) && selectedTypeId != 0)
            {
                filteredGoods = filteredGoods.Where(g => g.ServicesTypeId == selectedTypeId);
            }
            /* if(servicesType_cb.SelectedIndex == 0)
             {
                 filteredGoods = allServices.AsEnumerable();
             }*/


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
            UpdateServicesList(filteredGoods.ToList());
        }

        private void search_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplySearchFilters();
        }

        private void sort_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplySearchFilters();
        }

        private void servicesType_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplySearchFilters();
        }
        public void LoadReviews()
        {
            using (var db = new DbDentistry1Context())
            {
                allReview = db.Reviews.OrderByDescending(r => r.ReviewsDate).ToList();
                UpdateTourDisplay(allReview);
            }
        }

        private void servicesBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateTourDisplay(List<Review> reviewsToDisplay)
        {
            ReviewContainer.Items.Clear();
            foreach (var review in reviewsToDisplay)
            {
                ReviewContainer.Items.Add(new ReviewControl(review));
            }
        }

        private void publicReview_btn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textReview_txt.Text))
            {
                MessageBox.Show("Пожалуйста, введите текст отзыва", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            using (var db = new DbDentistry1Context())
            {
                Review review1 = new Review();
                review1.ReviewsText = textReview_txt.Text;
                review1.ReviewsDate = DateTime.Now;
                db.Reviews.Add(review1);
                db.SaveChanges();
                LoadReviews();
                textReview_txt.Text = string.Empty;
            }
        }

        private void textReview_txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
        }

        private void textReview_txt_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;



            if (textBox.Text != "")
            {
                materialDesign: TextFieldAssist.SetUnderlineBrush(textBox, Brushes.Green);
            }
            else
            {
                materialDesign: TextFieldAssist.SetUnderlineBrush(textBox, Brushes.Red);
            }
        }
    }
}