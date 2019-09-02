namespace Project
{
    partial class StudentApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentApp));
            this.errorProviderStudent = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lbErrorStudent = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSubmitEvaluate = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tbTeaching = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tbSupport = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbPunctuality = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbUnderstand = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbClassEvalua = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.tbContact = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnChangeProfile = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvStudyRecords = new System.Windows.Forms.DataGridView();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Module = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hw1Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hw2Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hw3Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hw4Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hw5Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderStudent)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTeaching)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSupport)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPunctuality)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbUnderstand)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudyRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProviderStudent
            // 
            this.errorProviderStudent.ContainerControl = this;
            this.errorProviderStudent.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProviderStudent.Icon")));
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 456);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.lbTitle);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(793, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Register";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.lbErrorStudent);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(17, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 386);
            this.panel1.TabIndex = 14;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(136, 136);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(482, 43);
            this.btnSubmit.TabIndex = 15;
            this.btnSubmit.Text = "Register";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lbErrorStudent
            // 
            this.lbErrorStudent.AutoSize = true;
            this.lbErrorStudent.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorStudent.ForeColor = System.Drawing.Color.Red;
            this.lbErrorStudent.Location = new System.Drawing.Point(47, 10);
            this.lbErrorStudent.Name = "lbErrorStudent";
            this.lbErrorStudent.Size = new System.Drawing.Size(35, 16);
            this.lbErrorStudent.TabIndex = 13;
            this.lbErrorStudent.Text = "labe";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.cbClass);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(17, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(728, 71);
            this.panel3.TabIndex = 1;
            // 
            // cbClass
            // 
            this.cbClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(77, 10);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(613, 21);
            this.cbClass.TabIndex = 3;
            this.cbClass.SelectedIndexChanged += new System.EventHandler(this.cbClass_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Class";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTitle.Location = new System.Drawing.Point(258, 10);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(160, 25);
            this.lbTitle.TabIndex = 13;
            this.lbTitle.Text = "Form Register";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSubmitEvaluate);
            this.tabPage2.Controls.Add(this.panel10);
            this.tabPage2.Controls.Add(this.panel9);
            this.tabPage2.Controls.Add(this.panel8);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.cbClassEvalua);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(793, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Evaluate";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSubmitEvaluate
            // 
            this.btnSubmitEvaluate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitEvaluate.Location = new System.Drawing.Point(223, 335);
            this.btnSubmitEvaluate.Name = "btnSubmitEvaluate";
            this.btnSubmitEvaluate.Size = new System.Drawing.Size(263, 47);
            this.btnSubmitEvaluate.TabIndex = 6;
            this.btnSubmitEvaluate.Text = "Submit";
            this.btnSubmitEvaluate.UseVisualStyleBackColor = true;
            this.btnSubmitEvaluate.Click += new System.EventHandler(this.btnSubmitEvaluate_Click);
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.Controls.Add(this.tbTeaching);
            this.panel10.Controls.Add(this.label10);
            this.panel10.Location = new System.Drawing.Point(116, 269);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(459, 51);
            this.panel10.TabIndex = 5;
            // 
            // tbTeaching
            // 
            this.tbTeaching.Location = new System.Drawing.Point(139, 23);
            this.tbTeaching.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tbTeaching.Name = "tbTeaching";
            this.tbTeaching.Size = new System.Drawing.Size(231, 20);
            this.tbTeaching.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Teaching";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.tbSupport);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Location = new System.Drawing.Point(116, 182);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(459, 49);
            this.panel9.TabIndex = 4;
            // 
            // tbSupport
            // 
            this.tbSupport.Location = new System.Drawing.Point(139, 23);
            this.tbSupport.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tbSupport.Name = "tbSupport";
            this.tbSupport.Size = new System.Drawing.Size(231, 20);
            this.tbSupport.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Support";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.tbPunctuality);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(116, 107);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(459, 48);
            this.panel8.TabIndex = 3;
            // 
            // tbPunctuality
            // 
            this.tbPunctuality.Location = new System.Drawing.Point(139, 20);
            this.tbPunctuality.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tbPunctuality.Name = "tbPunctuality";
            this.tbPunctuality.Size = new System.Drawing.Size(231, 20);
            this.tbPunctuality.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Punctuality";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.tbUnderstand);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(116, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 46);
            this.panel2.TabIndex = 2;
            // 
            // tbUnderstand
            // 
            this.tbUnderstand.Location = new System.Drawing.Point(139, 23);
            this.tbUnderstand.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tbUnderstand.Name = "tbUnderstand";
            this.tbUnderstand.Size = new System.Drawing.Size(231, 20);
            this.tbUnderstand.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Understand";
            // 
            // cbClassEvalua
            // 
            this.cbClassEvalua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassEvalua.FormattingEnabled = true;
            this.cbClassEvalua.Location = new System.Drawing.Point(191, 14);
            this.cbClassEvalua.Name = "cbClassEvalua";
            this.cbClassEvalua.Size = new System.Drawing.Size(121, 21);
            this.cbClassEvalua.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbLastName);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.dtpBirthDate);
            this.tabPage3.Controls.Add(this.tbContact);
            this.tabPage3.Controls.Add(this.tbFirstName);
            this.tabPage3.Controls.Add(this.btnLogout);
            this.tabPage3.Controls.Add(this.btnChangeProfile);
            this.tabPage3.Controls.Add(this.btnChangePass);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.dgvStudyRecords);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(793, 430);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Study Records";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Enabled = false;
            this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(138, 91);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(156, 22);
            this.dtpBirthDate.TabIndex = 7;
            // 
            // tbContact
            // 
            this.tbContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContact.Location = new System.Drawing.Point(138, 128);
            this.tbContact.Name = "tbContact";
            this.tbContact.ReadOnly = true;
            this.tbContact.Size = new System.Drawing.Size(156, 22);
            this.tbContact.TabIndex = 8;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFirstName.Location = new System.Drawing.Point(138, 22);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.ReadOnly = true;
            this.tbFirstName.Size = new System.Drawing.Size(156, 22);
            this.tbFirstName.TabIndex = 5;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(642, 59);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(129, 38);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangeProfile
            // 
            this.btnChangeProfile.Location = new System.Drawing.Point(488, 106);
            this.btnChangeProfile.Name = "btnChangeProfile";
            this.btnChangeProfile.Size = new System.Drawing.Size(129, 38);
            this.btnChangeProfile.TabIndex = 10;
            this.btnChangeProfile.Text = "Change Profile";
            this.btnChangeProfile.UseVisualStyleBackColor = true;
            this.btnChangeProfile.Click += new System.EventHandler(this.btnChangeProfile_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Location = new System.Drawing.Point(488, 11);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(129, 38);
            this.btnChangePass.TabIndex = 9;
            this.btnChangePass.Text = "Change Password";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(39, 128);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 16);
            this.label17.TabIndex = 1;
            this.label17.Text = "Contact";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(39, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 16);
            this.label15.TabIndex = 1;
            this.label15.Text = "Birth Date";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(39, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "First Name";
            // 
            // dgvStudyRecords
            // 
            this.dgvStudyRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudyRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudyRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudyRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Class,
            this.Module,
            this.Teacher,
            this.Hw1Grade,
            this.Hw2Grade,
            this.Hw3Grade,
            this.Hw4Grade,
            this.Hw5Grade,
            this.ExamGrade,
            this.Passed});
            this.dgvStudyRecords.Location = new System.Drawing.Point(3, 163);
            this.dgvStudyRecords.Name = "dgvStudyRecords";
            this.dgvStudyRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudyRecords.Size = new System.Drawing.Size(781, 261);
            this.dgvStudyRecords.TabIndex = 12;
            // 
            // Class
            // 
            this.Class.DataPropertyName = "ClassId";
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            // 
            // Module
            // 
            this.Module.DataPropertyName = "ModuleId";
            this.Module.HeaderText = "Module";
            this.Module.Name = "Module";
            // 
            // Teacher
            // 
            this.Teacher.DataPropertyName = "TeacherId";
            this.Teacher.HeaderText = "Teacher";
            this.Teacher.Name = "Teacher";
            // 
            // Hw1Grade
            // 
            this.Hw1Grade.DataPropertyName = "Hw1Grade";
            this.Hw1Grade.HeaderText = "Hw1Grade";
            this.Hw1Grade.Name = "Hw1Grade";
            // 
            // Hw2Grade
            // 
            this.Hw2Grade.DataPropertyName = "Hw2Grade";
            this.Hw2Grade.HeaderText = "Hw2Grade";
            this.Hw2Grade.Name = "Hw2Grade";
            // 
            // Hw3Grade
            // 
            this.Hw3Grade.DataPropertyName = "Hw3Grade";
            this.Hw3Grade.HeaderText = "Hw3Grade";
            this.Hw3Grade.Name = "Hw3Grade";
            // 
            // Hw4Grade
            // 
            this.Hw4Grade.DataPropertyName = "Hw4Grade";
            this.Hw4Grade.HeaderText = "Hw4Grade";
            this.Hw4Grade.Name = "Hw4Grade";
            // 
            // Hw5Grade
            // 
            this.Hw5Grade.DataPropertyName = "Hw5Grade";
            this.Hw5Grade.HeaderText = "Hw5Grade";
            this.Hw5Grade.Name = "Hw5Grade";
            // 
            // ExamGrade
            // 
            this.ExamGrade.DataPropertyName = "ExamGrade";
            this.ExamGrade.HeaderText = "ExamGrade";
            this.ExamGrade.Name = "ExamGrade";
            // 
            // Passed
            // 
            this.Passed.DataPropertyName = "Passed";
            this.Passed.HeaderText = "Passed";
            this.Passed.Name = "Passed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Last Name";
            // 
            // tbLastName
            // 
            this.tbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastName.Location = new System.Drawing.Point(138, 57);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.ReadOnly = true;
            this.tbLastName.Size = new System.Drawing.Size(156, 22);
            this.tbLastName.TabIndex = 6;
            // 
            // StudentApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 473);
            this.Controls.Add(this.tabControl1);
            this.Name = "StudentApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterStudent_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentApp_FormClosed);
            this.Load += new System.EventHandler(this.RegisterStudent_Load);
            this.SizeChanged += new System.EventHandler(this.RegisterStudent_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderStudent)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTeaching)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSupport)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPunctuality)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbUnderstand)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudyRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProviderStudent;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbClassEvalua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmitEvaluate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lbErrorStudent;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvStudyRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn Module;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hw1Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hw2Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hw3Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hw4Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hw5Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passed;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown tbTeaching;
        private System.Windows.Forms.NumericUpDown tbSupport;
        private System.Windows.Forms.NumericUpDown tbPunctuality;
        private System.Windows.Forms.NumericUpDown tbUnderstand;
        private System.Windows.Forms.Button btnChangeProfile;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.TextBox tbContact;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label label3;
    }
}