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
    public partial class WorkersOperations : Design
    {
        private Timer timer;
        private Employee currentWorker;
        private Enterprise currentEnterprise;
        public WorkersOperations(Employee worker, Enterprise enterprise)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.currentWorker = worker;
            this.currentEnterprise = enterprise;
          
            renderInfo();
            renderLog();
        }
        public void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }
        public void renderLog()
        {
            dataGridView1.Rows.Clear();
            currentEnterprise.addToWorkers(currentWorker);
            currentWorker.startedToWork();
         
            List<string> log = currentEnterprise.getLog();
           if(log.Count()==0)
            {
                MessageBox.Show("Log is empty");
                return;
            }    

          


            int rowsCount = log.Count();
            for (int i = rowsCount - 1; i >= 0; i--)
            {
                string wholeText = log[i];
                string[] parts = wholeText.Split('/');

                string name = parts[0];
                string text = parts[1];
                string date = parts[2];

                dataGridView1.Rows.Add();
                int rowIndex = rowsCount - 1 - i; // Найдем правильный индекс строки в dataGridView1
                dataGridView1.Rows[rowIndex].Cells[0].Value = name;
                dataGridView1.Rows[rowIndex].Cells[1].Value = text;
                dataGridView1.Rows[rowIndex].Cells[2].Value = date;
            }


        }
        public void renderInfo()
        {
            label1.Text = currentEnterprise.Name;

            label4.Text += currentEnterprise.ContactNumber.ToString();
        }

        private void WorkersOperations_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
        private void yt_Button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to clear log?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                currentEnterprise.clearLog();
                renderLog();
            }
            return;
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            CloseAllForms();
        }

        private void yt_Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhotoLog photoLogForm = new PhotoLog(currentWorker, currentEnterprise);
            photoLogForm.ShowDialog();
            this.Show();
        }

        private void yt_Button3_Click(object sender, EventArgs e)
        {
            Removing removeWorker = new Removing(currentWorker, currentEnterprise);
            this.Hide();
            removeWorker.ShowDialog();
        }

        private void yt_Button4_Click(object sender, EventArgs e)
        {

        }

        private void yt_Button7_Click(object sender, EventArgs e)
        {
            //AddNew addNew = new AddNew(c)
        }

        private void yt_Button6_Click(object sender, EventArgs e)
        {

        }
    }
}
