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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Dent.View
{
    /// <summary>
    /// Логика взаимодействия для AddReviews.xaml
    /// </summary>
    public partial class AddReviews : Page
    {
        private List<Review> allReview = new List<Review>();
        public AddReviews()
        {
            InitializeComponent();
            LoadReviews();
        }

        public void LoadReviews()
        {
            using (var db = new DbDentistry1Context())
            {
                allReview = db.Reviews.ToList();
                UpdateTourDisplay(allReview);
            }
        }

        private void servicesBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateTourDisplay(List<Review> reviewsToDisplay)
        {
            ReviewContainer.Children.Clear();
            foreach (var review in reviewsToDisplay)
            {
                ReviewContainer.Children.Add(new ReviewControl(review));
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
    }
}
