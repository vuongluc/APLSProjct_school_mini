namespace Project
{
    partial class TeacherApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherApp));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbErrorTeachingHour = new System.Windows.Forms.Label();
            this.btnCancelEditTeachingHour = new System.Windows.Forms.Button();
            this.btnUpdateTeachingHour = new System.Windows.Forms.Button();
            this.dgvClass = new System.Windows.Forms.DataGridView();
            this.ClassId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeachingHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.lbError = new System.Windows.Forms.Label();
            this.btnSaveGrade = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbCloseSearchStudent = new System.Windows.Forms.PictureBox();
            this.tbSearchStudent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbClassGrade = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvGrade = new System.Windows.Forms.DataGridView();
            this.StudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hw1Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hw2Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hw3Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hw4Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hw5Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvEvaluate = new System.Windows.Forms.DataGridView();
            this.CLassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Understand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Punctuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Support = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teaching = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbEvalua = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseSearchStudent)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrade)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(818, 483);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbErrorTeachingHour);
            this.tabPage1.Controls.Add(this.btnCancelEditTeachingHour);
            this.tabPage1.Controls.Add(this.btnUpdateTeachingHour);
            this.tabPage1.Controls.Add(this.dgvClass);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(810, 457);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Update Teachinghour";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbErrorTeachingHour
            // 
            this.lbErrorTeachingHour.AutoSize = true;
            this.lbErrorTeachingHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorTeachingHour.ForeColor = System.Drawing.Color.Red;
            this.lbErrorTeachingHour.Location = new System.Drawing.Point(28, 15);
            this.lbErrorTeachingHour.Name = "lbErrorTeachingHour";
            this.lbErrorTeachingHour.Size = new System.Drawing.Size(0, 18);
            this.lbErrorTeachingHour.TabIndex = 3;
            // 
            // btnCancelEditTeachingHour
            // 
            this.btnCancelEditTeachingHour.Location = new System.Drawing.Point(122, 120);
            this.btnCancelEditTeachingHour.Name = "btnCancelEditTeachingHour";
            this.btnCancelEditTeachingHour.Size = new System.Drawing.Size(75, 23);
            this.btnCancelEditTeachingHour.TabIndex = 2;
            this.btnCancelEditTeachingHour.Text = "Refresh";
            this.btnCancelEditTeachingHour.UseVisualStyleBackColor = true;
            this.btnCancelEditTeachingHour.Click += new System.EventHandler(this.btnCancelEditTeachingHour_Click);
            // 
            // btnUpdateTeachingHour
            // 
            this.btnUpdateTeachingHour.Location = new System.Drawing.Point(19, 120);
            this.btnUpdateTeachingHour.Name = "btnUpdateTeachingHour";
            this.btnUpdateTeachingHour.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateTeachingHour.TabIndex = 2;
            this.btnUpdateTeachingHour.Text = "Save";
            this.btnUpdateTeachingHour.UseVisualStyleBackColor = true;
            this.btnUpdateTeachingHour.Click += new System.EventHandler(this.btnUpdateTeachingHour_Click);
            // 
            // dgvClass
            // 
            this.dgvClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClassId,
            this.TeachingHour,
            this.ModuleId,
            this.StatusId,
            this.TeacherId,
            this.TypeId});
            this.dgvClass.Location = new System.Drawing.Point(6, 180);
            this.dgvClass.Name = "dgvClass";
            this.dgvClass.Size = new System.Drawing.Size(798, 271);
            this.dgvClass.TabIndex = 0;
            this.dgvClass.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClass_CellEndEdit);
            this.dgvClass.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClass_ColumnHeaderMouseClick);
            this.dgvClass.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvClass_DataBindingComplete);
            this.dgvClass.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvClass_DataError);
            this.dgvClass.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvClass_EditingControlShowing);
            this.dgvClass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvClass_KeyPress);
            // 
            // ClassId
            // 
            this.ClassId.DataPropertyName = "ClassId";
            this.ClassId.HeaderText = "Class ID";
            this.ClassId.Name = "ClassId";
            // 
            // TeachingHour
            // 
            this.TeachingHour.DataPropertyName = "TeachingHour";
            this.TeachingHour.HeaderText = "Teaching Hour";
            this.TeachingHour.Name = "TeachingHour";
            // 
            // ModuleId
            // 
            this.ModuleId.DataPropertyName = "ModuleId";
            this.ModuleId.HeaderText = "Module";
            this.ModuleId.Name = "ModuleId";
            // 
            // StatusId
            // 
            this.StatusId.DataPropertyName = "StatusId";
            this.StatusId.HeaderText = "Status";
            this.StatusId.Name = "StatusId";
            // 
            // TeacherId
            // 
            this.TeacherId.DataPropertyName = "TeacherId";
            this.TeacherId.HeaderText = "Teacher";
            this.TeacherId.Name = "TeacherId";
            // 
            // TypeId
            // 
            this.TypeId.DataPropertyName = "TypeId";
            this.TypeId.HeaderText = "Type";
            this.TypeId.Name = "TypeId";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCancelEdit);
            this.tabPage2.Controls.Add(this.lbError);
            this.tabPage2.Controls.Add(this.btnSaveGrade);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.dgvGrade);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(810, 457);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Grade";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Location = new System.Drawing.Point(137, 111);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(75, 23);
            this.btnCancelEdit.TabIndex = 17;
            this.btnCancelEdit.Text = "Refresh";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // lbError
            // 
            this.lbError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbError.AutoSize = true;
            this.lbError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(278, 18);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 16);
            this.lbError.TabIndex = 16;
            // 
            // btnSaveGrade
            // 
            this.btnSaveGrade.Location = new System.Drawing.Point(30, 111);
            this.btnSaveGrade.Name = "btnSaveGrade";
            this.btnSaveGrade.Size = new System.Drawing.Size(75, 23);
            this.btnSaveGrade.TabIndex = 15;
            this.btnSaveGrade.Text = "Save";
            this.btnSaveGrade.UseVisualStyleBackColor = true;
            this.btnSaveGrade.Click += new System.EventHandler(this.btnSaveGrade_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pbCloseSearchStudent);
            this.panel3.Controls.Add(this.tbSearchStudent);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(23, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 31);
            this.panel3.TabIndex = 2;
            // 
            // pbCloseSearchStudent
            // 
            this.pbCloseSearchStudent.BackColor = System.Drawing.Color.Transparent;
            this.pbCloseSearchStudent.ErrorImage = null;
            this.pbCloseSearchStudent.Image = global::Project.Properties.Resources.close1;
            this.pbCloseSearchStudent.Location = new System.Drawing.Point(174, 11);
            this.pbCloseSearchStudent.Margin = new System.Windows.Forms.Padding(5);
            this.pbCloseSearchStudent.Name = "pbCloseSearchStudent";
            this.pbCloseSearchStudent.Size = new System.Drawing.Size(15, 10);
            this.pbCloseSearchStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCloseSearchStudent.TabIndex = 63;
            this.pbCloseSearchStudent.TabStop = false;
            this.pbCloseSearchStudent.Visible = false;
            this.pbCloseSearchStudent.Click += new System.EventHandler(this.pbCloseSearchStudent_Click);
            // 
            // tbSearchStudent
            // 
            this.tbSearchStudent.Location = new System.Drawing.Point(76, 6);
            this.tbSearchStudent.Name = "tbSearchStudent";
            this.tbSearchStudent.Size = new System.Drawing.Size(121, 20);
            this.tbSearchStudent.TabIndex = 1;
            this.tbSearchStudent.TextChanged += new System.EventHandler(this.tbSearchStudent_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Filter Student";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbClassGrade);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(23, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 30);
            this.panel2.TabIndex = 1;
            // 
            // cbClassGrade
            // 
            this.cbClassGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassGrade.FormattingEnabled = true;
            this.cbClassGrade.Location = new System.Drawing.Point(76, 6);
            this.cbClassGrade.Name = "cbClassGrade";
            this.cbClassGrade.Size = new System.Drawing.Size(121, 21);
            this.cbClassGrade.TabIndex = 1;
            this.cbClassGrade.SelectedIndexChanged += new System.EventHandler(this.cbClassGrade_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Filter Class";
            // 
            // dgvGrade
            // 
            this.dgvGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentId,
            this.Class,
            this.Hw1Grade,
            this.Hw2Grade,
            this.Hw3Grade,
            this.Hw4Grade,
            this.Hw5Grade,
            this.Passed,
            this.ExamGrade});
            this.dgvGrade.Location = new System.Drawing.Point(6, 160);
            this.dgvGrade.Name = "dgvGrade";
            this.dgvGrade.Size = new System.Drawing.Size(798, 291);
            this.dgvGrade.TabIndex = 0;
            this.dgvGrade.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrade_CellEndEdit);
            this.dgvGrade.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGrade_ColumnHeaderMouseClick);
            this.dgvGrade.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvGrade_DataError);
            this.dgvGrade.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvGrade_EditingControlShowing);
            this.dgvGrade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvGrade_KeyPress);
            // 
            // StudentId
            // 
            this.StudentId.DataPropertyName = "StudentId";
            this.StudentId.FillWeight = 95F;
            this.StudentId.HeaderText = "Student";
            this.StudentId.Name = "StudentId";
            // 
            // Class
            // 
            this.Class.DataPropertyName = "ClassId";
            this.Class.FillWeight = 95F;
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            // 
            // Hw1Grade
            // 
            this.Hw1Grade.DataPropertyName = "Hw1Grade";
            this.Hw1Grade.FillWeight = 60.34969F;
            this.Hw1Grade.HeaderText = "Hw1Grade";
            this.Hw1Grade.Name = "Hw1Grade";
            // 
            // Hw2Grade
            // 
            this.Hw2Grade.DataPropertyName = "Hw2Grade";
            this.Hw2Grade.FillWeight = 60.34969F;
            this.Hw2Grade.HeaderText = "Hw2Grade";
            this.Hw2Grade.Name = "Hw2Grade";
            // 
            // Hw3Grade
            // 
            this.Hw3Grade.DataPropertyName = "Hw3Grade";
            this.Hw3Grade.FillWeight = 60.34969F;
            this.Hw3Grade.HeaderText = "Hw3Grade";
            this.Hw3Grade.Name = "Hw3Grade";
            // 
            // Hw4Grade
            // 
            this.Hw4Grade.DataPropertyName = "Hw4Grade";
            this.Hw4Grade.FillWeight = 60.34969F;
            this.Hw4Grade.HeaderText = "Hw4Grade";
            this.Hw4Grade.Name = "Hw4Grade";
            // 
            // Hw5Grade
            // 
            this.Hw5Grade.DataPropertyName = "Hw5Grade";
            this.Hw5Grade.FillWeight = 60.34969F;
            this.Hw5Grade.HeaderText = "Hw5Grade";
            this.Hw5Grade.Name = "Hw5Grade";
            // 
            // Passed
            // 
            this.Passed.DataPropertyName = "Passed";
            this.Passed.FillWeight = 60.34969F;
            this.Passed.HeaderText = "Passed";
            this.Passed.Name = "Passed";
            // 
            // ExamGrade
            // 
            this.ExamGrade.DataPropertyName = "ExamGrade";
            this.ExamGrade.FillWeight = 60.34969F;
            this.ExamGrade.HeaderText = "ExamGrade";
            this.ExamGrade.Name = "ExamGrade";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvEvaluate);
            this.tabPage3.Controls.Add(this.cbEvalua);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(810, 457);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Evaluate";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvEvaluate
            // 
            this.dgvEvaluate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEvaluate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvaluate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvaluate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLassName,
            this.StudentName,
            this.Understand,
            this.Punctuality,
            this.Support,
            this.Teaching});
            this.dgvEvaluate.Location = new System.Drawing.Point(6, 114);
            this.dgvEvaluate.Name = "dgvEvaluate";
            this.dgvEvaluate.ReadOnly = true;
            this.dgvEvaluate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvaluate.Size = new System.Drawing.Size(798, 337);
            this.dgvEvaluate.TabIndex = 2;
            // 
            // CLassName
            // 
            this.CLassName.DataPropertyName = "ClassId";
            this.CLassName.HeaderText = "Class";
            this.CLassName.Name = "CLassName";
            this.CLassName.ReadOnly = true;
            // 
            // StudentName
            // 
            this.StudentName.DataPropertyName = "Studentid";
            this.StudentName.HeaderText = "Student";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            // 
            // Understand
            // 
            this.Understand.DataPropertyName = "Understand";
            this.Understand.HeaderText = "UnderStand";
            this.Understand.Name = "Understand";
            this.Understand.ReadOnly = true;
            // 
            // Punctuality
            // 
            this.Punctuality.DataPropertyName = "Punctuality";
            this.Punctuality.HeaderText = "Punctuality";
            this.Punctuality.Name = "Punctuality";
            this.Punctuality.ReadOnly = true;
            // 
            // Support
            // 
            this.Support.DataPropertyName = "Support";
            this.Support.HeaderText = "Support";
            this.Support.Name = "Support";
            this.Support.ReadOnly = true;
            // 
            // Teaching
            // 
            this.Teaching.DataPropertyName = "Teaching";
            this.Teaching.HeaderText = "Teaching";
            this.Teaching.Name = "Teaching";
            this.Teaching.ReadOnly = true;
            // 
            // cbEvalua
            // 
            this.cbEvalua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvalua.FormattingEnabled = true;
            this.cbEvalua.Location = new System.Drawing.Point(96, 36);
            this.cbEvalua.Name = "cbEvalua";
            this.cbEvalua.Size = new System.Drawing.Size(121, 21);
            this.cbEvalua.TabIndex = 1;
            this.cbEvalua.SelectedIndexChanged += new System.EventHandler(this.cbEvalua_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Class";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // TeacherApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 507);
            this.Controls.Add(this.tabControl1);
            this.Name = "TeacherApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeacherApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeacherApp_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeacherApp_FormClosed);
            this.Load += new System.EventHandler(this.TeacherApp_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseSearchStudent)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrade)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvClass;
        private System.Windows.Forms.Button btnUpdateTeachingHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeachingHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeId;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvGrade;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbClassGrade;
        private System.Windows.Forms.TextBox tbSearchStudent;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbErrorTeachingHour;
        private System.Windows.Forms.PictureBox pbCloseSearchStudent;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvEvaluate;
        private System.Windows.Forms.ComboBox cbEvalua;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveGrade;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Button btnCancelEditTeachingHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Understand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Punctuality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Support;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teaching;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hw1Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hw2Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hw3Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hw4Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hw5Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamGrade;
    }
}