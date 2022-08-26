namespace WF_GuessTheNumber
{
    partial class GuessForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.guess = new System.Windows.Forms.Button();
            this.currentNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Угадай число от 1 до 100";
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info.ForeColor = System.Drawing.Color.Crimson;
            this.info.Location = new System.Drawing.Point(88, 177);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(388, 37);
            this.info.TabIndex = 1;
            this.info.Text = "больше загаданного числа";
            this.info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guess
            // 
            this.guess.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guess.Location = new System.Drawing.Point(87, 63);
            this.guess.Name = "guess";
            this.guess.Size = new System.Drawing.Size(389, 53);
            this.guess.TabIndex = 2;
            this.guess.Text = "Попробовать угадать";
            this.guess.UseVisualStyleBackColor = true;
            this.guess.Click += new System.EventHandler(this.button1_Click);
            // 
            // currentNumber
            // 
            this.currentNumber.AutoSize = true;
            this.currentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentNumber.ForeColor = System.Drawing.Color.Crimson;
            this.currentNumber.Location = new System.Drawing.Point(240, 131);
            this.currentNumber.Name = "currentNumber";
            this.currentNumber.Size = new System.Drawing.Size(64, 46);
            this.currentNumber.TabIndex = 3;
            this.currentNumber.Text = "25";
            this.currentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GuessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 236);
            this.Controls.Add(this.currentNumber);
            this.Controls.Add(this.guess);
            this.Controls.Add(this.info);
            this.Controls.Add(this.label1);
            this.Name = "GuessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Угадай число";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button guess;
        private System.Windows.Forms.Label currentNumber;
    }
}

