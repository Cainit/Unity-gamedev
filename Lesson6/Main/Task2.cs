using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HelperUtils;

namespace Main
{
    class Task2
    {
        /// <summary>
        /// делегат записываемой в файл функции
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public delegate double Function(double x);

        /// <summary>
        /// Записывает данные функции от a до b с шшагом h.
        /// </summary>
        /// <param name="fileName">имя сохраняемого файла</param>
        /// <param name="a">начальное значение</param>
        /// <param name="b">конечное значение</param>
        /// <param name="h">шаг значения</param>
        public static void SaveFunc(string fileName, Function userFunction, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create,
            FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(userFunction(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// Выполняет чтение файла и выводит минимальное значение
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }

        /// <summary>
        /// Возвращает массив значений
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double[] arrayValue = new double[fs.Length / sizeof(double)];
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                arrayValue[i] = d;
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return arrayValue;
        }

        /// <summary>
        /// Выполняет выбраннуую функцию и выводит минимальное значение
        /// </summary>
        /// <param name="userFunction">выполняемая функция</param>
        static void ProcessFunction(Function userFunction)
        {
            Helper.PrintLine("");

            //сохранение значений функции в файл
            SaveFunc("data.bin", userFunction, 
                Helper.WaitDouble("Задайте начальное значение x: "), 
                Helper.WaitDouble("Задайте конечное значение x: "), 
                0.5);

            //чтение значений из файла
            double minValue = 0;
            double[] arrayValue = Load("data.bin", out minValue);

            //Вывод значений и минимального значения
            Helper.PrintLine("");
            Helper.PrintUnderline();
            Helper.PrintYellow("Значения функции: ");

            foreach (double value in arrayValue)
                Helper.PrintLine(value.ToString());
            
            Helper.PrintYellow("Минимальное значение: " + minValue.ToString());
            Helper.PrintUnderline();

            Helper.PauseTask();
        }

        /// <summary>
        /// Задача 2
        /// </summary>
        public static void ExecuteTask()
        {
            int methodNumber = 0;

            //Список делегатов функций
            List<Function> functions = new List<Function>();
            functions.Add(null);    //Добавляем первый элемент для удобства выбора
            functions.Add(Func1);
            functions.Add(Func2);
            functions.Add(Func3);
            functions.Add(Func4);
            functions.Add(Func5);
            functions.Add(Func6);
            functions.Add(Func7);
            functions.Add(Func8);
            functions.Add(Func9);

            //Основной цикл программы, выбор решаемой задачи через консольное меню
            do
            {
                Console.Clear();
                Helper.PrintInfo(6, 2,
               @"2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.Использовать массив (или список) делегатов, в котором хранятся различные функции.
б) *Переделать функцию Load, чтобы она возвращала массив считанных значений.Пусть она возвращает минимум через параметр (с использованием модификатора out). ",
                "Долгов Константин");

                Helper.PrintProgrammInfo("Вы можете выбрать любую функцию из меню, а затем отрезок.");
                Helper.PrintProgrammInfo("Мы вычислим функцию на заданном отрезке с шагом 0.5 и сохраним данные в файл.");
                Helper.PrintProgrammInfo("Затем загрузим файл и найдём в нём минимальное значение.");


                //Вывод меню функций
                PrintMenu();

                //Выбор решаемой функции
                methodNumber = Helper.WaitNumber("Введите номер команды: ");

                if (methodNumber > 0 && methodNumber < 10)
                    ProcessFunction(functions[methodNumber]);

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
            Helper.PrintProgrammInfo("Меню выбора функции:");
            Helper.PrintProgrammInfo("1 -> Функция F(x)=x^2");
            Helper.PrintProgrammInfo("2 -> Функция F(x)=2^x");
            Helper.PrintProgrammInfo("3 -> Функция F(x)=sin(x)");
            Helper.PrintProgrammInfo("4 -> Функция F(x)=cos(x)");
            Helper.PrintProgrammInfo("5 -> Функция F(x)=tan(x)");
            Helper.PrintProgrammInfo("6 -> Функция F(x)=atan(x)");
            Helper.PrintProgrammInfo("7 -> Функция F(x)=sqrt(x)");
            Helper.PrintProgrammInfo("8 -> Функция F(x)=log2(x)");
            Helper.PrintProgrammInfo("9 -> Функция F(x)=x^2-2x");
            Helper.PrintProgrammInfo("0 -> Вернуться к меню выбора решенных задач.");
        }

        #region Functions

        public static double Func1(double x)
        {
            return Math.Pow(x, 2);
        }

        public static double Func2(double x)
        {
            return Math.Pow(2, x);
        }

        public static double Func3(double x)
        {
            return Math.Sin(x);
        }

        public static double Func4(double x)
        {
            return Math.Cos(x);
        }

        public static double Func5(double x)
        {
            return Math.Tan(x);
        }

        public static double Func6(double x)
        {
            return Math.Atan(x);
        }

        public static double Func7(double x)
        {
            return Math.Sqrt(x);
        }

        public static double Func8(double x)
        {
            return Math.Log(x, 2);
        }

        public static double Func9(double x)
        {
            return Math.Pow(x, 2) - (2 * x);
        }

        #endregion
    }
}
