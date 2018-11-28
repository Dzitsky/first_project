﻿using System;
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
        public Employee(string name,string language, uint age)
        {
            Name = name;
            Language = language;
            Age = age;//задали конструктор
        }
        public override string ToString()//без этого форматирования выводит название проекта
        {
            return string.Format("{0}{1}{2}", Name, Language, Age);
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
                    Employee b = new Employee($"ФИО: { name }",$"Язык программирования:{language}",age);
                    sw.WriteLine(b);//Записываем текст
                    sw.WriteLine("------------------------");
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
            Console.WriteLine(collection);
            Console.ReadKey();
            

        }
    
        }

 }   
    
    

