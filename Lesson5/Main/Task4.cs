using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HelperUtils;

namespace Main
{
    class Task4
    {
        /// <summary>
        /// Структура, хранящая данные ученика
        /// </summary>
        public struct Student
        {
            string name;
            string surname;
            double score;

            public string Name { get { return name;  }  set { name = value; } }
            public string Surname { get { return surname; } set { surname = value; } }
            public string Score { get { return score.ToString("#.##"); } }
            public double ScoreInDouble { get { return score; } }

            public void setStudent(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
            }
                    
            public void CalcScore(int score1, int score2, int score3)
            {
                score = Convert.ToDouble(score1 + score2 + score3) / 3.0;
            }
        }


        /// <summary>
        /// Загружает массив учеников из файла
        /// </summary>
        /// <param name="fileName">имя загружаемого файла</param>
        /// <returns>массив учеников</returns>
        public static Student[] LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader streamReader = new StreamReader(fileName);

                //Читаем количество учеников и создаём их массив
                int studCount = int.Parse(streamReader.ReadLine());
                if(studCount < 10)
                {
                    throw new Exception($"Количество учеников в файле Students = {studCount}. Допустимо от 10 учеников.");
                }

                Student[] students = new Student[studCount];

                //Читаем данные учеников
                for (int i = 0; i < students.Length; ++i)
                {
                    string[] studentStrings = streamReader.ReadLine().Split(' ');

                    if(studentStrings.Length != 5)
                    {
                        throw new Exception($"Формат данных строки {i+1} не соответствует <Фамилия> <Имя> <Оценка> <Оценка> <Оценка>.");
                    }

                    //проверка количества символов фамилии и имени
                    if (studentStrings[0].Length <= 20 && studentStrings[1].Length <= 15)
                    {
                        //запись данных ученика
                        students[i].setStudent(studentStrings[1], studentStrings[0]);
                        students[i].CalcScore(int.Parse(studentStrings[2]), int.Parse(studentStrings[3]), int.Parse(studentStrings[4]));
                    }
                    else
                    {
                        throw new Exception("Имя или фамилия состоят из слишком большого количества символов.");
                    }
                }

                streamReader.Close();

                return students;
            }
            else
                throw new FileNotFoundException("Файл Students.txt не найден");
        }

        public static void ExecuteTask()
        {
            Helper.PrintInfo(5, 4,
               @"4. *Задача ЕГЭ. На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
<Фамилия> <Имя> <оценки>, где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.",
               "Долгов Константин");

            Helper.PrintProgrammInfo("Мы загрузим всех учеников из файла Students.txt и выведем фамилии и имена трёх худших учеников.");

            Student[] students;

            //Загрузка студентов из файла
            try
            {
                students = LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "Students.txt");
            }
            catch (Exception ex)
            {
                Helper.PrintRed("При загрузке учеников из файла Students.txt произошла ошибка:");
                Helper.PrintRed(ex.Message);

                Helper.EndTask();

                return;
            }

            //Сортировка студентов по возрастанию среднего балла
            Student[] sortedStudents  =  students.OrderBy(s => s.Score).ToArray();

            //Вывод учеников согласно трём самым худшим показателем среднего балла
            int count = 0;
            double currentScore = 0;

            for (int i = 0; i < sortedStudents.Length; ++ i)
            {
                if(currentScore != sortedStudents[i].ScoreInDouble)
                {
                    //выход из цикла, если выбраны все ученики с трёмя наименьшими средними баллами
                    if (count >= 3)
                        break;

                    //выбор следующего среднего балла
                    currentScore = sortedStudents[i].ScoreInDouble;
                    Helper.PrintYellow($"{count+1}. Средний балл - {sortedStudents[i].Score}");

                    ++count;
                }

                //вывод информации о студенте с текущим средним баллом
                Helper.PrintLine($"{sortedStudents[i].Surname} {sortedStudents[i].Name}");
            }

            Helper.EndTask();
        }
    }
}
