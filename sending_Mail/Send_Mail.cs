using System;
using System.Net;
using System.Net.Mail;

namespace sending_Mail
{
    internal class Send_Mail
    {
        public void SendEmail(string toAddress, string subject, string body)
        {
            try
            {
                string fromAddress = "Your email";
                string password = "Your pasword"; 

                MailMessage mail = new MailMessage(fromAddress, toAddress, subject, body);

                // SmtpClient ayarları
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress, password)
                };

                smtp.Send(mail);
                Console.WriteLine("Email was sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while sending the email: " + ex.Message);
            }
        }
    }
}
