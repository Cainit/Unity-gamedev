using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Unity Gamedev 
Студент: Константин Долгов
Домашняя работа № 8
Задание № 1
1. С помощью рефлексии выведите все свойства структуры DateTime.
 */

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выводим свойста DataTime:");

            Type dataTimType = typeof(DateTime);

            foreach (var property in dataTimType.GetProperties())
            {
                Console.WriteLine(property.Name);
            }

            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
