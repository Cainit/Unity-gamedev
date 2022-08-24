using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperUtils;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Unity gamedev - Homework 6 - Dolgov K.";

            int taskNumber = 0;  //номер выполняемой задачи

            //Основной цикл программы, выбор решаемой задачи через консольное меню
            do
            {
                //Вывод информации о домашней работе
                Console.Clear();
                Helper.PrintHomeWork(6, "Долгов Константин");

                //Вывод программного меню
                PrintMenu();

                //Выбор решаемой задачи
                taskNumber = Helper.WaitNumber("Введите номер команды: ");
                switch (taskNumber)
                {
                    case 1: Task1.ExecuteTask(); break;
                    case 2: Task2.ExecuteTask(); break;
                    case 3: Task3.ExecuteTask(); break;
                    default: break;
                }
            }
            while (taskNumber > 0);
        }

        /// <summary>
        /// Вывод меню между задачами
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine();
            Helper.PrintMenuline();
            Helper.PrintProgrammInfo("Меню выбора задач. Выполненные задачи:");
            Helper.PrintProgrammInfo("1 -> Задача 1. Делегаты. ");
            Helper.PrintProgrammInfo("2 -> Задача 2. Минимум фуункции.");
            Helper.PrintProgrammInfo("3 -> Задача 3. Коллекции.");
            Helper.PrintProgrammInfo("0 -> Завершить работу с приложением.");

        }
    }
}
