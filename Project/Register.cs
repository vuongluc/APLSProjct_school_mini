using ProjectDomain;
using ProjectDomain.Business;
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
    public partial class Register : Form
    {
        ITeacherBusiness bizTeacher = new TeacherEF();
        IStudentBusiness bizStudent = new StudentEF();
        ILoginBusiness bizLogin = new LoginEF();
        Teacher teacher = new Teacher();
        ProjectDomain.EF.Student student = new ProjectDomain.EF.Student();
        Account account = new Account();
        List<string> listIdStudent = null;
        List<string> listIdTeacher = null;
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            cbRoles.SelectedIndex = 0;
            listIdStudent = bizStudent.listId();
            listIdTeacher = bizTeacher.listId();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login frLogin = new Login();
            frLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validateRegister())
            {
                if(cbRoles.SelectedIndex == 0)
                {
                    
                    string code = null;
                    string lastFourNumbers = null;
                    string monthYear = null;
                    for (var i = 0; i < ++i; i++)
                    {
                        List<string> list = new List<string> { "00", "01", "11", "10" };
                        Random rnd = new Random();
                        int index = rnd.Next(0, list.Count);
                        code = list[index];
                        lastFourNumbers = "";
                        for (var j = 0; j < 4; j++)
                        {
                            lastFourNumbers += rnd.Next(0, 9).ToString();
                        }
                        monthYear = Convert.ToDateTime(dtpBirthDate.Value).Year.ToString().Substring(2, 2) + Convert.ToDateTime(dtpBirthDate.Value).Month.ToString("00");
                        if (listIdStudent.Contains("S" + code + monthYear + lastFourNumbers))
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    student.StudentId = "S" + code + monthYear + lastFourNumbers;
                    student.FirstName = tbSFirstName.Text.Trim();
                    student.LastName = tbSLastName.Text.Trim();
                    student.Contact = tbSContact.Text.Trim();
                    student.BirthDate = Convert.ToDateTime(dtpBirthDate.Value.ToShortDateString());
                    student.StatusId = "SA";                  
                    bizStudent.createStudent(DTOEFMapper.GetDtoFromEntity(student));

                    var salf = BCrypt.Net.BCrypt.GenerateSalt(12);
                    var pass = BCrypt.Net.BCrypt.HashPassword(tbPassword.Text.Trim(), salf);

                    account.username = "S" + code + monthYear + lastFourNumbers;
                    account.salf = salf;
                    account.password = pass;
                    bizLogin.createAccount(DTOEFMapper.GetDtoFromEntity(account));
                }else if(cbRoles.SelectedIndex == 1)
                {
                    
                    string code = null;
                    string lastFourNumbers = null;
                    string monthYear = null;
                    for (var i = 0; i < ++i; i++)
                    {
                        List<string> list = new List<string> { "00", "01", "11", "10" };
                        Random rnd = new Random();
                        int index = rnd.Next(0, list.Count);
                        code = list[index];
                        lastFourNumbers = "";
                        for (var j = 0; j < 4; j++)
                        {
                            lastFourNumbers += rnd.Next(0, 9).ToString();
                        }
                        monthYear = Convert.ToDateTime(dtpBirthDate.Value).Year.ToString().Substring(2, 2) + Convert.ToDateTime(dtpBirthDate.Value).Month.ToString("00");
                        if (listIdTeacher.Contains("T" + code + monthYear + lastFourNumbers))
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    teacher.TeacherId = "T" + code + monthYear + lastFourNumbers;
                    teacher.FirstName = tbSFirstName.Text.Trim();
                    teacher.LastName = tbSLastName.Text.Trim();
                    teacher.Contact = tbSContact.Text.Trim();
                    teacher.BirthDate = Convert.ToDateTime(dtpBirthDate.Value.ToShortDateString());
                    teacher.StatusId = "TA";
                    bizTeacher.createTeacher(DTOEFMapper.GetDtoFromEntity(teacher));

                    var salf = BCrypt.Net.BCrypt.GenerateSalt(12);
                    var pass = BCrypt.Net.BCrypt.HashPassword(tbPassword.Text.Trim(), salf);

                    account.username = "T" + code + monthYear + lastFourNumbers;
                    account.salf = salf;
                    account.password = pass;
                    bizLogin.createAccount(DTOEFMapper.GetDtoFromEntity(account));
                }

                MessageBox.Show("Register Successfully", "Message");
                this.Close();
            }
        }

        private bool validateRegister()
        {
            var check = true;
            if (tbSFirstName.Text == "")
            {
                errorProvider.SetError(tbSFirstName, "Please enter first name");
                lbErrorStudent.Text = "Please enter first name";
                check = false;
            }
            else if (tbSLastName.Text == "")
            {
                errorProvider.Clear();
                errorProvider.SetError(tbSLastName, "Please enter last name");
                lbErrorStudent.Text = "Please enter last name";
                check = false;
            }
            else if (tbSContact.Text == "")
            {
                errorProvider.Clear();
                errorProvider.SetError(tbSContact, "Please enter contact");
                lbErrorStudent.Text = "Please enter contact";
                check = false;
            }else if(tbPassword.Text == "")
            {
                errorProvider.Clear();
                errorProvider.SetError(tbPassword, "Please enter password");
                lbErrorStudent.Text = "Please enter password";
                check = false;
            }
            else
            {
                errorProvider.Clear();
                lbErrorStudent.Text = "";

            }
            return check;
        }

        
    }
}
