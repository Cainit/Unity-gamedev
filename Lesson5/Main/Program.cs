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
            Console.Title = "Unity gamedev - Homework 5 - Dolgov K.";

            int taskNumber = 0;  //номер выполняемой задачи

            //Основной цикл программы, выбор решаемой задачи через консольное меню
            do
            {
                //Вывод информации о домашней работе
                Console.Clear();
                Helper.PrintHomeWork(5, "Долгов Константин");

                //Вывод программного меню
                PrintMenu();

                //Выбор решаемой задачи
                taskNumber = Helper.WaitNumber("Введите номер команды: ");
                switch (taskNumber)
                {
                    case 1: Task1.ExecuteTask(); break;
                    case 2: Task2.ExecuteTask(); break;
                    case 3: Task3.ExecuteTask(); break;
                    case 4: Task4.ExecuteTask(); break;
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
            Helper.PrintProgrammInfo("1 -> Проверка корректности логина.");
            Helper.PrintProgrammInfo("2 -> Статический класс Message.");
            Helper.PrintProgrammInfo("3 -> Сравнение перестановки символов в строках.");
            Helper.PrintProgrammInfo("4 -> Задача ЕГЭ.");
            Helper.PrintProgrammInfo("0 -> Завершить работу с приложением.");

        }
    }
}
