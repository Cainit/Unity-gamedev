using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HelperUtils;

namespace Main
{
    class Task1
    {
        /// <summary>
        /// проверяет корректность логина
        /// </summary>
        /// <param name="login">логин</param>
        /// <returns></returns>
        static bool IsLoginCorrect(string login)
        {
            //проверка на длину логина
            if (login.Length < 2 || login.Length > 10)
            {
                Helper.PrintRed("Логин недопустимой длины.");
                return false;
            }

            //проверка первого символа
            if (char.IsNumber(login.First()))
            {
                Helper.PrintRed("Логин начинается с цифры.");
                return false;
            }

            //проверка всех символов на латиницу и цифры
            foreach(char symbol in login)
            {
                if (!char.IsLetterOrDigit(symbol) ||  ((symbol < 'a' || symbol > 'z') && (symbol < 'A' || symbol > 'Z') && (symbol < '0' || symbol > '9')) )
                {
                    Helper.PrintRed("Логин содержит недопустимые символы.");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Задача 1
        /// </summary>
        public static void ExecuteTask()
        {
            Helper.PrintInfo(5, 1,
               "1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой.",
               "Долгов Константин");

            Helper.PrintProgrammInfo("Мы попрбоуем авторизоваться в программе с помощью логина.");
            Helper.PrintProgrammInfo("Введите логин, но помните:");
            Helper.PrintProgrammInfo("1. Логин не может быть короче 2 символов и длиннее 10.");
            Helper.PrintProgrammInfo("2. Логин может содержать только буквы латинского алфавита или цифры.");
            Helper.PrintProgrammInfo("3. Логин не может начитаться с цифры.");

            Helper.PrintLine("");
            Helper.Print("Пожалуйста, введите корректный логин: ");
            string login = Console.ReadLine();

            if (IsLoginCorrect(login))
                Helper.PrintGreen("Поздравляем, вы ввели корректный логин. Задача завершена успешно.");
            else
                Helper.PrintRed("К сожалению, ваш логин не соответствует условиям. Программа завершена.");

            Helper.EndTask();
        }
    }
}
