using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    public class Employee
    {
        public Employee(string name, string language, int age, int department, int salary, string position)
        {
            Name = name;
            Language = language;
            Age = age;
            DepartmentNum = department;
            Salary = salary;
            Position = position;
        }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Язык программирования
        /// </summary>
        public string Language { get; set; }

        public int Age { get; set; }
        public int DepartmentNum { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }

        public override bool Equals(object obj)
        {
            var employee = obj as Employee;
            return employee != null &&
                   Name == employee.Name &&
                   Language == employee.Language &&
                   Age == employee.Age &&
                   DepartmentNum == employee.DepartmentNum &&
                   Salary == employee.Salary &&
                   Position == employee.Position;
        }

        public override int GetHashCode()
        {
            var hashCode = -464477449;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Language);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + DepartmentNum.GetHashCode();
            hashCode = hashCode * -1521134295 + Salary.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Position);
            return hashCode;
        }

        /// <summary>
        /// Переопределение для вывода записи в консоли
        /// </summary>
        public override string ToString()
        {
            return string.Format($"ФИО:{Name}\nЯзык программирования:{Language}\nВозраст:{Age}\nНомер отдела:{DepartmentNum}\nЗарплата:{Salary}\nДолжность:{Position}\n");
        }
    }
}
