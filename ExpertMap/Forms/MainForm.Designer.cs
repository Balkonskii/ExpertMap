namespace ExpertMap.Forms
{
    partial class MainForm
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
            this.lwMarker = new System.Windows.Forms.ListView();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmDictionary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExpert = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSpecialization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslRegionName = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lwMarker
            // 
            this.lwMarker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lwMarker.Location = new System.Drawing.Point(550, 24);
            this.lwMarker.Name = "lwMarker";
            this.lwMarker.Size = new System.Drawing.Size(233, 398);
            this.lwMarker.TabIndex = 1;
            this.lwMarker.UseCompatibleStateImageBehavior = false;
            // 
            // pbMap
            // 
            this.pbMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMap.Image = global::ExpertMap.Properties.Resources.worldcontur;
            this.pbMap.Location = new System.Drawing.Point(0, 24);
            this.pbMap.Margin = new System.Windows.Forms.Padding(0);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(550, 398);
            this.pbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMap.TabIndex = 0;
            this.pbMap.TabStop = false;
            this.pbMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMap_Paint);
            this.pbMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseDown);
            this.pbMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseMove);
            this.pbMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseUp);
            this.pbMap.Resize += new System.EventHandler(this.pbMap_Resize);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDictionary});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmDictionary
            // 
            this.tsmDictionary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExpert,
            this.tsmCountry,
            this.tsmSpecialization,
            this.tsmRegion});
            this.tsmDictionary.Name = "tsmDictionary";
            this.tsmDictionary.Size = new System.Drawing.Size(94, 20);
            this.tsmDictionary.Text = "Справочники";
            // 
            // tsmExpert
            // 
            this.tsmExpert.Name = "tsmExpert";
            this.tsmExpert.Size = new System.Drawing.Size(161, 22);
            this.tsmExpert.Text = "Эксперты";
            this.tsmExpert.Click += new System.EventHandler(this.tsmExpert_Click);
            // 
            // tsmCountry
            // 
            this.tsmCountry.Name = "tsmCountry";
            this.tsmCountry.Size = new System.Drawing.Size(161, 22);
            this.tsmCountry.Text = "Страны";
            this.tsmCountry.Click += new System.EventHandler(this.tsmCountry_Click);
            // 
            // tsmSpecialization
            // 
            this.tsmSpecialization.Name = "tsmSpecialization";
            this.tsmSpecialization.Size = new System.Drawing.Size(161, 22);
            this.tsmSpecialization.Text = "Специализации";
            this.tsmSpecialization.Click += new System.EventHandler(this.tsmSpecialization_Click);
            // 
            // tsmRegion
            // 
            this.tsmRegion.Name = "tsmRegion";
            this.tsmRegion.Size = new System.Drawing.Size(161, 22);
            this.tsmRegion.Text = "Регионы";
            this.tsmRegion.Click += new System.EventHandler(this.tsmRegion_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslRegionName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslRegionName
            // 
            this.tslRegionName.Name = "tslRegionName";
            this.tslRegionName.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 444);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lwMarker);
            this.Controls.Add(this.pbMap);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.ListView lwMarker;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmDictionary;
        private System.Windows.Forms.ToolStripMenuItem tsmExpert;
        private System.Windows.Forms.ToolStripMenuItem tsmCountry;
        private System.Windows.Forms.ToolStripMenuItem tsmSpecialization;
        private System.Windows.Forms.ToolStripMenuItem tsmRegion;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslRegionName;
    }
}