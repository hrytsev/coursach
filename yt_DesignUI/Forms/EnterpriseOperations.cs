using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using yt_DesignUI.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace yt_DesignUI.Forms
{
    public partial class EnterpriseOperations : Design
    {
        private Timer timer;
        private Supervisor currentWorker;
        private Enterprise currentEnterprise;
        public EnterpriseOperations(Supervisor worker, Enterprise enterprise)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.currentWorker = worker;
            this.currentEnterprise = enterprise;
            renderLog();
            setComboBox();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label3.Text += DateTime.Now.ToString("HH:mm:ss");
        }

        private void EnterpriseOperations_Load(object sender, EventArgs e)
        {
            label4.Text += currentEnterprise.ContactNumber.ToString();
        }
        public void renderLog()
        {
            
            ChartArea chartArea1 = new ChartArea();
           // chart1.ChartAreas.Add(chartArea1);

            // Создаем новую серию
            Series series1 = new Series();
            chart1.Series.Add(series1);
            series1.ChartType = SeriesChartType.Line;
           List <Employee>  workers = currentEnterprise.returnEmployee();
            float total = 0;
            listBox1.Items.Clear();
            listBox1.Items.Add($"     this month: {DateTime.Now.ToString("MMMM")}");
            foreach (Employee employee in workers)
            {
                listBox1.Items.Add($"{employee.Name} - {employee.Rate*employee.WorkHours} \n");
                total += employee.Rate * employee.WorkHours;
                series1.Points.AddXY(employee.WorkHours,employee.Rate);
            }
            listBox1.Items.Add($"Total: {total}");



            label5.Text = $"Current entrpise has {currentEnterprise.returnEmployee().Count()} workers;";
            int supervisorCount = currentEnterprise.returnEmployee().Count(e => e is Supervisor);
            label6.Text = $"  {supervisorCount} admins;";
            label7.Text = $"salaries:  {total};";
            label8.Text = $"profit:  {total*0.5};";

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            AddNewEnterprise addNew =new  AddNewEnterprise(currentWorker,currentEnterprise);
            this.Hide();
            addNew.ShowDialog();

        }

        private void yt_Button3_Click(object sender, EventArgs e)
        {
            EnterpriseRemoving remove = new EnterpriseRemoving(currentWorker, currentEnterprise);
            this.Hide();
            remove.ShowDialog();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yt_Button4_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
                if (ListManager.getEnterprise().Count >= index)
                {
                    ListManager.changeIndex(index);
                    MessageBox.Show($"Index changed to {index}");

                }
           

        }
        public void setComboBox()
        {
            foreach (Enterprise enter in ListManager.getEnterprise())
            {
                comboBox1.Items.Add(enter.Name);
            }
            comboBox1.SelectedIndex =ListManager.getIndex();


        }
    }

}
