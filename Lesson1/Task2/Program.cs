using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*2. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); 
            где m — масса тела в килограммах, h — рост в метрах.

            Студент - Константин Долгов */

            Console.Title = "Рассчёт индекса массы тела";

            Console.Write("Сколько килограмм вы весите?");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Сколько сантиметров ваш рост? ");
            double height = Convert.ToDouble(Console.ReadLine()) / 100;

            double indexBodyMass = weight / (height * height);

            Console.WriteLine("Ваш индекс массы тела: "+ indexBodyMass);

            Console.ReadLine();
        }
    }
}
