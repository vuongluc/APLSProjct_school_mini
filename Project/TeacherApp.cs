using ProjectDomain;
using ProjectDomain.Business;
using ProjectDomain.Business.Capable;
using ProjectDomain.Business.Class;
using ProjectDomain.Business.Enroll;
using ProjectDomain.Business.Evaluate;
using ProjectDomain.DTOs;
using ProjectDomain.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class TeacherApp : Form
    {
        IClassTypeBusiness bizClassType = new ClassTypeEF();
        IStatusBusiness bizStatus = new StatusEF();
        IModuleBusiness bizModule = new ModuleEF();
        ITeacherBusiness bizTeacher = new TeacherEF();
        IStudentBusiness bizStudent = new StudentEF();
        IClassBusiness bizClass = new ClassEF();
        IEnrollBusiness bizEnroll = new EnrollEF();
        ICapableBusiness bizCapable = new CapableEF();
        IEvaluatesBusiness bizEvalua = new EvaluateEF();

        ClassType classType = new ClassType();
        Status status = new Status();
        Module module = new Module();
        Teacher teacher = new Teacher();
        StudentApp student = new StudentApp();
        Class classes = new Class();
        Enroll enroll = new Enroll();
        Capable capable = new Capable();
        string teacherIdDefault = null;
        public string teacherId; 
        public TeacherApp()
        {
            InitializeComponent();
        }
        private void TeacherApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult closeApp = MessageBox.Show("Are you sure you want to exit the program?", "Notification", MessageBoxButtons.YesNo);
            if (closeApp == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void TeacherApp_Load(object sender, EventArgs e)
        {
            teacherIdDefault = teacherId;
            // Class
           
            DisplayData();

            dgvGrade.Columns[0].ReadOnly = true;
            dgvGrade.Columns[1].ReadOnly = true;

            dgvClass.Columns[0].ReadOnly = true;
            dgvClass.Columns[2].ReadOnly = true;
            dgvClass.Columns[3].ReadOnly = true;
            dgvClass.Columns[4].ReadOnly = true;
            dgvClass.Columns[5].ReadOnly = true;
            btnUpdateTeachingHour.Enabled = false;
            // Grade
            cbClassGrade.DataSource = bizClass.findAllClass().Where(m => m.TeacherId == teacherIdDefault).Select(m => m.ClassId).ToList();
            //DataEnroll();
            btnSaveGrade.Enabled = false;
            dgvEvaluate.Columns[1].Visible = false;
            // Evaluate
            var list_class = bizClass.findAllClass().Where(m => m.TeacherId != teacherIdDefault).Select(m => m.ClassId).ToList();
            var result = bizEvalua.findAllEvaluate();
            foreach (var item in list_class)
            {
                result = result.Where(m => m.ClassId != item).ToList();
            }
            dgvEvaluate.DataSource = result.GroupBy(m => m.ClassId).Select(g => new
            {               
                ClassId = g.Key,
                Understand = g.Average(m => Convert.ToInt32(m.Understand)),
                Punctuality = g.Average(m => Convert.ToInt32(m.Punctuality)),
                Support = g.Average(m => Convert.ToInt32(m.Support)),
                Teaching = g.Average(m => Convert.ToInt32(m.Teaching)),
            });

            var list_combobox = bizClass.findAllClass().Where(m => m.TeacherId == teacherIdDefault && m.StatusId == "CE").Select(m => m.ClassId).ToList();
            cbEvalua.Items.Add("All");
            foreach(var item in list_combobox)
            {
                cbEvalua.Items.Add(item);
            }
            cbEvalua.SelectedIndex = 0;
           

        }


       

        // Class
        void DisplayData()
        {
            dgvClass.DataSource = bizClass.findAllClass().Where(m => m.TeacherId == teacherIdDefault).ToList();
        }
        private void btnUpdateTeachingHour_Click(object sender, EventArgs e)
        {
            if (lbErrorTeachingHour.Text == "")
            {
                foreach (DataGridViewRow row in dgvClass.Rows)
                {
                    
                    string moduleId = row.Cells["ModuleId"].Value.ToString();
                    string ModuleName = bizModule.findById(moduleId).ModuleName;
                    int duration = bizModule.findById(moduleId).Duration;
                    string classId = Convert.ToString(row.Cells["ClassId"].Value);
                    var classCurrent = bizClass.findById(classId);
                    if(Convert.ToString(row.Cells["TeachingHour"].Value) != "")
                    {
                        int teacherHour = Convert.ToInt32(row.Cells["TeachingHour"].Value.ToString());
                        classes.ClassId = Convert.ToString(row.Cells["ClassId"].Value);
                        classes.TeachingHour = Convert.ToInt32(row.Cells["TeachingHour"].Value.ToString());
                        classes.ModuleId = Convert.ToString(row.Cells["ModuleId"].Value);
                        classes.StatusId = Convert.ToString(row.Cells["StatusId"].Value);
                        classes.TeacherId = Convert.ToString(row.Cells["TeacherId"].Value);
                        classes.TypeId = Convert.ToString(row.Cells["TypeId"].Value);
                        if (Convert.ToInt32(row.Cells["TeachingHour"].Value.ToString()) == duration)
                        {
                            classes.ClassId = Convert.ToString(row.Cells["ClassId"].Value);
                            classes.TeachingHour = Convert.ToInt32(row.Cells["TeachingHour"].Value.ToString());
                            classes.ModuleId = Convert.ToString(row.Cells["ModuleId"].Value);
                            classes.StatusId = "CE";
                            classes.TeacherId = Convert.ToString(row.Cells["TeacherId"].Value);
                            classes.TypeId = Convert.ToString(row.Cells["TypeId"].Value);
                           
                        }
                    }
                    else
                    {
                        classes.ClassId = classCurrent.ClassId;
                        classes.TeachingHour = classCurrent.TeachingHour;
                        classes.ModuleId = classCurrent.ModuleId;
                        classes.StatusId = classCurrent.StatusId;
                        classes.TeacherId = classCurrent.TeacherId;
                        classes.TypeId = classCurrent.TypeId;
                    }
                }
                bizClass.updateClass(DTOEFMapper.GetDtoFromEntity(classes));
                MessageBox.Show("Update Sucessfully", "Message");   
                DisplayData();             
            }
        }
        private void dgvClass_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvClass.ClearSelection();
        }
        
        private void dgvClass_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += new KeyPressEventHandler(dgvClass_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dgvClass_KeyPress);
        }
        private void dgvClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false)
            {
                lbErrorTeachingHour.Text = "Please enter a number";
            }
            else
            {
                btnUpdateTeachingHour.Enabled = true;
                lbErrorTeachingHour.Text = "";
            }
        }
        private void dgvClass_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void dgvClass_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow indexRow = ((DataGridView)sender).Rows[e.RowIndex];
            int teacherHour = Convert.ToInt32(indexRow.Cells["TeachingHour"].Value.ToString());
            string moduleId = indexRow.Cells["ModuleId"].Value.ToString();
            string ModuleName = bizModule.findById(moduleId).ModuleName;
            int duration = bizModule.findById(moduleId).Duration;
            if (teacherHour > duration)
            {
                indexRow.ErrorText = ModuleName + " maximum is " + duration;
                lbErrorTeachingHour.Text = ModuleName + " maximum is " + duration;
            }
            else
            {
                btnUpdateTeachingHour.Enabled = true;
                indexRow.ErrorText = "";
                lbErrorTeachingHour.Text = "";
            }
        }
        private void dgvClass_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex.ToString());
        }
        private void btnCancelEditTeachingHour_Click(object sender, EventArgs e)
        {
            
            lbErrorTeachingHour.Text = "";
            dgvClass.DataSource = bizClass.findAllClass().Where(m => m.TeacherId == teacherIdDefault).ToList();
        }


        ////////////////////////////////////////////////////////////////////////////
        // Grade

        void DataEnroll()
        {
            dgvGrade.AutoGenerateColumns = false;
            // Edit trực tiếp được trên datagirdview
            dgvGrade.DataSource = bizEnroll.findAllEnroll().Where(m => m.ClassId == cbClassGrade.Text).ToList();
           

        }       
        private void cbClassGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvGrade.DataSource = bizEnroll.findAllEnroll().Where(m => m.ClassId == cbClassGrade.Text).ToList();
            //foreach (DataGridViewRow row in dgvGrade.Rows)
            //{
            //    string studentId = row.Cells["StudentId"].Value.ToString();
            //    dgvGrade.Rows[row.Index].Cells["StudentFullName"].Value = bizStudent.findById(studentId).FullName;
            //}
        }

       
       
        private void tbSearchStudent_TextChanged(object sender, EventArgs e)
        {
            if (tbSearchStudent.Text != "")
            {
                pbCloseSearchStudent.Visible = true;
            }
            else
            {
                pbCloseSearchStudent.Visible = false;
            }
            dgvGrade.DataSource = bizEnroll.search(tbSearchStudent.Text).Where(m => m.ClassId == cbClassGrade.Text).ToList();
            //foreach (DataGridViewRow row in dgvGrade.Rows)
            //{
            //    string studentId = row.Cells["StudentId"].Value.ToString();
            //    dgvGrade.Rows[row.Index].Cells["StudentFullName"].Value = bizStudent.findById(studentId).FullName;
            //}
        }
        private void pbCloseSearchStudent_Click(object sender, EventArgs e)
        {
            tbSearchStudent.Text = ""; 
        }
  
       
        /////////////////// validate
       
        private void dgvGrade_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += new KeyPressEventHandler(dgvGrade_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dgvGrade_KeyPress);
        }
        private void dgvGrade_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar) == false)
            {
                lbError.Text = "Please enter a number";
            }
            else
            {
                btnSaveGrade.Enabled = true;
                lbError.Text = "";
            }
        } 
        private void dgvGrade_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void dgvGrade_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow indexRow = ((DataGridView)sender).Rows[e.RowIndex];
            Regex pattern = new Regex("^([0-9]){1,3}$");
            if (Convert.ToString(dgvGrade.Rows[e.RowIndex].Cells[8].Value) != "" && Convert.ToString(dgvGrade.Rows[e.RowIndex].Cells[8].Value).Contains("%") == false)
            {
                if (pattern.IsMatch(Convert.ToString(dgvGrade.Rows[e.RowIndex].Cells[8].Value)) == false)
                {
                    indexRow.ErrorText = "Please enter a number";
                    lbError.Text = "Please enter a number";
                }
                else if (Convert.ToInt32(Convert.ToString(dgvGrade.Rows[e.RowIndex].Cells[8].Value)) > 100 || Convert.ToInt32(Convert.ToString(dgvGrade.Rows[e.RowIndex].Cells[8].Value)) < 0)
                {
                    indexRow.ErrorText = "ExamGrade range from 0 to 100";
                    lbError.Text = "ExamGrade range from 0 to 100";
                }
                else
                {
                    indexRow.ErrorText = "";
                    lbError.Text = "";
                }
            }
            else if (Convert.ToInt32(dgvGrade[e.ColumnIndex, e.RowIndex].Value) < 0 || Convert.ToInt32(dgvGrade[e.ColumnIndex, e.RowIndex].Value) > 10)
            {
                indexRow.ErrorText = "Please enter the correct number format 0 - 10";
                lbError.Text = "Please enter the correct number format 0 - 10";
            }
            else
            {
                btnSaveGrade.Enabled = true;
                indexRow.ErrorText = "";
                lbError.Text = "";
            }
        }

        //////////////// 
        // Evaluate
        private void cbEvalua_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbEvalua.SelectedIndex == 0)
            {
                dgvEvaluate.DataSource = bizEvalua.findAllEvaluate().Join(bizClass.findAllClass(), eva => eva.ClassId, clas => clas.ClassId, (eva, clas) => new
                {
                    ClassId = eva.ClassId,
                    Punctuality = eva.Punctuality,
                    Understand = eva.Understand,
                    Support = eva.Support,
                    Teaching = eva.Teaching,
                    StatusId = clas.StatusId
                }).Where(m => m.StatusId == "CE").GroupBy(m => m.ClassId).Select(g => new
                {
                    ClassId = g.Key,
                    Understand = g.Average(m => Convert.ToInt32(m.Understand)),
                    Punctuality = g.Average(m => Convert.ToInt32(m.Punctuality)),
                    Support = g.Average(m => Convert.ToInt32(m.Support)),
                    Teaching = g.Average(m => Convert.ToInt32(m.Teaching)),
                }).ToList();
            }else
            {
                dgvEvaluate.DataSource = bizEvalua.findAllEvaluate().Join(bizClass.findAllClass(), eva => eva.ClassId, clas => clas.ClassId, (eva, clas) => new
                {
                    ClassId = eva.ClassId,
                    Punctuality = eva.Punctuality,
                    Understand = eva.Understand,
                    Support = eva.Support,
                    Teaching = eva.Teaching,
                    StatusId = clas.StatusId
                }).Where(m => m.ClassId == cbEvalua.Text && m.StatusId == "CE").GroupBy(m => m.ClassId).Select(g => new
                {
                    ClassId = g.Key,
                    Understand = g.Average(m => Convert.ToInt32(m.Understand)),
                    Punctuality = g.Average(m => Convert.ToInt32(m.Punctuality)),
                    Support = g.Average(m => Convert.ToInt32(m.Support)),
                    Teaching = g.Average(m => Convert.ToInt32(m.Teaching)),
                }).ToList();
            }
            

           
        }
            
        private void dgvGrade_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex.ToString());
        }
        private void btnSaveGrade_Click(object sender, EventArgs e)
        {
            tbSearchStudent.Text = "";
            if(lbError.Text == "")
            {
                foreach (DataGridViewRow row in dgvGrade.Rows)
                {
                    string fullNameStudent = Convert.ToString(row.Cells["StudentId"].Value);
                    string classId = Convert.ToString(row.Cells["Class"].Value);
                    //string studentId = bizStudent.findAllStudent().Where(m => (m.FirstName + " " + m.LastName) == fullNameStudent).FirstOrDefault().StudentId;
                    var enrolls = bizEnroll.findById(fullNameStudent + classId);
                    enroll.StudentId = fullNameStudent;
                    enroll.ClassId = classId;
                    if (Convert.ToString(row.Cells["Hw1Grade"].Value) != "")
                    {
                        enroll.Hw1Grade = Convert.ToDouble(row.Cells["Hw1Grade"].Value.ToString());
                    }
                    else
                    {
                        enroll.Hw1Grade = enrolls.Hw1Grade;
                    }
                    if (Convert.ToString(row.Cells["Hw2Grade"].Value) != "")
                    {
                        enroll.Hw2Grade = Convert.ToDouble(row.Cells["Hw2Grade"].Value.ToString());
                    }
                    else
                    {
                        enroll.Hw2Grade = enrolls.Hw2Grade;
                    }
                    if (Convert.ToString(row.Cells["Hw3Grade"].Value) != "")
                    {
                        enroll.Hw3Grade = Convert.ToDouble(row.Cells["Hw3Grade"].Value.ToString());
                    }
                    else
                    {
                        enroll.Hw3Grade = enrolls.Hw3Grade;
                    }
                    if (Convert.ToString(row.Cells["Hw4Grade"].Value) != "")
                    {
                        enroll.Hw4Grade = Convert.ToDouble(row.Cells["Hw4Grade"].Value.ToString());
                    }
                    else
                    {
                        enroll.Hw4Grade = enrolls.Hw4Grade;
                    }
                    if (Convert.ToString(row.Cells["Hw5Grade"].Value) != "")
                    {
                        enroll.Hw5Grade = Convert.ToDouble(row.Cells["Hw5Grade"].Value.ToString());
                    }
                    else
                    {
                        enroll.Hw5Grade = enrolls.Hw5Grade;
                    }

                    if (Convert.ToString(row.Cells["ExamGrade"].Value) != "")
                    {
                        if (Convert.ToString(row.Cells["ExamGrade"].Value).Contains("%"))
                        {
                            enroll.ExamGrade = Convert.ToString(row.Cells["ExamGrade"].Value);
                            if (Convert.ToString(row.Cells["ExamGrade"].Value).Length == 2)
                            {
                                if (Convert.ToInt32(row.Cells["ExamGrade"].Value.ToString().Substring(0, 1)) >= 40)
                                {
                                    enroll.Passed = 1;
                                }
                                else
                                {
                                    enroll.Passed = 0;
                                }
                            }
                            else if (Convert.ToString(row.Cells["ExamGrade"].Value).Length == 3)
                            {
                                if (Convert.ToInt32(row.Cells["ExamGrade"].Value.ToString().Substring(0, 2)) >= 40)
                                {
                                    enroll.Passed = 1;
                                }
                                else
                                {
                                    enroll.Passed = 0;
                                }
                            }
                            else
                            {
                                enroll.Passed = 1;

                            }

                        }                        
                        else
                        {
                            enroll.ExamGrade = Convert.ToString(row.Cells["ExamGrade"].Value) + "%";
                            if (Convert.ToString(row.Cells["ExamGrade"].Value).Length == 1)
                            {
                                if (Convert.ToInt32(row.Cells["ExamGrade"].Value.ToString().Substring(0, 1)) >= 40)
                                {
                                    enroll.Passed = 1;
                                }
                                else
                                {
                                    enroll.Passed = 0;
                                }
                            }
                            else if (Convert.ToString(row.Cells["ExamGrade"].Value).Length == 2)
                            {
                                if (Convert.ToInt32(row.Cells["ExamGrade"].Value.ToString().Substring(0, 2)) >= 40)
                                {
                                    enroll.Passed = 1;
                                }
                                else
                                {
                                    enroll.Passed = 0;
                                }
                            }
                            else
                            {
                                enroll.Passed = 1;
                            }
                        }
                        
                        
                        
                    }
                    else
                    {
                        enroll.Passed = enrolls.Passed;
                        enroll.ExamGrade = enrolls.ExamGrade;
                    }
                    bizEnroll.updateEnroll(DTOEFMapper.GetDtoFromEntity(enroll));
                }
                DataEnroll();
                MessageBox.Show("Update Successfully", "Message");
            }
        }
        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            dgvGrade.DataSource = bizEnroll.findAllEnroll().Where(m => m.ClassId == cbClassGrade.Text).ToList();
         
            foreach (DataGridViewRow row in dgvGrade.Rows)
            {
                string studentId = row.Cells["StudentId"].Value.ToString();
                dgvGrade.Rows[row.Index].Cells["StudentFullName"].Value = bizStudent.findById(studentId).FullName;
            }
            btnSaveGrade.Enabled = false;
            lbError.Text = "";
        }

        private void TeacherApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login frLogin = new Login();
            frLogin.Show();
        }
    }

}
