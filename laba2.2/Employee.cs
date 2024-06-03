using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2._2
{
    internal class Employee
    {
        public string FullName { get; set; }
        public int NumberDepartment { get; set; }
        public string JobTitli { get; set; }
        public string DateSrart { get; set; }
        public Employee(string fullName, int numberDepartment, string jobTitli, string dateSrart)
        {
            FullName = fullName;
            NumberDepartment = numberDepartment;
            JobTitli = jobTitli;
            DateSrart = dateSrart;
        }
        public override string ToString()
        {
            string str = "";
            str += "ФИО " + FullName + '\n';
            str += "Номер отдела " + NumberDepartment + '\n';
            str += "Должность " + JobTitli + '\n';
            str += "дата начала работы " + DateSrart + '\n';
            return str;
        }
        public static Employee AddEmployee()
        {
            Console.WriteLine("Введите ФИО сотрудника : ");
            string FullName = Console.ReadLine();
            Console.WriteLine("Введите номер отдела сотрудника : ");
            int NumberDepartment = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите должность сотрудника : ");
            string JobTitle = Console.ReadLine();
            Console.WriteLine("Введите дату когда сотрудник начал работать : ");
            bool key;
            string DateStart;
            do
            {
                key = true;
                DateStart = Console.ReadLine();
                if (DateStart.Length == 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (Char.IsDigit(DateStart[i]))
                        {
                            if (i == 1)
                            {
                                string day = Convert.ToString(DateStart[i - 1]) + Convert.ToString(DateStart[i]);

                                if (Convert.ToInt32(day) > 31 || Convert.ToInt32(day) < 0)
                                {
                                    Console.WriteLine("Введенная строка не является датой !!!");
                                    key = false;
                                    break;
                                }
                            }
                            if (i == 4)
                            {
                                string month = Convert.ToString(DateStart[i - 1]) + Convert.ToString(DateStart[i]);
                                if (Convert.ToInt32(month) > 12 || Convert.ToInt32(month) < 0)
                                {
                                    Console.WriteLine("Введенная строка не является датой !!!");
                                    key = false;
                                    break;
                                }
                            }
                        }
                        else if (i == 2 || i == 5)
                        {
                            if (DateStart[i] != '.')
                            {
                                Console.WriteLine("Введенная строка не является датой !!!");
                                key = false;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Введенная строка не является датой !!!");
                            key = false;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Введенная строка не является датой !!!");
                    key = false;
                }
            } while (key == false);
            Employee employee = new Employee(FullName, NumberDepartment, JobTitle, DateStart);
            return employee;
        }
    }
}
