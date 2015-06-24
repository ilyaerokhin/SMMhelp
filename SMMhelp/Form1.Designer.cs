namespace SMMhelp
{
    partial class StartForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.repostbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // repostbutton
            // 
            this.repostbutton.Location = new System.Drawing.Point(12, 12);
            this.repostbutton.Name = "repostbutton";
            this.repostbutton.Size = new System.Drawing.Size(75, 23);
            this.repostbutton.TabIndex = 0;
            this.repostbutton.Text = "Репосты";
            this.repostbutton.UseVisualStyleBackColor = true;
            this.repostbutton.Click += new System.EventHandler(this.repostbutton_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 237);
            this.Controls.Add(this.repostbutton);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMM помощник";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button repostbutton;

    }
}

