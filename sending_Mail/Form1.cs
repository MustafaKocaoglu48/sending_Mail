using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;


namespace sending_Mail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


           
                try
                {
                 
                    string fromAddress = "Your email"; 
                    string password = "Your password";                           
                    string toAddress = textBox1.Text;                    
                    string subject = textBox2.Text;                     
                    string body = textBox3.Text;                       

                   
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
                    MessageBox.Show("Email was sent successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while sending the email: " + ex.Message);
                }
            }


        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
