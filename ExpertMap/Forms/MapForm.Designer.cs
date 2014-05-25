namespace ExpertMap.Forms
{
    partial class MapForm
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
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNewDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpenDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSaveDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDictionary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExpert = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSpecialization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuotes1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExperts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExpertAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExpertUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExpertDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSpecializations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSpecializaitionAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSpecializationUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSpecializationDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCountries = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCountryAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCountryUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCountryDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRegions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRegionAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRegionUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRegionDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuotes = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslRegionName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lwMarker = new System.Windows.Forms.ListView();
            this.tsmProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.tsmProject,
            this.toolStripMenuItem1,
            this.tsmDictionary,
            this.tsmExperts,
            this.tsmSpecializations,
            this.tsmCountries,
            this.tsmRegions,
            this.tsmQuotes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNewDataBase,
            this.tsmOpenDataBase,
            this.tsmSaveDataBase});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(86, 20);
            this.toolStripMenuItem1.Text = "База данных";
            this.toolStripMenuItem1.Visible = false;
            // 
            // tsmNewDataBase
            // 
            this.tsmNewDataBase.Name = "tsmNewDataBase";
            this.tsmNewDataBase.Size = new System.Drawing.Size(178, 22);
            this.tsmNewDataBase.Text = "Новая база данных";
            this.tsmNewDataBase.Click += new System.EventHandler(this.tsmNewDataBase_Click);
            // 
            // tsmOpenDataBase
            // 
            this.tsmOpenDataBase.Name = "tsmOpenDataBase";
            this.tsmOpenDataBase.Size = new System.Drawing.Size(178, 22);
            this.tsmOpenDataBase.Text = "Открыть";
            this.tsmOpenDataBase.Click += new System.EventHandler(this.tsmOpenDataBase_Click);
            // 
            // tsmSaveDataBase
            // 
            this.tsmSaveDataBase.Name = "tsmSaveDataBase";
            this.tsmSaveDataBase.Size = new System.Drawing.Size(178, 22);
            this.tsmSaveDataBase.Text = "Сохранить";
            this.tsmSaveDataBase.Click += new System.EventHandler(this.tsmSaveDataBase_Click);
            // 
            // tsmDictionary
            // 
            this.tsmDictionary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExpert,
            this.tsmCountry,
            this.tsmSpecialization,
            this.tsmRegion,
            this.tsmQuotes1});
            this.tsmDictionary.Name = "tsmDictionary";
            this.tsmDictionary.Size = new System.Drawing.Size(94, 20);
            this.tsmDictionary.Text = "Справочники";
            this.tsmDictionary.Visible = false;
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
            // tsmQuotes1
            // 
            this.tsmQuotes1.Name = "tsmQuotes1";
            this.tsmQuotes1.Size = new System.Drawing.Size(161, 22);
            this.tsmQuotes1.Text = "Цитаты";
            this.tsmQuotes1.Click += new System.EventHandler(this.tsmQuotes_Click);
            // 
            // tsmExperts
            // 
            this.tsmExperts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExpertAdd,
            this.tsmExpertUpdate,
            this.tsmExpertDelete});
            this.tsmExperts.Name = "tsmExperts";
            this.tsmExperts.Size = new System.Drawing.Size(72, 20);
            this.tsmExperts.Text = "Эксперты";
            // 
            // tsmExpertAdd
            // 
            this.tsmExpertAdd.Name = "tsmExpertAdd";
            this.tsmExpertAdd.Size = new System.Drawing.Size(128, 22);
            this.tsmExpertAdd.Text = "Добавить";
            this.tsmExpertAdd.Click += new System.EventHandler(this.tsmExpertAdd_Click);
            // 
            // tsmExpertUpdate
            // 
            this.tsmExpertUpdate.Name = "tsmExpertUpdate";
            this.tsmExpertUpdate.Size = new System.Drawing.Size(128, 22);
            this.tsmExpertUpdate.Text = "Изменить";
            this.tsmExpertUpdate.Click += new System.EventHandler(this.tsmExpertUpdate_Click);
            // 
            // tsmExpertDelete
            // 
            this.tsmExpertDelete.Name = "tsmExpertDelete";
            this.tsmExpertDelete.Size = new System.Drawing.Size(128, 22);
            this.tsmExpertDelete.Text = "Удалить";
            this.tsmExpertDelete.Click += new System.EventHandler(this.tsmExpertDelete_Click);
            // 
            // tsmSpecializations
            // 
            this.tsmSpecializations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSpecializaitionAdd,
            this.tsmSpecializationUpdate,
            this.tsmSpecializationDelete});
            this.tsmSpecializations.Name = "tsmSpecializations";
            this.tsmSpecializations.Size = new System.Drawing.Size(106, 20);
            this.tsmSpecializations.Text = "Специализации";
            // 
            // tsmSpecializaitionAdd
            // 
            this.tsmSpecializaitionAdd.Name = "tsmSpecializaitionAdd";
            this.tsmSpecializaitionAdd.Size = new System.Drawing.Size(128, 22);
            this.tsmSpecializaitionAdd.Text = "Добавить";
            this.tsmSpecializaitionAdd.Click += new System.EventHandler(this.tsmSpecializaitionAdd_Click);
            // 
            // tsmSpecializationUpdate
            // 
            this.tsmSpecializationUpdate.Name = "tsmSpecializationUpdate";
            this.tsmSpecializationUpdate.Size = new System.Drawing.Size(128, 22);
            this.tsmSpecializationUpdate.Text = "Изменить";
            this.tsmSpecializationUpdate.Click += new System.EventHandler(this.tsmSpecializationUpdate_Click);
            // 
            // tsmSpecializationDelete
            // 
            this.tsmSpecializationDelete.Name = "tsmSpecializationDelete";
            this.tsmSpecializationDelete.Size = new System.Drawing.Size(128, 22);
            this.tsmSpecializationDelete.Text = "Удалить";
            this.tsmSpecializationDelete.Click += new System.EventHandler(this.tsmSpecializationDelete_Click);
            // 
            // tsmCountries
            // 
            this.tsmCountries.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCountryAdd,
            this.tsmCountryUpdate,
            this.tsmCountryDelete});
            this.tsmCountries.Name = "tsmCountries";
            this.tsmCountries.Size = new System.Drawing.Size(61, 20);
            this.tsmCountries.Text = "Страны";
            // 
            // tsmCountryAdd
            // 
            this.tsmCountryAdd.Name = "tsmCountryAdd";
            this.tsmCountryAdd.Size = new System.Drawing.Size(128, 22);
            this.tsmCountryAdd.Text = "Добавить";
            this.tsmCountryAdd.Click += new System.EventHandler(this.tsmCountryAdd_Click);
            // 
            // tsmCountryUpdate
            // 
            this.tsmCountryUpdate.Name = "tsmCountryUpdate";
            this.tsmCountryUpdate.Size = new System.Drawing.Size(128, 22);
            this.tsmCountryUpdate.Text = "Изменить";
            this.tsmCountryUpdate.Click += new System.EventHandler(this.tsmCountryUpdate_Click);
            // 
            // tsmCountryDelete
            // 
            this.tsmCountryDelete.Name = "tsmCountryDelete";
            this.tsmCountryDelete.Size = new System.Drawing.Size(128, 22);
            this.tsmCountryDelete.Text = "Удалить";
            this.tsmCountryDelete.Click += new System.EventHandler(this.tsmCountryDelete_Click);
            // 
            // tsmRegions
            // 
            this.tsmRegions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRegionAdd,
            this.tsmRegionUpdate,
            this.tsmRegionDelete});
            this.tsmRegions.Name = "tsmRegions";
            this.tsmRegions.Size = new System.Drawing.Size(67, 20);
            this.tsmRegions.Text = "Регионы";
            // 
            // tsmRegionAdd
            // 
            this.tsmRegionAdd.Name = "tsmRegionAdd";
            this.tsmRegionAdd.Size = new System.Drawing.Size(128, 22);
            this.tsmRegionAdd.Text = "Добавить";
            this.tsmRegionAdd.Click += new System.EventHandler(this.tsmRegionAdd_Click);
            // 
            // tsmRegionUpdate
            // 
            this.tsmRegionUpdate.Name = "tsmRegionUpdate";
            this.tsmRegionUpdate.Size = new System.Drawing.Size(128, 22);
            this.tsmRegionUpdate.Text = "Изменить";
            this.tsmRegionUpdate.Click += new System.EventHandler(this.tsmRegionUpdate_Click);
            // 
            // tsmRegionDelete
            // 
            this.tsmRegionDelete.Name = "tsmRegionDelete";
            this.tsmRegionDelete.Size = new System.Drawing.Size(128, 22);
            this.tsmRegionDelete.Text = "Удалить";
            this.tsmRegionDelete.Click += new System.EventHandler(this.tsmRegionDelete_Click);
            // 
            // tsmQuotes
            // 
            this.tsmQuotes.Name = "tsmQuotes";
            this.tsmQuotes.Size = new System.Drawing.Size(60, 20);
            this.tsmQuotes.Text = "Цитаты";
            this.tsmQuotes.Click += new System.EventHandler(this.tsmQuotes_Click);
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
            // lwMarker
            // 
            this.lwMarker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lwMarker.Location = new System.Drawing.Point(550, 24);
            this.lwMarker.Name = "lwMarker";
            this.lwMarker.Size = new System.Drawing.Size(233, 398);
            this.lwMarker.TabIndex = 1;
            this.lwMarker.UseCompatibleStateImageBehavior = false;
            this.lwMarker.View = System.Windows.Forms.View.List;
            this.lwMarker.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lwMarker_MouseUp);
            // 
            // tsmProject
            // 
            this.tsmProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSave,
            this.tsmSaveAs,
            this.tsmClose,
            this.tsmExit});
            this.tsmProject.Name = "tsmProject";
            this.tsmProject.Size = new System.Drawing.Size(59, 20);
            this.tsmProject.Text = "Проект";
            // 
            // tsmSave
            // 
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(153, 22);
            this.tsmSave.Text = "Сохранить";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmSaveAs
            // 
            this.tsmSaveAs.Name = "tsmSaveAs";
            this.tsmSaveAs.Size = new System.Drawing.Size(153, 22);
            this.tsmSaveAs.Text = "Сохранить как";
            this.tsmSaveAs.Click += new System.EventHandler(this.tsmSaveAs_Click);
            // 
            // tsmClose
            // 
            this.tsmClose.Name = "tsmClose";
            this.tsmClose.Size = new System.Drawing.Size(153, 22);
            this.tsmClose.Text = "Закрыть";
            this.tsmClose.Click += new System.EventHandler(this.tsmClose_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(153, 22);
            this.tsmExit.Text = "Выход";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmDictionary;
        private System.Windows.Forms.ToolStripMenuItem tsmExpert;
        private System.Windows.Forms.ToolStripMenuItem tsmCountry;
        private System.Windows.Forms.ToolStripMenuItem tsmSpecialization;
        private System.Windows.Forms.ToolStripMenuItem tsmRegion;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslRegionName;
        private System.Windows.Forms.ToolStripMenuItem tsmQuotes1;
        private System.Windows.Forms.ListView lwMarker;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenDataBase;
        private System.Windows.Forms.ToolStripMenuItem tsmSaveDataBase;
        private System.Windows.Forms.ToolStripMenuItem tsmNewDataBase;
        private System.Windows.Forms.ToolStripMenuItem tsmExperts;
        private System.Windows.Forms.ToolStripMenuItem tsmExpertAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmExpertUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmExpertDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmSpecializations;
        private System.Windows.Forms.ToolStripMenuItem tsmSpecializaitionAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmSpecializationUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmSpecializationDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmCountries;
        private System.Windows.Forms.ToolStripMenuItem tsmCountryAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmCountryUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmCountryDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmRegions;
        private System.Windows.Forms.ToolStripMenuItem tsmRegionAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmRegionUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmRegionDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmQuotes;
        private System.Windows.Forms.ToolStripMenuItem tsmProject;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.ToolStripMenuItem tsmSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsmClose;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
    }
}