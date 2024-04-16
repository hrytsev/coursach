using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yt_DesignUI.Models
{
    public class Supervisor : Employee
    {
        
        public Supervisor(string _name, DateTime _birthday, int _id, float _rate,string position) : base(_name, _birthday, _id, _rate, position  )
        {
        }

        public void removeEmployeeAt(int index)
        {
            ListManager.removeEmployeeAt(index);
        }
       
        public void crеateAndAddNewEmployee(string _name, DateTime _birthday, int _id, float _rate)
        {
            Employee NewEmployee = new Employee(_name, _birthday, _id, _rate,position);
            ListManager.addNewEmployee(NewEmployee);
        }
        public void crеateAndAddNewSupervisor(string _name, DateTime _birthday, int _id, float _rate)
        {
            Supervisor NewSupervisor = new Supervisor(_name, _birthday, _id, _rate,position);
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
