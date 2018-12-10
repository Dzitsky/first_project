using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp6
{
    public class EmployeeManager : IEmployeeManager
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private const string filePath = @"D:\text.txt";

        /// <summary>
        /// Поле для <see cref="Employees"/>
        /// </summary>
        private readonly IList<Employee> employees = new List<Employee>();

        public void AddEmployees()
        {
            var canAddNewEmployees = true;
            while (canAddNewEmployees)
            {
                Console.WriteLine("Введите Ф.И.О.:");
                var name = Console.ReadLine();

                Console.WriteLine("Введите язык программирования:");
                var language = Console.ReadLine();

                Console.WriteLine("Введите возраст:");
                var age = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите номер отдела:");
                var department = int.Parse(Console.ReadLine());

                Console.WriteLine("Зарплата:");
                var salary = int.Parse(Console.ReadLine());

                Console.WriteLine("Должность:");
                var position = Console.ReadLine();

                employees.Add(new Employee(name, language, age, department, salary, position));//Заполняем коллекцию сотрудников

                Console.WriteLine("Добавить нового сотрудника?");
                var cmd = Console.ReadLine();
                if (cmd != "да")
                {
                    canAddNewEmployees = false;
                }
            }
        }

        /// <summary>
        /// Возвращает список сотрудников по указанным параметрам
        /// </summary>
        public IEnumerable<Employee> FindEmployees(string name = null, string language = null,
            int? age = null, int? department = null,
            int? salary = null, string position = null)
        {
            var result = new List<Employee>();
            if (!string.IsNullOrWhiteSpace(name))
            {
               // result.AddRange(employees.Where(employee => employee.Name == name));
                foreach (Employee s in employees)
                {
                    if (s.Name == name)
                    {
                        if (!result.Contains(s))
                        {
                            result.Add(s);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Сохраняет сотрудников в файл.
        /// </summary>
        public void SaveToFile()
        {
            if (employees.Any())
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default))//Записываем в файл
                {
                    foreach (var employee in employees)
                    {
                        sw.WriteLine(employee);
                        sw.WriteLine(new string('-', 50));
                    }

                    employees.Clear();
                }
            }
            else
            {
                Console.WriteLine("Коллекция сотрудников пустая. Нечего сохранять. Добавьте новых сотрудников");
            }
        }

        /// <summary>
        /// Читает из файла сотрудников
        /// </summary>
        public void ReadFromFile()
        {
            using (StreamReader sr = new StreamReader(filePath, Encoding.Default))//Считываем построчно
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
