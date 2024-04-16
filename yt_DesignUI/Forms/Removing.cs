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
    public partial class Removing : Design
    {
        private Timer timer;
        private Employee currentWorker;
        private Enterprise currentEnterprise;
        public Removing(Employee worker, Enterprise enterprise)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.currentWorker = worker;
            this.currentEnterprise = enterprise;
            setComboBox();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }

        public void setComboBox()
        {
            label4.Text += currentEnterprise.ContactNumber;

            currentEnterprise.addToWorkers(currentWorker);
            foreach(Employee workerToRemove in currentEnterprise.returnEmployee())
            {
                comboBox1.Items.Add(workerToRemove.Name);
            }
            comboBox1.SelectedIndex = 0;

        }
        private void Removing_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
                yt_Button2.Visible = false;
            else yt_Button2.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
                yt_Button2.Visible = false;
            else yt_Button2.Visible = true;
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void removeWorker()
        {
            currentEnterprise.removeAtWorkers(comboBox1.SelectedIndex);
        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to PERMONENTLY REMOVE this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                removeWorker();
                MessageBox.Show($"User was removed.", "Removed succefully", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
