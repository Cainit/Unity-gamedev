using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperUtils;

namespace Main
{
    class Task1
    {
        public delegate double Fun(double a, double x);

        public static void Table(Fun F, double a, double x, double b)
        {
            Helper.PrintYellow("------ X ----- Y ------");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                x += 1;
            }
            Helper.PrintYellow("-----------------------");
        }
        
        public static double FuncAPow(double a, double x)
        {
            return a * Math.Pow(x, 2);
        }

        public static double FuncASin(double a, double x)
        {
            return a * Math.Sin(x);
        }

        /// <summary>
        /// Возвращает введённое пользователем число 
        /// </summary>
        /// <returns></returns>
        public static double GetA()
        {
            return Helper.WaitDouble("Введите значение a: ");
        }
        
        /// <summary>
        /// Задача 1
        /// </summary>
        public static void ExecuteTask()
        {
            int methodNumber = 0;

            //Основной цикл программы, выбор решаемой задачи через консольное меню
            do
            {
                Console.Clear();
                Helper.PrintInfo(6, 1,
               "Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).",
                "Долгов Константин");

                //Вывод программного меню
                PrintMenu();

                //Выбор решаемой задачи
                methodNumber = Helper.WaitNumber("Введите номер команды: ");
                switch (methodNumber)
                {
                    case 1: Table(FuncAPow, GetA(), -2, 2); Helper.PauseTask(); break;
                    case 2: Table(FuncASin, GetA(), -2, 2); Helper.PauseTask(); break;
                    default: break;
                }
            }
            while (methodNumber != 0);

            Helper.EndTask();
        }

        /// <summary>
        /// Меню распечатки функций
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine();
            Helper.PrintMenuline();
            Helper.PrintProgrammInfo("Меню выбора команд:");
            Helper.PrintProgrammInfo("1 -> Функция a*x^2.");
            Helper.PrintProgrammInfo("2 -> Функция a*sin(x)");
            Helper.PrintProgrammInfo("0 -> Вернуться к меню выбора решенных задач.");

        }
    }
}
