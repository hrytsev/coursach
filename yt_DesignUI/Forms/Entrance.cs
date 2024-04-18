using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yt_DesignUI.Forms;
using yt_DesignUI.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Newtonsoft.Json;
using System.IO;
namespace yt_DesignUI
{
    public partial class Entrance : Form
    {
        public Enterprise currentEnterprise;

        private bool isMouseHeld = false;
        private Timer holdTimer;
        private const int holdThreshold = 500;

        private Timer timer;
        public Entrance()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();


            yt_Button2.Click += Button_Click;
            yt_Button3.Click += Button_Click;
            yt_Button4.Click += Button_Click;
            yt_Button5.Click += Button_Click;
            yt_Button6.Click += Button_Click;
            yt_Button7.Click += Button_Click;
            yt_Button8.Click += Button_Click;
            yt_Button9.Click += Button_Click;
            yt_Button10.Click += Button_Click;


            yt_Button11.Click += Button_Click;

            holdTimer = new Timer();
            holdTimer.Interval = 150; // Интервал таймера - 100 миллисекунд
            holdTimer.Tick += HoldTimer_Tick;
          
            if (true)
            {

                string projectRootPath = Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath));
                string filePath = Path.Combine(projectRootPath, "storage", "temp.json");

                ListManager.DeserializeData(filePath);
            }
            else
            {
                generateStartStuff();
            }

            currentEnterprise = ListManager.getEnterprise()[ListManager.getIndex()];
            
            renderInfo(ListManager.getEnterprise()[ListManager.getIndex()]);

            //label1.Text=
            // Привязываем обработчики событий для кнопки
            //yt_Button12.MouseDown += yt_Button1_MouseDown;
            //yt_Button12.MouseUp += yt_Button1_MouseUp;
            //yt_Button13.Focus();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd") + " ";
            label2.Text += DateTime.Now.ToString("HH:mm:ss");
        }



        private void Entrance_Load(object sender, EventArgs e)
        {



           // generateStartStuff();


        }
        public void generateStartStuff()
        {
            Enterprise enterprise = new Enterprise("Hrytsev!CO!", "wear that shit", 380677454);
            //renderInfo(enterprise);
            this.currentEnterprise = enterprise;
            DateTime myDateTime = new DateTime(2024, 2, 9, 10, 30, 0);
            Employee supervisor = new Employee(true,new List<string>(),0,"geniy",false,"ivan",DateTime.Now,7777777,52,DateTime.Now);
           // Supervisor supervisor2 = new Supervisor("dimas", myDateTime, 7777776, 50, "geniy");
            ListManager.addNewEmployee(supervisor);
            //ListManager.addNewEmployee(supervisor2);
            ListManager.addNewEnterprise(enterprise);
            ListManager.addNewEnterprise(enterprise);
            ListManager.addNewEnterprise(enterprise);
        }
        private void renderInfo(Enterprise enterprise)
        {
            label1.Text = enterprise.Name ;
            egoldsCard1.TextDescrition = enterprise.Rules;
            label3.Text = enterprise.ContactNumber.ToString();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            string inputText = yt_Button12.Text;
            if (inputText.Length == 7)
                return;

            if (sender is System.Windows.Forms.Button clickedButton)
            {
                yt_Button12.Text += clickedButton.Text;
            }
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            removeOne();

        }

        private void yt_Button1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseHeld = true;
            holdTimer.Start();
        }
        private void HoldTimer_Tick(object sender, EventArgs e)
        {
            if (isMouseHeld && yt_Button12.Text.Length > 0)
            {



                yt_Button12.Text = yt_Button12.Text.Remove(yt_Button12.Text.Length - 1);
                // Продолжаем удалять символы каждые 100 миллисекунд,
                // пока кнопка не будет отпущена
            }
            else
            {
                holdTimer.Stop(); // Останавливаем таймер, если кнопка отпущена
            }
        }

        private void yt_Button1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseHeld = false;
            holdTimer.Stop();
        }

        private void yt_Button13_Click(object sender, EventArgs e)
        {
            goNext();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void goNext()
        {
            string inputText = yt_Button12.Text;
            if (inputText == "")
            {
                MessageBox.Show("Enter ID!");
                return;
            }
            foreach (Employee super in ListManager.getEmployeers())
            {

                if (inputText.ToString() == super.ID.ToString())
                {
                    PersonalAccount personalAccount = new PersonalAccount(super, currentEnterprise);
                    yt_Button12.Text = "";
                    this.Hide();
                    personalAccount.ShowDialog();
                    this.Show();

                    return;
                }
            }

            NoResults noRes = new NoResults(label1.Text, int.Parse(label3.Text), inputText);
            this.Hide();
            noRes.ShowDialog();

            this.Show();

            yt_Button12.Text = "";


        }
        private void removeOne()
        {
            string inputText = yt_Button12.Text;
            if (inputText.Length > 0)
                yt_Button12.Text = yt_Button12.Text.Remove(yt_Button12.Text.Length - 1);
        }

        private void Entrance_KeyUp(object sender, KeyEventArgs e)
        {




        }

        private void yt_Button3_Click(object sender, EventArgs e)
        {

        }

        private void Entrance_KeyDown(object sender, KeyEventArgs e)
        {

            string inputText = yt_Button12.Text;
            if (inputText.Length == 7)
                return;

            // Обрабатываем только цифровые клавиши, кроме клавиши Enter
            
            // Добавляем текст нажатой клавиши к тексту кнопки yt_Button12 только если это не клавиша Enter
            else if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                yt_Button12.Text += (char)e.KeyCode;
            }
        }
        

        private void Entrance_FormClosing(object sender, FormClosingEventArgs e)
        {
            string projectRootPath = Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath));
            string filePath = Path.Combine(projectRootPath, "storage",  "temp.json");
            ListManager.SerializeData(filePath);
        }
    }
    }

