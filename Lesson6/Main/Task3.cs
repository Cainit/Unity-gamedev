using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HelperUtils;

namespace Main
{
    /// <summary>
    /// Класс студента
    /// </summary>
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        // Создаем конструктор
        public Student(string firstName, string lastName, string university,
        string faculty, string department, int course, int age, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }

        public override string ToString()
        {
            return $"{lastName} {firstName} {university} {faculty} {course} {department} {group} {city} {age}";
        }
    }

    class Task3
    {
        /// <summary>
        /// Загружает список студентов из файла и возвращает его в списке
        /// </summary>
        /// <returns>список студентов</returns>
        static List<Student> LoadStudents()
        {
            List<Student> list = new List<Student>();
            
            StreamReader sr = new StreamReader("students.csv");
            while (!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(';');

                // Добавляем в список новый экземпляр класса Student
                list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[6]), int.Parse(s[5]), int.Parse(s[7]), s[8]));
            }
            sr.Close();

            return list;
        }

        /// <summary>
        /// Выводми на экран список сиудентов
        /// </summary>
        /// <param name="listStudents">список студентов</param>
        public static void PrintStudents(List<Student> listStudents)
        {
            foreach(Student student in listStudents)
            {
                Helper.PrintLine(student.ToString());
            }

            Helper.PauseTask();
        }

        /// <summary>
        /// Выводит количество студенов, учащихся на 5 и 6 курсе
        /// </summary>
        /// <param name="listStudents">список студентов</param>
        public static void PrintStudentCourceCount(List<Student> listStudents)
        {
            int course5 = 0, course6 = 0;

            foreach (Student student in listStudents)
            {
                if (student.course == 5)
                    ++course5;
                else if (student.course == 6)
                    ++course6;
            }

            /* или можно посчитать сразу общее количество как-то так
            Student[] course5and6 = listStudents.Where(st => st.course == 4 || st.course == 5).ToArray();
            */


            Helper.PrintYellow($"Количество студентов, учащихся на 5 курсе - {course5}");
            Helper.PrintYellow($"Количество студентов, учащихся на 6 курсе - {course6}");
            Helper.PrintYellow($"Общее количество студентов по условию поиска - {course5+course6}");

            Helper.PauseTask();
        }

        /// <summary>
        /// Выводит количество студенов на курсе возрастом от 18 до 20 лет
        /// </summary>
        /// <param name="listStudents">список студентов</param>
        public static void PrintStudentAllCourceCount(List<Student> listStudents)
        {
            int[] course = new int[6];  //частотный массив
            
            //распределяем студентов по курсам
            foreach (Student student in listStudents)
            {
                if (student.age >= 18 && student.age <= 20)
                    ++course[student.course-1];
            }

            //выводим информацию о количестве учащихся
            for(int i = 0; i < course.Length; ++i)
            {
                Helper.PrintYellow($"Количество студентов от 18 до 20 лет, учащихся на {i+1} курсе - {course[i]}");
            }
 
            Helper.PauseTask();
        }

        /// <summary>
        /// Выводит список студентов, отсортированных по возрасту
        /// </summary>
        /// <param name="listStudents">список студентов</param>
        public static void PrintSortAgeStudents(List<Student> listStudents)
        {
            Student[] sortedStudents = listStudents.OrderBy(s => s.age).ToArray();

            Helper.PrintProgrammInfo("Студенты отсортированы по возрасту:");

            foreach (Student student in sortedStudents)
            {
                Helper.PrintYellow($"{student.lastName} {student.firstName}, возраст - {student.age}");
            }

            Helper.PauseTask();
        }

        /// <summary>
        /// Выводит список студентов, отсортированных по курсу и возрасту
        /// </summary>
        /// <param name="listStudents">список студентов</param>
        public static void PrintSortCourseAgeStudents(List<Student> listStudents)
        {
            List<Student> sortedStudents = listStudents.OrderBy(x => x.course).ThenBy(x => x.age).ToList(); ;

            Helper.PrintProgrammInfo("Студенты отсортированы по курсу и возрасту:");

            foreach (Student student in sortedStudents)
            {
                Helper.PrintYellow($"{student.lastName} {student.firstName} - {student.course} курс, возраст - {student.age}");
            }

            Helper.PauseTask();
        }

        /// <summary>
        /// Задача 3
        /// </summary>
        public static void ExecuteTask()
        {
            int methodNumber = 0;

            List<Student> list = LoadStudents();

            //Основной цикл программы, выбор решаемой задачи через консольное меню
            do
            {
                Console.Clear();
                Helper.PrintInfo(6, 3,
               @"3. ** Переделать программу Пример использования коллекций для решения следующих задач:
а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
в) отсортировать список по возрасту студента;
г) *отсортировать список по курсу и возрасту студента;",
                "Долгов Константин");

                Helper.PrintProgrammInfo("Студенты были загружены из файла 'students.csv'.");
                Helper.PrintProgrammInfo("Вы можете получить различную информацию с помощью команд:");

                //Вывод программного меню
                PrintMenu();

                //Выбор решаемой задачи
                methodNumber = Helper.WaitNumber("Введите номер команды: ");
                switch (methodNumber)
                {
                    case 1: PrintStudentCourceCount(list); break;
                    case 2: PrintStudentAllCourceCount(list); break;
                    case 3: PrintSortAgeStudents(list);  break;
                    case 4: PrintSortCourseAgeStudents(list); break;
                    case 5: PrintStudents(list); break;
                    default: break;
                }
            }
            while (methodNumber != 0);

            Helper.EndTask();           
        }

        /// <summary>
        /// Меню распечатки функций
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine();
            Helper.PrintMenuline();
            Helper.PrintProgrammInfo("Меню выбора команд:");
            Helper.PrintProgrammInfo("1 -> Подсчитать количество студентов учащихся на 5 и 6 курсах");
            Helper.PrintProgrammInfo("2 -> Cколько студентов в возрасте от 18 до 20 лет на каком курсе учатся");
            Helper.PrintProgrammInfo("3 -> Отсортировать список по возрасту студента");
            Helper.PrintProgrammInfo("4 -> Отсортировать список по курсу и возрасту студента");
            Helper.PrintProgrammInfo("5 -> Вывести список студентов");
            Helper.PrintProgrammInfo("0 -> Вернуться к меню выбора решенных задач.");
        }
    }
}
