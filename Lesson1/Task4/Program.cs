using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*4. Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.
            а) с использованием третьей переменной;
            б) *без использования третьей переменной.

            Студент - Константин Долгов */

            Console.Title = "Обмен переменных";
            int varOne = 10;
            int varTwo = 20;

            Console.WriteLine("Значения переменных до обмена: первая=" + varOne + ", вторая =" + varTwo );

            //вариант а)
            int varThree = varOne;
            varOne = varTwo;
            varTwo = varThree;
            Console.WriteLine("Значения переменных для обмена а): первая=" + varOne + ", вторая =" + varTwo);

            //вариант б)
            varOne = varOne + varTwo;
            varTwo = varTwo - varOne;
            varTwo = -varTwo;
            varOne = varOne - varTwo;
            Console.WriteLine("Значения переменных для обмена б): первая=" + varOne + ", вторая =" + varTwo);

            Console.ReadLine();
        }
    }
}
