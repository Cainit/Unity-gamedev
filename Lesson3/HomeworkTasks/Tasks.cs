using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperUtils;
using ComplexNumber;

namespace HomeworkTasks
{
    public class Tasks
    {

        #region Task1

        /// <summary>
        /// Демонстрирует работу структуры SComplexNumber
        /// </summary>
        static void DemonstrateComplexStructure()
        {
            SComplexNumber complex1;
            complex1.re = 2;
            complex1.im = 1;

            SComplexNumber complex2;
            complex2.re = 3;
            complex2.im = 4;

            Helper.PrintColor("а.) Рассмотрим результат работы структуры:", ConsoleColor.White);
            SComplexNumber result = complex1.Plus(complex2);
            Helper.PrintLine($"Результом операции сложения чисел: {complex1} и {complex2} является {result}");
            result = complex1.Multi(complex2);
            Helper.PrintLine($"Результом операции умножения чисел: {complex1} и {complex2} является {result}");
            result = complex1.Minus(complex2);
            Helper.PrintLine($"Результом операции вычитания чисел: {complex1} и {complex2} является {result}");

            Helper.EndTask();
        }

        /// <summary>
        /// Демонстрирует работу класса CComplexNumber
        /// </summary>
        static void DemonstrateComplexClass()
        {
            CComplexNumber complex1 = new CComplexNumber(2, 1);
            CComplexNumber complex2 = new CComplexNumber(3, 4);

            Helper.PrintColor("б.) Рассмотрим результат работы класса:", ConsoleColor.White);
            CComplexNumber result = complex1.Plus(complex2);
            Helper.PrintLine($"Результом операции сложения чисел: {complex1} и {complex2} является {result}");
            result = complex1.Multi(complex2);
            Helper.PrintLine($"Результом операции умножения чисел: {complex1} и {complex2} является {result}");
            result = complex1.Minus(complex2);
            Helper.PrintLine($"Результом операции вычитания чисел: {complex1} и {complex2} является {result}");

            Helper.EndTask();
        }

        /// <summary>
        /// Возвращает комплексное число, запрашивая у пользователя его части
        /// </summary>
        /// <returns>комплексное число</returns>
        static CComplexNumber GetComplexNumberFromUser()
        {
            CComplexNumber complexNumber = new CComplexNumber();

            complexNumber.re = Helper.WaitNumber("Введите действительную часть комплексного числа: ");
            complexNumber.im = Helper.WaitNumber("Введите мнимую часть комплексного числа: ");

            return complexNumber;
        }

        /// <summary>
        /// Вывод информации по вычислению комплексных чисел
        /// </summary>
        /// <param name="operation">имя операции</param>
        /// <param name="complex1">первое число</param>
        /// <param name="complex2">второе число</param>
        /// <param name="complexResult">результат вычисления</param>
        static void PrintComplexOperation(string operation, CComplexNumber complex1, CComplexNumber complex2, CComplexNumber complexResult)
        {
            Helper.PrintColor($"Результом операции {operation} чисел: {complex1} и {complex2} является {complexResult}", ConsoleColor.Green);
        }

        /// <summary>
        /// Диалог по вычислению комплексных чисел 
        /// </summary>
        static void Task1Dialog()
        {
            Console.Clear();
            CComplexNumber complexResult = new CComplexNumber();

            Helper.PrintProgrammInfo("Вас приветсвует калькулятор комплексных чисел.");
            
            //Ввод первого числа
            Helper.PrintLine("Давайте сначала инициализируем первое число:");
            CComplexNumber complex1 = GetComplexNumberFromUser();

            //Ввод второго числа
            Helper.PrintLine($"Хорошо, первое число мы знаем = {complex1}");
            Helper.PrintLine("А теперь инициализируем второе:");
            CComplexNumber complex2 = GetComplexNumberFromUser();
            
            //Ввод оператора
            Helper.PrintLine($"Второе число = {complex2}");
            Helper.PrintLine("Введите операторы ( + - * ) для операций с числами или \"0\" для выхода");
            string operand = Console.ReadLine();
            switch (operand)
            {
                case "+": complexResult = complex1.Plus(complex2); PrintComplexOperation("сложения", complex1, complex2, complexResult); break;
                case "-": complexResult = complex1.Minus(complex2); PrintComplexOperation("вычитания", complex1, complex2, complexResult); break;
                case "*": complexResult = complex1.Multi(complex2); PrintComplexOperation("умножения", complex1, complex2, complexResult); break;
                case "0": Helper.PrintLine("Вы отказались от вычислений, до свидания."); break;
                default: Helper.PrintColor("Некорректный ввод. До свидания.", ConsoleColor.Red); break;
            }

            Helper.EndTask();
        }

        /// <summary>
        /// Задача № 1
        /// </summary>
        public static void ExecuteTask1()
        {
            int number = 0;
            do
            {
                Helper.PrintInfo(3, 1,
                  "1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры.\nб) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.\nв) Добавить диалог с использованием switch демонстрирующий работу класса.",
                  "Долгов Константин");

                Helper.PrintProgrammInfo("Выберетие вариант демонстрации задачи:");
                Helper.PrintProgrammInfo("1 -> Вариант а. Структура");
                Helper.PrintProgrammInfo("2 -> Вариант б. Класс");
                Helper.PrintProgrammInfo("3 -> Вариант в. Ручной ввод класса");

                Helper.PrintLine("");
                number = Convert.ToInt32(Helper.WaitNumber("Введите \"1\" для демонстрации работы класса, или \"0\" для выхода:"));
                switch (number)
                {
                    case 1: DemonstrateComplexStructure(); break;
                    case 2: DemonstrateComplexClass(); break;
                    case 3: Task1Dialog(); break;
                    default: break;
                }
            }
            while (number != 0);

            Helper.EndTask();
        }

        #endregion

        #region Task2

        /// <summary>
        /// Проверяет, является ли число положительным
        /// </summary>
        /// <param name="number">Проверяемое число</param>
        /// <returns></returns>
        public static bool IsNumberPositive(int number) 
        {
            return (number > 0);
        }

        /// <summary>
        /// Проверяет, является ли указанное число нечетным
        /// </summary>
        /// <param name="number">проверяемое число</param>
        /// <returns></returns>
        public static bool IsNumberOdd(int number)
        {
            return !(number % 2 == 0);
        }

        /// <summary>
        /// Задача № 2
        /// </summary>
        public static void ExecuteTask2()
        {
            Helper.PrintInfo(3, 2,
               "2. а) С клавиатуры вводятся числа, пока не будет введён 0(каждое число в новой строке).Требуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse.",
               "Долгов Константин");

            Helper.PrintProgrammInfo("Введите любые числа, а мы подсчитаем сумму нечётных положительных чисел. \nВведите '0', чтобы завершить задачу.");

            int number = 0;
            int numbersSum = 0;

            do
            {
                Helper.Print("Введите число: ");
                number = Convert.ToInt32(Helper.WaitNumber("Введите число:"));

                if (IsNumberPositive(number))
                {
                    if (IsNumberOdd(number))
                    {
                        numbersSum += number;
                    }
                }
            }
            while (number != 0);

            Helper.PrintGreen("Программа успешно завершена.");
            Helper.PrintGreen($"Сумма нечётных положительных цифр: {numbersSum}");

            Helper.EndTask();
        }

        #endregion

    }
}
