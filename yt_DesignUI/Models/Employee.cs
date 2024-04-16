using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yt_DesignUI.Models
{
    public class Employee
    {
        private DateTime lastStartTime;
        public Employee(string _name, DateTime _birthday, int _id, float _rate,string position)
        {
            this.name = _name;
            this.birthday = _birthday;
            this.id = _id;
            this.rate = _rate;
            this.position = position;
            this.inbox = new List<string>();
          this.lastStartTime = DateTime.MinValue; // Устанавливаем начальное значение времени последнего начала работы
        }
        protected bool isChecked=true;
        protected string name;
        protected DateTime birthday;
        protected int id;
        protected float rate;
        protected bool working = false;
        protected string position;
        protected float workHours =0;
        protected List<string> inbox;

        public delegate void EmployeeStateChangedHandler( Employee currentWorker);
        public event EmployeeStateChangedHandler EmployeeStateChanged;
        public bool IsChecked
        {
        
            get { return isChecked; }
        protected set
            {
                isChecked = value;
            }
        }
        public List<string> Inbox
        {
            get { return inbox; }
           
        }

        public float WorkHours
        {
            get { return (int)workHours; }
            protected set {
                if (value < 0)
                    return;
                workHours += value;
            }

        }
        public string Position
        {
            get { return position; }
          protected  set { position = value; }


        }
        public bool Working
        {
            get { return working; }
             protected set { working = value; }

        }
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            protected set { birthday = value; }
        }
        public int ID
        {
            get { return id; }
            protected set { id = value; }
        }
        public float Rate
        {
            get { return rate; }
            protected set
            {
                if (value < 0)
                    rate = 0;
                rate = value;
            }
        }
          
        public void startedToWork()
        {
            if (!working)
            {
                working = true;
                lastStartTime = DateTime.Now; 
                EmployeeStateChanged?.Invoke(this);
            }
          
        }
        public void finishedToWork()
        {
            if (working)
            {
                working = false;
                TimeSpan workedHours = DateTime.Now - lastStartTime;
                workHours += (float)workedHours.TotalHours;
                EmployeeStateChanged?.Invoke(this);
            }
        }
       public void changePosition(string newPos)
        {
            Position = newPos;
        }

        public void clearHours()
        {
            WorkHours = 0;
        }
        public void addToInbox(string message)
        {
            inbox.Add(message);
            IsChecked = false;
        }
        public void clearInbox()
        {
            inbox.Clear();
        }
        public void toChecked()
        {
            IsChecked = true;
        }
        public void changeName(string newName)
        {
            Name = newName;
        }
        public void changePositon(string newPosition)
        {
            Position = newPosition;
        }
        public void changeRate(float newRate)
        {
            Rate = newRate;
        }
        public void changeID(int newID)
        {
            ID = newID;
        }
    }
}
