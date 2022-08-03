using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*3.    а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
                    б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
            
            Студент - Константин Долгов */

            Console.Title = "Рассчёт расстояния между двумя точками";

            Console.Write("Введите 'x' координату первой точки ");
            double x1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите 'y' координату первой точки ");
            double y1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите 'x' координату второй точки ");
            double x2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите 'y' координату второй точки ");
            double y2 = Convert.ToDouble(Console.ReadLine());

            double distance = GetDistance(x1, y1, x2, y2);

            Console.Write("Расстояние равно: {0:F2}", distance);

            Console.ReadLine();
        }

        static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}