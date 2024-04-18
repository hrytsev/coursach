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
        public void addNew(bool isAdmin, bool isChecked, List<string> inbox, float workHours, string position, bool working, string name, DateTime birthday, int id, float rate, DateTime lastStartTime, Enterprise currentEnterprise)
        {
            if (isAdmin)
            {
                Supervisor super = new Supervisor(isChecked, inbox, workHours, position, working, name, birthday, id, rate, lastStartTime);
                currentEnterprise.addToWorkers(super);
            }else
            {
                Employee employee = new Employee(isChecked, inbox, workHours, position, working, name, birthday, id, rate, lastStartTime);
                currentEnterprise.addToWorkers(employee);
            }
        }
        public void remove(Enterprise currentEnterpise,int index)
        {
            currentEnterpise.Employeers.RemoveAt(index);
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
