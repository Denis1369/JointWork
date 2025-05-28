using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace dentistry.Model
{
    class EmailServis
    {
        public const int smtpPort = 587;
        public const string smtpServer = "smtp.mail.ru";

        public const string smtpUsername = "dentistrysyte@mail.ru";
        public const string smtpPassword = "dSf6gVFmyVn8KA1S42bZ";


        public static void SendMessage(string to, string title, string message)
        {
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    try
                    {
                        mailMessage.From = new MailAddress(smtpUsername);
                        mailMessage.To.Add(to);

                        mailMessage.Subject = title;
                        mailMessage.Body = message;
                        smtpClient.Send(mailMessage);
                    }
                    catch (SmtpException ex) when (ex.Message.Contains("invalid mailbox"))
                    {
                        MessageBox.Show($"Ошибка: почта {to} не существует или заблокирована.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка отправки сообщения: {ex.Message}");
                    }
                }
            }
        }

        public static List<string> GenerateExpectationEmail(string? name, DateTime? appointment)
        {
            string formattedDate = appointment.Value.ToString("dd.MM.yyyy");
            string formattedTime = appointment.Value.ToString("HH:mm");

            string body = $"Здравствуйте, {name}!\r\n\r\n" +
                          $"Ваша заявка на прием {formattedDate} в {formattedTime} находится в статусе «Ожидание».\r\n" +
                          $"Мы свяжемся с вами в ближайшее время для подтверждения.\r\n\r\n" +
                          $"Если нужно внести изменения, напишите на dentistrysyte@mail.ru.\r\n\r\n" +
                          $"С уважением,\r\nDentistry";

            string title = $"Ваша заявка на прием в Dentistry";

            return new List<string> { title, body };
        }

        public List<string> GenerateConfirmationEmail(string? name, DateTime? appointment)
        {
            string formattedDate = appointment.Value.ToString("dd.MM.yyyy");
            string formattedTime = appointment.Value.ToString("HH:mm");

            string body = $"Здравствуйте, {name}!\r\n\r\n" +
                          $"Ваш визит в Dentistry на {formattedDate} в {formattedTime} успешно подтвержден!\r\n" +
                          $"Просим прийти за 10 минут до начала приема.\r\n\r\n" +
                          $"Контакты для связи:\r\n" +
                          $"dentistrysyte@mail.ru\r\n" +
                          $"Ждем вас!\r\nDentistry";

            string title = "Запись подтверждена!";

            return new List<string> { title, body };
        }

        public List<string> GenerateCancellationEmail(string? name, DateTime? appointment)
        {
            string formattedDate = appointment.Value.ToString("dd.MM.yyyy");
            string formattedTime = appointment.Value.ToString("HH:mm");

            string body = $"Здравствуйте, {name}!\r\n\r\n" +
                          $"К сожалению, ваша запись на {formattedDate} в {formattedTime} была отменена.\r\n" +
                          $"Хотите перенести визит?\r\n" +
                          $"Напишите на dentistrysyte@mail.ru" +
                          $"Приносим извинения за неудобства.\r\nDentistry";

            string title = "Запись отменена";

            return new List<string> { title, body };
        }

    }
}
