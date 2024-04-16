using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yt_DesignUI.Models;

namespace yt_DesignUI.Forms
{
    public partial class StartOrFinishWorking : Design
    {
        private Timer timer;
        private Employee currentWorker;
        private Enterprise currentEnterprise;
        private bool working;
        private bool isCamera;
        public StartOrFinishWorking(Employee worker, Enterprise enterprise,bool _working,bool _isCamera)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.currentWorker = worker;
            this.currentEnterprise = enterprise;
            this.working = _working;
            this.isCamera = _isCamera;
            renderInfo();
            
        }
        public void renderInfo()
        {
            label1.Text += currentWorker.Name;
            label1.Text = currentEnterprise.Name;
            label3.Text += currentEnterprise.ContactNumber.ToString();
            string textToDisplay;
            if (working)
            textToDisplay = $"Worker {currentWorker.Name} started to work. \nHave a nice day!";
            else
                textToDisplay= $"Worker {currentWorker.Name} finished. Thank you!";
            label5.Text = textToDisplay;
            if (isCamera)
                renderPhoto();
            else
                renderNonePhoto();

            
           

        }
        public void renderNonePhoto()
        {

            string imagePath = Path.Combine(Application.StartupPath, "photos", "none.png");
            pictureBox2.Image = Image.FromFile(imagePath);

        }
        public void renderPhoto()
        {
            
            string photosPath = Path.Combine(Application.StartupPath, "photos");

            if (!Directory.Exists(photosPath))
            {
                MessageBox.Show("Папка с фотографиями не найдена.");
                return;
            }

          
            string[] photoFiles = Directory.GetFiles(photosPath);

           
            if (photoFiles.Length == 0)
            {
                MessageBox.Show("Нет фотографий для отображения.");
                return;
            }

            var sortedFiles = photoFiles.Select(file => new FileInfo(file))
                                         .OrderByDescending(fileInfo => fileInfo.LastWriteTime)
                                         .ToList();

            string latestPhotoPath = sortedFiles.First().FullName;

            pictureBox2.Image = Image.FromFile(latestPhotoPath);




        }
        private void StartOrFinishWorking_Load(object sender, EventArgs e)
        {

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            CloseAllForms();
           
        }
        public static void CloseAllForms()
        {
            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();

            foreach (Form form in forms)
            {

                if (form.GetType() != typeof(Entrance))
                {
                    // Закрываем форму, если она не является формой Entrance
                    form.Close();
                }
            }
        }
        private void yt_Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
