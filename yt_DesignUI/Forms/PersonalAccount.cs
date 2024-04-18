using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yt_DesignUI.Models;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.IO;

namespace yt_DesignUI.Forms
{

    public partial class PersonalAccount : Design
    {
        private Timer timer;
        private Employee CurrentWorker;
        private Enterprise CurrentEnterprise;
        private bool isCamera=true;
        private VideoCaptureDevice videoSource;
        public PersonalAccount(Employee worker, Enterprise enterprise)
        {
            InitializeComponent();
            this.CurrentWorker = worker;
            this.CurrentEnterprise = enterprise;          
            timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
            timer.Start();
           renderInfo();
            //yt_Button4.Click += CaptureButton_Click;
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            runVideo();
            getCurrentState();
         

        }
        public void runVideo()
        {
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                yt_Button4.Visible = false;
                isCamera = false;
                MessageBox.Show("Camera didn`t find");
                string projectRootPath = Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath));
                string directoryPath = Path.Combine(projectRootPath, "photos");

                // Проверяем, существует ли папка, и создаем ее, если она не существует
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string imagePath = Path.Combine(directoryPath, "none.png");
                pictureBox2.Image = Image.FromFile(imagePath); 
                return;
            }

            // Создаем объект для захвата видео с первой доступной камеры
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();
        }



        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (!videoSource.IsRunning)
                return;

            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            pictureBox2.Image = frame;
        }

        private void yt_Button4_Click(object sender, EventArgs e)
        {
            if (isCamera)
            {
                videoSource.Stop();
                yt_Button4.Visible = false;
                label7.Visible = true;
            }
              
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }
        public void renderInfo()
        {
            label1.Text += CurrentWorker.Name;
            label5.Text = CurrentEnterprise.Name;
            label3.Text = CurrentEnterprise.ContactNumber.ToString();
        }
        private void savePhoto(string fileName)
        {
            if (isCamera) {
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("No photo for saving");
                return;
            }


                string projectRootPath = Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath));
                string directoryPath = Path.Combine(projectRootPath, "photos");
                if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            string filePath = Path.Combine(directoryPath, fileName);

            
            try
            {
                pictureBox2.Image.Save(filePath, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving: {ex.Message}");
            }

            }


        }



       

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void PersonalAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
          
               if(isCamera)
                    videoSource.Stop();
             
            
        }

        private void yt_Button3_Click(object sender, EventArgs e)
        {
            if (isCamera) { 
                videoSource.Stop();
                yt_Button4.Visible = false;
                label7.Visible = true;
                string fileName = $"{CurrentEnterprise.Name}_{CurrentWorker.Name}_{(CurrentWorker.Working ? "started" : "finished")}_{DateTime.Now.ToString().Replace(':', '-')}.jpg";
                savePhoto(fileName);
            }



            currentState();
            StartOrFinishWorking startOrFinishForm = new StartOrFinishWorking(CurrentWorker, CurrentEnterprise, CurrentWorker.Working,isCamera);
            this.Hide();
            startOrFinishForm.ShowDialog();
            this.Show();
        
        }
        public void currentState()
        {
            if (CurrentWorker.Working == false)
            { CurrentWorker.startedToWork();
                yt_Button3.Text = "Finish work";
                return; }
            CurrentWorker.finishedToWork();
            yt_Button3.Text = "Start to work";
        }
        public void getCurrentState()
        {
            if (CurrentWorker.Working != false)
            {               
                yt_Button3.Text = "Finish work";
                return;
            }                
            yt_Button3.Text = "Start to work";
        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            GetInfoEmployee getInfoForm = new GetInfoEmployee(CurrentWorker, CurrentEnterprise);
            this.Hide();
            getInfoForm.ShowDialog();



        }

        private void PersonalAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
