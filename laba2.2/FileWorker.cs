using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace laba2._2
{
    internal class FileWorker
    {
        public static void InputInFile (string filename , Employee employee)
        {
            List<Employee> employees = OutPutOnFile(filename);
            employees.Add(employee);
            string SerializedEmployees = JsonConvert.SerializeObject(employees);
            File.WriteAllText(filename, SerializedEmployees);
        }
        public static List<Employee> OutPutOnFile (string filename)
        {
            string FileJson = File.ReadAllText (filename);
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(FileJson);
            if (employees != null)
            {
                return employees;
            }
            else
            {
                return new List<Employee> ();
            }
        }
        public static void DeleteInFile(string filename, string FullNameEmployee)
        {
            List<Employee> employees = FileWorker.OutPutOnFile(filename);
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].FullName == FullNameEmployee)
                {
                    employees.Remove(employees[i]);
                }
            }
            string SerializedEmployees = JsonConvert.SerializeObject(employees);
            File.WriteAllText(filename, SerializedEmployees);
        }
    }
}
