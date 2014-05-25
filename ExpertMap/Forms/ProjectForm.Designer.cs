namespace ExpertMap.Forms
{
    partial class ProjectForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDbPath = new System.Windows.Forms.TextBox();
            this.tbShortName = new System.Windows.Forms.TextBox();
            this.rtbShortDescription = new System.Windows.Forms.RichTextBox();
            this.tbMapPath = new System.Windows.Forms.TextBox();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.btnLoadMapPath = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Краткое название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Краткое описание:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Полное название:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "База данных:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Карта:";
            // 
            // tbDbPath
            // 
            this.tbDbPath.Location = new System.Drawing.Point(121, 166);
            this.tbDbPath.Name = "tbDbPath";
            this.tbDbPath.Size = new System.Drawing.Size(269, 20);
            this.tbDbPath.TabIndex = 3;
            this.tbDbPath.TextChanged += new System.EventHandler(this.tbDbPath_TextChanged);
            // 
            // tbShortName
            // 
            this.tbShortName.Location = new System.Drawing.Point(121, 6);
            this.tbShortName.Name = "tbShortName";
            this.tbShortName.Size = new System.Drawing.Size(269, 20);
            this.tbShortName.TabIndex = 0;
            // 
            // rtbShortDescription
            // 
            this.rtbShortDescription.Location = new System.Drawing.Point(121, 32);
            this.rtbShortDescription.Name = "rtbShortDescription";
            this.rtbShortDescription.Size = new System.Drawing.Size(269, 102);
            this.rtbShortDescription.TabIndex = 1;
            this.rtbShortDescription.Text = "";
            // 
            // tbMapPath
            // 
            this.tbMapPath.Location = new System.Drawing.Point(121, 192);
            this.tbMapPath.Name = "tbMapPath";
            this.tbMapPath.ReadOnly = true;
            this.tbMapPath.Size = new System.Drawing.Size(241, 20);
            this.tbMapPath.TabIndex = 4;
            // 
            // tbFullName
            // 
            this.tbFullName.Location = new System.Drawing.Point(121, 140);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(269, 20);
            this.tbFullName.TabIndex = 2;
            // 
            // btnLoadMapPath
            // 
            this.btnLoadMapPath.Location = new System.Drawing.Point(361, 190);
            this.btnLoadMapPath.Name = "btnLoadMapPath";
            this.btnLoadMapPath.Size = new System.Drawing.Size(29, 23);
            this.btnLoadMapPath.TabIndex = 5;
            this.btnLoadMapPath.Text = "...";
            this.btnLoadMapPath.UseVisualStyleBackColor = true;
            this.btnLoadMapPath.Click += new System.EventHandler(this.btnLoadMapPath_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(234, 221);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Ок";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.Location = new System.Drawing.Point(315, 221);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Отмена";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 256);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLoadMapPath);
            this.Controls.Add(this.tbFullName);
            this.Controls.Add(this.tbMapPath);
            this.Controls.Add(this.rtbShortDescription);
            this.Controls.Add(this.tbShortName);
            this.Controls.Add(this.tbDbPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProjectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDbPath;
        private System.Windows.Forms.TextBox tbShortName;
        private System.Windows.Forms.RichTextBox rtbShortDescription;
        private System.Windows.Forms.TextBox tbMapPath;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Button btnLoadMapPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}