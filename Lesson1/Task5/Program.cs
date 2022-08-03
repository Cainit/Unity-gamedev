using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*5. а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
            б) Сделать задание, только вывод организовать в центре экрана.
            в) *Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).

            Студент - Константин Долгов*/

            Console.Title = "Печать в центре экрана";

            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");
            string surname = Console.ReadLine();

            Console.Write("Введите город вашего проживания: ");
            string city = Console.ReadLine();


            string displayString = $"Вы {name} {surname}, и вы проживаете в городе {city}";

            // варианта а)
            Console.Write("Вариант а): "+displayString);

            // вариант б) и в)
            displayString = $"Вариант б,в): Вы {name} {surname}, и вы проживаете в городе {city}";
            PrintString(displayString, Console.WindowWidth / 2 - displayString.Length / 2, Console.WindowHeight / 2);

            Console.ReadLine();
        }

        static void PrintString(string str, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(str);
        }
    }
}
