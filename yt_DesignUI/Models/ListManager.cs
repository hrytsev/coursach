using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace yt_DesignUI.Models
{
    internal static class ListManager
    {
        private static List<Employee> employeeList = new List<Employee>();      
        private static List<Enterprise> enterpriseList = new List<Enterprise>();
        private static int currentEnterpriseIndex=0;
       
        public static void changeIndex(int index)
        {
            currentEnterpriseIndex = index;
        }
        public static List<Employee> getEmployeers()
        {
            return employeeList;
        }
       
        public static List<Enterprise> getEnterprise()
        {
            return enterpriseList;
        }

        public static int getIndex()
        {
            return currentEnterpriseIndex;
        }

        public static void addNewEmployee(Employee employee)
        {
            employeeList.Add(employee);
        }

       

        public static void addNewEnterprise(Enterprise enterprise)
        {
            enterpriseList.Add(enterprise);
        }

        public static void removeEmployeeAt(int index)
        {
            if (index < 0 || index >= employeeList.Count)
                return;
            employeeList.RemoveAt(index);
        }

        

        public static void removeEnterpriseAt(int index)
        {
            if (index < 0 || index >= enterpriseList.Count)
                return;
            enterpriseList.RemoveAt(index);
        }
        public static void SerializeData(string filePath)
        {
            var data = new
            {
                EmployeeList = AddTypeInformation(employeeList),
                EnterpriseList = AddTypeInformation(enterpriseList),
                CurrentEnterpriseIndex = currentEnterpriseIndex
            };

            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }

        public static void DeserializeData(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var data = JsonConvert.DeserializeObject<dynamic>(json);
                employeeList = RestoreWithTypeInformation<List<Employee>>(data.EmployeeList);
                enterpriseList = RestoreWithTypeInformation<List<Enterprise>>(data.EnterpriseList);
                currentEnterpriseIndex = data.CurrentEnterpriseIndex;
            }
        }
        private static List<object> AddTypeInformation<T>(List<T> dataList)
        {
            List<object> objects = new List<object>();
            foreach (var item in dataList)
            {
                objects.Add(new
                {
                    Type = item.GetType().FullName,
                    Data = item
                });
            }
            return objects;
        }

        private static List<T> RestoreWithTypeInformation<T>(List<object> objects)
        {
            List<T> resultList = new List<T>();
            foreach (var item in objects)
            {
                dynamic dynamicItem = item;
                string typeFullName = dynamicItem.Type;
                Type type = Type.GetType(typeFullName);

                T data = JsonConvert.DeserializeObject<T>(dynamicItem.Data.ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                resultList.Add(data);

            }
            return resultList;
        }

    }
}
