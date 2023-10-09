using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace otomatikmail
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
                string gonderilecekMail = textBox1.Text;
                string konu = "Konu";
                string icerik = "Bu bir test e-postasýdýr.";

                SmtpClient smtpClient = new SmtpClient("smtp.sunucuadresi.com");
                smtpClient.Port = 587; // SMTP sunucu port numarasý
                smtpClient.Credentials = new NetworkCredential("testemailimersin33@yopmail.com", "");
                smtpClient.EnableSsl = true; // SSL kullanýlacak mý?

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("gonderen@ornek.com");
                mail.To.Add(gonderilecekMail);
                mail.Subject = konu;
                mail.Body = icerik;

                smtpClient.Send(mail);

                MessageBox.Show("E-posta baþarýyla gönderildi.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderme hatasý: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}