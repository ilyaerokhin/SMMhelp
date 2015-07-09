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
            this.invitingbutton = new System.Windows.Forms.Button();
            this.friendsbutton = new System.Windows.Forms.Button();
            this.scriptbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // repostbutton
            // 
            this.repostbutton.Location = new System.Drawing.Point(12, 69);
            this.repostbutton.Name = "repostbutton";
            this.repostbutton.Size = new System.Drawing.Size(259, 23);
            this.repostbutton.TabIndex = 2;
            this.repostbutton.Text = "Репосты";
            this.repostbutton.UseVisualStyleBackColor = true;
            this.repostbutton.Click += new System.EventHandler(this.repostbutton_Click);
            // 
            // invitingbutton
            // 
            this.invitingbutton.Location = new System.Drawing.Point(12, 41);
            this.invitingbutton.Name = "invitingbutton";
            this.invitingbutton.Size = new System.Drawing.Size(259, 23);
            this.invitingbutton.TabIndex = 1;
            this.invitingbutton.Text = "Приглашения в группы";
            this.invitingbutton.UseVisualStyleBackColor = true;
            this.invitingbutton.Click += new System.EventHandler(this.invitingbutton_Click);
            // 
            // friendsbutton
            // 
            this.friendsbutton.Location = new System.Drawing.Point(12, 98);
            this.friendsbutton.Name = "friendsbutton";
            this.friendsbutton.Size = new System.Drawing.Size(259, 23);
            this.friendsbutton.TabIndex = 3;
            this.friendsbutton.Text = "Заявки в друзья";
            this.friendsbutton.UseVisualStyleBackColor = true;
            this.friendsbutton.Click += new System.EventHandler(this.friendsbutton_Click);
            // 
            // scriptbutton
            // 
            this.scriptbutton.Location = new System.Drawing.Point(12, 12);
            this.scriptbutton.Name = "scriptbutton";
            this.scriptbutton.Size = new System.Drawing.Size(259, 23);
            this.scriptbutton.TabIndex = 0;
            this.scriptbutton.Text = "Скрипт";
            this.scriptbutton.UseVisualStyleBackColor = true;
            this.scriptbutton.Click += new System.EventHandler(this.scriptbutton_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 133);
            this.Controls.Add(this.scriptbutton);
            this.Controls.Add(this.friendsbutton);
            this.Controls.Add(this.invitingbutton);
            this.Controls.Add(this.repostbutton);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMM помощник";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button repostbutton;
        private System.Windows.Forms.Button invitingbutton;
        private System.Windows.Forms.Button friendsbutton;
        private System.Windows.Forms.Button scriptbutton;

    }
}

