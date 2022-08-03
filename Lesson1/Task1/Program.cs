using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1. Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
            а) используя склеивание;
            б) используя форматированный вывод;
            в) используя вывод со знаком $.

            Студент - Константин Долгов */

            Console.Title = "Анкета";

            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");
            string surname = Console.ReadLine();

            Console.Write("Сколько вам лет? ");
            double age = Convert.ToDouble(Console.ReadLine());

            Console.Write("Сколько сантиметров ваш рост? ");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Сколько киллограмов вы весите? ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("а) Итак, Вы - " + surname + " " + name + ", вам " + age + " лет, ваш рост " + height + " сантиметров, а вес - " + weight + " килограмм");
            Console.WriteLine("б) Итак, Вы - {0} {1}, вам {2} лет, ваш рост {3} сантиметров, а вес - {4} килограмм", surname, name, age, height, weight);
            Console.WriteLine($"в) Итак, Вы - {surname} {name}, вам {age} лет, ваш рост {height} сантиметров, а вес - {weight} килограмм");

            Console.ReadLine();
        }
    }
}
