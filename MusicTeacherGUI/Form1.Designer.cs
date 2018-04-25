namespace MusicTeacherGUI
{
    partial class frmApp
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("DoubleTest");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Test");
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnTeachView = new System.Windows.Forms.Button();
            this.btnStudentView = new System.Windows.Forms.Button();
            this.pnlStudent = new System.Windows.Forms.Panel();
            this.s_tabCntrl = new System.Windows.Forms.TabControl();
            this.s_tabUpload = new System.Windows.Forms.TabPage();
            this.s_picThumbnail = new System.Windows.Forms.PictureBox();
            this.s_rchFileDetails = new System.Windows.Forms.RichTextBox();
            this.s_btnFileUpload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.s_cmboUploadAssignment = new System.Windows.Forms.ComboBox();
            this.s_cmboUploadClass = new System.Windows.Forms.ComboBox();
            this.s_btnSelect = new System.Windows.Forms.Button();
            this.s_tabGrades = new System.Windows.Forms.TabPage();
            this.s_listGrades = new System.Windows.Forms.ListView();
            this.s_listClasses = new System.Windows.Forms.ListView();
            this.s_tabAssignments = new System.Windows.Forms.TabPage();
            this.s_tabHome = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.s_fileSelector = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlTeacher = new System.Windows.Forms.Panel();
            this.pnlLogin.SuspendLayout();
            this.pnlStudent.SuspendLayout();
            this.s_tabCntrl.SuspendLayout();
            this.s_tabUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s_picThumbnail)).BeginInit();
            this.s_tabGrades.SuspendLayout();
            this.s_tabHome.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.pnlTeacher.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.btnTeachView);
            this.pnlLogin.Controls.Add(this.btnStudentView);
            this.pnlLogin.Location = new System.Drawing.Point(12, 12);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(675, 434);
            this.pnlLogin.TabIndex = 0;
            // 
            // btnTeachView
            // 
            this.btnTeachView.Location = new System.Drawing.Point(384, 114);
            this.btnTeachView.Name = "btnTeachView";
            this.btnTeachView.Size = new System.Drawing.Size(121, 52);
            this.btnTeachView.TabIndex = 1;
            this.btnTeachView.Text = "Teacher";
            this.btnTeachView.UseVisualStyleBackColor = true;
            this.btnTeachView.Click += new System.EventHandler(this.btnTeachView_Click);
            // 
            // btnStudentView
            // 
            this.btnStudentView.Location = new System.Drawing.Point(144, 114);
            this.btnStudentView.Name = "btnStudentView";
            this.btnStudentView.Size = new System.Drawing.Size(121, 52);
            this.btnStudentView.TabIndex = 0;
            this.btnStudentView.Text = "Student";
            this.btnStudentView.UseVisualStyleBackColor = true;
            this.btnStudentView.Click += new System.EventHandler(this.btnStudentView_Click);
            // 
            // pnlStudent
            // 
            this.pnlStudent.Controls.Add(this.s_tabCntrl);
            this.pnlStudent.Location = new System.Drawing.Point(12, 12);
            this.pnlStudent.Name = "pnlStudent";
            this.pnlStudent.Size = new System.Drawing.Size(675, 434);
            this.pnlStudent.TabIndex = 2;
            this.pnlStudent.Visible = false;
            // 
            // s_tabCntrl
            // 
            this.s_tabCntrl.Controls.Add(this.s_tabUpload);
            this.s_tabCntrl.Controls.Add(this.s_tabGrades);
            this.s_tabCntrl.Controls.Add(this.s_tabAssignments);
            this.s_tabCntrl.Controls.Add(this.s_tabHome);
            this.s_tabCntrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.s_tabCntrl.Location = new System.Drawing.Point(0, 0);
            this.s_tabCntrl.Name = "s_tabCntrl";
            this.s_tabCntrl.SelectedIndex = 0;
            this.s_tabCntrl.Size = new System.Drawing.Size(675, 434);
            this.s_tabCntrl.TabIndex = 0;
            // 
            // s_tabUpload
            // 
            this.s_tabUpload.Controls.Add(this.s_picThumbnail);
            this.s_tabUpload.Controls.Add(this.s_rchFileDetails);
            this.s_tabUpload.Controls.Add(this.s_btnFileUpload);
            this.s_tabUpload.Controls.Add(this.label3);
            this.s_tabUpload.Controls.Add(this.label2);
            this.s_tabUpload.Controls.Add(this.s_cmboUploadAssignment);
            this.s_tabUpload.Controls.Add(this.s_cmboUploadClass);
            this.s_tabUpload.Controls.Add(this.s_btnSelect);
            this.s_tabUpload.Location = new System.Drawing.Point(4, 22);
            this.s_tabUpload.Name = "s_tabUpload";
            this.s_tabUpload.Padding = new System.Windows.Forms.Padding(3);
            this.s_tabUpload.Size = new System.Drawing.Size(667, 408);
            this.s_tabUpload.TabIndex = 1;
            this.s_tabUpload.Text = "Upload";
            this.s_tabUpload.UseVisualStyleBackColor = true;
            this.s_tabUpload.Click += new System.EventHandler(this.s_tabUpload_Click);
            // 
            // s_picThumbnail
            // 
            this.s_picThumbnail.Location = new System.Drawing.Point(30, 174);
            this.s_picThumbnail.Name = "s_picThumbnail";
            this.s_picThumbnail.Size = new System.Drawing.Size(302, 200);
            this.s_picThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.s_picThumbnail.TabIndex = 11;
            this.s_picThumbnail.TabStop = false;
            // 
            // s_rchFileDetails
            // 
            this.s_rchFileDetails.DetectUrls = false;
            this.s_rchFileDetails.Location = new System.Drawing.Point(380, 174);
            this.s_rchFileDetails.Name = "s_rchFileDetails";
            this.s_rchFileDetails.ReadOnly = true;
            this.s_rchFileDetails.Size = new System.Drawing.Size(228, 200);
            this.s_rchFileDetails.TabIndex = 10;
            this.s_rchFileDetails.Text = "";
            // 
            // s_btnFileUpload
            // 
            this.s_btnFileUpload.Enabled = false;
            this.s_btnFileUpload.Location = new System.Drawing.Point(451, 107);
            this.s_btnFileUpload.Name = "s_btnFileUpload";
            this.s_btnFileUpload.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.s_btnFileUpload.Size = new System.Drawing.Size(157, 37);
            this.s_btnFileUpload.TabIndex = 9;
            this.s_btnFileUpload.Text = "Upload File";
            this.s_btnFileUpload.UseVisualStyleBackColor = true;
            this.s_btnFileUpload.Click += new System.EventHandler(this.s_btnFile_ClickAsync);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Assignment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Class";
            // 
            // s_cmboUploadAssignment
            // 
            this.s_cmboUploadAssignment.FormattingEnabled = true;
            this.s_cmboUploadAssignment.Location = new System.Drawing.Point(30, 114);
            this.s_cmboUploadAssignment.Name = "s_cmboUploadAssignment";
            this.s_cmboUploadAssignment.Size = new System.Drawing.Size(171, 21);
            this.s_cmboUploadAssignment.TabIndex = 6;
            // 
            // s_cmboUploadClass
            // 
            this.s_cmboUploadClass.FormattingEnabled = true;
            this.s_cmboUploadClass.Location = new System.Drawing.Point(30, 65);
            this.s_cmboUploadClass.Name = "s_cmboUploadClass";
            this.s_cmboUploadClass.Size = new System.Drawing.Size(171, 21);
            this.s_cmboUploadClass.TabIndex = 5;
            // 
            // s_btnSelect
            // 
            this.s_btnSelect.Location = new System.Drawing.Point(451, 56);
            this.s_btnSelect.Name = "s_btnSelect";
            this.s_btnSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.s_btnSelect.Size = new System.Drawing.Size(157, 37);
            this.s_btnSelect.TabIndex = 4;
            this.s_btnSelect.Text = "Select File";
            this.s_btnSelect.UseVisualStyleBackColor = true;
            this.s_btnSelect.Click += new System.EventHandler(this.button5_Click);
            // 
            // s_tabGrades
            // 
            this.s_tabGrades.Controls.Add(this.s_listGrades);
            this.s_tabGrades.Controls.Add(this.s_listClasses);
            this.s_tabGrades.Location = new System.Drawing.Point(4, 22);
            this.s_tabGrades.Name = "s_tabGrades";
            this.s_tabGrades.Padding = new System.Windows.Forms.Padding(3);
            this.s_tabGrades.Size = new System.Drawing.Size(667, 408);
            this.s_tabGrades.TabIndex = 2;
            this.s_tabGrades.Text = "Grades";
            this.s_tabGrades.UseVisualStyleBackColor = true;
            // 
            // s_listGrades
            // 
            this.s_listGrades.Dock = System.Windows.Forms.DockStyle.Left;
            this.s_listGrades.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.s_listGrades.Location = new System.Drawing.Point(192, 3);
            this.s_listGrades.Name = "s_listGrades";
            this.s_listGrades.Size = new System.Drawing.Size(209, 402);
            this.s_listGrades.TabIndex = 1;
            this.s_listGrades.UseCompatibleStateImageBehavior = false;
            // 
            // s_listClasses
            // 
            this.s_listClasses.Dock = System.Windows.Forms.DockStyle.Left;
            this.s_listClasses.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.s_listClasses.Location = new System.Drawing.Point(3, 3);
            this.s_listClasses.Name = "s_listClasses";
            this.s_listClasses.Size = new System.Drawing.Size(189, 402);
            this.s_listClasses.TabIndex = 0;
            this.s_listClasses.UseCompatibleStateImageBehavior = false;
            // 
            // s_tabAssignments
            // 
            this.s_tabAssignments.Location = new System.Drawing.Point(4, 22);
            this.s_tabAssignments.Name = "s_tabAssignments";
            this.s_tabAssignments.Padding = new System.Windows.Forms.Padding(3);
            this.s_tabAssignments.Size = new System.Drawing.Size(667, 408);
            this.s_tabAssignments.TabIndex = 3;
            this.s_tabAssignments.Text = "Assignments";
            this.s_tabAssignments.UseVisualStyleBackColor = true;
            // 
            // s_tabHome
            // 
            this.s_tabHome.Controls.Add(this.button3);
            this.s_tabHome.Controls.Add(this.button2);
            this.s_tabHome.Controls.Add(this.button1);
            this.s_tabHome.Controls.Add(this.label1);
            this.s_tabHome.Location = new System.Drawing.Point(4, 22);
            this.s_tabHome.Name = "s_tabHome";
            this.s_tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.s_tabHome.Size = new System.Drawing.Size(667, 408);
            this.s_tabHome.TabIndex = 0;
            this.s_tabHome.Text = "Home";
            this.s_tabHome.UseVisualStyleBackColor = true;
            this.s_tabHome.Click += new System.EventHandler(this.s_tabHome_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(236, 193);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(157, 37);
            this.button3.TabIndex = 5;
            this.button3.Text = "View Assignments";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(236, 150);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(157, 37);
            this.button2.TabIndex = 4;
            this.button2.Text = "View Grades";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 107);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(157, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Upload Assignment";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(257, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hello Student";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // s_fileSelector
            // 
            this.s_fileSelector.FileName = "openFileDialog1";
            this.s_fileSelector.Filter = "\"Media Files|*.mov;*.wmv;*.wma;*.mp4;*.mp3|All Files|*.*\"";
            this.s_fileSelector.FileOk += new System.ComponentModel.CancelEventHandler(this.s_fileSelector_FileOk);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(675, 434);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(667, 408);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Upload";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(30, 174);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Location = new System.Drawing.Point(380, 174);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(228, 200);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(451, 107);
            this.button4.Name = "button4";
            this.button4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button4.Size = new System.Drawing.Size(157, 37);
            this.button4.TabIndex = 9;
            this.button4.Text = "Upload File";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Assignment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Class";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(30, 114);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(171, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(30, 65);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(171, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(451, 56);
            this.button5.Name = "button5";
            this.button5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button5.Size = new System.Drawing.Size(157, 37);
            this.button5.TabIndex = 4;
            this.button5.Text = "Select File";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button6);
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Controls.Add(this.button8);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(667, 408);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Home";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(236, 193);
            this.button6.Name = "button6";
            this.button6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button6.Size = new System.Drawing.Size(157, 37);
            this.button6.TabIndex = 5;
            this.button6.Text = "Create Assignment";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(236, 150);
            this.button7.Name = "button7";
            this.button7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button7.Size = new System.Drawing.Size(157, 37);
            this.button7.TabIndex = 4;
            this.button7.Text = "Class Overview";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(236, 107);
            this.button8.Name = "button8";
            this.button8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button8.Size = new System.Drawing.Size(157, 37);
            this.button8.TabIndex = 3;
            this.button8.Text = "Grade Assignments";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(257, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Hello Teacher";
            // 
            // pnlTeacher
            // 
            this.pnlTeacher.Controls.Add(this.tabControl1);
            this.pnlTeacher.Location = new System.Drawing.Point(12, 15);
            this.pnlTeacher.Name = "pnlTeacher";
            this.pnlTeacher.Size = new System.Drawing.Size(675, 434);
            this.pnlTeacher.TabIndex = 3;
            this.pnlTeacher.Visible = false;
            // 
            // frmApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 458);
            this.Controls.Add(this.pnlTeacher);
            this.Controls.Add(this.pnlStudent);
            this.Controls.Add(this.pnlLogin);
            this.Name = "frmApp";
            this.Text = "Music Teacher Application";
            this.Load += new System.EventHandler(this.frmApp_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlStudent.ResumeLayout(false);
            this.s_tabCntrl.ResumeLayout(false);
            this.s_tabUpload.ResumeLayout(false);
            this.s_tabUpload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s_picThumbnail)).EndInit();
            this.s_tabGrades.ResumeLayout(false);
            this.s_tabHome.ResumeLayout(false);
            this.s_tabHome.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.pnlTeacher.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btnTeachView;
        private System.Windows.Forms.Button btnStudentView;
        private System.Windows.Forms.Panel pnlStudent;
        private System.Windows.Forms.TabControl s_tabCntrl;
        private System.Windows.Forms.TabPage s_tabHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage s_tabUpload;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button s_btnSelect;
        private System.Windows.Forms.OpenFileDialog s_fileSelector;
        private System.Windows.Forms.TabPage s_tabGrades;
        private System.Windows.Forms.ListView s_listGrades;
        private System.Windows.Forms.ListView s_listClasses;
        private System.Windows.Forms.TabPage s_tabAssignments;
        private System.Windows.Forms.ComboBox s_cmboUploadClass;
        private System.Windows.Forms.Button s_btnFileUpload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox s_cmboUploadAssignment;
        private System.Windows.Forms.RichTextBox s_rchFileDetails;
        private System.Windows.Forms.PictureBox s_picThumbnail;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlTeacher;
    }
}

