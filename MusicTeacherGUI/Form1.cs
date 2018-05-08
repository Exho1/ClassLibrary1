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

        /// <summary>
        /// Distinguishes 
        /// </summary>
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
            /*if (personID != null)
            {
                return;
            }*/

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

            Util.populateCombobox(s_cmboUploadClass, ConnectedUser.getCourses());

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

        private void s_tabUpload_Click(object sender, EventArgs e)
        {
            
        }




        /*
         * ///////////////////////////////////
         *  START STUDENT CODE
         * ///////////////////////////////////
         */


        private string s_selectedClass;
        private string s_selectedAssignment;

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

            int id = Submission.GetTotalSubmissions();

            id++;

            // Create a new submission object
            Submission upload = new Submission(id.ToString(), ConnectedUser.getID(), s_cmboUploadClass.SelectedItem.ToString(), s_cmboUploadAssignment.SelectedItem.ToString(), "null", DateTime.Now);

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

        private void s_cmboUploadClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the class we selected
            string selected = s_cmboUploadClass.SelectedItem.ToString();

            s_selectedClass = selected;

            s_cmboUploadAssignment.Items.Clear();

            // Populate the Assignments combo box
            Util.populateCombobox(s_cmboUploadAssignment, ConnectedUser.getAssignmentsFromCourse(selected));

        }

        private void s_cmboUploadAssignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When we select a class and assignment, we are now good to go for the submit

            string selected = s_cmboUploadClass.SelectedItem.ToString();

            s_selectedAssignment = selected;
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

            if (s_todoAssignments.SelectedItems.Count > 0)
            {

                ListViewItem selected = s_todoAssignments.SelectedItems[0];

                Assignment chosen = Util.listItemContainsAnyAssignment(selected.Text);

                if (chosen != null)
                {
                    s_txtAssignmentDueDate.Text = chosen.DueDate.ToShortDateString();

                    s_txtAssignmentPoints.Text = chosen.TotalPoints.ToString();

                    s_rchAssignmentInstructions.Text = chosen.Comments;
                }
            }

            //selected.Text;

            // Assignment.GetAssignmentRowDataByName

        }

        // Student tab handler
        private void s_tabCntrl_TabIndexChanged(object sender, EventArgs e)
        {
            // Get the current tab
            TabPage current = s_tabCntrl.SelectedTab;

            if (current == s_tabUpload)
            {
                Console.WriteLine("Populate uploader");

                // Populate the Classes combo box
                Util.populateCombobox(s_cmboUploadClass, ConnectedUser.getCourses());
            }
            else if (current == s_tabAssignments)
            {
                Console.WriteLine("Populate assignments");

                List<string> formattedAssignments = new List<string>();

                List<Tuple<string, string>> all = ConnectedUser.getAllAssignments();

                // Format all the assignments to "class - assignment" for the list view 
                for (int i = 0; i < all.Count; i++)
                {
                    if (all[i] != null)
                    {
                        Tuple<string, string> t = all[i];

                        // Don't add assignments to the "to do" that the student has already submitted
                        if (!Assignment.HasStudentSubmitted(t.Item2.ToString(), ConnectedUser.getID()))
                        {
                            // Format like class name - assignment name
                            formattedAssignments.Add(t.Item1.ToString() + " - " + t.Item2.ToString());
                        }
                    }
                }

                Console.WriteLine("Populating with: " + formattedAssignments.Count);

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
                //Util.populateCombobox(s_cmboUploadClass, ConnectedUser.getCourses());
            }
        }

        private void s_btnLogOut_Click(object sender, EventArgs e)
        {
            logout();
        }

        /*
         * ///////////////////////////////////
         *  END STUDENT CODE
         * ///////////////////////////////////
         */





        /*
         * ///////////////////////////////////
         *  START TEACHER CODE
         * ///////////////////////////////////
         */

        private void t_tabOverview_Click(object sender, EventArgs e)
        {

        }

        private void t_btnGrade_Click(object sender, EventArgs e)
        {
            t_tabCntrlTeacher.SelectedTab = t_tabGrade;
        }
        // Teacher tab handler
        private void t_tabCntrlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the current tab
            TabPage current = t_tabCntrlTeacher.SelectedTab;

            string teachID = ConnectedUser.getID();

            if (current == t_tabGrade)
            {

                Util.populateListView(t_lstClassOverview, Course.GetTeacherCourseList(teachID));

                
            }
        }

        private void t_lstClassOverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t_lstClassOverview.SelectedItems.Count > 0)
            {
                ListViewItem item = t_lstClassOverview.SelectedItems[0];

                string selectedClass = item.Text;

                Util.populateListView(t_lstStudentOverview, Course.GetCourseStudentList(selectedClass));
            }
        }

        private void t_btnLogOut_Click(object sender, EventArgs e)
        {
            logout();
        }

        /*
         * ///////////////////////////////////
         *  END TEACHER CODE
         * ///////////////////////////////////
         */

        private void logout()
        {
            pnlLogin.Visible = true;
            pnlTeacher.Visible = false;
            pnlStudent.Visible = false;

            // Wipe the connected user
            ConnectedUser.setConnUser();
        }
    }
}
