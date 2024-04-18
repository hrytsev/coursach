using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yt_DesignUI.Models
{
    public class Supervisor : Employee
    {

        public Supervisor(bool isChecked, List<string> inbox, float workHours, string position, bool working, string name, DateTime birthday, int id, float rate,DateTime lastStartTime)
                : base(isChecked, inbox, workHours, position, working, name, birthday, id, rate,lastStartTime)
        {
        }

        public void removeEmployeeAt(int index)
        {
            ListManager.removeEmployeeAt(index);
        }
       
        public void crеateAndAddNewEmployee(string _name, DateTime _birthday, int _id, float _rate,string _position)
        {
            Employee NewEmployee = new Employee(true,new List<string>(), 0, _position, false,_name,_birthday,_id,_rate,DateTime.Now);
            ListManager.addNewEmployee(NewEmployee);
        }
        public void crеateAndAddNewSupervisor(string _name, DateTime _birthday, int _id, float _rate, string _position)
        {
            Supervisor NewSupervisor = new Supervisor(true, new List<string>(), 0, _position, false, _name, _birthday, _id, _rate,DateTime.Now); ;
            ListManager.addNewEmployee(NewSupervisor);
        }
        public void editEmployye(Employee currentWorker,string newName,string newPosition, float newRate,int newId)
        {
            currentWorker.changeName(newName);
            currentWorker.changePosition(newPosition);
            currentWorker.changeRate(newRate);
            currentWorker.changeID(newId);
        }
    }
}
