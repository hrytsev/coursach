using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace yt_DesignUI.Models
{
    public class Enterprise
    {
        protected string name;
        protected string rules;
        protected List<string> log;
        protected int contactNumber;
        protected List <Employee> employeers;
        public Enterprise(string name, string rules,  List<string> log, int contactNumber, List<Employee> employeers)
        {
            this.name = name;
            this.rules = rules;
            this.contactNumber = contactNumber;
            this.employeers = employeers;
            this.log = log;
        }
        public Enterprise()
        {

        }
        public string Name
        {
            protected set { name = value; }
            get { return name; }
        }
        public string Rules
        {
            protected set { rules = value; }
            get { return rules; }
        }
        public List<string> Log
        {
            protected set { log = value; }
            get { return log; }
        }
        public int ContactNumber
        {
            protected set { contactNumber = value; }
            get { return contactNumber; }
        }
        public List<Employee> Employeers
        {
            protected set { employeers = value; }
            get { return employeers; }
        }




        public List<string> getLog()
        {
            return log;
        }
        public void addStringToLog(string message)
        {
            log.Add(message);
        }

        public void addToWorkers(Employee employee)
        {
            employeers.Add(employee);
            employee.EmployeeStateChanged += OnEmployeeStateChanged;

        }
        public void OnEmployeeStateChanged(Employee employee)
        {
            string logMessage = $"{employee.Name}/{(employee.Working ? "started" : "finished")}/{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}";
            addStringToLog(logMessage);
        }
      public List<Employee> returnEmployee()
        {
            return employeers;
        }

        public void removeAtWorkers(int index)
        {
            employeers.RemoveAt(index);
        }
       public void clearLog()
        {
            log.Clear();
        }
    }
}
