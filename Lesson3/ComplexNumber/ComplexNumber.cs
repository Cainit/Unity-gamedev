using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumber
{
    /// <summary>
    /// Структура комплексного числа
    /// </summary>
    public struct SComplexNumber
    {
        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        public double im;

        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        public double re;

        /// <summary>
        /// сложение комплексных чисел
        /// </summary>
        /// <param name="x">слагаемое комплексное число</param>
        /// <returns>сумма комплексных чисел</returns>
        public SComplexNumber Plus(SComplexNumber x)
        {
            SComplexNumber y = new SComplexNumber();
            y.re = re + x.re;
            y.im = im + x.im;
            return y;
        }

        /// <summary> вычитание комплексных чисел </summary>
        /// <param name="x">Комплексное число для вычитания</param>
        /// <returns>разница комплексных чисел</returns>
        public SComplexNumber Minus(SComplexNumber x)
        {
            SComplexNumber y = new SComplexNumber();
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }

        /// <summary> Метод произведения с другим комплексным числом </summary>
        /// <param name="x">Комплексное число для множителя</param>
        /// <returns>произведение комплексных чисел</returns>
        public SComplexNumber Multi(SComplexNumber x)
        {
            SComplexNumber y = new SComplexNumber();
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }

        /// <summary>
        /// Сложение двух комплексных чисел
        /// </summary>
        /// <param name="complex1">слагаемое комплексное число</param>
        /// <param name="complex2">слагаемое комплексное число</param>
        /// <returns>сумма комплексных чисел</returns>
        public static SComplexNumber Plus(SComplexNumber complex1, SComplexNumber complex2)
        {
            return complex1.Plus(complex2);
        }

        /// <summary> вычитание комплексных чисел </summary>
        /// <param name="x">Комплексное число для вычитания</param>
        /// <returns>разница комплексных чисел</returns>
        public static SComplexNumber Minus(SComplexNumber complex1, SComplexNumber complex2)
        {
            return complex1.Minus(complex2);
        }

        /// <summary> Метод произведения с другим комплексным числом </summary>
        /// <param name="x">Комплексное число для множителя</param>
        /// <returns>произведение комплексных чисел</returns>
        public static SComplexNumber Multi(SComplexNumber complex1, SComplexNumber complex2)
        {
            return complex1.Multi(complex2);
        }

        /// <summary>
        /// Представлет комплексное число как строку
        /// </summary>
        /// <returns>значение комплексного числа в строке</returns>
        public override string ToString()
        {
            return $"{re} + {im}i";
        }
    }

    /// <summary>
    /// Класс комплексного числа
    /// </summary>
    public class CComplexNumber
    {
        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        public double im;

        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        public double re;

        /// <summary>
        /// Конструктор комплексного числа
        /// </summary>
        /// <param name="re">действительная часть числа</param>
        /// <param name="im">мнимая часть числа</param>
        public CComplexNumber(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        /// <summary>
        /// Конструктор комплексного числа
        /// </summary>
        public CComplexNumber()
        {
            this.re = 0;
            this.im = 0;
        }

        /// <summary>
        /// сложение комплексных чисел
        /// </summary>
        /// <param name="x">слагаемое комплексное число</param>
        /// <returns>сумма комплексных чисел</returns>
        public CComplexNumber Plus(CComplexNumber x)
        {
            CComplexNumber y = new CComplexNumber();
            y.re = re + x.re;
            y.im = im + x.im;
            return y;
        }

        /// <summary> вычитание комплексных чисел </summary>
        /// <param name="x">Комплексное число для вычитания</param>
        /// <returns>разница комплексных чисел</returns>
        public CComplexNumber Minus(CComplexNumber x)
        {
            CComplexNumber y = new CComplexNumber();
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }

        /// <summary> Метод произведения с другим комплексным числом </summary>
        /// <param name="x">Комплексное число для множителя</param>
        /// <returns>произведение комплексных чисел</returns>
        public CComplexNumber Multi(CComplexNumber x)
        {
            CComplexNumber y = new CComplexNumber();
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }


        /// <summary>
        /// Сложение двух комплексных чисел
        /// </summary>
        /// <param name="complex1">слагаемое комплексное число</param>
        /// <param name="complex2">слагаемое комплексное число</param>
        /// <returns>сумма комплексных чисел</returns>
        public static CComplexNumber Plus(CComplexNumber complex1, CComplexNumber complex2)
        {
            CComplexNumber res = new CComplexNumber();
            res.re = complex1.re + complex2.re;
            res.im = complex1.im + complex2.im;
            return res;
        }

        /// <summary> вычитание комплексных чисел </summary>
        /// <param name="x">Комплексное число для вычитания</param>
        /// <returns>разница комплексных чисел</returns>
        public static CComplexNumber Minus(CComplexNumber complex1, CComplexNumber complex2)
        {
            return complex1.Minus(complex2);
        }

        /// <summary> Метод произведения с другим комплексным числом </summary>
        /// <param name="x">Комплексное число для множителя</param>
        /// <returns>произведение комплексных чисел</returns>
        public static CComplexNumber Multi(CComplexNumber complex1, CComplexNumber complex2)
        {
            return complex1.Multi(complex2);
        }

        /// <summary>
        /// Представлет комплексное число как строку
        /// </summary>
        /// <returns>значение комплексного числа в строке</returns>
        public override string ToString()
        {
            return $"{re} + {im}i";
        }

    }
}
