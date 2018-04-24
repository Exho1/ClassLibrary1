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

        public frmApp()
        {
            InitializeComponent();

            pnlLogin.Visible = true;
        }

        private void frmApp_Load(object sender, EventArgs e)
        {

        }

        private void btnStudentView_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
            pnlStudent.Visible = true;
        }

        private void btnTeachView_Click(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            s_fileSelector.ShowDialog();
            s_fileSelector.Title = "Select video file..";
            s_fileSelector.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        }

        private void s_fileSelector_FileOk(object sender, CancelEventArgs e)
        {
            s_btnSelect.Text = "File Selected";
            s_btnFileUpload.Enabled = true;

            Debug.WriteLine("slob on me knob " + s_fileSelector.FileName);

            FileInfo f = new FileInfo(s_fileSelector.FileName);

            s_rchFileDetails.AppendText("Selected: " + f.Name + "\n");
            s_rchFileDetails.AppendText("File Size: " + Math.Round(f.Length / 1048576f, 1)  + " mb \n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s_tabCntrl.SelectedTab = s_tabUpload;
        }

        private void s_tabHome_Click(object sender, EventArgs e)
        {

        }

        private async void s_btnFile_ClickAsync(object sender, EventArgs e)
        {
            s_rchFileDetails.AppendText("\nStarting upload...\n");

            await studentUploader.UploadVideoFile(s_fileSelector.FileName, "Uploaded this bear from our app.mp4");

            /*Action<string> prog = studentUploader.getProgress();

            while (prog!= null)
            {
                s_rchFileDetails.AppendText(prog(""));
            }*/
        
            s_rchFileDetails.AppendText("Upload complete! \n");
        }
    }
}
