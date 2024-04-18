using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yt_DesignUI.Models;

namespace yt_DesignUI.Forms
{
    public partial class Editing : Design
    {
        private Timer timer;
        private Supervisor currentWorker;
        private Enterprise currentEnterprise;
        public Editing(Supervisor worker, Enterprise enterprise)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.currentWorker = worker;
            this.currentEnterprise = enterprise;
            renderInfo();
            setComboBox();
        }
        public void renderInfo()
        {
            ListManager.addNewEmployee(currentWorker);
            label6.Text =
                //ListManager.getEmployeers().Count().ToString();
                "EDITING";
            label3.Text += currentEnterprise.ContactNumber.ToString();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }
        public void setComboBox()
        {
            currentEnterprise.addToWorkers(currentWorker);
            foreach (Employee worker in currentEnterprise.returnEmployee())
            {
                comboBox1.Items.Add(worker.Name);
            }
            comboBox1.SelectedIndex = 0;
            
           
        }

        private void Editing_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                yt_Button2.Visible = false;
                label5.Visible = true;
            }
            else
            {
                yt_Button2.Visible = true;
                label5.Visible = false;
            }
        }


        private void yt_Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to edit this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                editEmployee();
            }
            else
                return;

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                yt_Button2.Visible = false;
                label5.Visible = true;
            }
            else
            {
                yt_Button2.Visible = true;
                label5.Visible = false;
            }
        }
        public void editEmployee()
        {
            if (egoldsGoogleTextBox1.Text == "" || egoldsGoogleTextBox2.Text == "" || egoldsGoogleTextBox3.Text == "" || egoldsGoogleTextBox4.Text == "")
            {
                MessageBox.Show("Enter new data!");
                return;
            }
            string newName = egoldsGoogleTextBox1.Text;
            string newPosition = egoldsGoogleTextBox2.Text;
            float newRate = float.Parse(egoldsGoogleTextBox3.Text);
            int newID = int.Parse( egoldsGoogleTextBox4.Text);
            bool admin = false;
            DateTime selectedDate = dateTimePicker1.Value;
            if (egoldsToggleSwitch1.Checked)
                admin = true;
            if (admin) { 
            Employee editingWorker= currentEnterprise.returnEmployee()[comboBox1.SelectedIndex];
            currentWorker.editEmployye(editingWorker, newName, newPosition, newRate, newID);
                this.Close();
                return;
            }
            currentEnterprise.removeAtWorkers(comboBox1.SelectedIndex);
           // Supervisor newSuper = new Supervisor(newName, selectedDate, newID, newRate, newPosition);
          //  currentEnterprise.addToWorkers(newSuper);

            this.Close();



        }

        private void egoldsGoogleTextBox3_TextChanged(object sender, EventArgs e)
        {
            string currentText = egoldsGoogleTextBox3.Text;
            if (float.TryParse(currentText, out float floatValue))
            {
                yt_Button2.Visible = true;
                return;
            }
            else if(currentText!="")
            {
                yt_Button2.Visible = false;
                MessageBox.Show("Invalid input. Please enter a valid floating-point number.");
                egoldsGoogleTextBox3.Text = "";
            }
        }

        private void egoldsGoogleTextBox4_TextChanged(object sender, EventArgs e)
        {
           
            string currentText = egoldsGoogleTextBox4.Text;
            if (currentText.Length == 7)
            {
            
                yt_Button2.Visible = true;
                return;
            }
            if (int.TryParse(currentText, out int intValue) && (currentText.Length < 8))
            {
                yt_Button2.Visible = false;
                return;

            }
            else if(currentText!="")
            {
                yt_Button2.Visible = true;
                MessageBox.Show("Invalid input. Please enter a valid int number(7).");
                egoldsGoogleTextBox4.Text = "";
            }
           
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void egoldsGoogleTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void egoldsToggleSwitch1_CheckedChanged(object sender)
        {
            
        }
    }
}
