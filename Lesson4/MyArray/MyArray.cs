using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperUtils;
using System.IO;

namespace MyArray
{
    /// <summary>
    /// Класс-обёртка для одномерного массива типа int
    /// </summary>
    public class ArrayClass
    {
        private int[] array;

        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        /// <summary>
        /// Количество элементов массива
        /// </summary>
        public int Length
        {
            get { return array.Length; }
        }

        /// <summary>
        /// Сумма чисел всех элементов массива
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;

                for (int i = 0; i < array.Length; ++i)
                {
                    sum = sum + array[i];
                }

                return sum;
            }
        }

        /// <summary>
        /// Возвращает количество максимальных элементов массива
        /// </summary>
        public int MaxCount
        {
            get
            {
                int maxCount = 1;
                int max = 0;
                for(int i = 0; i < Length; ++i)
                {
                    if(array[i] > max)
                    {
                        max = array[i];
                        maxCount = 1;
                    }
                    else if(array[i] == max)
                    {
                        ++maxCount;
                    }
                }

                return maxCount;
            }
        }

        /// <summary>
        /// Конструктор массива с инициализацией
        /// </summary>
        /// <param name="array"></param>
        public ArrayClass(int[] array)
        {
            this.array = array;
        }


        /// <summary>
        /// Возвращает новую копию массива
        /// </summary>
        /// <param name="array"></param>
        public ArrayClass Copy()
        {
            ArrayClass newArray = new ArrayClass(array);
            return newArray;
        }

        /// <summary>
        /// Констуктор массива с инициализацией заданного размера массива
        /// </summary>
        /// <param name="size"></param>
        public ArrayClass(int size)
        {
            Random random = new Random();
            array = new int[size];
            for (int i = 0; i < size; ++i)
            {
                array[i] = random.Next(-99, 100);
            }
        }

        /// <summary>
        /// Конструктор массива с заданным размером. Заполняет массив числами от заданного значения с определённым шагом.
        /// </summary>
        /// <param name="size">размер массива</param>
        /// <param name="originNumber">начальное значение</param>
        /// <param name="step">шаг заполнения</param>
        public ArrayClass(int size, int originNumber, int step)
        {
            array = new int[size];
            for(int i = 0; i < size; ++i)
            {
                array[i] = originNumber + step * i;
            }
        }

        /// <summary>
        /// Конструктор массива с инициализацией из файла
        /// </summary>
        /// <param name="fileName">имя загружаемого файла</param>
        public ArrayClass(string fileName)
        {
            array = LoadArrayFromFile(fileName);
        }

        /// <summary>
        /// Выводит все элементы массива в одну строку через запятую
        /// </summary>
        public void PrintArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            string arrayString = "";
            for (int i = 0; i < array.Length; i++)
            {
                arrayString += ($"{array[i]}, ");
            }
            return arrayString;
        }

        /// <summary>
        /// Возвращает новый массив с инвертированными значениями элементов
        /// </summary>
        /// <returns></returns>
        public ArrayClass Inverse()
        {
            ArrayClass newArray = new ArrayClass(array);

            for(int i = 0; i < newArray.Length; ++i)
            {
                newArray[i] = -newArray[i];
            }

            return newArray;
        }

        /// <summary>
        /// Умножает все элементы массива на заданное число
        /// </summary>
        /// <param name="mult">множитель</param>
        public void Multi(int mult)
        {
            for(int i = 0; i < Length; ++i)
            {
                array[i] *= mult;
            }
        }

        /// <summary>
        /// Загружает массив из указанного файла
        /// </summary>
        /// <param name="fileName">загружаемый файл</param>
        /// <returns>загруженный массив</returns>
        private int[] LoadArrayFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader streamReader = new StreamReader(fileName);
                int[] buf = new int[1000];
                int count = 0;

                while (!streamReader.EndOfStream)
                {
                    buf[count] = int.Parse(streamReader.ReadLine());
                    count++;
                }

                int[] arr = new int[count];
                Array.Copy(buf, arr, count);
                streamReader.Close();
                return arr;
            }
            else
                throw new FileNotFoundException();
        }
    }
}
