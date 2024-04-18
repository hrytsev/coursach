using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using yt_DesignUI.Models;

namespace yt_DesignUI.Forms
{
    public partial class AddNew : Design
    {
        private Timer timer;
        private Supervisor currentWorker;
        private Enterprise currentEnterprise;
        private bool confirm;
        private bool admin;
        public AddNew( Supervisor worker, Enterprise enterprise)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.currentWorker = worker;
            this.currentEnterprise = enterprise;
            this.confirm = false;
            this.admin = false;
            renderInfo();
        }
        public void renderInfo()
        {
            label6.Text =
                //ListManager.getEmployeers().Count().ToString();
                "Adding";
            label3.Text += currentEnterprise.ContactNumber.ToString();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }

        private void AddNew_Load(object sender, EventArgs e)
        {

        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void addNew()
        {
            string newName = egoldsGoogleTextBox1.Text.ToString();
            string newPosition = egoldsGoogleTextBox2.Text.ToString();
            float newRate = float.Parse(egoldsGoogleTextBox3.Text);
            int newID = int.Parse(egoldsGoogleTextBox4.Text);
            DateTime selectedDate = dateTimePicker1.Value;
            if (admin)
            {
                Supervisor super = new Supervisor(true, new List<string>(), 0, newPosition, false, newName, selectedDate, newID, newRate, DateTime.Now); 
                currentEnterprise.addToWorkers(super);
                ListManager.addNewEmployee(super);
                MessageBox.Show("Admin " +newName+ " was added succesfully");
                this.Close();
            }
            else
            {
                Employee employee = new Employee(true, new List<string>(), 0, newPosition, false, newName, selectedDate, newID, newRate,DateTime.Now);
                currentEnterprise.addToWorkers(employee);
                MessageBox.Show("Worker " + newName + " was added succesfully");
                ListManager.addNewEmployee(employee);
                this.Close();
            }

        }
        private void yt_Button2_Click(object sender, EventArgs e)
        {
            addNew();
        }

        private void egoldsGoogleTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (egoldsGoogleTextBox1.Text == "" || egoldsGoogleTextBox2.Text == "" || egoldsGoogleTextBox3.Text == "" || egoldsGoogleTextBox4.Text == "")
            {
                confirm = false;
            }
            else
                confirm = true;
            renderButtonOrNot();
        }

        private void egoldsGoogleTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (egoldsGoogleTextBox1.Text == "" || egoldsGoogleTextBox2.Text == "" || egoldsGoogleTextBox3.Text == "" || egoldsGoogleTextBox4.Text == "")
            {
                confirm = false;
            }
            else
                confirm = true;
            renderButtonOrNot();
        }

        private void egoldsGoogleTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (egoldsGoogleTextBox1.Text == "" || egoldsGoogleTextBox2.Text == "" || egoldsGoogleTextBox3.Text == "" || egoldsGoogleTextBox4.Text == "")
            {
                confirm = false;
            }
            else if(float.TryParse(egoldsGoogleTextBox3.Text, out float intValue))
                confirm = true;
            renderButtonOrNot();
        }

        private void egoldsGoogleTextBox4_TextChanged(object sender, EventArgs e)
        {
            if(egoldsGoogleTextBox4.Text.Length>7)
            {
                MessageBox.Show("Invalid input. Please enter 7 numbers.");
                egoldsGoogleTextBox4.Text = egoldsGoogleTextBox4.Text.Substring(0, 7);
            }    
            if (egoldsGoogleTextBox1.Text == "" || egoldsGoogleTextBox2.Text == "" || egoldsGoogleTextBox3.Text == "" || egoldsGoogleTextBox4.Text == "" || (egoldsGoogleTextBox4.Text.Length != 7))
                
            {
                confirm = false;
            }
            else if(int.TryParse(egoldsGoogleTextBox4.Text, out int intValue))
                confirm = true;
            renderButtonOrNot();
        }

        private void egoldsToggleSwitch1_CheckedChanged(object sender)
        {
            if (egoldsToggleSwitch1.Checked)
                admin = true;
            else
                admin = false;
        }
        public void renderButtonOrNot()
        {
            if (confirm)
                yt_Button2.Visible = true;
            else
                yt_Button2.Visible = false;

        }
        private void egoldsGoogleTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void egoldsGoogleTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void egoldsGoogleTextBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
