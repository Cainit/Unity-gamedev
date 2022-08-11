using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperUtils;
using HomeworkTasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Unity gamedev - Homework 3 - Dolgov K.";

            int taskNumber = 0;  //номер выполняемой задачи

            //Основной цикл программы, выбор решаемой задачи через консольное меню
            do
            {
                //Вывод информации о домашней работе
                Console.Clear();
                Helper.PrintHomeWork(3, "Долгов Константин");

                //Вывод программного меню
                PrintMenu();

                //Выбор решаемой задачи
                taskNumber = Convert.ToInt32(Helper.WaitNumber("Введите номер задачи или введите \"0\" для выхода:"));
                switch (taskNumber)
                {
                    case 1: Tasks.ExecuteTask1(); break;
                    case 2: Tasks.ExecuteTask2(); break;
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
            Helper.PrintProgrammInfo("1 -> Задача 1");
            Helper.PrintProgrammInfo("2 -> Задача 2 ");
        }
    }
}
