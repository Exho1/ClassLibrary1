using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using DropboxUpload;

using MusicTeacherAppDatabaseAccess;

namespace MusicTeacherGUI
{
    public partial class frmApp : Form
    {

        /*
         * Naming format:
         *      Objects:
         *          - s_ for Student controls and t_ for Teacher controls
         *          - Abbreviated name of their Type in lowercase
         *          - Then a unique name for the control
         *          - ex: Button for a student to upload would be s_btnUploadVideo
         *      
         *      Variables
         *          - camelCase for variables
         *          
         */

        private Uploader studentUploader = new Uploader();

        private char guiView;

        public frmApp()
        {
            InitializeComponent();

            pnlLogin.Visible = true;
        }

        private void frmApp_Load(object sender, EventArgs e)
        {

        }

        private void frmApp_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnStudentView_Click(object sender, EventArgs e)
        {
            guiView = 's';
            btn_Login.Text = "Login as a Student";
            btnStudentView.Enabled = false;
            btnTeachView.Enabled = true;
        }

        private void btnTeachView_Click(object sender, EventArgs e)
        {
            guiView = 't';
            btn_Login.Text = "Login as a Teacher";
            btnTeachView.Enabled = false;
            btnStudentView.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string personID = txtUsername.Text.ToLower();

            // Make sure this isn't empty
            if (personID != null)
            {
                return;
            }

            if (guiView == 's')
            {
                pnlLogin.Visible = false;
                pnlTeacher.Visible = false;
                pnlStudent.Visible = true;
            }
            else if (guiView == 't')
            {
                pnlLogin.Visible = false;
                pnlStudent.Visible = false;
                pnlTeacher.Visible = true;
            }

            btnTeachView.Enabled = true;
            btnStudentView.Enabled = true;

            // Get the data for the connected user
            List<string> pData = Person.GetPersonRowData(personID);

            // Create a user with that data
            Person user = new Person(pData);

            // Set our global user to this new person object
            ConnectedUser.setConnUser(user);

            // 
            if (guiView == 's')
            {
                

            }
            else if (guiView == 't')
            {
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void s_tabUpload_Click(object sender, EventArgs e)
        {
            
        }

        // Opens the file selector
        private void button5_Click(object sender, EventArgs e)
        {
            s_fileSelector.ShowDialog();
            s_fileSelector.Title = "Select video file..";
            s_fileSelector.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        }

        // Called when a file is validated
        private void s_fileSelector_FileOk(object sender, CancelEventArgs e)
        {
            s_resetUploader();

            s_btnSelect.Text = "File Selected";
            s_btnFileUpload.Enabled = true;

            string fullFilePath = s_fileSelector.FileName;

            Debug.WriteLine(fullFilePath);

            FileInfo f = new FileInfo(fullFilePath);

            // Gets a thumbnail frame
            string thumb = studentUploader.getVideoThumbnail(fullFilePath);
            s_picThumbnail.Image = Image.FromFile(thumb);

            // Give feedback about the file before uploading
            s_rchFileDetails.AppendText("Selected: " + f.Name + "\n");
            s_rchFileDetails.AppendText("File Size: " + Math.Round(f.Length / 1048576f, 1)  + " mb \n");
            s_rchFileDetails.AppendText("Ready to upload! \n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s_tabCntrl.SelectedTab = s_tabUpload;
        }

        private async void s_btnFile_ClickAsync(object sender, EventArgs e)
        {
            // Create a new submission object
            Submission upload = new Submission("1", ConnectedUser.getID(), s_cmboUploadClass.SelectedText, s_cmboUploadAssignment.SelectedText, "null", DateTime.Now);

            s_rchFileDetails.AppendText("\nStarting upload...\n");

            // Uploads the video file and gets the url
            string uploadURL = await studentUploader.UploadVideoFile(s_fileSelector.FileName, "Uploaded this bear from our app.mp4");

            // This would involve some multithreading
            /*Action<string> prog = studentUploader.getProgress();

            while (prog!= null)
            {
                s_rchFileDetails.AppendText(prog(""));
            }*/

            // Sets the url to our object
            upload.FileLocation = uploadURL;

            // Uploads the object to the database
            Submission.InsertSubmissionData(upload);
        
            s_rchFileDetails.AppendText("Upload complete! \n");
        }

        private void s_resetUploader()
        {
            s_rchFileDetails.ResetText();
            s_picThumbnail.Image = null;

            s_btnSelect.ResetText();
            s_btnFileUpload.Enabled = false;
        }

        private void t_tabOverview_Click(object sender, EventArgs e)
        {

        }

        private void t_btnGrade_Click(object sender, EventArgs e)
        {
            t_tabCntrlTeacher.SelectedTab = t_tabGrade;
        }

        private void s_cmboUploadClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the class we selected
            string selected = s_cmboUploadClass.SelectedText;

            // Populate the Assignments combo box
            Util.populateCombobox(s_cmboUploadAssignment, ConnectedUser.getAssignmentsFromCourse(selected));

        }

        private void s_cmboUploadAssignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When we select a class and assignment, we are now good to go for the submit
        }

        // Selecting an assignment in the students assignments tab
        private void s_todoAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * Index changed:
             *      Get assignment name
             *      Get assignment ID from assignment name through database
             *      Populate panel with asdsignment info
             */

            //ListViewI selected = s_todoAssignments.SelectedItems[0];

            
        }

        // Student tab handler
        private void s_tabCntrl_TabIndexChanged(object sender, EventArgs e)
        {
            // Get the current tab
            TabPage current = s_tabCntrl.SelectedTab;

            if (current == s_tabUpload)
            {
                // Populate the Classes combo box
                Util.populateCombobox(s_cmboUploadClass, ConnectedUser.getCourses());
            }
            else if (current == s_tabAssignments)
            {


                List<string> formattedAssignments = new List<string>();

                List<Tuple<string, string>> all = ConnectedUser.getAllAssignments();

                // Format all the assignments to "class - assignment" for the list view 
                for (int i = 0; i < all.Count; i++)
                {
                    if (all[i] != null)
                    {
                        Tuple<string, string> t = all[i];

                        formattedAssignments.Add(t.Item1.ToString() + " - " + t.Item2.ToString());
                    }
                }

                // Populate the list view with the contents
                Util.populateListView(s_todoAssignments, formattedAssignments);
            }
        }

        // Student view loading handler
        private void pnlStudent_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlStudent.Visible)
            {
                // Fills the class combo box with the course list
                Util.populateCombobox(s_cmboUploadClass, ConnectedUser.getCourses());
            }
        }
    }
}
