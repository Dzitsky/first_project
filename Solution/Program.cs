using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    public class Program
    {
        static void Main(string[] args)
        {
            var manager = new EmployeeManager();//экземпляр класса
            bool stillWorking = true;
            while (stillWorking)
            {
                Console.WriteLine("1 - Отобразить сотрудников\n" +
                    "2 - Добавить новых сотрудников\n" +
                    "3 - Сохранить сотрудников в файл\n" +
                    "4 - Закрыть приложение\n");
                int cmd;
                if (int.TryParse(Console.ReadLine(), out cmd))
                {
                    switch (cmd)
                    {
                        case 1:
                            manager.ReadFromFile();
                            break;
                        case 2:
                            manager.AddEmployees();
                            break;
                        case 3:
                            manager.SaveToFile();
                            break;
                        case 4:
                            stillWorking = false;
                            break;
                        default:
                            Console.WriteLine("Команда не распознана\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Введите команду в допустимом формате\n");
                }
            }
        }
    }
}
