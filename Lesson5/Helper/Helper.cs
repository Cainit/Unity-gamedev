using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public class Helper
    {
        #region Print functions

        /// <summary>
        /// Вывод текста в текущей строке
        /// </summary>
        /// <param name="message"></param>
        public static void Print(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// Вывод текста в новой строке
        /// </summary>
        /// <param name="message"></param>
        public static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Выводит строку текста зелёным цветом
        /// </summary>
        /// <param name="message"></param>
        public static void PrintGreen(string message)
        {
            PrintColor(message, ConsoleColor.Green);
        }

        /// <summary>
        /// Выводит строку текста жёлтым цветом
        /// </summary>
        /// <param name="message"></param>
        public static void PrintYellow(string message)
        {
            PrintColor(message, ConsoleColor.Yellow);
        }


        /// <summary>
        /// Выводит строку текста красным цветом
        /// </summary>
        /// <param name="message"></param>
        public static void PrintRed(string message)
        {
            PrintColor(message, ConsoleColor.Red);
        }

        /// <summary>
        /// Вывод текста в отдельной строке с определённым цветом
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void PrintColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Выводит строки описывающие действие текущей программы
        /// </summary>
        /// <param name="message"></param>
        public static void PrintProgrammInfo(string message)
        {
            PrintColor(message, ConsoleColor.White);
        }

        /// <summary>
        /// Вывод информации о задании и студенте при выполнении задачи
        /// </summary>
        /// <param name="lessonNumber">Номер урока</param>
        /// <param name="taskNumber">Номер выполняемой задачи</param>
        /// <param name="taskCondition">Описание текущей задачи</param>
        /// <param name="fio">Информация о студенте</param>
        public static void PrintInfo(int lessonNumber, int taskNumber, string taskCondition, string fio)
        {
            Console.Clear();
            PrintUnderlineColor(ConsoleColor.DarkCyan);
            PrintColor($"Домашняя работа - Урок № {lessonNumber}, Задача № {taskNumber}", ConsoleColor.Cyan);
            PrintColor($"Задача: {taskCondition}", ConsoleColor.Cyan);
            PrintColor($"Студент: {fio}", ConsoleColor.Cyan);
            PrintUnderlineColor(ConsoleColor.DarkCyan);
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод информации о домашней работе при запуске программы
        /// </summary>
        /// <param name="homeworkNumber">номер домашней работы</param>
        /// <param name="student">фио студента</param>
        public static void PrintHomeWork(int homeworkNumber, string student)
        {
            PrintUnderlineColor(ConsoleColor.DarkCyan);
            PrintColor("Курс \t\t- Unity gamedev", ConsoleColor.Cyan);
            PrintColor($"Программа \t- Домашняя работа № {homeworkNumber}", ConsoleColor.Cyan);
            PrintColor($"Студент \t- {student}", ConsoleColor.Cyan);
            PrintUnderlineColor(ConsoleColor.DarkCyan);
        }

        /// <summary>
        /// Вывод строки подчеркивания
        /// </summary>
        public static void PrintUnderline()
        {
            Console.WriteLine("==========================================================");
        }

        /// <summary>
        /// Вывод цветной строки подчеркивания
        /// </summary>
        public static void PrintUnderlineColor(ConsoleColor color)
        {
            PrintColor("==========================================================", color);
        }

        /// <summary>
        /// Вывод строки меню
        /// </summary>
        public static void PrintMenuline()
        {

            PrintLine("========================МЕНЮ==============================");
        }

        /// <summary>
        /// Завершает текущю задачу ожиданием
        /// </summary>
        public static void EndTask()
        {
            Console.WriteLine();
            PrintColor("...Нажмите любую клавишу для возвращения в меню задач...", ConsoleColor.DarkGreen);
            Console.ReadKey();
        }

        /// <summary>
        /// Ставит текущю задачу на паузу
        /// </summary>
        public static void PauseTask()
        {
            Console.WriteLine();
            PrintColor("...Нажмите любую клавишу для продолжения...", ConsoleColor.DarkGreen);
            Console.ReadKey();
        }

        #endregion


        /// <summary>
        /// Возвращает введёное пользователем число с проверкой корректности ввода
        /// </summary>
        /// <param name="message">Сообщение на запросе числа</param>
        /// <returns>Введённое число</returns>
        public static int WaitNumber(string message)
        {
            int x;   //число для записи
            bool flag;  //флаг корректности ввода

            //выполнение цикла, пока не будет введено корректное число
            do
            {
                Print(message);
                flag = int.TryParse(Console.ReadLine(), out x);
                if (!flag)
                    PrintRed("Обнаружен некорректный ввод. Пожалуйста, введите корректное число.");
            }
            while (!flag);

            return x;
        }

    }
}
