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
    public partial class NoResults : Form
    {
        private Timer timer;
        public string name;
        public int contact;
        public string notFoundName;
        public NoResults(string _name,int _contact,string _notFoundName)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.name = _name;
            this.contact = _contact;
            this.notFoundName = _notFoundName;
            renderInfo();
            System.Media.SystemSounds.Asterisk.Play();
        }

        public void renderInfo()
        {
            label1.Text = name;
            label3.Text += contact;
            label4.Text = "Account " + notFoundName + " didn`t found \n please try again";
        }

        private void NoResults_Load(object sender, EventArgs e)
        {

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}
