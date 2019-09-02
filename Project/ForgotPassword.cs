using ProjectDomain.Business.Login;
using ProjectDomain.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectDomain;

namespace Project
{
    public partial class ForgotPassword : Form
    {
        ILoginBusiness bizLogin = new LoginEF();
        Account account = new Account();
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
            if (validate())
            {
                SendNewPassword();
            }
        }
        private void SendNewPassword()
        {
            string Newpass = "";
            Random rnd = new Random();
            for (var j = 0; j < 5; j++)
            {
                Newpass += Convert.ToChar(rnd.Next(97, 122));
            }
            string salf = BCrypt.Net.BCrypt.GenerateSalt(12);
            string pass = BCrypt.Net.BCrypt.HashPassword(Newpass, salf);
            account.username = tbUserNm.Text;
            account.salf = salf;
            account.password = pass;
            bizLogin.updateAccount(DTOEFMapper.GetDtoFromEntity(account));
            MailMessage mess = new MailMessage("vuongluc2708@gmail.com", tbEmail.Text.Trim(), "Provide a new password", $@"Your new password is: {Newpass} \r\n You can now use this password to log in to the application.");
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential("vuongluc2708@gmail.com", "lucbeo123");
            client.Send(mess);

            MessageBox.Show("New password has been sent to your email. Please check your email!", "Message");           
            this.Close();
        }

        private bool validate()
        {
            var check = true;
            if (tbUserNm.Text.Length == 0)
            {
                errorProvider1.SetError(tbUserNm, "Please enter User Name");
                lbError.Text = "Please enter User Name";
                check = false;
            }
            else if (tbEmail.Text.Length == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbEmail, "Please enter email address");
                lbError.Text = "Please enter email address";
                check = false;
            }
            else if (bizLogin.findById(tbUserNm.Text) == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(tbUserNm, "Username is incorrect");
                lbError.Text = "Username is incorrect";
                check = false;
            }
            else
            {
                errorProvider1.Clear();
                lbError.Text = "";

            }
            return check;
        }

        private void ForgotPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login frLogin = new Login();
            frLogin.Show();
        }
    }
}
