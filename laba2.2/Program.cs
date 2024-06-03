using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FileName = "C:\\Users\\belos\\source\\repos\\laba2.2\\Employees.json";
            while (true) 
            {
                Function.WriteFunctions();
                string key = Console.ReadLine();
                if (key == "1") 
                {
                    Function.WriteAllEmployees(FileName);
                }
                else if (key == "2") 
                {
                    Employee employee = Employee.AddEmployee();
                    Function.AddEmployee(FileName, employee);
                }
                else if (key == "3")
                { 
                    Console.Write("Введите ФИО сотрудника : ");
                    string FullName = Console.ReadLine();
                    Function.DeleteEmployee(FileName, FullName);
                }
                else if (key == "4")
                {
                    Function.SortByDate(FileName);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
