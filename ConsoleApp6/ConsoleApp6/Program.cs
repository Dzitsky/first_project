using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;//обобщенные коллекции
using System.IO;

namespace ConsoleApp6
{
    public class Employee
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public uint Age { get; set; }
        public int Num_department { get; set; }
        public uint Salary { get; set; }
        public string Position { get; set; }
        public Employee(string name,string language, uint age, int department, uint salary, string position)
        {
            Name = name;
            Language = language;
            Age = age;//задали конструктор
            Num_department = department;
            Salary = salary;
            Position = position;
        }
        public override string ToString()//без этого форматирования выводит название проекта
        {
            return string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}", $"ФИО: {Name}", $"Язык программирования: {Language}", $"Возраст:{Age}", $"Номер отдела:{Num_department}",$"зарплата:{Salary}", $"Должность: { Position}");
            
        }
    }
    public class EmployeeCollection
    {
        public List<Employee> Data { get; set; }
        public EmployeeCollection()
        {
            Data = new List<Employee>();//коллекция с сотрудниками типа Employee
           
        }
        

    }
    
    public class WorkWithFile
    {
        string writePath = @"D:\text.txt";
        string readPath = @"D:\text.txt";
        public WorkWithFile(EmployeeCollection collection)//коллекция 
        {
            using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))//Считываем построчно
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                //foreach (Employee s in collection.Data)// Выводим нашу коллекцию
                //{
                //    Console.WriteLine(s);
                //    Console.ReadLine();
                //}
            }
           
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))//Записываем в файл
            {
                while (true)
                {
                    Console.WriteLine("Введите Ф.И.О.:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите язык программирования:");
                    string language = Console.ReadLine();
                    Console.WriteLine("Введите возраст:");
                    uint age = uint.Parse(Console.ReadLine());
                    Console.WriteLine("Введите номер отдела:");
                    int department = int.Parse(Console.ReadLine());
                    Console.WriteLine("Зарплата:");
                    uint salary = uint.Parse(Console.ReadLine());
                    Console.WriteLine("Должность:");
                    string position = Console.ReadLine();
                    Employee b = new Employee(name, language, age, department, salary, position);
                    sw.WriteLine(b);//Записываем текст
                    sw.WriteLine("--------------------------------------------------------------");
                    break;
                 }
            }    
        }
    }
        public class ProgramP
        {

        static void Main(string[] args)
        {
            var collection = new EmployeeCollection();//создали новую коллекцию
            var work = new WorkWithFile(collection);//передали коллецию
            Console.Write(collection);
            Console.ReadKey();
            

        }
    
        }

 }   
    
    

