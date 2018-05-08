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
            s_rchFileDetails.AppendText("File Size: " + Math.Round(f.Length / 1048576f, 1) + " mb \n");
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
            else if (current == s_tabGrades)
            {
                string currentID = ConnectedUser.getID();

                Util.populateCombobox(s_cmboGradesClass, Course.GetStudentCourseList(currentID));

            }
        }

        // Student view loading handler
        private void pnlStudent_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void s_cmboGradesClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = s_cmboGradesClass.SelectedItem.ToString();

            var assignments = Course.GetCourseAssignmentList(selected);

            Util.populateListView(s_listGradesAssignments, assignments);
        }

        private void s_listGradesAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {
            s_wipeGradePanel();

            if (s_listGradesAssignments.SelectedItems.Count > 0)
            {
                Console.WriteLine("Selected");

                string selectedClass = s_cmboGradesClass.SelectedItem.ToString();

                ListViewItem item = s_listGradesAssignments.SelectedItems[0];
                string assignmentName = item.Text;

                var assignData = Assignment.GetAssignmentRowDataByName(assignmentName);
                Assignment assigned = new Assignment(assignData);

                if (assignData.Count < 1)
                {
                    Console.WriteLine("Invalid assignment data");
                    return;
                }

                var gradeData = Grade.GetGradeDataFromAssignment(assigned.AssignmentId, ConnectedUser.getID());

                if (gradeData.Count < 1)
                {
                    Console.WriteLine("Invalid grade data");
                    return;
                }

                var subInfo = Submission.GetSubmissionInfoForStudent(assigned.AssignmentName, ConnectedUser.getID());

                if (subInfo.Count < 1)
                {
                    Console.WriteLine("Invalid submission info");
                    return;
                }

                Grade g = new Grade(gradeData);
                Submission sub = new Submission(subInfo);

                try
                {

                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = sub.FileLocation;
                    s_linkAssignmentURL.Links.Add(link);

                    s_txtAssignmentGrade.Text = g.Score.ToString();
                    s_rchInstructorComments.Text = assigned.Comments;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("heck " + ex.Message);
                }
            }
        }

        private void s_wipeGradePanel()
        {
            /*t_linkSubmission.Links.Clear();
            t_txtAssignmentGrade.Text = "";
            t_rchAssignmentComments.Text = "";
            t_chkLateBox.Checked = false;*/

            s_linkAssignmentURL.Links.Clear();
            s_txtAssignmentGrade.Text = "";
            s_rchInstructorComments.Text = "";
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
            t_wipeGradingPanel();

            if (t_lstClassOverview.SelectedItems.Count > 0)
            {
                // Clear the previous ones
                t_lstStudentOverview.Items.Clear();
                t_lstAssignmentOverview.Items.Clear();

                // Get the selected class
                ListViewItem item = t_lstClassOverview.SelectedItems[0];
                string selectedClass = item.Text;

                List<string> studentIDs = Course.GetCourseStudentList(selectedClass);

                // Lambda to convert the list of student ids to a list of student names
                //studentIDs.ForEach<string>(p => Person.GetNameFromID(p));

                List<string> studentNames = new List<string>();

                foreach(string id in studentIDs)
                {
                    studentNames.Add(Person.GetNameFromID(id));
                }

                studentNames.Sort();

                // Populate the students table
                Util.populateListView(t_lstStudentOverview, studentNames);
            }
        }

        private void t_lstStudentOverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_wipeGradingPanel();

            if (t_lstStudentOverview.SelectedItems.Count > 0)
            {
                // Clear the previous ones
                t_lstAssignmentOverview.Items.Clear();

                ListViewItem item = t_lstClassOverview.SelectedItems[0];
                string selectedClass = item.Text;

                Util.populateListView(t_lstAssignmentOverview, Course.GetCourseAssignmentList(selectedClass));
            }
        }

        private void t_lstAssignmentOverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_wipeGradingPanel();

            if (t_lstAssignmentOverview.SelectedItems.Count > 0)
            {
                Console.WriteLine("Selected");

                ListViewItem item = t_lstClassOverview.SelectedItems[0];
                string selectedClass = item.Text;

                item = t_lstStudentOverview.SelectedItems[0];
                string selectedStudent = item.Text;

                // Get the student data from the format used in the list view
                var studentData = Person.fromFirstNameLastNameFormat(selectedStudent);

                // Make sure its valid
                if (studentData.Count > 0)
                {
                    Console.WriteLine("Valid student");

                    Person student = new Person(studentData);

                    item = t_lstAssignmentOverview.SelectedItems[0];
                    string selectedAssignmentName = item.Text;

                    t_pnlGrade.Enabled = true;

                    var subInfo = Submission.GetSubmissionInfoForStudent(selectedAssignmentName, student.PersonId);

                    if (subInfo.Count > 0)
                    {
                        Submission sub = new Submission(subInfo);

                        // Activate the link label
                        LinkLabel.Link link = new LinkLabel.Link();
                        link.LinkData = sub.FileLocation;
                        t_linkSubmission.Links.Add(link);

                        // Try to find a grade object for the given assignment and student

                        var assignmentData = Assignment.GetAssignmentRowDataByName(selectedAssignmentName);
                        Assignment a = new Assignment(assignmentData);


                        var data = Grade.GetGradeDataFromAssignment(a.AssignmentId, student.PersonId);
                        
                        if (data.Count < 1)
                        {
                            Console.WriteLine("Grade data doesnt exist");
                            return;
                        }

                        Grade g = new Grade(data);

                        t_txtAssignmentGrade.Text = g.Score.ToString();
                        t_rchAssignmentComments.Text = a.Comments;
                    }
                }
            }
        }

        private void t_btnGradeChangeSave_Click(object sender, EventArgs e)
        {
            int total = Grade.GetTotalGrades();
            total++;

            ListViewItem item = t_lstAssignmentOverview.SelectedItems[0];
            string selectedAssignmentName = item.Text;
            var assignmentData = Assignment.GetAssignmentRowDataByName(selectedAssignmentName);
            Assignment a = new Assignment(assignmentData);

            item = t_lstStudentOverview.SelectedItems[0];
            string selectedStudent = item.Text;
            var studentData = Person.fromFirstNameLastNameFormat(selectedStudent);
            Person student = new Person(studentData);

            int grade = Convert.ToInt32(t_txtAssignmentGrade.Text);

            Grade newGrade = new Grade(total.ToString(), a.AssignmentId, grade, student.PersonId, "true");

            Grade.InsertGradeData(newGrade);

            Console.WriteLine("Submitted new grade data successfully");
        }

        private void t_wipeGradingPanel()
        {
            t_linkSubmission.Links.Clear();
            t_txtAssignmentGrade.Text = "";
            t_rchAssignmentComments.Text = "";
            t_chkLateBox.Checked = false;
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

        private void t_linkSubmission_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url;
            if (e.Link.LinkData != null)
                url = e.Link.LinkData.ToString();
            else
                url = t_linkSubmission.Text.Substring(e.Link.Start, e.Link.Length);

            if (!url.Contains("://"))
                url = "http://" + url;

            var si = new ProcessStartInfo(url);
            Process.Start(si);
            t_linkSubmission.LinkVisited = true;

        }

        private void s_linkAssignmentURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url;
            if (e.Link.LinkData != null)
                url = e.Link.LinkData.ToString();
            else
                url = s_linkAssignmentURL.Text.Substring(e.Link.Start, e.Link.Length);

            if (!url.Contains("://"))
                url = "http://" + url;

            var si = new ProcessStartInfo(url);
            Process.Start(si);
            s_linkAssignmentURL.LinkVisited = true;
        }
    }
}
