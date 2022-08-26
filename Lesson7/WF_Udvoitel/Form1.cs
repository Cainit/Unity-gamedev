using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Udvoitel
{
    /* Unity Gamedev - Homework 7 - Task 1
    а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
    б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число
    должен получить игрок.Игрок должен получить это число за минимальное количество ходов.
    в) * Добавить кнопку «Отменить», которая отменяет последние ходы.Используйте обобщенный
     класс Stack.
     Вся логика игры должна быть реализована в классе с удвоителем.

        Студент - Константин Долгов
     */

    public partial class Form1 : Form
    {
        int NeedNumber          = int.MaxValue;     //Число, которое требуется набрать
        int CommandCount        = 0;                //Количество команд за игру
        Stack<int> StackNumber  = new Stack<int>(); //Стек команд

        /// <summary>
        /// Инициализация
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            //Блокируем командные кнопки
            DisableControl();
        }

        /// <summary>
        /// Добавляет команду в стек
        /// </summary>
        /// <param name="num"></param>
        private void AddComand(int num)
        {
            //Обновляем команды
            ++CommandCount;
            lblCommand.Text = $"Количество команд: {CommandCount}";
            StackNumber.Push(num);

            //Разблокируем кнопку отмены
            if(StackNumber.Count > 0)
            {
                btnCancel.Enabled = true;
            }
        }

        /// <summary>
        /// Устанавливает новое значение и проверяет условия игры
        /// </summary>
        /// <param name="num"></param>
        private void SetNumber(int num)
        {
            lblNumber.Text = num.ToString();

            btnReset.Enabled = (num != 1);

            //Определяем условия победы или поражения
            if(num == NeedNumber)
            {
                Win();
            }
            else if(num > NeedNumber)
            {
                Loose();
            }
        }

        /// <summary>
        /// Отключает все кнопки
        /// </summary>
        private void DisableControl()
        {
            btnCommand1.Enabled = false;
            btnCommand2.Enabled = false;
            btnReset.Enabled = false;
            btnCancel.Enabled = false;
        }

        /// <summary>
        /// Игрок выиграл
        /// </summary>
        private void Win()
        {
            MessageBox.Show("Поздравляем, у вас получилось. Вы выиграли!", "Победа");
            DisableControl();
        }

        /// <summary>
        /// Игрок проиграл
        /// </summary>
        private void Loose()
        {
            MessageBox.Show("Увы, у вас перебор. Игра окончена.", "Проигрыш");
            DisableControl();
        }

        /// <summary>
        /// Нажатие на кнопку +1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommand1_Click(object sender, EventArgs e)
        {
            AddComand(int.Parse(lblNumber.Text));
            SetNumber(int.Parse(lblNumber.Text) + 1);
        }

        /// <summary>
        /// Нажатие на кнопку x2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommand2_Click(object sender, EventArgs e)
        {
            AddComand(int.Parse(lblNumber.Text));
            SetNumber(int.Parse(lblNumber.Text) * 2);
        }

        /// <summary>
        /// Нажатие на кнопку Сбросить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            AddComand(int.Parse(lblNumber.Text));
            SetNumber(1);
        }

        /// <summary>
        /// Нажатие на кнопку Отменить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ++CommandCount;
            lblCommand.Text = $"Количество команд: {CommandCount}";

            SetNumber(StackNumber.Pop());

            if (StackNumber.Count == 0)
            {
                btnCancel.Enabled = false;
            }
        }

        /// <summary>
        /// Нажатие на команду меню Играть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Обнуляем команды
            CommandCount = 0;
            StackNumber.Clear();
            SetNumber(1);

            //Выбираем новое значение
            NeedNumber = new Random().Next(25, 1024);
            lblNeedNumber.Text = NeedNumber.ToString();

            //Выводим информацию по игре
            MessageBox.Show($"Начинаем игру! \nЧтобы выиграть, вам необходимо набрать число {NeedNumber}. \nИспользуйте командные кнопки, чтобы сделать это как можно быстрее.", $"Необходимое число - {NeedNumber}");

            //Разблокируем команды
            btnCommand1.Enabled = true;
            btnCommand2.Enabled = true;
            btnReset.Enabled = false;
            btnCancel.Enabled = false;
        }
    }
}
