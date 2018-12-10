using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp6 // Переименовать неймспейс
{
    public class EmployeeManager : IEmployeeManager // Реализовать новый интерфейс (см. замечания к IEmployeeManager), для методов, которые еще не реализованы, добавить пока заглушки
    {
        // Тут xml-комментарии не нужны, к тому же это private поле и не будет видно извне
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private const string filePath = @"D:\text.txt";

        // То же самое
        /// <summary>
        /// Поле для <see cref="Employees"/>
        /// </summary>
        private readonly IList<Employee> employees = new List<Employee>();

        //TODO: Переделать по новому интерфейсу, вынести все обращения к Console в class Program (а все обращения к файлу (sw/rw), в идеале, в новый класс EmployeeRepository c интерфейсом IEmployeeRepository)
        
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
            int? salary = null, string position = null) // TODO: Тут явно напрашивается класс-фильтр )
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

        // TODO: А эти два метода просятся в IEmployeeRepository
        
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
