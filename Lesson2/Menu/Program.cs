using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonUtils;
using HomeworkTasks;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            int taskNumber = 0;
            
            //Основной цикл программы, выбор решаемой задачи через консольное меню
            do
            {
                Console.Clear();
                HelperClass.PrintHomeWork(2, "Долгов Константин");

                Console.WriteLine();
                PrintMenu();
                taskNumber = int.Parse(Console.ReadLine());

                switch (taskNumber)
                {
                    case 1: Tasks.ExecuteTask1(); break;
                    case 2: Tasks.ExecuteTask2(); break;
                    case 3: Tasks.ExecuteTask3(); break;
                    case 4: Tasks.ExecuteTask4(); break;
                    case 5: Tasks.ExecuteTask5(); break;
                    case 6: Tasks.ExecuteTask6(); break;
                    default: break;
                }
            }
            while (taskNumber > 0);

        }



        static void PrintMenu()
        {
            HelperClass.PrintMenuline();
            Console.WriteLine("Меню выбора задач.");
            Console.WriteLine("Выполненные задачи:");
            Console.WriteLine("1 -> Задача 1");
            Console.WriteLine("2 -> Задача 2 ");
            Console.WriteLine("3 -> Задача 3 ");
            Console.WriteLine("4 -> Задача 4 ");
            Console.WriteLine("5 -> Задача 5 ");
            Console.WriteLine("6 -> Задача 6 ");
            Console.Write("Введите номер задачи для перехода к ней, или введите \'0\' для завершения работы приложения: ");
        }

    }
}
