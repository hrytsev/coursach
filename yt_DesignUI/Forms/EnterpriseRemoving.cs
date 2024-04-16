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
    public partial class EnterpriseRemoving : Design
    {
        private Timer timer;
        private Supervisor currentWorker;
        private Enterprise currentEnterprise;
        public EnterpriseRemoving(Supervisor worker, Enterprise enterprise)
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

            ListManager.addNewEnterprise(currentEnterprise);
            foreach (Enterprise entr in ListManager.getEnterprise())
            {
                comboBox1.Items.Add(entr.Name);
            }
            comboBox1.SelectedIndex = 0;

        }
        public void removeEnerprise ()
        {
            ListManager.removeEnterpriseAt(comboBox1.SelectedIndex);
        }

        private void EnterpriseRemoving_Load(object sender, EventArgs e)
        {

        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to PERMONENTLY REMOVE this enterpirse? Changes will apply after reloading", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                removeEnerprise();
                MessageBox.Show($"Enterprise was removed.", "Removed succefully", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
                yt_Button2.Visible = false;
            else yt_Button2.Visible = true;
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
                yt_Button2.Visible = false;
            else yt_Button2.Visible = true;
        }
    }
}
