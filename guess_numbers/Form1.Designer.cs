namespace guess_number
{
    partial class Form1
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
            this.btnAnswer = new System.Windows.Forms.Button();
            this.userAnswer = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblTry = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(164, 25);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(75, 23);
            this.btnAnswer.TabIndex = 0;
            this.btnAnswer.Text = "button2";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // userAnswer
            // 
            this.userAnswer.Location = new System.Drawing.Point(41, 28);
            this.userAnswer.Name = "userAnswer";
            this.userAnswer.Size = new System.Drawing.Size(100, 20);
            this.userAnswer.TabIndex = 2;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(161, 71);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(35, 13);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "label2";
            // 
            // lblTry
            // 
            this.lblTry.AutoSize = true;
            this.lblTry.Location = new System.Drawing.Point(64, 71);
            this.lblTry.Name = "lblTry";
            this.lblTry.Size = new System.Drawing.Size(35, 13);
            this.lblTry.TabIndex = 4;
            this.lblTry.Text = "label2";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblTry);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.userAnswer);
            this.Controls.Add(this.btnAnswer);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.TextBox userAnswer;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblTry;
    }
}

