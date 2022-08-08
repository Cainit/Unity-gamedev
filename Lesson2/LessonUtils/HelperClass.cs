using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonUtils
{
    public class HelperClass
    {
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
            PrintUnderline();
            Console.WriteLine($"Домашняя работа - Урок № {lessonNumber}, Задача № {taskNumber}");
            Console.WriteLine($"Задача: {taskCondition}");
            Console.WriteLine($"Студент: {fio}");
            PrintUnderline();
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод информации о домашней работе при запуске программы
        /// </summary>
        /// <param name="homeworkNumber">номер домашней работы</param>
        /// <param name="student">фио студента</param>
        public static void PrintHomeWork(int homeworkNumber, string student)
        {
            PrintUnderline();
            Console.WriteLine($"Программа - домашняя работа № {homeworkNumber}");
            Console.WriteLine($"Студент - {student}");
            PrintUnderline();
        }

        /// <summary>
        /// Вывод строки подчеркивания
        /// </summary>
        public static void PrintUnderline()
        {
            Console.WriteLine("==========================================================");
        }

        /// <summary>
        /// Вывод строки меню
        /// </summary>
        public static void PrintMenuline()
        {
            Console.WriteLine("========================MENU==============================");
        }

        /// <summary>
        /// Завершает текущю задачу ожиданием
        /// </summary>
        public static void EndTask()
        {
            Console.WriteLine();
            Console.WriteLine("Введите любой символ для перехода к меню.");
            Console.ReadLine();
        }
    }
}
