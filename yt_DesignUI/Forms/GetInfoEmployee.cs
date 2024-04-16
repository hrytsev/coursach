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
    public partial class GetInfoEmployee : Design
    {
        private Timer timer;
        private Employee currentWorker;
        private Enterprise currentEnterprise;
        
        public GetInfoEmployee(Employee worker, Enterprise enterprise)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.currentWorker = worker;
            this.currentEnterprise = enterprise;
           
            renderInfo();
            renderText();
            generateOrNotNew();
        }
      public void generateOrNotNew()
        {
            if (currentWorker.IsChecked)
            {
                yt_Button4.Visible = false;
                return;
            }
            yt_Button4.Visible = true;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }
        public void renderInfo()
        {
            label1.Text = currentEnterprise.Name;
         
            label4.Text += currentEnterprise.ContactNumber.ToString();
            string textToDisplay;
            bool isSupervior;

            
            if (currentWorker.GetType().ToString() != "yt_DesignUI.Models.Supervisor")
            {
                yt_Button5.Visible = false;
                yt_Button6.Visible = false;
            }
        }
        public void renderText()
        {
            label5.Text = $"Hello {currentWorker.Name}.Your position in our team is {currentWorker.Position}. We \nappreciatethat work mate. This month you did  \ngreat work. You will get a salary \n in the end of the month, it would be about\n $“{currentWorker.WorkHours*currentWorker.Rate}”";

            if (currentWorker.GetType().ToString() == "yt_DesignUI.Models.Supervisor")
            {
                label3.Text += "\n Dear Admin";
            }
        }
        private void GetInfoEmployee_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void yt_Button3_Click(object sender, EventArgs e)
        {
            Inbox inboxForm = new Inbox(currentWorker, currentEnterprise);
            this.Hide();
            inboxForm.ShowDialog();
            this.Show();
            currentWorker.toChecked();
            generateOrNotNew();

        }

        private void yt_Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            WorkersOperations workersOperatonsForm = new WorkersOperations(currentWorker, currentEnterprise);
            workersOperatonsForm.ShowDialog();
            this.Show();
        }

        private void yt_Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Supervisor currentSupervisor = currentWorker as Supervisor;
            if (currentSupervisor != null)
            {
                EnterpriseOperations entrop = new EnterpriseOperations(currentSupervisor, currentEnterprise);
                entrop.ShowDialog();
            }
            else
            {
                // Обработка ситуации, если currentWorker не является Supervisor
                MessageBox.Show("Critical security error.");
            }
            this.Show();
        }
    }
}
