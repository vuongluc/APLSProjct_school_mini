using ProjectDomain;
using ProjectDomain.Business;
using ProjectDomain.Business.Capable;
using ProjectDomain.Business.Class;
using ProjectDomain.Business.Enroll;
using ProjectDomain.Business.Evaluate;
using ProjectDomain.DTOs;
using ProjectDomain.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Admin : Form
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
        ProjectDomain.EF.Student student = new ProjectDomain.EF.Student();
        Class classes = new Class();
        Enroll enroll = new Enroll();
        Capable capable = new Capable();
        Evaluate evaluate = new Evaluate();
        List<StudentDTO> list_student = null;        
        public Admin()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbModuleName.DataSource = bizModule.findAllModule().Select(m => m.ModuleName).ToList();
            chart1.Series["Percent"].XValueMember = "ClassId";
            chart1.Series["Percent"].YValueMembers = "Passed";
            chart1.DataSource = bizClass.findAllClass().Join(bizEnroll.findAllEnroll(), clas => clas.ClassId, enrol => enrol.ClassId, (clas, enrol) => new
            {
                ClassId = clas.ClassId,
                Passed = enrol.Passed,
                ModuleId = clas.ModuleId
            }).Where(m => bizModule.findById(m.ModuleId).ModuleName == cbModuleName.Text).GroupBy(m => m.ClassId).Select(g => new
            {
                ClassId = g.Key,
                Passed = g.Average(m => Convert.ToInt32(m.Passed)) * 100
            }).ToList(); 
            chart1.DataBind();
            pbCloseSearchClassType.Visible = false;
            //ClassType
            Clear();
            DisplayDataGirdView();
            //Status
            ClearStatus();
            DataStatus();
            //Module
            ClearModule();
            DataModule();
            //Teacher   
         
            using (var db = new ProjectDbContext())
            {
                cbStatusId.DataSource = db.Status.Where(p => p.StatusName.Contains("teacher")).Select(m => m.StatusName).ToList();
                //cbStatusId.DisplayMember = "StatusName";
                cbSStatusId.DataSource = db.Status.Where(p => p.StatusName.Contains("student")).Select(m => m.StatusName).ToList();
                //cbSStatusId.DisplayMember = "StatusName";

                cbStatusClass.DataSource = db.Status.Where(p => p.StatusName.Contains("class")).Select(m => m.StatusName).ToList();
                //cbStatusClass.DisplayMember = "StatusName";
            }
            lbModule.ClearSelected();
            ClearTeacher();
            DataTeacher();
            lbModule.DataSource = bizModule.findAllModule().Select(x => x.ModuleName).ToList();
            //Student
            list_student = bizStudent.findAllStudent();
            ClearStudent();
            DataStudent();
            pageTotal();
           

            // Class
            cbModuleClass.DataSource = bizModule.findAllModule().Select(m => m.ModuleName).ToList();
            cbTeacherClass.DataSource = bizTeacher.findAllTeacher().Select(x => x.FullName).ToList();
            cbTypeClass.DataSource = bizClassType.findAllClassType().Select(x => x.TypeId).ToList();
            ClearClass();
            DataClass();
            cbStatusClass.SelectedIndex = 3;
            // Enroll
            lbStudent.DataSource = bizStudent.findAllStudent().Select(x => x.FullName).ToList();
            cbClassEnroll.DataSource = bizClass.findAllClass().Select(m => m.ClassId).ToList();
            ClearEnroll();
            DataEnroll();

            // Evaluate
           
            cbClassEvaluate.DataSource = bizClass.findAllClass().Where(m => m.StatusId =="CE").Select(m => m.ClassId).ToList();
            var list_IdStudent = bizEnroll.findAllEnroll().Where(m => m.ClassId == cbClassEnroll.Text).Select(m => m.StudentId).ToList();
            List<string> student = new List<string>();
            foreach(var item in list_IdStudent)
            {
                var name = bizStudent.findById(item).FullName;
                student.Add(name);
            }
            cbStudentEvaluate.DataSource = student;
            ClearEvalueate();
            DataEvaluate();
            chart1.Titles.Add("Pass percentage of modules");
            chart2.Titles.Add("Average exam grades of modules");
            chart3.Titles.Add("The number of students of modules");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult closeApp = MessageBox.Show("Are you sure you want to exit the program?", "Notification", MessageBoxButtons.YesNo);
            if (closeApp == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        /* Regex: ^[T]([0-1]{2})$
         * "S01#{year(field("BirthDate")) % 100}#{month(field("BirthDate"), true)}#{random(0, 9)}#{random(0, 9)}#{random(0, 9)}#{random(0, 9)}"
         * private void dgvStatus_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                tbStatusId.Text = dgvStatus.Rows[e.RowIndex].Cells["StatusId"].Value.ToString();
            }
        */


        ////////////////////////////////////////////////////////////////////////////
        // Class Type
            // Reuse method
        void Clear()
        {
            tbTypeId.Text=tbTeachingTime.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCreate.Enabled = true;
            btnImPort.Enabled = false;
            btnNew.Text = "Reset";
        }
        void DisplayDataGirdView()
        {
            dgwClassType.AutoGenerateColumns = false;            
            dgwClassType.DataSource = bizClassType.findAllClassType().ToList();
        }
        void dataBidingsClassType()
        {
            errorTypeId.Clear();
            errorTypeId.SetError(tbTypeId, null);
            errorTeachingTime.Clear();
            errorTeachingTime.SetError(tbTeachingTime, null);
            tbTypeId.DataBindings.Clear();
            tbTypeId.DataBindings.Add("Text", dgwClassType.DataSource, "TypeId");
            tbTeachingTime.DataBindings.Clear();
            tbTeachingTime.DataBindings.Add("Text", dgwClassType.DataSource, "TeachingTime");
            btnCreate.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            tbTypeId.Enabled = false;
        }
            //Form method
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (validateTypeId() && validateTeachingTime() )
            {
                errorTypeId.Clear();
                errorTeachingTime.Clear();
                classType.TypeId = tbTypeId.Text.Trim().ToUpper();
                classType.TeachingTime = tbTeachingTime.Text.Trim();
                bizClassType.createClass(DTOEFMapper.GetDtoFromEntity(classType));
                Clear();
                DisplayDataGirdView();
                MessageBox.Show("Create Successfully","Message");
            }

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateTeachingTime())
            {
                errorTypeId.Clear();
                errorTeachingTime.Clear();
                classType.TypeId = tbTypeId.Text.Trim();
                classType.TeachingTime = tbTeachingTime.Text.Trim();
                bizClassType.updateClass(DTOEFMapper.GetDtoFromEntity(classType));
                Clear();
                DisplayDataGirdView();
                tbTypeId.Enabled = true;
                btnCreate.Enabled = true;
                MessageBox.Show("Update Successfully", "Message");
            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string typeId = dgwClassType.Rows[dgwClassType.CurrentRow.Index].Cells["TypeId"].Value.ToString();

            if (MessageBox.Show("Are you sure to delete record?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bizClassType.deleteClass(typeId);
                Clear();
                DisplayDataGirdView();
                tbTypeId.Enabled = true;
                btnCreate.Enabled = true;
                MessageBox.Show("Delete Successfully", "Message");
            }else
            {
                //Clear();
                //DisplayDataGirdView();
                //tbTypeId.Enabled = true;
                //btnCreate.Enabled = true;
            }
        }
        private void dgwClassType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorTypeId.Clear();
            errorTeachingTime.Clear();
            lbError.Text = "";
            if ((tbTypeId.Text != "" || tbTeachingTime.Text != "") && btnUpdate.Enabled == false)
            {
                DialogResult mess = MessageBox.Show("The data you have entered will be lost. do you want to continue?", "Message", MessageBoxButtons.OKCancel);
                if (mess == DialogResult.OK)
                {
                    btnNew.Text = "Cancel";
                    dataBidingsClassType();
                }
            }
            else
            {
                btnNew.Text = "Cancel";
                dataBidingsClassType();
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            DisplayDataGirdView();
            errorTypeId.Clear();
            errorTypeId.SetError(tbTypeId, null);
            errorTeachingTime.Clear();
            errorTypeId.SetError(tbTeachingTime, null);
            tbTypeId.Enabled = true;
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text != "")
            {
                pbCloseSearchClassType.Visible = true;
            }
            else
            {
                pbCloseSearchClassType.Visible = false;
            }
            dgwClassType.DataSource = bizClassType.search(tbSearch.Text).ToList();
        }
        private void pbClose_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            pbCloseSearchClassType.Visible = false;
        }
        private void dgwClassType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgwClassType.ClearSelection();
        }
            //Validate Class Type
        private bool validateTypeId()
        {
            var listID = bizClassType.listId();
            var check = true;
            if (tbTypeId.Text == "")
            {
                errorTypeId.SetError(tbTypeId, "Please enter Type ID");
                lbError.Text = "Please enter Type ID";
                check = false;
            }
            else if (new Regex(@"^([a-zA-Z]){1}$").IsMatch(tbTypeId.Text) == false)
            {
                errorTypeId.SetError(tbTypeId, "Type ID only 1 letter can be entered");
                lbError.Text = "Type ID only 1 letter can be entered";
                check = false;
            }
            else if (listID.Contains(tbTypeId.Text.ToUpper()))
            {
                errorTypeId.SetError(tbTypeId, "Type ID already exist please enter again");
                lbError.Text = "Type ID already exist please enter again";
                check = false;
            }
            else
            {
                errorTypeId.Clear();
                errorTypeId.SetError(tbTypeId, null);
                lbError.Text = "";
             
            }
            return check;
        }
        private bool validateTeachingTime()
        {
            var check = true;
            if (tbTeachingTime.Text == "")
            {
                errorTeachingTime.SetError(tbTeachingTime, "Please enter Teaching Time");
                lbError.Text = "Please enter Teaching Time";
                check = false;
            }
            else if (new Regex(@"([0-9]{4})(\s-\s)([0-9]{4})$").IsMatch(tbTeachingTime.Text) == false)
            {
                errorTeachingTime.SetError(tbTeachingTime, "Please enter the correct format. Eg 8000 - 1200");
                lbError.Text = "Please enter the correct format. Eg 8000 - 1200";
                check = false;
            }
            else
            {                
                errorTeachingTime.Clear();
                errorTypeId.SetError(tbTeachingTime, null);
                lbError.Text = "";
            }
            return check;
        }        
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileClassType.Filter = "csv files (*.csv)|*.csv";
            openFileClassType.ShowDialog();
            var filename = Path.GetFileName(openFileClassType.FileName);
            tbFileClassType.Text = filename;
            if (tbFileClassType.Text != "")
            {
                btnImPort.Enabled = true;
            }
            else
            {
                btnImPort.Enabled = false;
            }
        }
        private bool validateImport()
        {
            var check = true;
            var filename = Path.GetFileName(openFileClassType.FileName);
            var path = Path.GetDirectoryName(openFileClassType.FileName);
            var fullPath = path + "\\" + filename;
            var listId = bizClassType.listId();
            using (var db = new ProjectDbContext())
            {
                StreamReader streamCsv = new StreamReader(fullPath);

                string csvDataLine = "";
                string[] data = null;
                var lineHeader = streamCsv.ReadLine();
                int count = 0;
                while ((csvDataLine = streamCsv.ReadLine()) != null)
                {
                    data = csvDataLine.Split(',');
                    if (listId.Contains(data[0]))
                    {
                        count = 1;
                    }
                }
                if (count == 1)
                {
                    errorImport.SetError(tbFileClassType, "File there is data TypeId already exists");
                    check = false;
                }
                else if (Path.GetExtension(tbFileClassType.Text) != ".csv")
                {
                    errorImport.SetError(tbFileClassType, "Please select the file with the .csv extension");
                    check = false;
                }
                return check;

            }
        }
        private void btnImPort_Click(object sender, EventArgs e)
        {
            if (tbFileClassType.Text != "" && validateImport())
            {
                errorImport.Clear();
                var filename = Path.GetFileName(openFileClassType.FileName);
                var path = Path.GetDirectoryName(openFileClassType.FileName);
                var fullPath = path + "\\" + filename;
                bizClassType.importData(fullPath);
                tbFileClassType.Text = "";
                DisplayDataGirdView();
                MessageBox.Show("Import successfully", "Message", MessageBoxButtons.OK);
                btnImPort.Enabled = false;
            }

        }





        ////////////////////////////////////////////////////////////////////////////       
        // Status
            // Reuse method
        void DataStatus()
        {
            dgvStatus.AutoGenerateColumns = false;
            dgvStatus.DataSource = bizStatus.fidAllStatus().ToList();
        } 
        void ClearStatus()
        {
            tbStatusId.Text = tbDescription.Text = tbStatusName.Text = "";
            btnUpdateStatus.Enabled = false;
            btnDeleteStatus.Enabled = false;
            btnSImPort.Enabled = false;
            btnNewStatus.Text = "Reset";
        }
        void dataBindingsStatus()
        {
            tbStatusId.DataBindings.Clear();
            tbStatusId.DataBindings.Add("Text", dgvStatus.DataSource, "StatusId");
            tbDescription.DataBindings.Clear();
            tbDescription.DataBindings.Add("Text", dgvStatus.DataSource, "Description");
            tbStatusName.DataBindings.Clear();
            tbStatusName.DataBindings.Add("Text", dgvStatus.DataSource, "StatusName");
            btnCreateStatus.Enabled = false;
            btnDeleteStatus.Enabled = true;
            btnUpdateStatus.Enabled = true;
            tbStatusId.Enabled = false;
        }
            // Form method
        private void btnCreateStatus_Click(object sender, EventArgs e)
        {
            if(validateStatusId() && validateStatusName())
            {
                errorStatusId.Clear();
                errorStatusName.Clear();
                status.StatusId = tbStatusId.Text.Trim().ToUpper();
                status.Description = tbDescription.Text.Trim();
                status.StatusName = tbStatusName.Text.Trim();
                bizStatus.createStatus(DTOEFMapper.GetDtoFromEntity(status));
                ClearStatus();
                DataStatus();
                MessageBox.Show("Create Successfully", "Message");
            }
           
        }
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (validateStatusName())
            {
                errorStatusId.Clear();
                errorStatusName.Clear();
                status.StatusId = tbStatusId.Text.Trim();
                status.Description = tbDescription.Text.Trim();
                status.StatusName = tbStatusName.Text.Trim();
                bizStatus.updateStatus(DTOEFMapper.GetDtoFromEntity(status));
                ClearStatus();
                DataStatus();
                tbStatusId.Enabled = true;
                btnCreateStatus.Enabled = true;
                MessageBox.Show("Update Successfully", "Message");
            }
           
        }      
        private void btnDeleteStatus_Click(object sender, EventArgs e)
        {
            string statusId = dgvStatus.Rows[dgvStatus.CurrentRow.Index].Cells["StatusId"].Value.ToString();

            if (MessageBox.Show("Are you sure to delete record?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bizStatus.deleteStatus(statusId);
                ClearStatus();
                DataStatus();
                tbStatusId.Enabled = true;
                btnCreateStatus.Enabled = true;
                MessageBox.Show("Delete Successfully", "Message");
            }
            else
            {
                //ClearStatus();
                //DataStatus();
            }
            //tbStatusId.Enabled = true;
            //btnCreateStatus.Enabled = true;
        }
        private void dgvStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorStatusId.Clear();
            errorStatusName.Clear();
            lbErrorStatus.Text = "";
            if ((tbStatusId.Text != "" || tbStatusName.Text != "" || tbDescription.Text != "") && btnUpdateStatus.Enabled == false)
            {
                DialogResult mess = MessageBox.Show("The data you have entered will be lost. do you want to continue?", "Message", MessageBoxButtons.OKCancel);
                if (mess == DialogResult.OK)
                {
                    btnNewStatus.Text = "Cancel";
                    dataBindingsStatus();
                }
            }
            else
            {
                btnNewStatus.Text = "Cancel";
                dataBindingsStatus();
            }
        }
        private void btnNewStatus_Click(object sender, EventArgs e)
        {
            ClearStatus();
            DataStatus();
            tbStatusId.Enabled = true;
            btnCreateStatus.Enabled = true;
            errorImportStatus.Clear();
            tbFileStatus.Text = "";
        }
        private void tbSearchStatus_TextChanged(object sender, EventArgs e)
        {
            if (tbSearchStatus.Text != "")
            {
                pbCloseSearchStatus.Visible = true;
            }
            else
            {
                pbCloseSearchStatus.Visible = false;
            }
            dgvStatus.DataSource = bizStatus.search(tbSearchStatus.Text).ToList();
        }
        private void pbSClose_Click(object sender, EventArgs e)
        {
            tbSearchStatus.Text = "";
        }
        private void dgvStatus_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvStatus.ClearSelection();
        }
            // Validate Status
        private bool validateStatusId()
        {
            var listID = bizStatus.listId();
            var check = true;
            if (tbStatusId.Text == "")
            {
                errorStatusId.SetError(tbStatusId, "Please enter Status ID");
                lbErrorStatus.Text = "Please enter Status ID";
                check = false;
            }
            else if (new Regex(@"^([a-zA-Z]){2}$").IsMatch(tbStatusId.Text) == false)
            {
                errorStatusId.SetError(tbStatusId, "Status ID can only enter 2 uppercase and lowercase letters");
                lbErrorStatus.Text = "Status ID can only enter 2 uppercase and lowercase letters";
                check = false;
            }
            else if (listID.Contains(tbStatusId.Text.ToUpper()))
            {
                errorStatusId.SetError(tbStatusId, "Status ID already exist please enter again");
                lbErrorStatus.Text = "Status ID already exist please enter again";
                check = false;
            }
            else
            {
                errorStatusId.Clear();
                errorStatusId.SetError(tbStatusId, null);
                lbErrorStatus.Text = "";
            }
            return check;
        }
        private bool validateStatusName()
        {
            var check = true;
            if (tbStatusName.Text == "")
            {
                errorStatusName.SetError(tbStatusName, "Please enter Status Name");
                lbErrorStatus.Text = "Please enter Status Name";
                check = false;
            }
            else
            {
                errorStatusName.Clear();
                errorStatusName.SetError(tbStatusName, null);
                lbErrorStatus.Text = "";
            }
            return check;
        }
        private void btnOpenFileStatus_Click(object sender, EventArgs e)
        {
            openFileStatus.Filter = "csv files (*.csv)|*.csv";
            openFileStatus.ShowDialog();
            var filename = Path.GetFileName(openFileStatus.FileName);
            tbFileStatus.Text = filename;
            if (tbFileStatus.Text != "")
            {
                btnSImPort.Enabled = true;
            }
            else
            {
                btnSImPort.Enabled = false;
            }
        }
        private bool validateImportStatus()
        {
            var check = true;
            var filename = Path.GetFileName(openFileStatus.FileName);
            var path = Path.GetDirectoryName(openFileStatus.FileName);
            var fullPath = path + "\\" + filename;
            var listId = bizStatus.listId();
            using (var db = new ProjectDbContext())
            {
                StreamReader streamCsv = new StreamReader(fullPath);

                string csvDataLine = "";
                string[] data = null;
                var lineHeader = streamCsv.ReadLine();
                int count = 0;
                while ((csvDataLine = streamCsv.ReadLine()) != null)
                {
                    data = csvDataLine.Split(',');
                    if (listId.Contains(data[0]))
                    {
                        count = 1;
                    }
                }
                if (count == 1)
                {
                    errorImportStatus.SetError(tbFileStatus, "File there is data StatusId already exists");
                    check = false;
                }
                else if (Path.GetExtension(tbFileStatus.Text) != ".csv")
                {
                    errorImportStatus.SetError(tbFileStatus, "Please select the file with the .csv extension");
                    check = false;
                }
                return check;

            }
        }
        private void btnSImPort_Click(object sender, EventArgs e)
        {
            if (tbFileStatus.Text != "" && validateImportStatus())
            {
                errorImportStatus.Clear();
                var filename = Path.GetFileName(openFileStatus.FileName);
                var path = Path.GetDirectoryName(openFileStatus.FileName);
                var fullPath = path + "\\" + filename;
                bizStatus.importData(fullPath);
                tbFileStatus.Text = "";
                DataStatus();
                MessageBox.Show("Import successfully", "Message", MessageBoxButtons.OK);
                btnSImPort.Enabled = false;
            }
        }





        ////////////////////////////////////////////////////////////////////////////  
        //Module
            // Reuse method
        void DataModule()
        {
            dgvModule.AutoGenerateColumns = false;
            dgvModule.DataSource = bizModule.findAllModule().ToList();
        }
        void ClearModule()
        {
            tbModuleId.Text = tbDuration.Text = tbModuleName.Text = tbHomeWork.Text = "";
            btnUpdateModule.Enabled = false;
            btnDeleteModule.Enabled = false;
            btnNewModule.Text = "Reset";
            lbModule.SelectedIndex = -1;
        }
        void databindingsModule()
        {
            tbModuleId.DataBindings.Clear();
            tbModuleId.DataBindings.Add("Text", dgvModule.DataSource, "ModuleId");

            tbDuration.DataBindings.Clear();
            string duration = dgvModule.Rows[dgvModule.CurrentRow.Index].Cells["Duration"].Value.ToString();
            //tbDuration.DataBindings.Add("Text", dgvModule.DataSource, "Duration");
            tbDuration.Text = duration;

            tbModuleName.DataBindings.Clear();
            tbModuleName.DataBindings.Add("Text", dgvModule.DataSource, "ModuleName");

            tbHomeWork.DataBindings.Clear();
            string homeWork = dgvModule.Rows[dgvModule.CurrentRow.Index].Cells["HomeWork"].Value.ToString();
            //tbHomeWork.DataBindings.Add("Text", dgvModule.DataSource, "Homework");
            tbHomeWork.Text = homeWork;

            btnCreateModule.Enabled = false;
            btnDeleteModule.Enabled = true;
            btnUpdateModule.Enabled = true;
            tbModuleId.Enabled = false;
        }
            // Form method
        private void btnCreateModule_Click(object sender, EventArgs e)
        {
            if(validateModuleId() && validateModule())
            {
                errorModuleId.Clear();
                errorModuleName.Clear();
                errorDuration.Clear();
                errorHomeWork.Clear();
                module.ModuleId = tbModuleId.Text.Trim().ToUpper();
                module.Duration = Convert.ToByte(tbDuration.Text.Trim());
                module.ModuleName = tbModuleName.Text.Trim();
                module.Homework = Convert.ToByte(tbHomeWork.Text.Trim());
                bizModule.createModule(DTOEFMapper.GetDtoFromEntity(module));
                ClearModule();
                DataModule();
                MessageBox.Show("Create Successfully", "Message");
            }
         
        }
        private void btnUpdateModule_Click(object sender, EventArgs e)
        {
            if(validateModule())
            {
                errorHomeWork.Clear();
                errorModuleId.Clear();
                errorModuleName.Clear();
                errorDuration.Clear();
                module.ModuleId = tbModuleId.Text.Trim();
                module.Duration = Convert.ToByte(tbDuration.Text);
                module.ModuleName = tbModuleName.Text.Trim();
                module.Homework = Convert.ToByte(tbHomeWork.Text);
                bizModule.updateModule(DTOEFMapper.GetDtoFromEntity(module));
                ClearModule();
                DataModule();
                tbModuleId.Enabled = true;
                btnCreateModule.Enabled = true;
                MessageBox.Show("Update Successfully", "Message");
            }
            
        }
        private void btnDeleteModule_Click(object sender, EventArgs e)
        {
            string moduleId = dgvModule.Rows[dgvModule.CurrentRow.Index].Cells["ModuleId"].Value.ToString();

            if (MessageBox.Show("Are you sure to delete record?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bizModule.deleteModule(moduleId);
                ClearModule();
                DataModule();
                tbStatusId.Enabled = true;
                btnCreateModule.Enabled = true;
                MessageBox.Show("Delete Successfully", "Message");
            }
            else
            {
                //ClearModule();
                //DataModule();
            }
            //tbStatusId.Enabled = true;
            //btnCreateModule.Enabled = true;
        }
        private void dgvModule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorModuleId.Clear();
            errorModuleName.Clear();
            errorDuration.Clear();
            errorHomeWork.Clear();
            lbErrorModule.Text = "";
            if ((tbModuleId.Text != "" || tbModuleName.Text != "" || tbDuration.Text != "" || tbHomeWork.Text != "") && btnUpdateModule.Enabled == false)
            {
                DialogResult mess = MessageBox.Show("The data you have entered will be lost. do you want to continue?", "Message", MessageBoxButtons.OKCancel);
                if (mess == DialogResult.OK)
                {
                    btnNewModule.Text = "Cancel";
                    databindingsModule();
                }
            }
            else
            {
                btnNewModule.Text = "Cancel";
                databindingsModule();
            }
        }
        private void btnNewModule_Click(object sender, EventArgs e)
        {
            ClearModule();
            DataModule();
            tbModuleId.Enabled = true;
            btnCreateModule.Enabled = true;
            errorImportModule.Clear();
            tbFileModule.Text = "";
        }
        private void pbCloseSearchModule_Click(object sender, EventArgs e)
        {
            tbSearchModule.Text = "";
        }
        private void tbSearchModule_TextChanged(object sender, EventArgs e)
        {
            if (tbSearchModule.Text != "")
            {
                pbCloseSearchModule.Visible = true;
            }
            else
            {
                pbCloseSearchModule.Visible = false;
            }
            dgvModule.DataSource = bizModule.search(tbSearchModule.Text).ToList();
        }
        private void dgvModule_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvModule.ClearSelection();
        }
            // Validate Module
        private void btnOpenFileModule_Click(object sender, EventArgs e)
        {
            openFileModule.Filter = "csv files (*.csv)|*.csv";
            openFileModule.ShowDialog();
            var filename = Path.GetFileName(openFileModule.FileName);
            tbFileModule.Text = filename;
            if (tbFileModule.Text != "")
            {
                btnImportModule.Enabled = true;
            }
            else
            {
                btnImportModule.Enabled = false;
            }
        }
        private bool validateImportModule()
        {
            var check = true;
            var filename = Path.GetFileName(openFileModule.FileName);
            var path = Path.GetDirectoryName(openFileModule.FileName);
            var fullPath = path + "\\" + filename;
            var listId = bizModule.listId();
            using (var db = new ProjectDbContext())
            {
                StreamReader streamCsv = new StreamReader(fullPath);

                string csvDataLine = "";
                string[] data = null;
                var lineHeader = streamCsv.ReadLine();
                int count = 0;
                while ((csvDataLine = streamCsv.ReadLine()) != null)
                {
                    data = csvDataLine.Split(',');
                    if (listId.Contains(data[0]))
                    {
                        count = 1;
                    }
                }
                if (count == 1)
                {
                    errorImportModule.SetError(tbFileModule, "File there is data ModuleId already exists");
                    check = false;
                }
                else if (Path.GetExtension(tbFileModule.Text) != ".csv")
                {
                    errorImportModule.SetError(tbFileModule, "Please select the file with the .csv extension");
                    check = false;
                }
                return check;

            }
        }
        private void btnImportModule_Click(object sender, EventArgs e)
        {
            if (tbFileModule.Text != "" && validateImportModule())
            {
                errorImportModule.Clear();
                var filename = Path.GetFileName(openFileModule.FileName);
                var path = Path.GetDirectoryName(openFileModule.FileName);
                var fullPath = path + "\\" + filename;
                bizModule.importData(fullPath);
                tbFileModule.Text = "";
                DataModule();
                MessageBox.Show("Import successfully", "Message", MessageBoxButtons.OK);
                btnImportModule.Enabled = false;
            }
        }
        private bool validateModuleId()
        {
            var listID = bizModule.listId();
            var check = true;
            if (tbModuleId.Text == "")
            {
                errorModuleId.SetError(tbModuleId, "Please enter Module ID");
                lbErrorModule.Text = "Please enter Module ID";
                check = false;
            }
            else if (new Regex(@"^([a-zA-Z]){1,5}$").IsMatch(tbModuleId.Text) == false)
            {
                errorModuleId.SetError(tbModuleId, "Module ID can only enter up to 5 uppercase and lowercase letters");
                lbErrorModule.Text = "Module ID can only enter up to 5 uppercase and lowercase letters";
                check = false;
            }
            else if (listID.Contains(tbModuleId.Text.ToUpper()))
            {
                errorModuleId.SetError(tbModuleId, "Module ID already exist please enter again");
                lbErrorModule.Text = "Module ID already exist please enter again";
                check = false;
            }
            else
            {
                errorModuleId.Clear();
                errorModuleId.SetError(tbModuleId, null);
                lbErrorModule.Text = "P";

            }
            return check;
        }
        private bool validateModule()
        {
            var check = true;
            if (tbDuration.Text == "")
            {
                errorDuration.SetError(tbDuration, "Please enter Duration");
                lbErrorModule.Text = "Please enter Duration";
                check = false;
            }
            else if (new Regex(@"^([0-9]){2}$").IsMatch(tbDuration.Text) == false)
            {
                errorDuration.SetError(tbDuration, "Duration only 2 digits can be entered");
                lbErrorModule.Text = "Duration only 2 digits can be entered";
                check = false;
            }
            else if (tbModuleName.Text == "")
            {
                errorDuration.Clear();
                errorModuleName.SetError(tbModuleName, "Please enter Module Name");
                lbErrorModule.Text = "Please enter Module Name";
                check = false;
            }
            else if (tbHomeWork.Text == "")
            {
                errorModuleName.Clear();
                errorHomeWork.SetError(tbHomeWork, "Please enter Home Work");
                lbErrorModule.Text = "Please enter Home Work";
                check = false;
            }
            else if (new Regex(@"^([0-9]){1,2}$").IsMatch(tbHomeWork.Text) == false)
            {
                errorHomeWork.SetError(tbHomeWork, "HomeWork only enter up to 2 letters");
                lbErrorModule.Text = "HomeWork only enter up to 2 letters";
                check = false;
            }
            else
            {
                errorDuration.Clear();
                errorDuration.Clear();
                errorHomeWork.Clear();
                lbErrorModule.Text = "";
            }
            return check;
        }




        ////////////////////////////////////////////////////////////////////////////  
        // Teacher
        // Reuse mothod
        void ClearTeacher()
        {
            tbTeacherId.Text = tbLastName.Text = tbFirstName.Text = tbContact.Text = "";
            dtpBirthDate.Text = DateTime.Now.ToShortDateString();
            cbStatusId.SelectedIndex = 0;
            btnUpdateTeacher.Enabled = false;
            btnDeleteTeacher.Enabled = false;
            btnImportTeacher.Enabled = false;
            btnNewTeacher.Text = "Reset";
            lbModule.SelectedIndex = -1;

        }
        void DataTeacher()
        {
            dgvTeacher.AutoGenerateColumns = false;
            dgvTeacher.DataSource = bizTeacher.findAllTeacher().ToList();
        }
        void databindingsTeacher()
        {
            tbTeacherId.DataBindings.Clear();
            tbTeacherId.DataBindings.Add("Text", dgvTeacher.DataSource, "TeacherId");
            tbFirstName.DataBindings.Clear();
            tbFirstName.DataBindings.Add("Text", dgvTeacher.DataSource, "FirstName");
            tbLastName.DataBindings.Clear();
            tbLastName.DataBindings.Add("Text", dgvTeacher.DataSource, "LastName");
            tbContact.DataBindings.Clear();
            tbContact.DataBindings.Add("Text", dgvTeacher.DataSource, "Contact");
            dtpBirthDate.DataBindings.Clear();
            dtpBirthDate.DataBindings.Add("Text", dgvTeacher.DataSource, "BirthDate");
            cbStatusId.DataBindings.Clear();
            string StatusId = dgvTeacher.Rows[dgvTeacher.CurrentRow.Index].Cells["StatusIDs"].Value.ToString();
            cbStatusId.DataBindings.Add("Text", bizStatus.findById(StatusId), "StatusName");

            btnCreateTeacher.Enabled = false;
            btnDeleteTeacher.Enabled = true;
            btnUpdateTeacher.Enabled = true;
            tbTeacherId.Enabled = false;
        }
            // Form method
        private void btnCreateTeacher_Click(object sender, EventArgs e)
        {
            List<string> modules = new List<string>();
            foreach(var module in lbModule.SelectedItems)
            {
                modules.Add(module.ToString());
            }
            if (validateTeacherId() && validateTeacher())
            {
                teacher.TeacherId = tbTeacherId.Text.Trim();
                teacher.FirstName = tbFirstName.Text.Trim();
                teacher.LastName = tbLastName.Text.Trim();
                teacher.Contact = tbContact.Text.Trim();
                teacher.BirthDate = Convert.ToDateTime(dtpBirthDate.Value.ToShortDateString());
                using (var db = new ProjectDbContext())
                {
                    var teachers = db.Status.Where(x => x.StatusName == cbStatusId.Text).FirstOrDefault();
                    if (teachers != null)
                    {
                        teacher.StatusId = teachers.StatusId;
                    }
                }
                bizTeacher.createTeacher(DTOEFMapper.GetDtoFromEntity(teacher));
                foreach (string module in modules)
                {
                    var moduleId = bizModule.findAllModule().Where(m => m.ModuleName == module).FirstOrDefault();
                    capable.ModuleId = moduleId.ModuleId;
                    capable.TeacherId = tbTeacherId.Text;         
                    bizCapable.createCapable(DTOEFMapper.GetDtoFromEntity(capable));

                }
                //teacher.StatusId = cbStatusId.Text.Trim();

                ClearTeacher();
                DataTeacher();
                MessageBox.Show("Create Successfully", "Message");
            }
           
        }
        private void btnUpdateTeacher_Click(object sender, EventArgs e)
        {
            List<string> modules = new List<string>();
            foreach (object module in lbModule.SelectedItems)
            {
                modules.Add(module.ToString());
            }
            bizCapable.deleteCapable(tbTeacherId.Text.Trim());
            bizTeacher.deleteTeacher(tbTeacherId.Text.Trim());
            if (validateTeacher())
            {
                teacher.TeacherId = tbTeacherId.Text.Trim();
                teacher.FirstName = tbFirstName.Text.Trim();
                teacher.LastName = tbLastName.Text.Trim();
                teacher.Contact = tbContact.Text.Trim();
                teacher.BirthDate = Convert.ToDateTime(dtpBirthDate.Value.ToShortDateString());
                using (var db = new ProjectDbContext())
                {
                    var teachers = db.Status.Where(x => x.StatusName == cbStatusId.Text).FirstOrDefault();
                    if (teachers != null)
                    {
                        teacher.StatusId = teachers.StatusId;
                    }
                }
                //bizTeacher.updateTeacher(DTOEFMapper.GetDtoFromEntity(teacher));               

                bizTeacher.createTeacher(DTOEFMapper.GetDtoFromEntity(teacher));
                foreach (string module in modules)
                {
                    var moduleId = bizModule.findAllModule().Where(m => m.ModuleName == module).FirstOrDefault();
                    capable.ModuleId = moduleId.ModuleId;
                    capable.TeacherId = tbTeacherId.Text;
                    bizCapable.createCapable(DTOEFMapper.GetDtoFromEntity(capable));

                }
                lbModule.SelectedIndex = -1;
                ClearTeacher();
                DataTeacher();
                tbTeacherId.Enabled = true;
                btnCreateTeacher.Enabled = true;
                MessageBox.Show("Update Successfully", "Message");
            }
         
        }
        private void btnDeleteTeacher_Click(object sender, EventArgs e)
        {
            string teacherID = dgvTeacher.Rows[dgvTeacher.CurrentRow.Index].Cells["TeacherId"].Value.ToString();

            if (MessageBox.Show("Are you sure to delete record?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var capableId = bizCapable.findAllCapable().Where(m => m.TeacherId == tbTeacherId.Text).FirstOrDefault();
                //var classId = bizClass.findAllClass().Where(m => m.TeacherId == teacherID).FirstOrDefault().ClassId;
                //if(classId != null)
                //{
                    
                //}
                bizCapable.deleteCapable(tbTeacherId.Text);
                bizTeacher.deleteTeacher(teacherID);
                ClearTeacher();
                DataTeacher();
                tbTeacherId.Enabled = true;
                btnCreateTeacher.Enabled = true;
                MessageBox.Show("Delete Successfully", "Message");
            }
            else
            {
                //ClearTeacher();
                //DataTeacher();
            }
            //tbTeacherId.Enabled = true;
            //btnCreateTeacher.Enabled = true;
        }
        private void dgvTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbModule.SelectedIndex = -1;
            string teacherId = dgvTeacher.Rows[dgvTeacher.CurrentRow.Index].Cells["TeacherId"].Value.ToString();
            var list = bizCapable.findById(teacherId);
            if (list != null)
            {
                List<string> module_name = new List<string>();
                foreach (var item in list)
                {
                    var moduleName = bizModule.findById(item.ModuleId).ModuleName;
                    module_name.Add(moduleName);
                }
                for (int i = 0; i < lbModule.Items.Count; i++)
                {
                    for (int j = 0; j < module_name.Count; j++)
                    {
                        if (lbModule.Items[i].ToString() == module_name[j])
                        {
                            lbModule.SetSelected(i, true);
                        }
                    }
                }
            }

            errorTeacherId.Clear();
            errorFirstNameTeacher.Clear();
            errorLastNameTeacher.Clear();
            errorContactTeacher.Clear();
            lbErrorTeacher.Text = "";
            if ((tbTeacherId.Text != "" || tbLastName.Text != "" || tbFirstName.Text != "" || tbContact.Text != "") && btnUpdateTeacher.Enabled == false)
            {
                DialogResult mess = MessageBox.Show("The data you have entered will be lost. do you want to continue?", "Message", MessageBoxButtons.OKCancel);
                if (mess == DialogResult.OK)
                {
                    btnNewTeacher.Text = "Cancel";
                    databindingsTeacher();

                }
            }
            else
            {
                btnNewTeacher.Text = "Cancel";
                databindingsTeacher();
            }
        }
        private void btnNewTeacher_Click(object sender, EventArgs e)
        {
            ClearTeacher();
            DataTeacher();
            tbTeacherId.Enabled = true;
            btnCreateTeacher.Enabled = true;
            errorImportTeacher.Clear();
            tbFileTeacher.Text = "";
            lbModule.SelectedIndex = -1;
        }
        private void pbCloseSearchTeacher_Click(object sender, EventArgs e)
        {
            tbSearchTeacher.Text = "";
        }
        private void tbSearchTeacher_TextChanged(object sender, EventArgs e)
        {
            if (tbSearchTeacher.Text != "")
            {
                pbCloseSearchTeacher.Visible = true;
            }
            else
            {
                pbCloseSearchTeacher.Visible = false;
            }
            dgvTeacher.DataSource = bizTeacher.search(tbSearchTeacher.Text).ToList();
        }
        private void dgvTeacher_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvTeacher.ClearSelection();
        }
        // Validate Teacher
        private void btnOpenFileTeacher_Click(object sender, EventArgs e)
        {
            openFileTeacher.Filter = "csv files (*.csv)|*.csv";
            openFileTeacher.ShowDialog();
            var filename = Path.GetFileName(openFileTeacher.FileName);
            tbFileTeacher.Text = filename;
            if (tbFileTeacher.Text != "")
            {
                btnImportTeacher.Enabled = true;
            }
            else
            {
                btnImportTeacher.Enabled = false;
            }
        }
        private bool validateImportTeacher()
        {
            var check = true;
            var filename = Path.GetFileName(openFileTeacher.FileName);
            var path = Path.GetDirectoryName(openFileTeacher.FileName);
            var fullPath = path + "\\" + filename;
            var listId = bizTeacher.listId();
            using (var db = new ProjectDbContext())
            {
                StreamReader streamCsv = new StreamReader(fullPath);

                string csvDataLine = "";
                string[] data = null;
                var lineHeader = streamCsv.ReadLine();
                int count = 0;
                while ((csvDataLine = streamCsv.ReadLine()) != null)
                {
                    data = csvDataLine.Split(',');
                    if (listId.Contains(data[0]))
                    {
                        count = 1;
                    }
                }
                if (count == 1)
                {
                    errorImportTeacher.SetError(tbFileTeacher, "File there is data TeacherId already exists");
                    check = false;
                }
                else if (Path.GetExtension(tbFileTeacher.Text) != ".csv")
                {
                    errorImportTeacher.SetError(tbFileTeacher, "Please select the file with the .csv extension");
                    check = false;
                }
                return check;
            }
        }
        private void btnImportTeacher_Click(object sender, EventArgs e)
        {
            if (validateImportTeacher())
            {
                errorImportTeacher.Clear();
                var filename = Path.GetFileName(openFileTeacher.FileName);
                var path = Path.GetDirectoryName(openFileTeacher.FileName);
                var fullPath = path + "\\" + filename;
                bizTeacher.importData(fullPath);
                tbFileTeacher.Text = "";
                DataTeacher();
                MessageBox.Show("Import successfully", "Message", MessageBoxButtons.OK);
                btnImportTeacher.Enabled = false;
            }
        }
        private bool validateTeacherId()
        {
            var year = dtpBirthDate.Value.Year.ToString().Substring(2, 2);
            var month = "";
            if (dtpBirthDate.Value.Month < 10)
            {
                month += "0" + dtpBirthDate.Value.Month;
            }
            else
            {
                month = dtpBirthDate.Value.Month.ToString();
            }
            var listID = bizTeacher.listId();
            var check = true;
            if (tbTeacherId.Text == "")
            {
                errorTeacherId.SetError(tbTeacherId, "Please enter Teacher ID");
                lbErrorTeacher.Text = "Please enter Teacher ID";
                check = false;
            }
            else if (new Regex("^[T]([0-1]{2})(" + year + month + ")([0-9]{4})$").IsMatch(tbTeacherId.Text) == false)
            {
                errorTeacherId.SetError(tbTeacherId, "Teacher Id must start with the letter 'T' then 01 or 00 or 11 or 10 or 2 digits of the year and 2 digits of the month and 4 random digits");
                lbErrorTeacher.Text = "Teacher Id must start with the letter 'T' then 01 or 00 or 11 or 10 or 2 digits of the year and 2 digits of the month and 4 random digits";
                check = false;
            }
            else if (listID.Contains(tbTeacherId.Text))
            {
                errorTeacherId.SetError(tbModuleId, "Teacher ID already exist please enter again");
                lbErrorTeacher.Text = "Teacher ID already exist please enter again";
                check = false;
            }
            else
            {
                errorTeacherId.Clear();
                lbErrorTeacher.Text = "";

            }
            return check;
        }
        private bool validateTeacher()
        {
            var check = true;
            if (tbFirstName.Text == "")
            {
                errorFirstNameTeacher.SetError(tbFirstName, "Please enter first name");
                lbErrorTeacher.Text = "Please enter first name";
                check = false;
            }
            else if (tbLastName.Text == "")
            {
                errorFirstNameTeacher.Clear();
                errorLastNameTeacher.SetError(tbLastName, "Please enter last name");
                lbErrorTeacher.Text = "Please enter last name";
                check = false;
            }
            else if (tbContact.Text == "")
            {
                errorLastNameTeacher.Clear();
                errorContactTeacher.SetError(tbContact, "Please enter contact");
                lbErrorTeacher.Text = "Please enter contact";
                check = false;
            }else if(lbModule.SelectedItems.Count < 1)
            {
                errorContactTeacher.Clear();
                errorContactTeacher.SetError(lbModule, "Please select a minimum of 1 module");
                lbErrorTeacher.Text = "Please select a minimum of 1 module";
                check = false;
            }
            else
            {
                errorTeacherId.Clear();
                errorFirstNameTeacher.Clear();
                errorLastNameTeacher.Clear();
                errorContactTeacher.Clear();
                lbErrorTeacher.Text = "";

            }
            return check;
        }




        ////////////////////////////////////////////////////////////////////////////  
        // Student
        // Reuse moethod

            // Paging
        int currentPageIndex = 1;
        int pageSize = 10; //Số dòng hiển thị lên lưới
        int pageNumber = 0; //Số trang
        int rows; //Số dòng được trả về từ câu truy vấn trong formLoad
        int column = 0; // Biến đếm để sorting
        int countFistName = 0;
        int countLastName = 0;
        int countStudentId = 0;
        int countContact = 0;
        int countBirthDate = 0;
        int countStatus = 0;


        void pageTotal()
        {
            rows = bizStudent.findAllStudent().Count();
            pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
            lbTotalPage.Text = " / " + pageNumber.ToString();
            cbPage.Items.Clear();
            for (int i = 1; i <= pageNumber; i++)
            {
                cbPage.Items.Add(i + "");
            }
            cbPage.SelectedIndex = 0;
        }
        void ClearStudent()
        {
            tbStudentId.Text = tbSLastName.Text = tbSFirstName.Text = tbSContact.Text = "";
            dtpSBirthDate.Text = DateTime.Now.ToShortDateString();
            cbSStatusId.SelectedIndex = 0;
            btnUpdateStudent.Enabled = false;
            btnDeleteStudent.Enabled = false;
            btnImportStudent.Enabled = false;
            btnNewStudent.Text = "Reset";
        }
        void DataStudent()
        {
            dgvStudent.AutoGenerateColumns = false;
            dgvStudent.DataSource = bizStudent.findAllStudent().Skip(10).Take(10).ToList();
        }
        void databindingsStudent()
        {
            tbStudentId.DataBindings.Clear();
            tbStudentId.DataBindings.Add("Text", dgvStudent.DataSource, "StudentId");
            tbSFirstName.DataBindings.Clear();
            tbSFirstName.DataBindings.Add("Text", dgvStudent.DataSource, "FirstName");
            tbSLastName.DataBindings.Clear();
            tbSLastName.DataBindings.Add("Text", dgvStudent.DataSource, "LastName");
            tbSContact.DataBindings.Clear();
            tbSContact.DataBindings.Add("Text", dgvStudent.DataSource, "Contact");
            dtpSBirthDate.DataBindings.Clear();
            dtpSBirthDate.DataBindings.Add("Text", dgvStudent.DataSource, "BirthDate");
            cbSStatusId.DataBindings.Clear();
            string StatusId = dgvStudent.Rows[dgvStudent.CurrentRow.Index].Cells["SStatusId"].Value.ToString();            
            cbSStatusId.DataBindings.Add("Text", bizStatus.findById(StatusId), "StatusName");               
            btnCreateStudent.Enabled = false;
            btnDeleteStudent.Enabled = true;
            btnUpdateStudent.Enabled = true;
            tbStudentId.Enabled = false;
        }
            // Form method
        private void btnCreateStudent_Click(object sender, EventArgs e)
        {
            if (validateStudentId() && validateStudent())
            {
                student.StudentId = tbStudentId.Text.Trim();
                student.FirstName = tbSFirstName.Text.Trim();
                student.LastName = tbSLastName.Text.Trim();
                student.Contact = tbSContact.Text.Trim();
                student.BirthDate = Convert.ToDateTime(dtpSBirthDate.Value.ToShortDateString());
                using (var db = new ProjectDbContext())
                {
                    var students = db.Status.Where(x => x.StatusName == cbSStatusId.Text).FirstOrDefault();
                    if (students != null)
                    {
                        student.StatusId = students.StatusId;
                    }
                }
                //student.StatusId = cbSStatusId.Text.Trim();
                bizStudent.createStudent(DTOEFMapper.GetDtoFromEntity(student));
                ClearStudent();
                DataStudent();
                MessageBox.Show("Create Successfully", "Message");
            }
        }
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (validateStudent())
            {
                student.StudentId = tbStudentId.Text.Trim();
                student.FirstName = tbSFirstName.Text.Trim();
                student.LastName = tbSLastName.Text.Trim();
                student.Contact = tbSContact.Text.Trim();
                student.BirthDate = Convert.ToDateTime(dtpSBirthDate.Value.ToShortDateString());
                using (var db = new ProjectDbContext())
                {
                    var status = db.Status.Where(x => x.StatusName == cbSStatusId.Text).FirstOrDefault();
                    if (status != null)
                    {
                        student.StatusId = status.StatusId;
                    }
                }
                //student.StatusId = cbSStatusId.Text.Trim();
                bizStudent.updateStudent(DTOEFMapper.GetDtoFromEntity(student));
                ClearStudent();
                DataStudent();
                tbStudentId.Enabled = true;
                btnCreateStudent.Enabled = true;
                MessageBox.Show("Update Successfully","Message");
            }
    
        }
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorStudentId.Clear();
            errorFistNameStudent.Clear();
            errorLastNameStudent.Clear();
            errorContactStudent.Clear();
            lbErrorStudent.Text = "";
            if ((tbStatusId.Text != "" || tbSLastName.Text != "" || tbSFirstName.Text != "" || tbSContact.Text != "") && btnUpdateStudent.Enabled == false)
            {
                DialogResult mess = MessageBox.Show("The data you have entered will be lost. do you want to continue?", "Message", MessageBoxButtons.OKCancel);
                if (mess == DialogResult.OK)
                {
                    btnNewStudent.Text = "Cancel";
                    databindingsStudent();
                }
            }
            else
            {
                btnNewStudent.Text = "Cancel";
                databindingsStudent();
            }
        }
        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            string studentID = dgvStudent.Rows[dgvStudent.CurrentRow.Index].Cells["StudentId"].Value.ToString();

            if (MessageBox.Show("Are you sure to delete record?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bizStudent.deleteStudent(studentID);
                ClearStudent();
                DataStudent();
                tbStudentId.Enabled = true;
                btnCreateStudent.Enabled = true;
                MessageBox.Show("Delete Successfully", "Message");
            }
            else
            {
                //ClearStudent();
                //DataStudent();
            }
            //tbStudentId.Enabled = true;
            //btnCreateStudent.Enabled = true;
        }
        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            ClearStudent();
            DataStudent();
            tbStudentId.Enabled = true;
            btnCreateStudent.Enabled = true;
            errorImportStudent.Clear();
            tbFileStudent.Text = "";
        }
        private void pbCloseSearchStudent_Click(object sender, EventArgs e)
        {
            tbSearchStudent.Text = "";
        }
        private void tbSearchStudent_TextChanged(object sender, EventArgs e)
        {
            var data = bizStudent.search(tbSearchStudent.Text);
            if (tbSearchStudent.Text != "")
            {                
                if (data.Count == 0)
                {
                    rows = 0;
                    cbPage.Items.Clear();
                    dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).ToList();
                    lbTotalPage.Text = "/ 0";
                    cbPage.Items.Add("0");
                    cbPage.SelectedIndex = 0;
                }
                else
                {                    
                    rows = data.Count();
                    pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                    lbTotalPage.Text = " / " + pageNumber.ToString();
                    cbPage.Items.Clear();
                    for (int i = 1; i <= pageNumber; i++)
                    {
                        cbPage.Items.Add(i + "");
                    }
                    cbPage.SelectedIndex = 0;
                    currentPageIndex = Convert.ToInt32(cbPage.Text);
                    pbCloseSearchStudent.Visible = true;
                    dgvStudent.DataSource = data.Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                }
               
            }
            else
            {
                var datas = bizStudent.findAllStudent();
                rows = datas.Count();
                pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lbTotalPage.Text = " / " + pageNumber.ToString();
                cbPage.Items.Clear();
                for (int i = 1; i <= pageNumber; i++)
                {
                    cbPage.Items.Add(i + "");
                }
                cbPage.Text = "1";
                currentPageIndex = Convert.ToInt32(cbPage.Text);
                cbPage.SelectedIndex = 0;
                dgvStudent.DataSource = datas.Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                pbCloseSearchStudent.Visible = false;
            }
            
        }
        private void dgvStudent_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvStudent.ClearSelection();
        }
            // Validate Student
        private void btnOpenFileStudent_Click(object sender, EventArgs e)
        {
            openFileStudent.Filter = "csv files (*.csv)|*.csv";
            openFileStudent.ShowDialog();
            var filename = Path.GetFileName(openFileStudent.FileName);
            tbFileStudent.Text = filename;
            if (tbFileStudent.Text != "")
            {
                btnImportStudent.Enabled = true;
            }
            else
            {
                btnImportStudent.Enabled = false;
            }
        }
        private bool validateImportStudent()
        {
            var check = true;
            var filename = Path.GetFileName(openFileStudent.FileName);
            var path = Path.GetDirectoryName(openFileStudent.FileName);
            var fullPath = path + "\\" + filename;
            var listId = bizStudent.listId();
            using (var db = new ProjectDbContext())
            {
                StreamReader streamCsv = new StreamReader(fullPath);

                string csvDataLine = "";
                string[] data = null;
                var lineHeader = streamCsv.ReadLine();
                int count = 0;
                while ((csvDataLine = streamCsv.ReadLine()) != null)
                {
                    data = csvDataLine.Split(',');
                    if (listId.Contains(data[0]))
                    {
                        count = 1;
                    }
                }
                if (count == 1)
                {
                    errorImportStudent.SetError(tbFileStudent, "File there is data StudentId already exists");
                    check = false;
                }
                else if (Path.GetExtension(tbFileStudent.Text) != ".csv")
                {
                    errorImportStudent.SetError(tbFileStudent, "Please select the file with the .csv extension");
                    check = false;
                }
                return check;
            }
        }
        private void btnImportStudent_Click(object sender, EventArgs e)
        {
            if (validateImportStudent())
            {
                errorImportStudent.Clear();
                var filename = Path.GetFileName(openFileStudent.FileName);
                var path = Path.GetDirectoryName(openFileStudent.FileName);
                var fullPath = path + "\\" + filename;
                bizStudent.importData(fullPath);
                tbFileStudent.Text = "";
                DataStudent();
                MessageBox.Show("Import successfully", "Message", MessageBoxButtons.OK);
                btnImportStudent.Enabled = false;
            }
        }  
        private bool validateStudentId()
        {
            var year = dtpSBirthDate.Value.Year.ToString().Substring(2, 2);
            var month = "";
            if (dtpSBirthDate.Value.Month < 10)
            {
                month += "0" + dtpSBirthDate.Value.Month;
            }
            else
            {
                month = dtpSBirthDate.Value.Month.ToString();
            }
            var listID = bizStudent.listId();
            var check = true;
            if (tbStudentId.Text == "")
            {
                errorStudentId.SetError(tbStudentId, "Please enter Student ID");
                lbErrorStudent.Text = "Please enter Student ID";
                check = false;
            }
            else if (new Regex("^[S]([0-1]{2})(" + year + month + ")([0-9]{4})$").IsMatch(tbStudentId.Text) == false)
            {
                errorStudentId.SetError(tbStudentId, "Student Id must start with the letter 'S' then 01 or 00 or 11 or 10 or 2 digits of the year and 2 digits of the month and 4 random digits");
                lbErrorStudent.Text = "Student Id must start with the letter 'S' then 01 or 00 or 11 or 10 or 2 digits of the year and 2 digits of the month and 4 random digits";
                check = false;
            }
            else if (listID.Contains(tbStudentId.Text))
            {
                errorStudentId.SetError(tbModuleId, "Student ID already exist please enter again");
                lbErrorStudent.Text = "Student ID already exist please enter again";
                check = false;
            }
            else
            {
                errorStudentId.Clear();
                lbErrorStudent.Text = "";

            }
            return check;
        }
        private bool validateStudent()
        {
            var check = true;
            if (tbSFirstName.Text == "")
            {
                errorFistNameStudent.SetError(tbSFirstName, "Please enter first name");
                lbErrorStudent.Text = "Please enter first name";
                check = false;
            }
            else if (tbSLastName.Text == "")
            {
                errorFistNameStudent.Clear();
                errorLastNameStudent.SetError(tbSLastName, "Please enter last name");
                lbErrorStudent.Text = "Please enter last name";
                check = false;
            }
            else if (tbSContact.Text == "")
            {
                errorLastNameStudent.Clear();
                errorContactStudent.SetError(tbSContact, "Please enter contact");
                lbErrorStudent.Text = "Please enter contact";
                check = false;
            }
            else
            {
                errorFistNameStudent.Clear();
                errorLastNameStudent.Clear();
                errorContactStudent.Clear();
                lbErrorStudent.Text = "";

            }
            return check;
        }
       
            // Paging and Sorting 
        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPageIndex = Convert.ToInt32(cbPage.Text);
            if(tbSearchStudent.Text == "")
            {
                if (countFistName == 0 && countLastName == 0)
                {
                    dgvStudent.DataSource = list_student.Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                }else if( column == 0)
                {
                    if (countStudentId % 2 == 0)
                    {
                        dgvStudent.DataSource = list_student.OrderByDescending(c => c.StudentId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = list_student.OrderBy(c => c.StudentId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                }
                else if (column == 1)
                {
                    if (countFistName % 2 == 0)
                    {
                        dgvStudent.DataSource = list_student.OrderByDescending(c => c.FirstName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = list_student.OrderBy(c => c.FirstName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                }
                else if (column == 2)
                {
                    if (countLastName % 2 == 0)
                    {
                        dgvStudent.DataSource = list_student.OrderByDescending(c => c.LastName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = list_student.OrderBy(c => c.LastName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }else if(column == 3)
                {
                    if (countContact % 2 == 0)
                    {
                        dgvStudent.DataSource = list_student.OrderByDescending(c => c.Contact).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = list_student.OrderBy(c => c.Contact).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }else if(column == 4)
                {
                    if (countBirthDate % 2 == 0)
                    {
                        dgvStudent.DataSource = list_student.OrderByDescending(c => c.BirthDate).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = list_student.OrderBy(c => c.BirthDate).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }else
                {
                    if (countStatus % 2 == 0)
                    {
                        dgvStudent.DataSource = list_student.OrderByDescending(c => c.StatusId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = list_student.OrderBy(c => c.StatusId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }
            }else
            {
                if (countFistName == 0 && countLastName == 0)
                {
                    dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                }
                else if (column == 0)
                {
                    if (countStudentId % 2 == 0)
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderByDescending(c => c.StudentId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderBy(c => c.StudentId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                }
                else if (column == 1)
                {
                    if (countFistName % 2 == 0)
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderByDescending(c => c.FirstName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderBy(c => c.FirstName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                }
                else if (column == 2)
                {
                    if (countLastName % 2 == 0)
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderByDescending(c => c.LastName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderBy(c => c.LastName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }
                else if (column == 3)
                {
                    if (countContact % 2 == 0)
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderByDescending(c => c.Contact).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderBy(c => c.Contact).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }
                else if (column == 4)
                {
                    if (countBirthDate % 2 == 0)
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderByDescending(c => c.BirthDate).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderBy(c => c.BirthDate).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }
                else
                {
                    if (countStatus % 2 == 0)
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderByDescending(c => c.StatusId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderBy(c => c.StatusId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }
            }
           
            
        }           
        private void dgvStudent_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ClearStudent();
            tbStudentId.Enabled = true;
            btnCreateStudent.Enabled = true;
            column = e.ColumnIndex;
            currentPageIndex = Convert.ToInt32(cbPage.Text);
            if(e.ColumnIndex == 0)
            {
                countStudentId++;
                if (tbSearchStudent.Text != "")
                {
                    if (countStudentId % 2 == 0)
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderByDescending(c => c.StudentId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderBy(c => c.StudentId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                }
                else
                {
                    if (countStudentId % 2 == 0)
                    {
                        dgvStudent.DataSource = list_student.OrderByDescending(c => c.StudentId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = list_student.OrderBy(c => c.StudentId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                }
            }
            else if (e.ColumnIndex == 1)
            {
                countFistName++;
                if (tbSearchStudent.Text != "")
                {
                    if (countFistName % 2 == 0)
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderByDescending(c => c.FirstName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderBy(c => c.FirstName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                }else
                {
                    if (countFistName % 2 == 0)
                    {
                        dgvStudent.DataSource = list_student.OrderByDescending(c => c.FirstName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = list_student.OrderBy(c => c.FirstName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                }               
                
                
            }else if(e.ColumnIndex == 2)
            {
                countLastName++;
                if(tbSearchStudent.Text != "")
                {
                    if (countLastName % 2 == 0)
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderByDescending(c => c.LastName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderBy(c => c.LastName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }else
                {
                    if (countLastName % 2 == 0)
                    {
                        dgvStudent.DataSource = list_student.OrderByDescending(c => c.LastName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = list_student.OrderBy(c => c.LastName).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }
                
            }else if(e.ColumnIndex == 3)
            {
                countContact++;
                if (tbSearchStudent.Text != "")
                {
                    if (countContact % 2 == 0)
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderByDescending(c => c.Contact).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderBy(c => c.Contact).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }
                else
                {
                    if (countContact % 2 == 0)
                    {
                        dgvStudent.DataSource = list_student.OrderByDescending(c => c.Contact).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = list_student.OrderBy(c => c.Contact).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }
            }else if(e.ColumnIndex == 4)
            {
                countBirthDate++;
                if (tbSearchStudent.Text != "")
                {
                    if (countBirthDate % 2 == 0)
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderByDescending(c => c.BirthDate).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderBy(c => c.BirthDate).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }
                else
                {
                    if (countBirthDate % 2 == 0)
                    {
                        dgvStudent.DataSource = list_student.OrderByDescending(c => c.BirthDate).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = list_student.OrderBy(c => c.BirthDate).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }
            }else
            {
                countStatus++;
                if (tbSearchStudent.Text != "")
                {
                    if (countStatus % 2 == 0)
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderByDescending(c => c.StatusId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = bizStudent.search(tbSearchStudent.Text).OrderBy(c => c.StatusId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }
                else
                {
                    if (countStatus % 2 == 0)
                    {
                        dgvStudent.DataSource = list_student.OrderByDescending(c => c.StatusId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        dgvStudent.DataSource = list_student.OrderBy(c => c.StatusId).Skip(currentPageIndex * pageSize - pageSize).Take(pageSize).ToList();

                    }
                }
            }
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (tabControl.SelectedIndex == 0)
            //{
            //    DisplayDataGirdView();
            //}
            //else if (tabControl.SelectedIndex == 1)
            //{
            //    DataStatus();
            //}
            //else if (tabControl.SelectedIndex == 2)
            //{
            //    DataModule();
            //}
            //else if (tabControl.SelectedIndex == 3)
            //{
            //    DataTeacher();
            //}
            //else if (tabControl.SelectedIndex == 4)
            //{
            //    DataStudent();
            //}
            //else if (tabControl.SelectedIndex == 5)
            //{
            //    DataClass();

            //}
            //else if (tabControl.SelectedIndex == 6)
            //{
            //    DataEnroll();

            //}
            //else
            //{
            //    DataEvaluate();

            //}

            //DisplayDataGirdView();
            //DataStatus();
            //DataModule();
            //DataTeacher();
            //DataStudent();
            //DataClass();
            //DataEnroll();
            //DataEvaluate();


            dgwClassType.ClearSelection();
            dgvStatus.ClearSelection();
            dgvModule.ClearSelection();
            dgvTeacher.ClearSelection();
            dgvStudent.ClearSelection();
            dgvClass.ClearSelection();
        }


        //////////////////////////////////////////////////////////////////////////// 
        // Class

            // Reuse method
        void ClearClass()
        {
            tbClassId.Text  = "";
            cbModuleClass.SelectedIndex  = cbTeacherClass.SelectedIndex = cbTypeClass.SelectedIndex = 0;
            cbStatusClass.SelectedIndex = 3;
            btnUpdateClass.Enabled = false;
            btnImportClass.Enabled = false;
            btnResetClass.Text = "Reset";
        }
        void DataClass()
        {
            dgvClass.AutoGenerateColumns = false;
            dgvClass.DataSource = bizClass.findAllClass().Select(m => new
            {
                ClassId = m.ClassId,
                TeachingHour = m.TeachingHour,
                ModuleId = bizModule.findById(m.ModuleId).ModuleName,
                StatusId = bizStatus.findById(m.StatusId).StatusName,
                TeacherId = bizTeacher.findById(m.TeacherId).FullName,
                m.TypeId                
            }).ToList();
        }
        void databindingsClass()
        {
            tbClassId.DataBindings.Clear();
            tbClassId.DataBindings.Add("Text", dgvClass.DataSource, "ClassId");


            cbModuleClass.DataBindings.Clear();
            //string moduleId = dgvClass.Rows[dgvClass.CurrentRow.Index].Cells["ModuleClass"].Value.ToString();
            //cbModuleClass.DataBindings.Add("Text", bizModule.findById(moduleId), "ModuleName");
            cbModuleClass.DataBindings.Add("Text", dgvClass.DataSource, "ModuleId");
            
            cbStatusClass.DataBindings.Clear();
            //string statusId = dgvClass.Rows[dgvClass.CurrentRow.Index].Cells["StatusClass"].Value.ToString();
            //cbStatusClass.DataBindings.Add("Text", bizStatus.findById(statusId), "Statusname");
            cbStatusClass.DataBindings.Add("Text", dgvClass.DataSource, "StatusId"); 

            cbTeacherClass.DataBindings.Clear();
            //string teacherId = dgvClass.Rows[dgvClass.CurrentRow.Index].Cells["TeacherClass"].Value.ToString();
            //cbTeacherClass.DataBindings.Add("Text", bizTeacher.findById(teacherId), "FullName");
            cbTeacherClass.DataBindings.Add("Text", dgvClass.DataSource, "TeacherId");

            cbTypeClass.DataBindings.Clear();
            cbTypeClass.DataBindings.Add("Text", dgvClass.DataSource, "TypeId");

            btnCreateClass.Enabled = false;
            btnUpdateClass.Enabled = true;
            tbClassId.Enabled = false;
        }
        // Form method
        string TypeCurrent = null;
        private void btnCreateClass_Click(object sender, EventArgs e)
        {
            var moduleName = cbModuleClass.Text;
            var moduleId = bizModule.findAllModule().Where(m => m.ModuleName == moduleName).FirstOrDefault().ModuleId;
                //classes.ClassId = tbClassId.Text.Trim();
                for(var i = 1; i < 30; i++)
                {
                    var classID =  classes.ClassId = "C" + DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString("00") + moduleId + "_"+i;
                    if (bizClass.listId().Contains(classID))
                    {
                        continue;
                    }else
                    {
                        break;
                    }
                }

                //classes.TeachingHour = Convert.ToInt32(tbTeachingHour.Text.Trim());
                classes.ModuleId = moduleId;
                classes.TypeId = cbTypeClass.Text;
                using (var db = new ProjectDbContext())
                {
                    var teacher = db.Teachers.Where(x => x.FirstName + " " + x.LastName == cbTeacherClass.Text.Trim()).FirstOrDefault();
                    if (teacher != null)
                    {
                        classes.TeacherId = teacher.TeacherId;
                    }
                    var status = db.Status.Where(x => x.StatusName == cbStatusClass.Text).FirstOrDefault();
                    if(status != null)
                    {
                        classes.StatusId = status.StatusId;
                    }

                }
                bizClass.createClass(DTOEFMapper.GetDtoFromEntity(classes));
                ClearClass();
                DataClass();
                MessageBox.Show("Create Successfully", "Message");
            
        }
        private void btnUpdateClass_Click(object sender, EventArgs e)
        {
            var moduleName = cbModuleClass.Text;
            var moduleId = bizModule.findAllModule().Where(m => m.ModuleName == moduleName).FirstOrDefault().ModuleId;
           
                classes.ClassId = tbClassId.Text.Trim();
                //classes.TeachingHour = Convert.ToInt32(tbTeachingHour.Text.Trim());
                classes.ModuleId = moduleId;
                classes.TypeId = cbTypeClass.Text;
                using (var db = new ProjectDbContext())
                {
                    var teacher = db.Teachers.Where(x => x.FirstName + " " + x.LastName == cbTeacherClass.Text.Trim()).FirstOrDefault();
                    if (teacher != null)
                    {
                        classes.TeacherId = teacher.TeacherId;
                    }
                    var status = db.Status.Where(x => x.StatusName == cbStatusClass.Text).FirstOrDefault();
                    if (status != null)
                    {
                        classes.StatusId = status.StatusId;
                    }
                }
                //student.StatusId = cbSStatusId.Text.Trim();
                bizClass.updateClass(DTOEFMapper.GetDtoFromEntity(classes));
                ClearClass();
                DataClass();
                tbClassId.Enabled = true;
                btnCreateClass.Enabled = true;
                MessageBox.Show("Update Successfully", "Message");
            

        }
        private void dgvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TypeCurrent = dgvClass.Rows[dgvClass.CurrentRow.Index].Cells["TypeClass"].Value.ToString();
            var moduleId = bizModule.findAllModule().Where(m => m.ModuleName == cbModuleClass.Text).FirstOrDefault().ModuleId;

            var teacher = bizClass.findAllClass().Where(m => m.ModuleId == moduleId && m.TypeId == cbTypeClass.Text).Select(m => m.TeacherId).ToList();
            var list_teacher = bizTeacher.findAllTeacher().Select(m => m.FullName).ToList();
            foreach (var item in teacher)
            {
                var teacherName = bizTeacher.findById(item).FullName;
                list_teacher = list_teacher.Where(m => m != teacherName).ToList();
            }
            cbTeacherClass.DataSource = list_teacher;



            var teacherId = bizCapable.findAllCapable().Where(m => m.ModuleId == moduleId).ToList();
            List<string> teacherModule = new List<string>();
            for (var i = 0; i < teacherId.Count; i++)
            {
                var teacherName = bizTeacher.findAllTeacher().Where(x => x.TeacherId == teacherId[i].TeacherId).FirstOrDefault().FullName;
                teacherModule.Add(teacherName.ToString());
            }
            cbTeacherClass.DataSource = teacherModule;
            dgvClass.Refresh();
            errorStudentId.Clear();
            errorDuration.Clear();
            lbErrorClass.Text = "";

            btnResetClass.Text = "Cancel";
            databindingsClass();

        }
        private void btnResetClass_Click(object sender, EventArgs e)
        {
            ClearClass();
            DataClass();
            tbClassId.Enabled = true;
            btnCreateClass.Enabled = true;
            lbErrorClass.Text = "";
            errorStudentId.Clear();
            errorDuration.Clear();
        }
        private void dgvClass_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvClass.ClearSelection();
        }
        private void tbSearchClass_TextChanged(object sender, EventArgs e)
        {
            if (tbSearchClass.Text != "")
            {
                pbCloseSearchClass.Visible = true;
            }
            else
            {
                pbCloseSearchClass.Visible = false;
            }
            dgvClass.DataSource = bizClass.search(tbSearchClass.Text).Select(m => new
            {
                ClassId = m.ClassId,
                TeachingHour = m.TeachingHour,
                ModuleId = bizModule.findById(m.ModuleId).ModuleName,
                StatusId = bizStatus.findById(m.StatusId).StatusName,
                TeacherId = bizTeacher.findById(m.TeacherId).FullName,
                m.TypeId
            }).ToList();
        }
        private void pbCloseSearchClass_Click(object sender, EventArgs e)
        {
            tbSearchClass.Text = "";
        }
            // Validate Class
        private bool validateClassId()
        {
            var year = DateTime.Now.Year.ToString().Substring(2, 2);
            var month = DateTime.Now.Month.ToString("00");            
            var listID = bizClass.listId();
            var check = true;
            if (tbClassId.Text == "")
            {
                errorStudentId.SetError(tbClassId, "Please enter Class ID");
                lbErrorClass.Text = "Please enter Class ID";
                check = false;
            }
            else if (new Regex("^[C](" + year + month + cbModuleClass.Text + "_" +")([0-9]{1})$").IsMatch(tbClassId.Text) == false)
            {
                errorStudentId.SetError(tbClassId, "The Class ID must begin with the letter 'C' followed by the last 2 digits of the 2nd year of the year of the code year of the character '_' and finally 1 random number");
                lbErrorClass.Text = "The Class ID must begin with the letter 'C' followed by the last 2 digits of the 2nd year of the year of the code year of the character '_' and finally 1 random number";
                check = false;
            }
            else if (listID.Contains(tbClassId.Text))
            {
                errorStudentId.SetError(tbClassId, "Class ID already exist please enter again");
                lbErrorClass.Text = "Class ID already exist please enter again";
                check = false;
            }
            else
            {
                errorStudentId.Clear();
                lbErrorClass.Text = "";

            }
            return check;
        }
        private void finbyTeacher()
        {
            var moduleId = bizModule.findAllModule().Where(m => m.ModuleName == cbModuleClass.Text).FirstOrDefault().ModuleId;

            var teacher = bizClass.findAllClass().Where(m => m.ModuleId == moduleId && m.TypeId == cbTypeClass.Text).Select(m => m.TeacherId).ToList();
            var list_teacher = bizTeacher.findAllTeacher().Select(m => m.FullName).ToList();

            foreach (var item in teacher)
            {
                var teacherName = bizTeacher.findById(item).FullName;
                list_teacher = list_teacher.Where(m => m != teacherName).ToList();
            }
            cbTeacherClass.DataSource = list_teacher;



            var teacherId = bizCapable.findAllCapable().Where(m => m.ModuleId == moduleId).ToList();
            List<string> teacherModule = new List<string>();
            for (var i = 0; i < teacherId.Count; i++)
            {
                var teacherName = bizTeacher.findAllTeacher().Where(x => x.TeacherId == teacherId[i].TeacherId).FirstOrDefault().FullName;
                teacherModule.Add(teacherName.ToString());
            }
            cbTeacherClass.DataSource = teacherModule;
        }
        private void cbModuleClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            var moduleId = bizModule.findAllModule().Where(m => m.ModuleName == cbModuleClass.Text).FirstOrDefault().ModuleId;

            var teacher = bizClass.findAllClass().Where(m => m.ModuleId == moduleId && m.TypeId == cbTypeClass.Text).Select(m => m.TeacherId).ToList();
            var list_teacher = bizTeacher.findAllTeacher().Select(m => m.FullName).ToList();
            foreach (var item in teacher)
            {
                var teacherName = bizTeacher.findById(item).FullName;
                list_teacher = list_teacher.Where(m => m != teacherName).ToList();
            }
            cbTeacherClass.DataSource = list_teacher;



            var teacherId = bizCapable.findAllCapable().Where(m => m.ModuleId == moduleId).ToList();
            List<string> teacherModule = new List<string>();
            for (var i = 0; i < teacherId.Count; i++)
            {
                var teacherName = bizTeacher.findAllTeacher().Where(x => x.TeacherId == teacherId[i].TeacherId).FirstOrDefault().FullName;
                teacherModule.Add(teacherName.ToString());
            }
            cbTeacherClass.DataSource = teacherModule;
        }
        private void cbTypeClass_SelectedIndexChanged(object sender, EventArgs e)
        {

            var moduleId = bizModule.findAllModule().Where(m => m.ModuleName == cbModuleClass.Text).FirstOrDefault().ModuleId;

            var teacher = bizClass.findAllClass().Where(m => m.ModuleId == moduleId && m.TypeId == cbTypeClass.Text).Select(m => m.TeacherId).ToList();
            var list_teacher = bizTeacher.findAllTeacher().Select(m => m.FullName).ToList();

            foreach (var item in teacher)
            {
                var teacherName = bizTeacher.findById(item).FullName;
                list_teacher = list_teacher.Where(m => m != teacherName).ToList();
            }
            cbTeacherClass.DataSource = list_teacher;



            var teacherId = bizCapable.findAllCapable().Where(m => m.ModuleId == moduleId).ToList();
            List<string> teacherModule = new List<string>();
            for (var i = 0; i < teacherId.Count; i++)
            {
                var teacherName = bizTeacher.findAllTeacher().Where(x => x.TeacherId == teacherId[i].TeacherId).FirstOrDefault().FullName;
                teacherModule.Add(teacherName.ToString());
            }
            cbTeacherClass.DataSource = teacherModule;

            foreach (var item in teacher)
            {
                var teacherName = bizTeacher.findById(item).FullName;
                teacherModule = teacherModule.Where(m => m != teacherName).ToList();
            }
            cbTeacherClass.DataSource = teacherModule;

            if (cbTypeClass.Text == TypeCurrent)
            {
                finbyTeacher();
            }
        }





        //////////////////////////////////////////////////////////////////////////// 
        // Enroll

        // Reuse method
        void ClearEnroll()
        {
            cbClassEnroll.SelectedIndex = 0;
            lbStudent.SelectedIndex = -1;
            //cbPassed.SelectedIndex = 0;
            //tbHw1.Text = tbHw2.Text = tbHw3.Text = tbHw4.Text = tbHw5.Text = tbExam.Text = "";
            btnUpdateEnroll.Enabled = false;
            btnDeleteEnroll.Enabled = false;
            btnResetEnroll.Text = "Reset";
            cbClassEnroll.Enabled = true;
            //cbStudentEnroll.Enabled = true;
        }
        void DataEnroll()
        {
            dgvEnroll.AutoGenerateColumns = false;
            dgvEnroll.DataSource = bizEnroll.findAllEnroll().Select(m => new
            {
                StudentId = bizStudent.findById(m.StudentId).FullName,
                ClassId = m.ClassId,
                Hw1Grade = m.Hw1Grade,
                Hw2Grade = m.Hw2Grade,
                Hw3Grade = m.Hw3Grade,
                Hw4Grade = m.Hw4Grade,
                Hw5Grade = m.Hw5Grade,
                Passed = m.Passed,
                ExamGrade = m.ExamGrade
            }).ToList();
        }
        void databindingsEnroll()
        {
            //string studentId = dgvEnroll.Rows[dgvEnroll.CurrentRow.Index].Cells["StudentEnroll"].Value.ToString();

            lbStudent.DataBindings.Clear();
            //lbStudent.DataBindings.Add("Text", bizStudent.findById(studentId), "FullName");
            lbStudent.DataBindings.Add("Text", dgvEnroll.DataSource, "StudentId");

            cbClassEnroll.DataBindings.Clear();
            cbClassEnroll.DataBindings.Add("Text", dgvEnroll.DataSource, "ClassId");


            btnCreateEnroll.Enabled = false;
            btnUpdateEnroll.Enabled = true;
            cbClassEnroll.Enabled = false;
            //lbStudent.Enabled = false;
        }

        // Form method
        
        private void btnCreateEnroll_Click(object sender, EventArgs e)
        {
            List<string> students = new List<string>();
            foreach (var student in lbStudent.SelectedItems)
            {
                students.Add(student.ToString());
            }
            if (validateEnrollId() && validateEnroll())
            {
                foreach (string student in students)
                {
                    var studentId = bizStudent.findAllStudent().Where(m => m.FullName == student).FirstOrDefault();
                    enroll.ClassId = cbClassEnroll.Text;
                    enroll.StudentId= studentId.StudentId;
                    enroll.Passed = 0;
                    bizEnroll.createEnroll(DTOEFMapper.GetDtoFromEntity(enroll));

                }
                //enroll.ClassId = cbClassEnroll.Text;              
                //using (var db = new ProjectDbContext())
                //{
                //    var student = db.Students.Where(x => x.FirstName + " " + x.LastName == lbStudent.Text.Trim()).FirstOrDefault();
                //    if (teacher != null)
                //    {
                //        enroll.StudentId = student.StudentId;
                //    }                   
                //}
                //bizEnroll.createEnroll(DTOEFMapper.GetDtoFromEntity(enroll));
                ClearEnroll();
                DataEnroll();
                MessageBox.Show("Create Successfully", "Message");
            }
        }
        private void btnUpdateEnroll_Click(object sender, EventArgs e)
        {
                enroll.ClassId = cbClassEnroll.Text;
               
                using (var db = new ProjectDbContext())
                {
                    var student = db.Students.Where(x => x.FirstName + " " + x.LastName == lbStudent.Text.Trim()).FirstOrDefault();
                    if (teacher != null)
                    {
                        enroll.StudentId = student.StudentId;
                    }
                }
                bizEnroll.updateEnroll(DTOEFMapper.GetDtoFromEntity(enroll));
                ClearEnroll();
                DataEnroll();
                //tbStudentId.Enabled = true;
                btnCreateEnroll.Enabled = true;
                MessageBox.Show("Update Successfully", "Message");
           
        }
        private void btnDeleteEnroll_Click(object sender, EventArgs e)
        {
            string enrollId = dgvEnroll.Rows[dgvEnroll.CurrentRow.Index].Cells["StudentEnroll"].Value.ToString() + dgvEnroll.Rows[dgvEnroll.CurrentRow.Index].Cells["ClassEnroll"].Value.ToString();

            if (MessageBox.Show("Are you sure to delete record?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bizEnroll.deleteEnroll(enrollId);
                ClearEnroll();
                DataEnroll();
                //tbStudentId.Enabled = true;
                btnCreateEnroll.Enabled = true;
                MessageBox.Show("Delete Successfully", "Message");
            }
            else
            {
                //ClearEnroll();
                //DataEnroll();
            }
            //tbStudentId.Enabled = true;
            //btnCreateStudent.Enabled = true;
        }
        private void dgvEnroll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            lbStudent.SelectedIndex = -1;
            errorEnroll.Clear();
            lbErrorEnroll.Text = "";
            btnDeleteEnroll.Enabled = true;
            //if (btnUpdateEnroll.Enabled == false)
            //{
            //    DialogResult mess = MessageBox.Show("The data you have entered will be lost. do you want to continue?", "Message", MessageBoxButtons.OKCancel);
            //    if (mess == DialogResult.OK)
            //    {
                    btnResetEnroll.Text = "Cancel";
                    databindingsEnroll();

            //    }
            //}
            //else
            //{
            //    btnResetEnroll.Text = "Cancel";
            //    databindingsEnroll();
            //}
        }
        private void btnResetEnroll_Click(object sender, EventArgs e)
        {
            btnCreateEnroll.Enabled = true;
            ClearEnroll();
            DataEnroll();
            lbErrorEnroll.Text = "";
            errorEnroll.Clear();
        }
        private void pbCloseSearchEnroll_Click(object sender, EventArgs e)
        {
            tbSearchEnroll.Text = "";
        }
        private void tbSearchEnroll_TextChanged(object sender, EventArgs e)
        {
            if (tbSearchEnroll.Text != "")
            {
                pbCloseSearchEnroll.Visible = true;
            }
            else
            {
                pbCloseSearchEnroll.Visible = false;
            }
            dgvEnroll.DataSource = bizEnroll.search(tbSearchEnroll.Text).Select(m => new
            {
                StudentId = bizStudent.findById(m.StudentId).FullName,
                ClassId = m.ClassId,
                Hw1Grade = m.Hw1Grade,
                Hw2Grade = m.Hw2Grade,
                Hw3Grade = m.Hw3Grade,
                Hw4Grade = m.Hw4Grade,
                Hw5Grade = m.Hw5Grade,
                Passed = m.Passed,
                ExamGrade = m.ExamGrade
            }).ToList();
        }
        private void dgvEnroll_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvEnroll.ClearSelection();
        }
        // Validate Enroll
        // ^([1-9]{1,9}[05]+)|5$
        private bool validateEnrollId()
        {
            string studentId = ""; 
            using (var db = new ProjectDbContext())
            {
                var student = db.Students.Where(x => x.FirstName + " " + x.LastName == lbStudent.Text.Trim()).FirstOrDefault();
                if (teacher != null)
                {
                    studentId = student.StudentId;
                }
            }
            string enrollId = studentId + cbClassEnroll.Text; 
            var listID = bizEnroll.listId();
            var check = true;
            if (listID.Contains(enrollId))
            {
                errorEnroll.SetError(lbStudent, "This student is already in class");
                lbErrorEnroll.Text = "This student is already in class";
                check = false;
            }
            else
            {
                errorEnroll.Clear();
                lbErrorEnroll.Text = "";

            }
            return check;
        }
        private bool validateEnroll()
        {
            var check = true;
            if (bizEnroll.findAllEnroll().Where(m => m.ClassId == cbClassEnroll.Text).ToList().Count >= 24)
            {
                errorEnroll.SetError(lbStudent, "Class enough. Please choose another class");
                lbErrorEnroll.Text = "Class enough. Please choose another class";
                check = false;
            }
            else
            {
                errorEnroll.Clear();
                lbErrorEnroll.Text = "";

            }
            return check;
        }
        private void cbClassEnroll_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbStudent.SelectedIndex = -1;
            var studentsId = bizEnroll.findAllEnroll().Select(m => m.StudentId).ToList();
            var list_student = bizStudent.findAllStudent().Select(m => m.FullName).ToList();

            foreach(var student in studentsId)
            {
                var FullNameStudent = bizStudent.findById(student).FullName;
                list_student = list_student.Where(m => m != FullNameStudent).ToList();
            }

            var studentNotPass = bizEnroll.findAllEnroll().Where(m => m.Passed == 0).Select(m => m.StudentId).ToList();
            foreach(var item in studentNotPass)
            {
                var FullNameStudent = bizStudent.findById(item).FullName;
                list_student.Add(FullNameStudent);
            }
            lbStudent.DataSource = list_student;
        }



        //////////////////////////////////////////////////////////////////////////////
        // Evaluate

        void ClearEvalueate()
        {
           
            tbUnderstand.Text = tbSupport.Text = tbTeaching.Text = tbPunctuality.Text = "";
            cbClassEvaluate.SelectedIndex = 0;
            cbStudentEvaluate.SelectedIndex = 0;
            btnUpdateEvaluate.Enabled = false;
            btnResetEvaluate.Text = "Reset";
            btnCreateEvaluate.Enabled = true;
            cbClassEvaluate.Enabled = true;
            cbStudentEvaluate.Enabled = true;
            DataEvaluate();
        }
        void DataEvaluate()
        {
            dgvEvaluate.AutoGenerateColumns = false;
            dgvEvaluate.DataSource = bizEvalua.findAllEvaluate().Select(m => new
            {
                StudentId = bizStudent.findById(m.StudentId).FullName,
                ClassId = m.ClassId,
                Understand = m.Understand,
                Punctuality = m.Punctuality,
                Support = m.Support,
                Teaching = m.Teaching
            }).ToList();
        }
        void bindingsEvaluate()
        {

            string studentId = dgvEvaluate.Rows[dgvEvaluate.CurrentRow.Index].Cells["StudentEvalua"].Value.ToString();

            cbClassEvaluate.DataBindings.Clear();
            cbClassEvaluate.DataBindings.Add("Text", dgvEvaluate.DataSource, "ClassId", true, DataSourceUpdateMode.OnPropertyChanged);

            cbStudentEvaluate.DataBindings.Clear();
            cbStudentEvaluate.DataBindings.Add("Text", dgvEvaluate.DataSource, "StudentId", true, DataSourceUpdateMode.OnPropertyChanged);

            tbUnderstand.DataBindings.Clear();
            tbUnderstand.DataBindings.Add("Text", dgvEvaluate.DataSource, "Understand", true, DataSourceUpdateMode.OnPropertyChanged);

            tbPunctuality.DataBindings.Clear();
            tbPunctuality.DataBindings.Add("Text", dgvEvaluate.DataSource, "Punctuality", true, DataSourceUpdateMode.OnPropertyChanged);

            tbSupport.DataBindings.Clear();
            tbSupport.DataBindings.Add("Text", dgvEvaluate.DataSource, "Support", true, DataSourceUpdateMode.OnPropertyChanged);

            tbTeaching.DataBindings.Clear();
            tbTeaching.DataBindings.Add("Text", dgvEvaluate.DataSource, "Teaching", true, DataSourceUpdateMode.OnPropertyChanged);
            btnCreateEvaluate.Enabled = false;
            btnUpdateEvaluate.Enabled = true;
            btnResetEvaluate.Text = "Cancel";
            cbClassEvaluate.Enabled = false;
            cbStudentEvaluate.Enabled = false;
        }
        private void cbClassEvaluate_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> student = new List<string>();
            var list_studentId = bizEnroll.findAllEnroll().Where(m => m.ClassId == cbClassEvaluate.Text).Select(m => m.StudentId).ToList();
            foreach(var item in list_studentId)
            {
                student.Add(bizStudent.findById(item).FullName);
            }
            cbStudentEvaluate.DataSource = student;
        }
        private void btnCreateEvaluate_Click(object sender, EventArgs e)
        {
            if (validateEvaluate())
            {
                string studentId = bizStudent.findAllStudent().Where(m => m.FullName == cbStudentEvaluate.Text).FirstOrDefault().StudentId;
                evaluate.StudentId = studentId;
                evaluate.ClassId = cbClassEvaluate.Text;
                evaluate.Understand = tbUnderstand.Text.Trim();
                evaluate.Punctuality = tbPunctuality.Text.Trim();
                evaluate.Support = tbSupport.Text.Trim();
                evaluate.Teaching = tbTeaching.Text.Trim();
                bizEvalua.createEvaluate(DTOEFMapper.GetDtoFromEntity(evaluate));
                ClearEvalueate();
                DataEvaluate();
                MessageBox.Show("Create Successfully", "Message");
            }       
            
        }
        private void dgvEvaluate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bindingsEvaluate();
        }
        private void btnResetEvaluate_Click(object sender, EventArgs e)
        {
            lbErrorEvaluate.Text = "";
            ClearEvalueate();
        }
        private void btnUpdateEvaluate_Click(object sender, EventArgs e)
        {

            string studentId = bizStudent.findAllStudent().Where(m => m.FullName == cbStudentEvaluate.Text).FirstOrDefault().StudentId;
            evaluate.StudentId = studentId;
            evaluate.ClassId = cbClassEvaluate.Text;
            evaluate.Understand = tbUnderstand.Text.Trim();
            evaluate.Punctuality = tbPunctuality.Text.Trim();
            evaluate.Support = tbSupport.Text.Trim();
            evaluate.Teaching = tbTeaching.Text.Trim();
            bizEvalua.updateEvaluate(DTOEFMapper.GetDtoFromEntity(evaluate));
            ClearEvalueate();
            DataEvaluate();
            MessageBox.Show("Update Successfully", "Message");

        }
        private void dgvEvaluate_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvEvaluate.ClearSelection();
        }
        private bool validateEvaluate()
        {
            string studentId = bizStudent.findAllStudent().Where(m => m.FullName == cbStudentEvaluate.Text).FirstOrDefault().StudentId;
            var check = true;
            if (bizEvalua.findById(studentId+cbClassEvaluate.Text) != null)
            {               
                lbErrorEvaluate.Text = "Students had an evaluate in this class";
                check = false;
            }
            else
            {               
                lbErrorEnroll.Text = "";
            }
            return check;
        }

        private void cbModuleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chart 1
            chart1.ChartAreas[0].AxisX.Title = "Class";
            chart1.ChartAreas[0].AxisY.Title = "Passed Percent";
            chart1.Series["Percent"].XValueMember = "ClassId";
            chart1.Series["Percent"].YValueMembers = "Passed";
            chart1.DataSource = bizClass.findAllClass().Join(bizEnroll.findAllEnroll(), clas => clas.ClassId, enrol => enrol.ClassId, (clas, enrol) => new
            {
                ClassId = clas.ClassId,
                Passed = enrol.Passed,
                ModuleId = clas.ModuleId
            }).Where(m => bizModule.findById(m.ModuleId).ModuleName == cbModuleName.Text).GroupBy(m => m.ClassId).Select(g => new
            {
                ClassId = g.Key,
                Passed = g.Count(m => m.Passed == 1) * 1.0 / (g.Count() * 1.0) * 100.0
                //Passed = g.Average(m => m.Passed) * 100
            }).ToList();
            chart1.DataBind();
            // Chart 2
            chart2.Series["AvgExam"].XValueMember = "ClassId";
            chart2.Series["AvgExam"].YValueMembers = "ExamGrade";
            chart2.DataSource = bizClass.findAllClass().Join(bizEnroll.findAllEnroll(), clas => clas.ClassId, enrol => enrol.ClassId, (clas, enrol) => new
            {
                ClassId = clas.ClassId,
                ExamGrade = Convert.ToString(enrol.ExamGrade.Split('%')[0]),
                ModuleId = clas.ModuleId
            }).Where(m => bizModule.findById(m.ModuleId).ModuleName == cbModuleName.Text).GroupBy(m => m.ClassId).Select(g => new
            {
                ClassId = g.Key,
                ExamGrade = g.Average(m => Convert.ToInt32(m.ExamGrade))
            }).ToList();
            chart2.DataBind();
            // Chart 3           
            chart3.Series["Student"].XValueMember = "ClassId";
            chart3.Series["Student"].YValueMembers = "StudentId";
            chart3.DataSource = bizClass.findAllClass().Join(bizEnroll.findAllEnroll(), clas => clas.ClassId, enrol => enrol.ClassId, (clas, enrol) => new
            {
                ClassId = clas.ClassId,
                StudentId = enrol.StudentId,
                ModuleId = clas.ModuleId
            }).Where(m => bizModule.findById(m.ModuleId).ModuleName == cbModuleName.Text).GroupBy(m => m.ClassId).Select(g => new
            {
                ClassId = g.Key,
                StudentId = g.Count()
            }).ToList();
            chart3.DataBind();

            
        }

    }
}
