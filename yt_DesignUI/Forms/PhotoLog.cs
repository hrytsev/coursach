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
    public partial class PhotoLog : Design
    {
        private Timer timer; 
        private Employee currentWorker;
        private Enterprise currentEnterprise;
        public PhotoLog(Employee worker, Enterprise enterprise)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.currentWorker = worker;
            this.currentEnterprise = enterprise;
            renderInfo();
            string imagePath = Path.Combine(Application.StartupPath, "photos", "none.png");
            pictureBox2.Image = Image.FromFile(imagePath);
            label5.Text = "";
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }
        public void renderInfo()
        {
            label1.Text = currentEnterprise.Name;
            label4.Text = currentEnterprise.ContactNumber.ToString();
        }

            private void PhotoLog_Load(object sender, EventArgs e)
        {

        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
        public void photoPreview()
        {
            string currentDirectory = Environment.CurrentDirectory;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.IO.Path.Combine(currentDirectory, "photos");
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                pictureBox2.ImageLocation = selectedFilePath;
                generateSign(selectedFilePath);
            }
            else
            { MessageBox.Show("Photo wasn`t choosen");
                string imagePath = Path.Combine(Application.StartupPath, "photos", "none.png");
                pictureBox2.Image = Image.FromFile(imagePath);

            }
        }
        public void generateSign(string path)
        {
            string fileName = Path.GetFileName(path);
            string data = fileName;
            string[] dataArray = data.Split('_');
            string[] dateParts = dataArray[3].Split('j');
            label5.Text = $"At {dataArray[0]} worker {dataArray[1]} {dataArray[2]} to work at {dateParts[0]}";
        }
        private void yt_Button3_Click(object sender, EventArgs e)
        {
            photoPreview();
            yt_Button3.Text = "Choose again";
        }
    }
}
