//Раз мы все переименовали﻿на Solution, я бы и неймспейс везде переименовал бы (ConsoleApp6 -> Solution)
namespace ConsoleApp6
{
    public interface IEmployeeManager
    {
        // Тут у нас смешиваются два слоя UI И BLL (смоти описание), так быть не должно, такой код будет сложно переделать!
        void AddEmployees();
        void ReadFromFile();
        void SaveToFile();
        
        //Я бы хотел тут видеть следующие методы:
        // List<Employee> ReadAll(); // Получить список всех сотрудников
        // Employee Read(int Id); // Получить сотрудника по Id
        // List<Employee> ReadByFilter(EmployeeFilter filter); // Получить список сотрудников по фильтру, добавить класс фильтра (со всемми необходимыми для поиска полями)
        // void Add(Employee employee); // Добавлене сотрудника
        // void Delete(int Id); // Удаление сотрудника
        // void Update(Employee employee); // Изменение сотрудника
        
        //SaveToFile - сохранение в файл я бы выполнял неявно, в самих методах Add, Update, Delete
        
        //TODO: почитать про generic-коллекции, класс List и интерфейсы IList, IEnumirable и LINQ для фильтра
    }
}
