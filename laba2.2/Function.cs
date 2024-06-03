using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Net;

namespace laba2._2
{
    internal class Function
    {
        public static void WriteFunctions ()
        {
            Console.WriteLine("1 - Вывести всех сотрудников");
            Console.WriteLine("2 - Добавить нового сотрудника");
            Console.WriteLine("3 - удалить сотрудника");
            Console.WriteLine("4 - отсортировать сотрудников по стажу работу");
            Console.WriteLine("любая другая клавиша - выйти\n");
        }
        public static void AddEmployee (string filename, Employee employee)
        {
            List<Employee> employees = FileWorker.OutPutOnFile(filename);
            bool otvet = true;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].FullName == employee.FullName)
                {
                    if (employees[i].JobTitli != employee.JobTitli)
                    {
                        employees.Remove(employees[i]);
                    }
                    else
                    {
                        Console.WriteLine("Введенный сотрудник уже добавлен\n");
                        otvet = false;
                    }
                }
            }
            if (otvet == true)
            {
                employees.Add(employee);
                Console.WriteLine("Введенный сотрудник успешно добавлен\n");
            }
            string SerializedEmployees = JsonConvert.SerializeObject(employees);
            File.WriteAllText(filename, SerializedEmployees);
        }
        public static void WriteAllEmployees (string filename)
        {
            List<Employee> employees = FileWorker.OutPutOnFile(filename);
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
            if (employees.Count == 0) 
            {
                Console.WriteLine("В данный момент нету сотрудников\n");
            }
        }
        public static void DeleteEmployee(string filename, string FullNameEmployee)
        {
            List<Employee> employees = FileWorker.OutPutOnFile(filename);
            bool otvet = false;
            for (int i = 0; i < employees.Count; i++)
            {
                if (FullNameEmployee == employees[i].FullName)
                {
                    otvet = true;
                }
            }
            if (otvet == true)
            {
                FileWorker.DeleteInFile(filename, FullNameEmployee);
                Console.WriteLine("Введенный сотрудник успешно удален\n");
            }
            else 
            {
                Console.WriteLine("Введенный сотрудник не найден\n");
            }
        }
        public static void SortByDate (string filename)
        {
            List<Employee> employees = FileWorker.OutPutOnFile (filename);
            for (int i = 0; i < employees.Count - 1; i++)
            {
                int min = i;
                for (int j = 1 + i; j < employees.Count; j++)
                {
                    if (Convert.ToDateTime(employees[min].DateSrart) > Convert.ToDateTime(employees[j].DateSrart))
                    {
                        min = j;
                    }
                }
                Employee employee = employees[i];
                employees[i] = employees[min];
                employees[min] = employee;
            }
            string SerializedEmployees = JsonConvert.SerializeObject(employees);
            File.WriteAllText(filename, SerializedEmployees);
            Console.WriteLine("Сотрудники успешно отсортированы\n");
        }
    }
}
