namespace BotWF
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
            this.textX = new System.Windows.Forms.TextBox();
            this.textY = new System.Windows.Forms.TextBox();
            this.textTrig = new System.Windows.Forms.TextBox();
            this.textWood = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.IceText = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.Col2 = new System.Windows.Forms.TextBox();
            this.Col1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textX
            // 
            this.textX.Location = new System.Drawing.Point(12, 62);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(100, 20);
            this.textX.TabIndex = 34;
            // 
            // textY
            // 
            this.textY.Location = new System.Drawing.Point(12, 88);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(100, 20);
            this.textY.TabIndex = 35;
            // 
            // textTrig
            // 
            this.textTrig.Location = new System.Drawing.Point(126, 62);
            this.textTrig.Name = "textTrig";
            this.textTrig.Size = new System.Drawing.Size(38, 20);
            this.textTrig.TabIndex = 36;
            this.textTrig.TextChanged += new System.EventHandler(this.textTrig_TextChanged);
            // 
            // textWood
            // 
            this.textWood.Location = new System.Drawing.Point(230, 97);
            this.textWood.Multiline = true;
            this.textWood.Name = "textWood";
            this.textWood.Size = new System.Drawing.Size(134, 31);
            this.textWood.TabIndex = 37;
            this.textWood.Text = "\r\n\r\n\r\n";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 111);
            this.button2.TabIndex = 39;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // IceText
            // 
            this.IceText.Location = new System.Drawing.Point(230, 51);
            this.IceText.Name = "IceText";
            this.IceText.Size = new System.Drawing.Size(173, 20);
            this.IceText.TabIndex = 42;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(230, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 35);
            this.button4.TabIndex = 44;
            this.button4.Text = "ЛёдСкан";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Col2
            // 
            this.Col2.Location = new System.Drawing.Point(12, 36);
            this.Col2.Name = "Col2";
            this.Col2.Size = new System.Drawing.Size(212, 20);
            this.Col2.TabIndex = 48;
            this.Col2.TextChanged += new System.EventHandler(this.Col2_TextChanged);
            // 
            // Col1
            // 
            this.Col1.Location = new System.Drawing.Point(12, 10);
            this.Col1.Name = "Col1";
            this.Col1.Size = new System.Drawing.Size(212, 20);
            this.Col1.TabIndex = 47;
            this.Col1.TextChanged += new System.EventHandler(this.Col1_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(187, 162);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 17);
            this.checkBox1.TabIndex = 49;
            this.checkBox1.Text = "AutoGame";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 262);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Col2);
            this.Controls.Add(this.Col1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.IceText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textWood);
            this.Controls.Add(this.textTrig);
            this.Controls.Add(this.textY);
            this.Controls.Add(this.textX);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.TextBox textTrig;
        private System.Windows.Forms.TextBox textWood;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox IceText;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Col2;
        private System.Windows.Forms.TextBox Col1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

