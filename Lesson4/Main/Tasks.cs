using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperUtils;
using MyArray;
using System.IO;

namespace Main
{
    public class Tasks
    {
        #region Task1

        /// <summary>
        /// Позволяет вручную установить значения массива
        /// </summary>
        /// <returns></returns>
        public static ArrayClass SetArray()
        {
            Console.Clear();
            Helper.PrintProgrammInfo("Ручная установка значений массива.");
            Helper.PrintProgrammInfo("Вы можете вводить любые целые числа или ввести \"q\" для завершения ввода.");

            int[] buf = new int[1000];
            int count = 0;      //количество элементов в массиве
            int arrayValue;     //число для записи
            bool flagCorrect;   //флаг корректности ввода
            bool onSet = true;

            //выполнение цикла, пока не будет введено корректное число или символ "q"
            while (onSet)
            {
                do
                {
                    Helper.Print("Введите число или 'q': ");
                    string parseString = Console.ReadLine();
                    flagCorrect = int.TryParse(parseString, out arrayValue);
                    if (!flagCorrect)
                    {
                        if (parseString == "q")
                        {
                            flagCorrect = true; onSet = false;
                        }
                        else
                            Helper.PrintRed("Некорректный ввод. Пожалуйста, введите число или 'q' для выхода.");
                    }
                    else //добавление нового элемента массива
                    {
                        buf[count] = arrayValue;
                        ++count;
                    }
                }
                while (!flagCorrect);
            }


            int[] arr = new int[count];
            Array.Copy(buf, arr, count);

            ArrayClass newArray = new ArrayClass(arr);

            return newArray;
        }

        /// <summary>
        /// Демонстрирует метод инверсии
        /// </summary>
        /// <param name="taskArray"></param>
        public static void Inverse(ArrayClass taskArray)
        {
            Helper.PrintProgrammInfo("Значения инвертированного массива: ");
            Helper.PrintColor(taskArray.Inverse().ToString(), ConsoleColor.Yellow);

            Helper.EndTask();
        }

        /// <summary>
        /// Демонстрирует метод умножения
        /// </summary>
        /// <param name="taskArray"></param>
        public static void Mult(ArrayClass taskArray)
        {
            ArrayClass multArray = taskArray.Copy();
            int mult = Helper.WaitNumber("Введите множитель для элементов массива:");

            multArray.Multi(mult);

            Helper.PrintProgrammInfo("Значения умноженного массива: ");
            Helper.PrintColor(multArray.ToString(), ConsoleColor.Yellow);

            Helper.EndTask();
        }

        /// <summary>
        /// Демонстрирует вывод в консоль элементов массива средствами самого класса
        /// </summary>
        /// <param name="taskArray"></param>
        public static void PrintArray(ArrayClass taskArray)
        {
            Helper.PrintProgrammInfo("Значения массива: ");
            taskArray.PrintArray();

            Helper.EndTask();
        }

        /// <summary>
        /// Демонстрирует загрузку из файла
        /// </summary>
        /// <param name="taskArray"></param>
        public static void LoadFromFile(ArrayClass taskArray)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "Array.txt";

            ArrayClass loadedArray = new ArrayClass(fileName);

            Helper.PrintProgrammInfo($"Массив загружен из файла: {fileName}");
            Helper.PrintProgrammInfo("Значения загруженного массива: ");
            Helper.PrintColor(loadedArray.ToString(), ConsoleColor.Yellow);

            Helper.EndTask();
        }

        /// <summary>
        /// Задача 1
        /// </summary>
        public static void ExecuteTask1()
        {
            int number = 0;

            int[] array = { -1, 0, 2, 4, -2, 7, 8, 1, 7, 8 };
            ArrayClass taskArray = new ArrayClass(array);
            
            do
            {
                Helper.PrintInfo(4, 1,
                  "1. а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений), метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов."+
                  "б)**Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки",
                  "Долгов Константин");

                Helper.PrintProgrammInfo($"Массив состоит из {taskArray.Length} элементов: ");
                Helper.PrintColor(taskArray.ToString(), ConsoleColor.Yellow);

                Helper.PrintProgrammInfo("Выберетие действие:");
                Helper.PrintProgrammInfo("1 -> Установить значения MyArray");
                Helper.PrintProgrammInfo("2 -> Свойство Length");
                Helper.PrintProgrammInfo("3 -> Свойство Sum");
                Helper.PrintProgrammInfo("4 -> Свойство MaxCount");
                Helper.PrintProgrammInfo("5 -> Метод Inverse");
                Helper.PrintProgrammInfo("6 -> Метод Multi");
                Helper.PrintProgrammInfo("7 -> Метод PrintArray");
                Helper.PrintProgrammInfo("8 -> Метод LoadArrayFromFile");
                Helper.PrintProgrammInfo("0 -> Выход");

                Helper.PrintLine("");
                number = (int)Helper.WaitNumber("Введите номер команды:");
                switch (number)
                {
                    case 1: taskArray = SetArray(); break;
                    case 2: Helper.PrintColor("Размер массива: " + taskArray.Length, ConsoleColor.Green); Helper.EndTask();  break;
                    case 3: Helper.PrintColor("Сумма массива: " + taskArray.Sum, ConsoleColor.Green); Helper.EndTask(); break;
                    case 4: Helper.PrintColor("Количество максимальных элементов массива: " + taskArray.MaxCount, ConsoleColor.Green); Helper.EndTask(); break;
                    case 5: Inverse(taskArray); break;
                    case 6: Mult(taskArray); break;
                    case 7: PrintArray(taskArray); break;
                    case 8: LoadFromFile(taskArray); break;
                    default: break;
                }
            }
            while (number != 0);

            Helper.EndTask();
        }

        #endregion

        #region Task2

        /// <summary>
        /// Структура аккаунта с логином и паролем
        /// </summary>
        public struct Account
        {
            string login;
            string password;

            public string Login
            {
                get { return login; }
                set { login = value; }
            }

            public string Password
            {
                get { return password; }
                set { password = value; }
            }

            public override string ToString()
            {
                return $"Login: {login}, Password: {password}";
            }
        }

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
                if (parol == "GeekBrains")
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Загружает массив аккаунтов из файла
        /// </summary>
        /// <param name="fileName">имя загружаемого файла</param>
        /// <returns>массив аккаунтов</returns>
        public static Account[] LoadLoginFromFile(string fileName)
        {
            Account[] accounts = new Account[3];

            //Заполняем массив пустыми значениями
            for(int i=0; i<accounts.Length; ++i)
            {
                accounts[i].Login = "";
                accounts[i].Password = "";
            }

            //Проверяем наличие файла
            if (File.Exists(fileName))
            {
                //Читаем из файла
                StreamReader streamReader = new StreamReader(fileName);
                
                int count = 0;

                while (!streamReader.EndOfStream && count < 3 )
                {
                    accounts[count].Login    = streamReader.ReadLine();

                    if(!streamReader.EndOfStream)
                        accounts[count].Password = streamReader.ReadLine();

                    count++;
                }
               
                streamReader.Close();

                //удаление лишних аккаунтов
                Account[] accountsReturn = new Account[count];
                Array.Copy(accounts, accountsReturn, count);

                //Возвращаем заполненный массив Account
                return accountsReturn;
            }
            else
                throw new FileNotFoundException();

        }

        /// <summary>
        /// Задача № 4
        /// </summary>
        public static void ExecuteTask2()
        {
            Helper.PrintInfo(4, 2,
               "Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.",
               "Долгов Константин");

            Helper.PrintProgrammInfo("Мы попрбоуем авторизоваться в программе с помощью логина и пароля.");
            Helper.PrintProgrammInfo("Логин и пароль будут считаны из приложенного файла Logins.txt");

            Helper.PrintLine("");
            Helper.PrintGreen("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            

            //Загружаем аккаунты
            Account[] accounts = LoadLoginFromFile(AppDomain.CurrentDomain.BaseDirectory + "Logins.txt");

            //Печатаем данные загруженных аккаунтов
            Helper.PrintGreen("Были загружены следующие аккаунты:");
            foreach (Account account in accounts)
            {
                Helper.PrintColor(account.ToString(), ConsoleColor.Yellow);
            }


            Helper.PrintLine("");
            Helper.PrintGreen("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();

            
            //Пробуем авторизоваться с помощью аккаунтов 
            int numberCount = 3;
            bool loginValid = false;

            for(int i = 0; i < numberCount; ++i)
            {
                //Проверка существования аккаунта
                if(i == accounts.Length)
                {
                    numberCount = i;
                    break;
                }
                else
                {   
                    //Авторизация
                    if(IsLoginParolValid(accounts[i].Login, accounts[i].Password))
                    {
                        Helper.PrintGreen($"Попытка №{i + 1}: Авторизация успешна. "+accounts[i].ToString());
                        loginValid = true;
                        numberCount = i + 1;
                        break;
                    }
                    else
                    {
                        Helper.PrintRed($"Попытка №{i + 1}: Авторизоваться не удалось. " + accounts[i].ToString());
                    }
                }
            }

            //завершение программы в зависимости от правильности ввода
            if (loginValid)
            {
                Helper.PrintGreen($"Логин и пароль указаны верно. Поздравляем, задача завершена успешно. Количество попыток - {numberCount}");
            }
            else
            {
                Helper.PrintRed($"Логин и пароль указаны неверно. Программа завершена, так как Вы ввели неправильные данные {numberCount} раз.");
            }

            Helper.EndTask();
        }

        #endregion
    }
}
