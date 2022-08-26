using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_GuessTheNumber
{
    public partial class GuessForm : Form
    {
        NumberForm numberForm = new NumberForm();

        int GuessNumber = 0;

        public GuessForm()
        {
            InitializeComponent();

            GuessNumber = new Random().Next(1, 101);

            info.Text = "";
            currentNumber.Text = "";
        }

        /// <summary>
        /// пользователь нажимает на кнопку Угадать число
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //показываем отдельную форму для ввода числа
            numberForm.numberBox.Text = "";
            numberForm.ShowDialog();

            //проверяем, что пользователь ввел число
            if (numberForm.numberBox.Text.Length >= 1)
            {
                currentNumber.Text = numberForm.numberBox.Text;

                int number = int.Parse(currentNumber.Text);

                //проверяем условия числа
                if (number > GuessNumber )
                {
                    info.Text = "больше загаданного числа";
                }
                else if(number < GuessNumber)
                {
                    info.Text = "меньше загаданного числа";
                }
                else
                {
                    info.Text = "Вы угадали число!";
                    info.ForeColor = Color.Green;
                    currentNumber.ForeColor = Color.Green;
                    guess.Enabled = false;
                }
            }
        }
    }
}
