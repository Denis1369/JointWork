using Dent.Model;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Appointment.xaml
    /// </summary>
    public partial class Appointment : Window
    {
        //private List<Entry> entry = new List<Entry>();
        public Appointment()
        {
            InitializeComponent();
            datePicker.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1))); // Запретить даты раньше сегодня
            UpdateBlackoutDates();
        }

        private void booking_btn_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату!");
                return;
            }

            DateTime selectedDate = datePicker.SelectedDate.Value.Date;
            DateTime resultDateTime;

            string hours = (hours_cb.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? hours_cb.Text;
            string minutes = (minute_cb.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? minute_cb.Text;

            if (!string.IsNullOrEmpty(hours) && !string.IsNullOrEmpty(minutes))
            {
                hours = hours.Trim();
                minutes = minutes.Trim();

                if (int.TryParse(hours, out int h) && int.TryParse(minutes, out int m))
                {
                    if (h >= 0 && h < 24 && m >= 0 && m < 60)
                    {
                        resultDateTime = selectedDate.AddHours(h).AddMinutes(m);
                    }
                    else
                    {
                        MessageBox.Show("Некорректное время. Часы должны быть 0-23, минуты 0-59", "Ошибка");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show($"Некорректный формат времени. Часы: '{hours}', минуты: '{minutes}'", "Ошибка");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите время", "Ошибка");
                return;
            }

            if (string.IsNullOrWhiteSpace(name_tb.Text) || string.IsNullOrWhiteSpace(email_tb.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            using (var db = new DbDentistry1Context())
            {
                Entry en = new Entry();
                en.UserName = name_tb.Text;
                en.UserEmail = email_tb.Text;
                en.DateTime = resultDateTime;
                en.EntryStatus = "Ожидание";
                db.Entries.Add(en);
                db.SaveChanges();
                //EmailServis emailServis = new EmailServis();
                //var list = new List<string>();
                //list = emailServis.GenerateExpectationEmail(name_tb.Text, resultDateTime);
                //EmailServis.SendMessage(email_tb.Text, list[0], list[1]);
                MessageBox.Show($"Вы оставили заявку на прием на: {resultDateTime}");
                this.Close();
            }
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            hours_cb.IsEnabled = datePicker.SelectedDate != null;
            minute_cb.IsEnabled = datePicker.SelectedDate != null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void email_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            bool isValid = IsValidEmail(textBox.Text);

            textBox.Foreground = isValid ? Brushes.Black : Brushes.Red;
            if (isValid)
            {
            materialDesign: TextFieldAssist.SetUnderlineBrush(textBox, Brushes.Green);
            }
            else
            {
            materialDesign: TextFieldAssist.SetUnderlineBrush(textBox, Brushes.Red);
            }
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var regex = new System.Text.RegularExpressions.Regex(
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        private void email_tb_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!IsValidEmail(textBox.Text))
            {
                MessageBox.Show("Некорректный email!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void name_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            materialDesign: TextFieldAssist.SetUnderlineBrush(textBox, Brushes.Green);
        }

        private void name_tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, @"[а-яА-Я]"))
            {
                e.Handled = true;
            }
        }
        private void UpdateBlackoutDates()
        {
            datePicker.BlackoutDates.Clear();

            datePicker.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1)));

            DateTime startDate = DateTime.Today;
            DateTime endDate = startDate.AddYears(1);

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    datePicker.BlackoutDates.Add(new CalendarDateRange(date));
                }
            }

            var holidays = new List<DateTime>
        {
            new DateTime(DateTime.Now.Year, 1, 1),
            new DateTime(DateTime.Now.Year, 1, 7),
            new DateTime(DateTime.Now.Year, 2, 23),
            new DateTime(DateTime.Now.Year, 3, 8),
            new DateTime(DateTime.Now.Year, 5, 1),
            new DateTime(DateTime.Now.Year, 5, 9), 
            new DateTime(DateTime.Now.Year, 6, 12),
            new DateTime(DateTime.Now.Year, 11, 4)
        };

            foreach (var holiday in holidays)
            {
                datePicker.BlackoutDates.Add(new CalendarDateRange(holiday));
            }
        }
    }
}
