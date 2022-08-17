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
        /// Устанавливает новый текст для работы
        /// </summary>
        /// <returns></returns>
        public static string SetNewText()
        {
            Helper.PrintLine("");
            Helper.Print("Введите новый текст: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Удаляет слова с количеством символов меньше н
        /// </summary>
        /// <param name="text"></param>
        public static void OnlyShortWords(string text)
        {
            Helper.PrintLine("");

            int n = Helper.WaitNumber("Введите максимально допустимое количество символов в словах: ");

            string newText = Message.PrintOnlyShort(text, n);

            if (newText.Length > 0)
            {
                Helper.PrintLine($"Класс Message с помощью метода PrintOnlyShort убрал все слова, где символов меньше {n}");
                Helper.PrintLine("В результате получился следующий текст:");
                Helper.PrintYellow(newText);
            }
            else
            {
                Helper.PrintRed($"Текст не содержит слов, с количеством символов меньше или равно {n}");
            }

            Helper.PauseTask();
        }

        /// <summary>
        /// Удаляет слова, заканчивающиеся на определенный символ 
        /// </summary>
        /// <param name="text"></param>
        public static void DeleteWordsFromLastSymbol(string text)
        {
            Helper.PrintLine("");
            Helper.Print("Введите символ: ");
            string str = Console.ReadLine();
            char symbol;

            if (str.Length > 1)
            {
                symbol = str.First();
                Helper.PrintRed($"Вы ввели несколько символов. При решении задачи мы будем использовать первый - {symbol}");
            }
            else
            {
                symbol = str.First();
            }

            string newText = Message.DeleteWordsFromLastSymbol(text, symbol);

            if (newText.Length > 0)
            {
                Helper.PrintLine($"Класс Message с помощью метода DeleteWordsFromLastSymbol убрал все слова, заканчивающиеся на символ '{symbol}'");
                Helper.PrintLine("В результате получился следующий текст:");
                Helper.PrintYellow(newText);
            }
            else
            {
                Helper.PrintRed("В тексте не осталось никаких слов.");
            }

            Helper.PauseTask();

        }

        /// <summary>
        /// Находит самое длинное слово
        /// </summary>
        /// <param name="text"></param>
        public static void FindMostLong(string text)
        {
            Helper.PrintLine("");
            
            string newText = Message.FindMostLong(text);

            if (newText.Length > 0)
            {
                Helper.PrintLine($"Класс Message с помощью метода FindMostLong нашёл самое длинное слово:");
                Helper.PrintYellow(newText);
            }
            else
            {
                Helper.PrintRed("В тексте нет слов.");
            }

            Helper.PauseTask();
        }

        /// <summary>
        /// Формирует строку из самых длинных слов
        /// </summary>
        /// <param name="text"></param>
        public static void FormString(string text)
        {
            Helper.PrintLine("");

            string newText = Message.FormStringFromLong(text);
            int longCount = text.Split(new[] { ' ', '.', ',', '!', '?', '*', '/', ')', '(', ':' }, StringSplitOptions.RemoveEmptyEntries).Length;

            if (newText.Length > 0)
            {
                Helper.PrintLine($"Класс Message с помощью метода FormStringFromLong сформировал строку.");
                Helper.PrintLine($"В тексте содержалось {longCount} длинных слов:");
                Helper.PrintYellow(newText);
            }
            else
            {
                Helper.PrintRed("В тексте нет слов.");
            }

            Helper.PauseTask();
        }

        /// <summary>
        /// Частотный анализ текста
        /// </summary>
        /// <param name="text"></param>
        public static void AnalizeFrequency(string text)
        {
            Helper.PrintLine("");
            Helper.PrintLine("Нужно сформировать массив слов для частотного анализа текста.");

            //Формирование массива
            Dictionary<string, int> dict = new Dictionary<string, int>();

            string wordAnalize = "";
            do
            {
                Helper.Print("Введите слово для анализа или '0' для завершения: ");
                wordAnalize = Console.ReadLine();
                if(wordAnalize != "")
                {
                    dict.Add(wordAnalize, 0);
                }
            }
            while (wordAnalize != "0");
            
            dict = Message.AnalizeFrequency(dict.Keys.ToArray(), text);

            if (dict.Count > 0)
            {
                Helper.PrintLine($"Класс Message с помощью метода AnalizeFrequency провел частотный анализ текста.");

                foreach (var word in dict)
                {
                    Helper.PrintYellow($"Слово '{word.Key}' встречается в тексте {word.Value} раз.");
                }
            }
            else
            {
                Helper.PrintRed("В тексте нет слов.");
            }

            Helper.PauseTask();
        }

        public static void ExecuteTask()
        {
            Helper.PrintInfo(5, 2,
               @"2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста.В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.",
               "Долгов Константин");

            Helper.PauseTask();

            string text = "Это проверочное сообщение для метода Message. Оно служит исключительно для проверки. Если хотите, вы можете изменить этот текст на любой другой с помощью команды 1.";

            int methodNumber = 0;
            //Основной цикл программы, выбор решаемой задачи через консольное меню
            do
            {
                Console.Clear();
                Helper.PrintProgrammInfo("У нас есть статический класс Message, который имеет свои методы.");
                Helper.PrintProgrammInfo("Для проверки методов у нас есть текст:");
                Helper.PrintYellow($"{text}");

                //Вывод программного меню
                PrintMenu();

                //Выбор решаемой задачи
                methodNumber = Helper.WaitNumber("Введите номер команды: ");
                switch (methodNumber)
                {
                    case 1: text = SetNewText(); break;
                    case 2: OnlyShortWords(text); break;
                    case 3: DeleteWordsFromLastSymbol(text); break;
                    case 4: FindMostLong(text); break;
                    case 5: FormString(text); break;
                    case 6: AnalizeFrequency(text); break;
                    default: break;
                }
            }
            while (methodNumber != 0);
        }

        /// <summary>
        /// Меню проверки методов класса Message
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine();
            Helper.PrintMenuline();
            Helper.PrintProgrammInfo("Меню выбора команд:");
            Helper.PrintProgrammInfo("1 -> Установить новый текст для проверки.");
            Helper.PrintProgrammInfo("2 -> Вывести слова с не более чем 'n' количеством букв.");
            Helper.PrintProgrammInfo("3 -> Удалить слова, заканчивающиеся на заданный символ.");
            Helper.PrintProgrammInfo("4 -> Найти самое длинное слово.");
            Helper.PrintProgrammInfo("5 -> Сформировать строку из самых длинных слов.");
            Helper.PrintProgrammInfo("6 -> Частотный анализ текста.");
            Helper.PrintProgrammInfo("0 -> Вернуться к меню выбора решенных задач.");

        }
    }
}
