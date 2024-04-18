using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace yt_DesignUI.Models
{
    internal static class ListManager
    {
        private static List<Enterprise> enterpriseList = new List<Enterprise>();
        private static int currentEnterpriseIndex=0;
       
        public static void changeIndex(int index)
        {
            currentEnterpriseIndex = index;
        }
        
       
        public static List<Enterprise> getEnterprise()
        {
            return enterpriseList;
        }

        public static int getIndex()
        {
            return currentEnterpriseIndex;
        }

        

       

        public static void addNewEnterprise(Enterprise enterprise)
        {
            enterpriseList.Add(enterprise);
        }

      

        

        public static void removeEnterpriseAt(int index)
        {
            if (index < 0 || index >= enterpriseList.Count)
                return;
            enterpriseList.RemoveAt(index);
        }
        public static void SerializeData(string filePath)
        {
            var serializedEnterpriseList = new List<object>();
            foreach (var enterprise in enterpriseList)
            {
                var enterpriseData = new
                {
                    Name = enterprise.Name,
                    Rules = enterprise.Rules,
                    Log = enterprise.Log,
                    ContactNumber = enterprise.ContactNumber,
                    Employeers = enterprise.Employeers.Select(e => new { Type = e.GetType().FullName, Data = e }).ToList()
                };

                serializedEnterpriseList.Add(enterpriseData);
            }

            var data = new
            {
                EnterpriseList = serializedEnterpriseList,
                CurrentEnterpriseIndex = currentEnterpriseIndex
            };

            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }




        private static object AddTypeInformation<T>(T data)
        {
            return new
            {
                Type = data.GetType().FullName,
                Data = data
            };
        }
        public static void DeserializeData(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var data = JsonConvert.DeserializeObject<dynamic>(json);
                enterpriseList.Clear(); 

                foreach (var enterpriseData in data.EnterpriseList)
                {
                    var employeersData = enterpriseData.Employeers;
                    var employeersList = new List<Employee>();

                    foreach (var employeeData in employeersData)
                    {
                        var employeeTypeString = (string)employeeData.Type;
                        var dataType = Type.GetType(employeeTypeString);
                        
                        Employee employee = null;
                        var employeeJson = employeeData.Data.ToString();
                        switch ((string)employeeData.Type)
                        {
                            case "yt_DesignUI.Models.Employee":
                                employee = JsonConvert.DeserializeObject<Employee>(employeeJson);
                                break;
                            case "yt_DesignUI.Models.Supervisor":
                                employee = JsonConvert.DeserializeObject<Supervisor>(employeeJson);
                                break;
                            // Добавьте другие кейсы для других типов сотрудников, если они есть
                            default:
                                // Обработка неизвестного типа сотрудника, если это необходимо
                                break;
                        }

                        employeersList.Add(employee);
                    }

                    var enterprise = new Enterprise(
                          enterpriseData.Name.ToString(), 
                         enterpriseData.Rules.ToString(),
                        JsonConvert.DeserializeObject<List<string>>(enterpriseData.Log.ToString()), 
                         Convert.ToInt32(enterpriseData.ContactNumber), 
                       employeersList 
);


                    enterpriseList.Add(enterprise);
                }

                currentEnterpriseIndex = data.CurrentEnterpriseIndex;
            }
        }


    }

}

