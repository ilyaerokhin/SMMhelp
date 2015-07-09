namespace SMMhelp
{
    partial class RepostForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.akklabel = new System.Windows.Forms.Label();
            this.repostlabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupslabel = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Аккаунт #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Репост #";
            // 
            // akklabel
            // 
            this.akklabel.AutoSize = true;
            this.akklabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.akklabel.Location = new System.Drawing.Point(130, 18);
            this.akklabel.Name = "akklabel";
            this.akklabel.Size = new System.Drawing.Size(17, 18);
            this.akklabel.TabIndex = 2;
            this.akklabel.Text = "0";
            // 
            // repostlabel
            // 
            this.repostlabel.AutoSize = true;
            this.repostlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.repostlabel.Location = new System.Drawing.Point(130, 57);
            this.repostlabel.Name = "repostlabel";
            this.repostlabel.Size = new System.Drawing.Size(17, 18);
            this.repostlabel.TabIndex = 3;
            this.repostlabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Кол-во групп";
            // 
            // groupslabel
            // 
            this.groupslabel.AutoSize = true;
            this.groupslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupslabel.Location = new System.Drawing.Point(130, 94);
            this.groupslabel.Name = "groupslabel";
            this.groupslabel.Size = new System.Drawing.Size(17, 18);
            this.groupslabel.TabIndex = 5;
            this.groupslabel.Text = "0";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(15, 128);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(257, 121);
            this.listBox.TabIndex = 6;
            // 
            // RepostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.groupslabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.repostlabel);
            this.Controls.Add(this.akklabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RepostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RepostForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RepostForm_FormClosed);
            this.Shown += new System.EventHandler(this.RepostForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label akklabel;
        private System.Windows.Forms.Label repostlabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label groupslabel;
        private System.Windows.Forms.ListBox listBox;
    }
}