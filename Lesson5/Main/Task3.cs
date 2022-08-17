using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HelperUtils;

namespace Main
{
    class Task3
    {
        /// <summary>
        /// Сравнивает две строки на перестановку символов
        /// </summary>
        /// <param name="stringOrigin">первая строка</param>
        /// <param name="stringReplace">вторая строка</param>
        /// <returns></returns>
        public static bool IsStringSymbolReplace(string stringOrigin, string stringReplace)
        {
            bool flagReplace = true;

            //Проверка длины строк
            if (stringOrigin.Length != stringReplace.Length)
                return false;

            /* Вариант с сортировкой символов.
            //Сортировка строк
            char[] contentFirst = stringOrigin.ToCharArray();
            char[] contentSecond = stringReplace.ToCharArray();

            //Сравнение символов строк
            return contentFirst.Equals(contentSecond);
            */

            // Счётчик символов
            int[] unicodeSymbols = new int[96000]; //Массив позиций Unicode

            char[] contentFirst = stringOrigin.ToCharArray();
            foreach  (char symbol in contentFirst)
            {
                ++unicodeSymbols[symbol];
            }

            for (int i = 0; i < stringReplace.Length; ++i)
            {
                int symbol = (int)stringReplace.ElementAt(i);

                if (--unicodeSymbols[symbol] < 0)
                {
                    return false;
                }
            }

            //Строки прошли проверку успешно
            return true;
        }

        /// <summary>
        /// Выводит информацию о результате сравнения
        /// </summary>
        /// <param name="first">первая строка</param>
        /// <param name="second">вторая строка</param>
        public static void PrintComparing(string first, string second)
        {
            Helper.PrintLine($"Сравниваем строки");
            Helper.PrintLine($"Первая строка: {first}");
            Helper.PrintLine($"Вторая строка: {second}");
            
            if (IsStringSymbolReplace(first, second))
                Helper.PrintGreen("Вторая строка является перестановкой символов первой.");
            else
                Helper.PrintRed("Вторая строка не является перестановкой символов первой.");
        }

        /// <summary>
        /// Задача 3
        /// </summary>
        public static void ExecuteTask()
        {
            Helper.PrintInfo(5, 3,
               "3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Например: badc являются перестановкой abcd.",
               "Долгов Константин");


            Helper.PrintProgrammInfo("Мы сможем определить, является ли одна строка перестановкой другой.");
            Helper.PrintLine("Приведём небольшой прример.");

            //автоматический пример метода
            string firstString = "abcd";
            string secondString = "dcba";

            PrintComparing(firstString, secondString);

            Helper.PauseTask();

            Console.Clear();

            //ручная проверка метода
            Helper.PrintLine("А теперь, продемонстрируем работу метода вручную.");
            Helper.Print("Введите первую строку: ");
            firstString = Console.ReadLine();

            Helper.Print("Введите вторую строку: ");
            secondString = Console.ReadLine();

            PrintComparing(firstString, secondString);

            Helper.EndTask();
        }
    }
}
