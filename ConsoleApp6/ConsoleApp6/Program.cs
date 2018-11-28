using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;//обобщенные коллекции
using System.IO;

namespace ConsoleApp6
{
    // Вынести в отдельный файл
    // Добавить xml-документацию (https://docs.microsoft.com/ru-ru/dotnet/csharp/codedoc)
    public class Employee
    {        
        // Если у тебя ФИО, то скорее всего еще и фамиля понадобится (Last Name), обычно для ФИО заводят при поля (First\Middle\Last Name, а если нужно получить ФИО целиком - можно добавить свойство либо расширение, которое будет возвращать строку, в которую сводятся эти поля)
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
        
        // >без этого форматирования выводит название проекта
        // А ты понимаешь, почему?
        // Сам метод мне прям нравится, тут и перегрузка и форматирование строки, молодец
        public override string ToString()//без этого форматирования выводит название проекта
        {
            return string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}", $"ФИО: {Name}", $"Язык программирования: {Language}", $"Возраст:{Age}", $"Номер отдела:{Num_department}",$"зарплата:{Salary}", $"Должность: { Position}");
            
        }
    }
    
    // А зачем нам эта коллекция, почему не используем просто: 
    //var employees = new List<Employee>();
    // для чего ещё оборачивать в EmployeeCollection?
    public class EmployeeCollection
    {
        public List<Employee> Data { get; set; }
        public EmployeeCollection()
        {
            Data = new List<Employee>();//коллекция с сотрудниками типа Employee
           
        }
        

    }
    
    // Ну не совсем то, что я хотел
    // Давай пока всю логику работы с сотрудниками вынесем в отдельный файл, назовем его EmployeeService
    // Хочу, что бы он реализовывал интерфейс IEmployeeService, в котором будут все необходимые CRUD-операции для сотрудников (посмотри, что такое CRUD, если не знаешь)
    // Для тех операций, которые еще не реализованы, добавить заглушки
    public class WorkWithFile
    {
        string writePath = @"D:\text.txt";
        string readPath = @"D:\text.txt";
        public WorkWithFile(EmployeeCollection collection)//коллекция 
        {   
            // Понимаешь, для чего конструкция using используется?
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
                // Зачем тут while?
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
            
            // В идеале еще всю логику по чтению\записи из файла с sr\sw вынести в отдельный файл, чтоб EmployeeService обращался к нему и уже в нет происходила работа и с файлом (см. комментарии в Main)
            // Плавно подходим к паттерну Репозиторий (https://metanit.com/sharp/articles/mvc/11.php)
        }
    }
        public class Program
        {

        static void Main(string[] args)
        {
            var collection = new EmployeeCollection();//создали новую коллекцию
           
            // Taк, это чтение всех из файла и добавление нового, уже хорошо!
            var work = new WorkWithFile(collection);//передали коллецию            
            Console.Write(collection);
            Console.ReadKey();
                                    
            // Давай сделаем меню, в котором будет:
            //1: Вывести список всех сотрудников
            //2: Добавить сотрудника
            //...
            //0: Выход
            
            // Должно получиться что-то типа этого:
            //switch (i)
            //{
            //    case 1:
            //        Console.WriteLine("Список всех сотрудников:");
            //          List<Employee> employees = EmployeeService.Read();
            //          //TODO: Вывод в консоль
            //        break;
            //    case 2:
            //        Console.WriteLine("Добавление пользователя:");
            //        Employee> employee;   
            //        //TODO: чтение с консоли
            //        EmployeeService.Add(employee);
            //        break;
            //    ...
            //}

        }
 }   
    
    

