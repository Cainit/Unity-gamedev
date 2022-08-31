using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelieveOrNotBelieve
{
    public partial class Form1 : Form
    {
        TrueFalse database;

        public Form1()
        {
            InitializeComponent();
        }

        private void SetQuestion()
        {
            if ((int)nudNumber.Value - 1 >= 0)
            {
                database[(int)nudNumber.Value - 1].text = tboxQuestion.Text;
                database[(int)nudNumber.Value - 1].trueFalse = cboxTrue.Checked;
            }
        }

        private void ShowQuestion()
        {
            if ((int)nudNumber.Value - 1 >= 0)
            {
                tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
                cboxTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
            }
        }

        private void DataBaseNotFound()
        {
            MessageBox.Show("База данных не создана");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                DataBaseNotFound();
                return;
            }

            database.Add((database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
            ShowQuestion();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                DataBaseNotFound(); return;
            }
            else if(nudNumber.Maximum == 1)
            {
                MessageBox.Show("База данных должна содержать хотя бы один вопрос."); return;
            }

            if (nudNumber.Value >= 1)
            {
                database.Remove((int)nudNumber.Value - 1);

                if (nudNumber.Maximum > 1)
                { 
                    --nudNumber.Maximum;
                }

                ShowQuestion();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                SetQuestion();
            }
            else
            {
                DataBaseNotFound();
            }
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (database != null)
            {
                ShowQuestion();
            }
            else
            {
                DataBaseNotFound();
            }
        }

        private void cboxTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (database != null)
            {
                SetQuestion();
            }
            else
            {
                DataBaseNotFound();
            }
        }

        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add("123", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                ShowQuestion();
            };
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
                ShowQuestion();
            }
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save();
            else DataBaseNotFound();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    database.FileName = saveDialog.FileName;
                }
                database.Save();
            }
            else DataBaseNotFound();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, 
                    "Программа Редактор Верю-Не верю\n\n"+
                    "Данная программа предназначена для создания и редактирования вопросов игры ВерюНеверю. \nВы можете создавать базу данных вопросов или открыть уже готовую, а затем создавать, редактировать или удалять вопросы."+
                    "\n\nАвтор - Константин Долгов\n"+
                    "Версия - 1.00", "О программе");
        }
    }
}
