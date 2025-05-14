using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
using dentistry.Model;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;
using System.Text.RegularExpressions;
using dentistry.View;

namespace dentistry
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void enter_btn_Click(object sender, RoutedEventArgs e)
        {
            string password = "";
            if (password_manager_pass1.Visibility == Visibility.Visible)
                password = password_manager_pass1.Password;
            else
                password = password_manager_tb.Text;
            if (string.IsNullOrEmpty(code_manager_tb.Text) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Поля ввода не должны быть пустыми");
                return;
            }

            using (var db = new DbDentistryContext())
            {
                var manager = db.Managers
                    .AsNoTracking()
                    .FirstOrDefault(m => m.ManagerId.ToString() == code_manager_tb.Text);

                if (manager == null)
                {
                    MessageBox.Show("Неверный логин");
                    return;
                }

                string hashedInputPassword = HashPassword(password);
                if (manager.ManagerPassword == hashedInputPassword)
                {
                    RefreshDatabaseContext();
                    new Main().Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Метод для принудительного обновления данных
        private void RefreshDatabaseContext()
        {
            using (var refreshDb = new DbDentistryContext())
            {
                // Принудительно загружаем свежие данные
                var freshManagers = refreshDb.Managers
                    .AsNoTracking()
                    .ToList();

                // Можно добавить логирование для проверки
                System.Diagnostics.Debug.WriteLine($"Обновлено записей менеджеров: {freshManagers.Count}");
            }
        }

        private void password_chb_Checked(object sender, RoutedEventArgs e)
        {
            password_manager_pass1.Visibility = Visibility.Collapsed;
            password_manager_tb.Visibility = Visibility.Visible;
            password_manager_tb.Text = password_manager_pass1.Password;
        }

        private void password_chb_Unchecked(object sender, RoutedEventArgs e)
        {
            password_manager_pass1.Visibility = Visibility.Visible;
            password_manager_tb.Visibility = Visibility.Collapsed;
            password_manager_pass1.Password = password_manager_tb.Text;
        }

        private void code_manager_tb_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

        }

        private void code_manager_tb_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, @"^[0-9]"))
            {
                e.Handled = true;
            }
            if (code_manager_tb.Text.Length >= 4)
            {
                e.Handled = true;
            }
        }

        private void password_manager_tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, @"^[A-Za-z0-9]"))
            {
                e.Handled = true;
            }
            if (password_manager_pass1.Password.Length >= 12 || password_manager_tb.Text.Length >= 12)
            {
                e.Handled = true;
            }
        }
    }
}