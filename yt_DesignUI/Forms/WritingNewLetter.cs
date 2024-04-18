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

namespace yt_DesignUI.Forms
{
    public partial class WritingNewLetter : Design
    {
        private Timer timer;
        private Employee currentWorker;
        private Enterprise currentEnterprise;
        public WritingNewLetter(Employee worker, Enterprise enterprise)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.currentWorker = worker;
            this.currentEnterprise = enterprise;
            renderInfo();
           
           
            generateComboBox();
            comboBox1.SelectedIndex = 0;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }
        public void renderInfo()
        {
            //ListManager.addNewEmployee(currentWorker);
            label5.Text = 
                //ListManager.getEmployeers().Count().ToString();
                currentEnterprise.Name;
            label3.Text += currentEnterprise.ContactNumber.ToString();
          
        }
        public void generateComboBox()
        {
          
            List<Employee> listOfAll = currentEnterprise.returnEmployee();
            int length = listOfAll.Count();
            foreach (Employee worker in listOfAll)
            {
                comboBox1.Items.Add(worker.Name);
            }



        }
        private void WritingNewLetter_Load(object sender, EventArgs e)
        {

        }

        private void yt_Button3_Click(object sender, EventArgs e)
        {
            if (egoldsToggleSwitch1.Checked)
            
                sendLetterToAll();
            
            else
            sendLetter();
            egoldsGoogleTextBox1.Text = "";
            comboBox1.SelectedIndex = 0;

        }
        public void sendLetterToAll()
        {
            string textToSend = egoldsGoogleTextBox1.Text;
            List<Employee> allWorkers = currentEnterprise.returnEmployee();
            foreach(Employee worker in allWorkers)
            {
                if (worker == currentWorker)
                    continue;
                worker.addToInbox(currentWorker.Name + "/" + textToSend + "/" + DateTime.Now);
            }
        }
        public void sendLetter()
        {
            string textToSend = egoldsGoogleTextBox1.Text;
            int selectedWorkerIndex = comboBox1.SelectedIndex;
            List<Employee> allWorkers = currentEnterprise.returnEmployee();

            DialogResult result = MessageBox.Show($"Are you sure you want to send this letter to {allWorkers[selectedWorkerIndex].Name} ?", "Letter confiramtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                allWorkers[selectedWorkerIndex].addToInbox(currentWorker.Name + "/" + textToSend + "/" + DateTime.Now);
            }
            else
                egoldsGoogleTextBox1.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void yt_Button2_Click(object sender, EventArgs e)
        {
            CloseAllForms();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                yt_Button3.Visible = false;
                label1.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                yt_Button3.Visible = true;
                label1.Visible = false;
            }
        }

        private void egoldsToggleSwitch1_CheckedChanged(object sender)
        {
            if (egoldsToggleSwitch1.Checked)
            {
                comboBox1.Visible = false;
            }
            else
                comboBox1.Visible = true;
        }
    }
}
