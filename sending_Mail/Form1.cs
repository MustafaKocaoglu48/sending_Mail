using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;




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

          
            DateTime tarih = dateTime.Value;

           
            string formattedDate = tarih.ToString("dd/MM/yyyy").TrimEnd('0', ':');

            Send_Mail mailSender = new Send_Mail();
            mailSender.SendEmail(txtMail.Text, txtSubject.Text, txtContenents.Text);


            try
            {
                using (SqlConnection con = new SqlConnection("Your database according;"))
                {
                    string query = "INSERT INTO Note_To_Future (Konu, Icerik, Tarih,Mail) VALUES (@Konu, @Icerik, @Tarih, @Mail)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = txtMail.Text; 
                        cmd.Parameters.Add("@Konu", SqlDbType.NVarChar).Value = txtSubject.Text; 
                        cmd.Parameters.Add("@Icerik", SqlDbType.NVarChar).Value = txtContenents.Text; 
                        cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = formattedDate;

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }


                MessageBox.Show("Record added successfully.");
                txtContenents.Text = "";
                txtMail.Text = "";
                txtSubject.Text = "";
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
