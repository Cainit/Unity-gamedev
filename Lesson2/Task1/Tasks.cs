using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonUtils;

namespace HomeworkTasks
{
    public class Tasks
    {
        #region Task1
        /// <summary>
        /// Метод возвращающий меньшее из трех чисел
        /// </summary>
        /// <param name="numberOne">Первое число</param>
        /// <param name="numberTwo">Второе число</param>
        /// <param name="numberThree">Третье число</param>
        /// <returns>Наибольшее число</returns>
        public static double GetMinNumber(double numberOne, double numberTwo, double numberThree)
        {
            return numberOne < numberTwo ? (numberOne < numberThree ? numberOne : numberThree) : (numberTwo < numberThree ? numberTwo : numberThree);
        }

        /// <summary>
        /// Задача № 1
        /// </summary>
        public static void ExecuteTask1()
        {
            HelperClass.PrintInfo(2, 1,
                "Написать метод, возвращающий минимальное из трёх чисел.",
                "Долгов Константин");

            Console.WriteLine("Здравствуйте, введите три числа, а мы скажем, какое было минимальным.");

            Console.Write("Введите первое число:");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Введите второе число:");
            double num2 = double.Parse(Console.ReadLine());

            Console.Write("Введите третье число:");
            double num3 = double.Parse(Console.ReadLine());

            Console.WriteLine("Минимальное число = {0}", GetMinNumber(num1, num2, num3));

            HelperClass.EndTask();
        }
        #endregion

        #region Task2

        /// <summary>
        /// Подсчёт количества цифр в числе
        /// </summary>
        /// <param name="number">число для подсчета цифр</param>
        /// <returns>количество цифр в числе</returns>
        public static int GetNumberSymbolCount(double number)
        {
            string str = number.ToString();
            return str.Length;
        }

        /// <summary>
        /// Задача № 2
        /// </summary>
        public static void ExecuteTask2()
        {
            HelperClass.PrintInfo(2, 2,
               "Написать метод подсчета количества цифр числа..",
               "Долгов Константин");

            Console.WriteLine("Здравствуйте, введите число, а мы скажем, сколько в нём цифр.");

            Console.Write("Введите число:");

            double number = GetNumberSymbolCount(double.Parse(Console.ReadLine()));
            
            Console.WriteLine("Количество цифр указанного числа = {0}", number);

            HelperClass.EndTask();
        }

        #endregion

        #region Task3

        /// <summary>
        /// Проверяет, является ли число положительным
        /// </summary>
        /// <param name="number">Проверяемое число</param>
        /// <returns></returns>
        public static bool IsNumberPositive(int number)
        {
            if (number > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Проверяет, является ли указанное число нечетным
        /// </summary>
        /// <param name="number">проверяемое число</param>
        /// <returns></returns>
        public static bool IsNumberOdd(int number)
        {
            if (number % 2 == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Задача № 3
        /// </summary>
        public static void ExecuteTask3()
        {
            HelperClass.PrintInfo(2, 3,
               "С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.",
               "Долгов Константин");

            Console.WriteLine("Введите любые числа, а мы подсчитаем все нечётные положительные числа. \nВведите '0', чтобы завершить задачу.");

            int number = 0;
            int numberCount = 0;

            do
            {
                Console.Write("Введите число: ");
                number = int.Parse(Console.ReadLine());

               if(IsNumberPositive(number))
                {
                    if(IsNumberOdd(number))
                    {
                        ++numberCount;
                    }
                }
            }
            while (number != 0);
            
            Console.WriteLine("Количество нечётных положительных цифр: {0}", numberCount);

            HelperClass.EndTask();
        }

        #endregion

        #region Task4

        /// <summary>
        /// Проверяет правильность ввода логина и пароля
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="parol">пароль</param>
        /// <returns></returns>
        public static bool IsLoginParolValid(string login, string parol)
        {
            if (login == "root")
            {
                if(parol == "GeekBrains")
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Задача № 4
        /// </summary>
        public static void ExecuteTask4()
        {
            HelperClass.PrintInfo(2, 4,
               "Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.",
               "Долгов Константин");

            Console.WriteLine("Здравствуйте, введите пожалуйста логин и пароль для авторизации.");

            int numberCount = 3;
            bool isParolValid = false;

            //цикл ввода пароля
            do
            {
                //информирование о количестве оставшихся попыток
                switch(numberCount)
                {
                    case 3: Console.WriteLine("У Вас осталось {0} попытки.", numberCount); break;
                    case 2: Console.WriteLine("У Вас осталось {0} попытки.", numberCount); break;
                    case 1: Console.WriteLine("У Вас осталась {0} попытка.", numberCount); break;
                    default: break;
                }

                //ввод логина и пароля
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();

                Console.Write("Введите пароль: ");
                string parol = Console.ReadLine();

                if (IsLoginParolValid(login, parol))    //пароль верный
                {
                    isParolValid = true;
                    break;
                }
                else                                    //пароль неверный
                {
                    --numberCount;
                    Console.WriteLine("Вы ввели неправильный логин или пароль. Пожалуйста, повторите попытку.");
                }
            }
            while (numberCount > 0);

            //завершение программы в зависимости от правильности ввода
            if(isParolValid)
            {
                Console.WriteLine("Логин и пароль указаны верно. Поздравляем, задача завершена успешно.");
            }
            else
            {
                Console.WriteLine("Логин и пароль указаны неверно. Программа завершена, так как Вы ввели неправильные данные 3 раза.");
            }

            HelperClass.EndTask();
        }

        #endregion

        #region Task5

        /// <summary>
        /// Определяет индекс массы тела человека
        /// </summary>
        /// <param name="height">рост человека</param>
        /// <param name="weight">вес человека</param>
        /// <returns></returns>
        public static double GetHumanMassIndex(double height, double weight)
        {

            return weight / (height * height);
        }

        /// <summary>
        /// Возвращает нормальный вес для роста 
        /// </summary>
        /// <param name="height">рост</param>
        /// <param name="ibm">индекс массы тела</param>
        /// <returns></returns>
        public static double GetNormalWeightIndexFromHeight(double height, double ibm)
        {
            return (height * height) * ibm;
        }

        /// <summary>
        /// Печатает индекс массы тела и даёт рекомендации по изменению
        /// </summary>
        /// <param name="ibm">индекс массы тела</param>
        public static void PrintHumanMassIndexInformation(double ibm)
        {
            Console.WriteLine("Ваш индекс массы тела равен {0}.", ibm);

            //печать информации
            if (ibm <= 16)
            {
                Console.WriteLine("У Вас выраженный дефицит массы тела.");
            }
            else if (ibm > 16 && ibm <= 18.5)
            {
                Console.WriteLine("У Вас недостаточная масса тела.");
            }
            else if (ibm > 18.5 && ibm <= 25)
            {
                Console.WriteLine("Поздравляем, Ваш индекс массы тела в полной норме.");
            }
            else if (ibm > 25 && ibm <= 30)
            {
                Console.WriteLine("У Вас ожирение первой степени.");
            }
            else if (ibm > 30 && ibm <= 35)
            {
                Console.WriteLine("У Вас ожирение второй степени.");
            }
            else if (ibm > 40)
            {
                Console.WriteLine("У Вас ожирение третьей степени.");
            }
        }

        /// <summary>
        /// Даёт рекомендации по похудению или толстению
        /// </summary>
        /// <param name="ibm">индекс массы тела</param>
        /// <param name="height">рост</param>
        /// <param name="weight">вес</param>
        public static void PrintHumanMassIndexRecomendation(double ibm, double height, double weight)
        {
            if (ibm <= 16)  //недостаточный вес
            {
                double normalWeight = GetNormalWeightIndexFromHeight(height, 18.5) - weight;

                Console.WriteLine("Вам необходимо набрать минимум {0} килограмм. Кушайте чаще и больше.", normalWeight);
            }
            else if (ibm > 25)  //избыток веса
            {
                double normalWeight = weight - GetNormalWeightIndexFromHeight(height, 25);

                Console.WriteLine("Вам необходимо скинуть минимум {0} килограмм. Если не хотите отрезать от себя части, пожалуйста кушайте поменьше и занимайтесь побольше.", normalWeight);
            }
        }

        /// <summary>
        /// Задача № 5
        /// </summary>
        public static void ExecuteTask5()
        {
            HelperClass.PrintInfo(2, 5,
               "а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме. \nб) * Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.",
               "Долгов Константин");

            Console.WriteLine("Здравствуйте, мы поможем определить Ваш индекс массы тела и предоставим рекомендации. Ответьте пожалуйста на пару вопросов.");

            //Ввод данных
            Console.Write("1. Сколько килограмм вы весите?");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("2. Сколько сантиметров ваш рост? ");
            double height = double.Parse(Console.ReadLine()) * 0.01;

            //Определение индекса массы тела
            double indexBodyMass = GetHumanMassIndex(height, weight);

            //вывод информации и рекомендаций
            PrintHumanMassIndexInformation(indexBodyMass);

            PrintHumanMassIndexRecomendation(indexBodyMass, height, weight);

            HelperClass.EndTask();

        }

        #endregion

        #region Task6

        /// <summary>
        /// Проверяет, является ли число "хорошим"
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsGoodNumber(int number)
        {
            string s = Convert.ToString(number);

            int sum = 0;

            for (int i = 0; i < s.Length; ++i)
            {
                sum += s[i] - '0';
            }

            if (number % sum == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Задача № 6
        /// </summary>
        public static void ExecuteTask6()
        {
            HelperClass.PrintInfo(2, 6,
               "6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. «Хорошим» называется число, которое делится на сумму своих цифр. Реализовать подсчёт времени выполнения программы, используя структуру DateTime.",
               "Долгов Константин");

            Console.WriteLine("Здравствуйте, это программа подсчитывает 'хорошие' числа в диапазоне от 1 до 1 000 000 000.");

            //Ввод данных
            Console.Write("Задайте диапазон от 1 до : ");
            int numberDiapason = int.Parse(Console.ReadLine());

            if(numberDiapason <= 0 && numberDiapason > 1000000000) //ошибка ввода
            {
                Console.WriteLine("Вы ввели недопустимый диапазон. Программа завершена."); 
            }
            else //подсчет хороших чисел
            {
                Console.WriteLine("Пожалуйста, подождите. Программа выполняет вычисления...");

                int goodNumbersCount = 0;
                DateTime startData = DateTime.Now;

                for (int i = 1; i <= numberDiapason; i++)
                {
                    if (IsGoodNumber(i))
                    {
                        ++goodNumbersCount;
                    }
                }

                Console.WriteLine("Время работы программы: {0}", DateTime.Now - startData);
                Console.WriteLine("В заданном диапазоне содержится {0} хороших чисел", goodNumbersCount);

                HelperClass.EndTask();
            }
        }

        #endregion
    }
}
