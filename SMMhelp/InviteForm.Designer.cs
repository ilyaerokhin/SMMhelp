namespace SMMhelp
{
    partial class InviteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox = new System.Windows.Forms.ListBox();
            this.requestlabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.invitelabel = new System.Windows.Forms.Label();
            this.akklabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.loglabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(15, 128);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(257, 121);
            this.listBox.TabIndex = 13;
            // 
            // requestlabel
            // 
            this.requestlabel.AutoSize = true;
            this.requestlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.requestlabel.Location = new System.Drawing.Point(130, 67);
            this.requestlabel.Name = "requestlabel";
            this.requestlabel.Size = new System.Drawing.Size(17, 18);
            this.requestlabel.TabIndex = 12;
            this.requestlabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Всего запросов";
            // 
            // invitelabel
            // 
            this.invitelabel.AutoSize = true;
            this.invitelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.invitelabel.Location = new System.Drawing.Point(130, 42);
            this.invitelabel.Name = "invitelabel";
            this.invitelabel.Size = new System.Drawing.Size(17, 18);
            this.invitelabel.TabIndex = 10;
            this.invitelabel.Text = "0";
            // 
            // akklabel
            // 
            this.akklabel.AutoSize = true;
            this.akklabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.akklabel.Location = new System.Drawing.Point(130, 17);
            this.akklabel.Name = "akklabel";
            this.akklabel.Size = new System.Drawing.Size(17, 18);
            this.akklabel.TabIndex = 9;
            this.akklabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Приглашение #";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Аккаунт #";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "В логе";
            // 
            // loglabel
            // 
            this.loglabel.AutoSize = true;
            this.loglabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loglabel.Location = new System.Drawing.Point(130, 92);
            this.loglabel.Name = "loglabel";
            this.loglabel.Size = new System.Drawing.Size(17, 18);
            this.loglabel.TabIndex = 15;
            this.loglabel.Text = "0";
            // 
            // InviteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.loglabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.requestlabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.invitelabel);
            this.Controls.Add(this.akklabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InviteForm";
            this.Text = "InviteForm";
            this.Shown += new System.EventHandler(this.InviteForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label requestlabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label invitelabel;
        private System.Windows.Forms.Label akklabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label loglabel;
    }
}