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
    public partial class Inbox : Design
    {
        private Timer timer;
        private Employee currentWorker;
        private Enterprise currentEnterprise;
        private bool allowedToWrite=false;
        public Inbox(Employee worker, Enterprise enterprise)
        {
            InitializeComponent();

          

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.currentWorker = worker;
            this.currentEnterprise = enterprise;

      

            getPermisionToWrite();
            renderInfo();
      
        }
        public void getPermisionToWrite()
        {
            if (currentWorker.GetType().ToString() == "yt_DesignUI.Models.Supervisor")
                allowedToWrite = true;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }
        public void renderInfo()
        {
            label5.Text = currentEnterprise.Name;
            label3.Text += currentEnterprise.ContactNumber.ToString();

            if (allowedToWrite)
            {
                yt_Button3.Visible = true;
            }
        }

            private void Inbox_Load(object sender, EventArgs e)
              {
            renderInbox();
             }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void renderInbox()
        {
            
            dataGridView1.Rows.Clear();
            if (currentWorker.Inbox.Count == 0)
                return;
          
         
            int rowsCount = currentWorker.Inbox.Count();
            for(int i = 0; i < rowsCount; i++)
            {
               string wholeText = currentWorker.Inbox[i];
                string sender= wholeText.Split('/')[0];

                int forText_1 = wholeText.IndexOf('/'); 
                int forText_2 = wholeText.IndexOf('/', forText_1 + 1); 

                string text = wholeText.Substring(forText_1 + 1, forText_2 - forText_1 - 1);
               
             
                    int forDate = wholeText.IndexOf('/', wholeText.IndexOf('/') + 1); 
                string date = wholeText.Substring(forDate + 1);

                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = sender.ToString();
                dataGridView1.Rows[i].Cells[1].Value = text.ToString();
                dataGridView1.Rows[i].Cells[2].Value = date.ToString();
                    //date.ToString();
                
            }

            dataGridView1.Rows.Add();
           


        }

        private void yt_Button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to PERMANENTLY delete all inboxes?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                currentWorker.clearInbox();
                renderInbox();
            }
         

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

        private void yt_Button3_Click(object sender, EventArgs e)
        {
            WritingNewLetter newLetterForm = new WritingNewLetter(currentWorker, currentEnterprise);
            this.Hide();
            newLetterForm.ShowDialog();
            this.Show();
           
            renderInbox();
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
