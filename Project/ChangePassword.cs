using ProjectDomain;
using ProjectDomain.Business.Login;
using ProjectDomain.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class ChangePassword : Form
    {
        
        ILoginBusiness bizLogin = new LoginEF();        
        Account account = new Account();
        public string idStudent;
        string studentId = null;
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            studentId = idStudent;
            btnSave.Enabled = false;
        }

        private void tbPassChange_TextChanged(object sender, EventArgs e)
        {
            if(tbPassChange.Text.Length == 0)
            {
                btnSave.Enabled = false;
            }else
            {
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var salf = BCrypt.Net.BCrypt.GenerateSalt(12);
            var pass = BCrypt.Net.BCrypt.HashPassword(tbPassChange.Text.Trim(), salf);

            account.username = studentId;
            account.salf = salf;
            account.password = pass;
            bizLogin.updateAccount(DTOEFMapper.GetDtoFromEntity(account));

            this.Close();
            MessageBox.Show("Changed Password Successfully", "Message");
            StudentApp frStudent = new StudentApp();
            frStudent.studentId = studentId;           
            frStudent.Show();
        }
    }
}
