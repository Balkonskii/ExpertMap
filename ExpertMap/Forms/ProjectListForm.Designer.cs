namespace ExpertMap.Forms
{
    partial class ProjectListForm
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
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.lbProjectNames = new System.Windows.Forms.ListBox();
            this.rtbProjectProperties = new System.Windows.Forms.RichTextBox();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCreateProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbProjectNames
            // 
            this.lbProjectNames.FormattingEnabled = true;
            this.lbProjectNames.Location = new System.Drawing.Point(12, 12);
            this.lbProjectNames.Name = "lbProjectNames";
            this.lbProjectNames.Size = new System.Drawing.Size(202, 173);
            this.lbProjectNames.TabIndex = 0;
            this.lbProjectNames.SelectedIndexChanged += new System.EventHandler(this.lbProjectNames_SelectedIndexChanged);
            // 
            // rtbProjectProperties
            // 
            this.rtbProjectProperties.Location = new System.Drawing.Point(220, 12);
            this.rtbProjectProperties.Name = "rtbProjectProperties";
            this.rtbProjectProperties.ReadOnly = true;
            this.rtbProjectProperties.Size = new System.Drawing.Size(283, 173);
            this.rtbProjectProperties.TabIndex = 1;
            this.rtbProjectProperties.Text = "";
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(311, 191);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(118, 23);
            this.btnAddProject.TabIndex = 2;
            this.btnAddProject.Text = "Добавить проект";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(435, 191);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(67, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCreateProject
            // 
            this.btnCreateProject.Location = new System.Drawing.Point(187, 191);
            this.btnCreateProject.Name = "btnCreateProject";
            this.btnCreateProject.Size = new System.Drawing.Size(118, 23);
            this.btnCreateProject.TabIndex = 4;
            this.btnCreateProject.Text = "Создать проект";
            this.btnCreateProject.UseVisualStyleBackColor = true;
            this.btnCreateProject.Click += new System.EventHandler(this.btnCreateProject_Click);
            // 
            // ProjectListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 221);
            this.Controls.Add(this.btnCreateProject);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.rtbProjectProperties);
            this.Controls.Add(this.lbProjectNames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProjectListForm";
            this.Text = "Проекты";
            this.Load += new System.EventHandler(this.ProjectListForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.ListBox lbProjectNames;
        private System.Windows.Forms.RichTextBox rtbProjectProperties;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCreateProject;
    }
}