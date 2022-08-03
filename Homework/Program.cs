using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.WriteLine("а) Итак, Вы - "+ surname+" "+name+", вам "+age+" лет, ваш рост "+height+" сантиметров, а вес - "+weight+" килограмм");
            Console.WriteLine("б) Итак, Вы - {0} {1}, вам {2} лет, ваш рост {3} сантиметров, а вес - {4} килограмм", surname, name, age, height, weight);
            Console.WriteLine($"в) Итак, Вы - {surname} {name}, вам {age} лет, ваш рост {height} сантиметров, а вес - {weight} килограмм");

            Console.ReadLine();
        }
    }
}
