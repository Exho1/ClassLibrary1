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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Test");
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("DoubleTest");
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnTeachView = new System.Windows.Forms.Button();
            this.btnStudentView = new System.Windows.Forms.Button();
            this.pnlStudent = new System.Windows.Forms.Panel();
            this.s_tabCntrl = new System.Windows.Forms.TabControl();
            this.s_tabHome = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.s_tabUpload = new System.Windows.Forms.TabPage();
            this.s_btnUpload = new System.Windows.Forms.Button();
            this.s_fileSelector = new System.Windows.Forms.OpenFileDialog();
            this.s_tabGrades = new System.Windows.Forms.TabPage();
            this.s_listClasses = new System.Windows.Forms.ListView();
            this.s_listGrades = new System.Windows.Forms.ListView();
            this.s_tabAssignments = new System.Windows.Forms.TabPage();
            this.pnlLogin.SuspendLayout();
            this.pnlStudent.SuspendLayout();
            this.s_tabCntrl.SuspendLayout();
            this.s_tabHome.SuspendLayout();
            this.s_tabUpload.SuspendLayout();
            this.s_tabGrades.SuspendLayout();
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
            this.s_tabCntrl.Controls.Add(this.s_tabHome);
            this.s_tabCntrl.Controls.Add(this.s_tabGrades);
            this.s_tabCntrl.Controls.Add(this.s_tabAssignments);
            this.s_tabCntrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.s_tabCntrl.Location = new System.Drawing.Point(0, 0);
            this.s_tabCntrl.Name = "s_tabCntrl";
            this.s_tabCntrl.SelectedIndex = 0;
            this.s_tabCntrl.Size = new System.Drawing.Size(675, 434);
            this.s_tabCntrl.TabIndex = 0;
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
            // s_tabUpload
            // 
            this.s_tabUpload.Controls.Add(this.s_btnUpload);
            this.s_tabUpload.Location = new System.Drawing.Point(4, 22);
            this.s_tabUpload.Name = "s_tabUpload";
            this.s_tabUpload.Padding = new System.Windows.Forms.Padding(3);
            this.s_tabUpload.Size = new System.Drawing.Size(667, 408);
            this.s_tabUpload.TabIndex = 1;
            this.s_tabUpload.Text = "Upload";
            this.s_tabUpload.UseVisualStyleBackColor = true;
            this.s_tabUpload.Click += new System.EventHandler(this.s_tabUpload_Click);
            // 
            // s_btnUpload
            // 
            this.s_btnUpload.Location = new System.Drawing.Point(238, 92);
            this.s_btnUpload.Name = "s_btnUpload";
            this.s_btnUpload.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.s_btnUpload.Size = new System.Drawing.Size(157, 37);
            this.s_btnUpload.TabIndex = 4;
            this.s_btnUpload.Text = "Select File";
            this.s_btnUpload.UseVisualStyleBackColor = true;
            this.s_btnUpload.Click += new System.EventHandler(this.button5_Click);
            // 
            // s_fileSelector
            // 
            this.s_fileSelector.FileName = "openFileDialog1";
            this.s_fileSelector.Filter = "\"Media Files|*.mov;*.wmv;*.wma;*.mp4;*.mp3|All Files|*.*\"";
            this.s_fileSelector.FileOk += new System.ComponentModel.CancelEventHandler(this.s_fileSelector_FileOk);
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
            // frmApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 458);
            this.Controls.Add(this.pnlStudent);
            this.Controls.Add(this.pnlLogin);
            this.Name = "frmApp";
            this.Text = "Music Teacher Application";
            this.Load += new System.EventHandler(this.frmApp_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlStudent.ResumeLayout(false);
            this.s_tabCntrl.ResumeLayout(false);
            this.s_tabHome.ResumeLayout(false);
            this.s_tabHome.PerformLayout();
            this.s_tabUpload.ResumeLayout(false);
            this.s_tabGrades.ResumeLayout(false);
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
        private System.Windows.Forms.Button s_btnUpload;
        private System.Windows.Forms.OpenFileDialog s_fileSelector;
        private System.Windows.Forms.TabPage s_tabGrades;
        private System.Windows.Forms.ListView s_listGrades;
        private System.Windows.Forms.ListView s_listClasses;
        private System.Windows.Forms.TabPage s_tabAssignments;
    }
}

