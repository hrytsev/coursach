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
    public partial class AddNewEnterprise : Design
    {
        private Timer timer;
        private Supervisor currentWorker;
        private Enterprise currentEnterprise;
        private bool confirm;
        private bool admin;
        public AddNewEnterprise(Supervisor worker, Enterprise enterprise)
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
            label4.Text += currentEnterprise.ContactNumber.ToString();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }

        private void AddNewEnterprise_Load(object sender, EventArgs e)
        {

        }
        public void renderButtonOrNot()
        {
            if (confirm)
                yt_Button2.Visible = true;
            else
                yt_Button2.Visible = false;

        }
        public void addNew()
        {
            string name = egoldsGoogleTextBox1.Text.ToString();
            string rules = egoldsGoogleTextBox2.Text.ToString();
            int contactNumber = int.Parse( egoldsGoogleTextBox3.Text);
            Enterprise newEntr = new Enterprise(name, rules, new List<string>(), contactNumber, new List<Employee>());
            ListManager.addNewEnterprise(newEntr);
            MessageBox.Show($"Enterpise {name} added succesfully");
            this.Close();
        }
        private void yt_Button2_Click(object sender, EventArgs e)
        {
            addNew();
        }

        private void egoldsGoogleTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (egoldsGoogleTextBox1.Text == "" || egoldsGoogleTextBox2.Text == "" || egoldsGoogleTextBox3.Text == "")
            {
                confirm = false;
            }
            else if (int.TryParse(egoldsGoogleTextBox3.Text, out int intValue))
                confirm = true;
            renderButtonOrNot();

        }

        private void egoldsGoogleTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (egoldsGoogleTextBox1.Text == "" || egoldsGoogleTextBox2.Text == "" || egoldsGoogleTextBox3.Text == "" )
            {
                confirm = false;
            }
            else
                confirm = true;
            renderButtonOrNot();
        }

        private void egoldsGoogleTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (egoldsGoogleTextBox1.Text == "" || egoldsGoogleTextBox2.Text == "" || egoldsGoogleTextBox3.Text == "")
            {
                confirm = false;
            }
            else
                confirm = true;
            renderButtonOrNot();
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
