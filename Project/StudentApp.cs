using ProjectDomain;
using ProjectDomain.Business;
using ProjectDomain.Business.Class;
using ProjectDomain.Business.Enroll;
using ProjectDomain.Business.Evaluate;
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
    public partial class StudentApp : Form
    {
        IEnrollBusiness bizEnroll = new EnrollEF();
        IStudentBusiness bizStudent = new StudentEF();
        IClassBusiness bizClass = new ClassEF();
        IEvaluatesBusiness bizEvalua = new EvaluateEF();
        ProjectDomain.EF.Student student = new ProjectDomain.EF.Student();
        IModuleBusiness bizModule = new ModuleEF();
        ITeacherBusiness bizTeacher = new TeacherEF();
        Enroll enroll = new Enroll();
        Class classes = new Class();
        Evaluate evaluate = new Evaluate();
        string studentIdDefault = null;
        public string studentId;
        List<string> list_classId = null;
        public StudentApp()
        {
            this.MinimumSize = new Size(300, 400);            
            InitializeComponent();
            
        }
        private void RegisterStudent_Load(object sender, EventArgs e)
        {
            studentIdDefault = studentId;

            list_classId = bizEnroll.findAllEnroll().Where(m => m.StudentId == studentIdDefault).Select(m => m.ClassId).ToList();
            var list_fullClass = bizClass.findAllClass().Select(m => m.ClassId).ToList();

            foreach (var item in list_classId)
            {
                list_fullClass = list_fullClass.Where(m => m != item).ToList();
                var statusId = bizClass.findById(item).StatusId;
                if (statusId != "CE")
                {
                    list_classId = list_classId.Where(m => m != item).ToList();
                }
                if (bizEvalua.findById(studentIdDefault + item) != null)
                {
                    list_classId = list_classId.Where(m => m != item).ToList();
                }
            }
            // Register Class
            cbClass.DataSource = list_fullClass;
            lbErrorStudent.Text = "Class " + cbClass.Text + " currently " + (24 - bizEnroll.findAllEnroll().Where(m => m.ClassId == cbClass.Text).ToList().Count) + " seats available";

            if (cbClass.Items.Count == 0)
            {
                lbErrorStudent.Text = "";
                btnSubmit.Enabled = false;
            }

            cbClassEvalua.DataSource = list_classId;
            if (cbClassEvalua.Items.Count == 0)
            {
                btnSubmitEvaluate.Enabled = false;
            }
            dgvStudyRecords.DataSource = bizEnroll.findAllEnroll().Where(m => m.StudentId == studentIdDefault).Select(m => new
            {
                ClassId = m.ClassId,
                ModuleId = bizModule.findById((bizClass.findById(m.ClassId).ModuleId)).ModuleName,
                TeacherId = bizTeacher.findById((bizClass.findById(m.ClassId).TeacherId)).FullName,
                Hw1Grade = m.Hw1Grade,
                Hw2Grade = m.Hw2Grade,
                Hw3Grade = m.Hw3Grade,
                Hw4Grade = m.Hw4Grade,
                Hw5Grade = m.Hw5Grade,
                Passed = m.Passed
            }).ToList();
            tbFirstName.Text = bizStudent.findById(studentIdDefault).FirstName;
            tbLastName.Text = bizStudent.findById(studentIdDefault).LastName;
            dtpBirthDate.Text = Convert.ToDateTime(bizStudent.findById(studentIdDefault).BirthDate).ToShortDateString();
            tbContact.Text = bizStudent.findById(studentIdDefault).Contact;

        }

        private void RegisterStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult closeApp = MessageBox.Show("Are you sure you want to exit the program?", "Notification", MessageBoxButtons.YesNo);
            if (closeApp == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void RegisterStudent_SizeChanged(object sender, EventArgs e)
        {
            lbTitle.Left = (this.ClientSize.Width - lbTitle.Size.Width) / 2;
        }

       
        private void btnSubmit_Click(object sender, EventArgs e)
        {


            enroll.StudentId = studentIdDefault;
            enroll.ClassId = cbClass.Text;
            enroll.Passed = 0;
            bizEnroll.createEnroll(DTOEFMapper.GetDtoFromEntity(enroll));
            if (bizEnroll.findAllEnroll().Where(m => m.ClassId == cbClass.Text).ToList().Count == 24)
            {
                var classCureent = bizClass.findById(cbClass.Text);
                classes.ClassId = cbClass.Text;
                classes.ModuleId = classCureent.ModuleId;
                classes.TeacherId = classCureent.TeacherId;
                classes.TypeId = classCureent.TypeId;
                classes.StatusId = "CA";
                bizClass.updateClass(DTOEFMapper.GetDtoFromEntity(classes));
            }
            var class_register = bizEnroll.findAllEnroll().Where(m => m.StudentId == studentIdDefault).Select(m => m.ClassId).ToList();
            var list_fullClass = bizClass.findAllClass().Select(m => m.ClassId).ToList();

            foreach (string item in class_register)
            {
                list_fullClass = list_fullClass.Where(m => m != item).ToList();
            }
            cbClass.DataSource = list_fullClass;
            if (cbClass.Items.Count == 0)
            {
                lbErrorStudent.Text = "";
                btnSubmit.Enabled = false;
            }
            MessageBox.Show("Register Successfully", "Message");


        }


        void ClearEvalua()
        {
            tbUnderstand.Value = tbTeaching.Value = tbSupport.Value = tbPunctuality.Value = 0;
        }

        private void btnSubmitEvaluate_Click(object sender, EventArgs e)
        {

            evaluate.ClassId = cbClassEvalua.Text;
            evaluate.StudentId = studentIdDefault;
            evaluate.Understand = tbUnderstand.Text.Trim();
            evaluate.Punctuality = tbPunctuality.Text.Trim();
            evaluate.Support = tbSupport.Text.Trim();
            evaluate.Teaching = tbTeaching.Text.Trim();

            bizEvalua.createEvaluate(DTOEFMapper.GetDtoFromEntity(evaluate));
            ClearEvalua();
            MessageBox.Show("Thanks for your evaluation!", "Message");
            var evalua = bizEvalua.findById(studentIdDefault + cbClassEvalua.Text);
            if (evalua != null)
            {
                list_classId = list_classId.Where(m => m != cbClassEvalua.Text).ToList();
            }
            cbClassEvalua.DataSource = list_classId;
            if (cbClassEvalua.Items.Count == 0)
            {
                btnSubmitEvaluate.Enabled = false;
            }
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbErrorStudent.Text = "Class " + cbClass.Text + " currently " + (24 - bizEnroll.findAllEnroll().Where(m => m.ClassId == cbClass.Text).ToList().Count) + " seats available";
        }

        private void StudentApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login frLogin = new Login();
            frLogin.Show();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            ChangePassword frChange = new ChangePassword();
            frChange.idStudent = studentIdDefault;
            this.Hide();
            frChange.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearProfile()
        {
            btnChangeProfile.Text = "Change Profile";
            tbFirstName.ReadOnly = true;
            tbContact.ReadOnly = true;
            dtpBirthDate.Enabled = false;
            tbLastName.ReadOnly = true;
        }
        int i = 0;
        private void btnChangeProfile_Click(object sender, EventArgs e)
        {            
            i++;
            if(i % 2 == 1)
            {
                btnChangeProfile.Text = "Save";
                tbFirstName.ReadOnly = false;
                tbContact.ReadOnly = false;
                dtpBirthDate.Enabled = true;
                tbLastName.ReadOnly = false;
            }else
            {
                student.StudentId = studentIdDefault;
                student.FirstName = tbFirstName.Text.Trim();
                student.LastName = tbLastName.Text.Trim();
                student.Contact = tbContact.Text.Trim();
                student.BirthDate = Convert.ToDateTime(dtpBirthDate.Value.ToShortDateString());
                bizStudent.updateStudent(DTOEFMapper.GetDtoFromEntity(student));
                ClearProfile();
                MessageBox.Show("Update Successfully", "Message");
            }
            
        }
    }
}
