using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HelperUtils;

namespace Main
{
/* 2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста. 
В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива 
входит в этот текст. Здесь требуется использовать класс Dictionary. */

    static class Message
    {
        /// <summary>
        /// Возвращает строку из слов, длина которых состоит из не менее чем 'n' символов
        /// </summary>
        /// <param name="text">текст для анализа</param>
        /// <param name="n">максимальная длина слова</param>
        /// <returns>слова</returns>
        public static string PrintOnlyShort(string text, int n)
        {
            string shortedWords = "";

            string[] words = text.Split(new[] { ' ', '.', ',', '!', '?', '*', '/', ')', '(', ':' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string word in words)
            {
                if (word.Length <= n)
                {
                    shortedWords = string.Join(" ", new []{ shortedWords, word });
                }
            }
            
            return shortedWords;
        }

        /// <summary>
        /// Удаляет все слова, заканчивающиеся на определённый символ
        /// </summary>
        /// <param name="text">анализируемый текст</param>
        /// <param name="symbol">символ</param>
        /// <returns>строка без слов, оканчивающихся на указанный символ</returns>
        public static string DeleteWordsFromLastSymbol(string text, char symbol)
        {
            string[] words = text.Split(new[] { ' ', '.', ',', '!', '?', '*', '/', ')', '(', ':' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string s in words)
            {
                if (s.EndsWith(symbol.ToString()))
                {
                    text = text.Replace(s, string.Empty);
                }
            }

            return text;
        }

        /// <summary>
        /// Находит самое длинное слово
        /// </summary>
        /// <param name="text">обрабатывемый текст</param>
        /// <returns>самое длинное слово</returns>
        public static string FindMostLong(string text)
        {
            string longestWord = "";
            string[] words = text.Split(new[] { ' ', '.', ',', '!', '?', '*', '/', ')', '(', ':' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (word.Length > longestWord.Length)
                    longestWord = word;
            }

            return longestWord;
        }

        /// <summary>
        /// Формирует строку с помощью StringBuilder из самых длинных слов
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string FormStringFromLong(string text)
        {
            string longestWord = FindMostLong(text);

            string[] words = text.Split(new[] { ' ', '.', ',', '!', '?', '*', '/', ')', '(', ':' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();
            
            foreach (string word in words)
            {
                if (word.Length == longestWord.Length)
                    sb.Append(word + " ");
            }
            

            return sb.ToString();
        }

        /// <summary>
        /// Частотный анализ текста.
        /// </summary>
        /// <param name="words">искомые слова</param>
        /// <param name="text">текст для анализа</param>
        /// <returns>словарь с количеством встречающихся слов</returns>
        public static Dictionary<string, int> AnalizeFrequency(string[] words, string text)
        {
            //Заполнение словаря
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for(int i = 0; i < words.Length; ++i)
            {
                dict.Add(words[i].ToLower(), 0);
            }

            //Анализ текста
            string[] textWords = text.Split(new[] { ' ', '.', ',', '!', '?', '*', '/', ')', '(', ':' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string word in textWords)
            {
                if(dict.ContainsKey(word.ToLower()))
                {
                    ++dict[word];
                }
            }

            return dict;
        }
    }
}
