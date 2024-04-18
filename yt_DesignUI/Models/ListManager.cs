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
                // Check if the item is an IDictionary
                if (item is IDictionary<string, object>)
                {
                    var dictionary = (IDictionary<string, object>)item;

                    // Check if the type information is present
                    if (dictionary.ContainsKey("Type"))
                    {
                        string typeFullName = dictionary["Type"] as string;
                        Type type = Type.GetType(typeFullName);

                        // Get the actual type of the data using typeof
                        var actualType = typeof(List<>).MakeGenericType(type);

                        // Check if the data is an IEnumerable
                        if (dictionary["Data"] is IEnumerable)
                        {
                            var jsonData = JsonConvert.SerializeObject(dictionary["Data"]); // Serialize data to JSON string
                            var typedData = JsonConvert.DeserializeObject(jsonData, actualType); // Deserialize JSON string to target type
                            resultList.Add((T)Convert.ChangeType(typedData, typeof(T))); // Convert deserialized data to type T and add to result list
                        }
                        else
                        {
                            // Handle the case where the data is not an IEnumerable
                            Console.WriteLine($"Warning: Item[\"Data\"] is not an IEnumerable: {item}");
                        }
                    }
                    else
                    {
                        // Handle the case where type information is missing
                        Console.WriteLine($"Warning: Type information missing for item: {item}");
                    }
                }
                else
                {
                    // Handle the case where the item is not an IDictionary
                    Console.WriteLine($"Warning: Item is not an IDictionary: {item}");
                }
            }
            return resultList;
        }
    }

}

