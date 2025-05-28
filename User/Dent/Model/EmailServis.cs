using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dent.Model
{
    class EmailServis
    {
        public const int smtpPort = 587;
        public const string smtpServer = "smtp.mail.ru";

        public const string smtpUsername = "dentistrysyte@mail.ru";
        public const string smtpPassword = "dSf6gVFmyVn8KA1S42bZ";


        public static bool SendMessage(string to, string title, string message)
        {
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(to);

                    mailMessage.Subject = title;
                    mailMessage.Body = message;

                    try
                    {
                        smtpClient.Send(mailMessage);
                        return true;
                    }
                    catch (SmtpException ex) when (
                        ex.Message.Contains("invalid mailbox") ||
                        ex.Message.Contains("Mailbox unavailable") ||
                        ex.Message.Contains("recipient verification failed")
                    )
                    {
                        MessageBox.Show($"Ошибка: почта {to} не существует или заблокирована.");
                        return false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка отправки сообщения: {ex.Message}");
                        return false;
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

    }
}
