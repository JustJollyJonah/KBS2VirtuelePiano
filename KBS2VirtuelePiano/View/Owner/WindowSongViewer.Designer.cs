namespace KBS2VirtuelePiano.View
{
    partial class WindowSongViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowSongViewer));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.AddSongButton = new System.Windows.Forms.Button();
            this.SearchSongByNameTextBox = new System.Windows.Forms.TextBox();
            this.SearchSongByNameDataGrid = new System.Windows.Forms.DataGridView();
            this.SongInformationPanel = new System.Windows.Forms.Panel();
            this.SongAuthorPlaceholder = new System.Windows.Forms.Label();
            this.SongLevelPlaceholder = new System.Windows.Forms.Label();
            this.SongNamePlaceholder = new System.Windows.Forms.Label();
            this.SongLevelLabel = new System.Windows.Forms.Label();
            this.SongAuthorLabel = new System.Windows.Forms.Label();
            this.SongNameLabel = new System.Windows.Forms.Label();
            this.groupBoxSongDetails = new System.Windows.Forms.GroupBox();
            this.buttonTerug = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SearchSongByNameDataGrid)).BeginInit();
            this.SongInformationPanel.SuspendLayout();
            this.groupBoxSongDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddSongButton
            // 
            this.AddSongButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSongButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddSongButton.Location = new System.Drawing.Point(273, 612);
            this.AddSongButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddSongButton.Name = "AddSongButton";
            this.AddSongButton.Size = new System.Drawing.Size(143, 24);
            this.AddSongButton.TabIndex = 11;
            this.AddSongButton.Text = "Liedje toevoegen";
            this.AddSongButton.UseVisualStyleBackColor = false;
            this.AddSongButton.Click += new System.EventHandler(this.AddSongButton_Click);
            // 
            // SearchSongByNameTextBox
            // 
            this.SearchSongByNameTextBox.Location = new System.Drawing.Point(39, 141);
            this.SearchSongByNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SearchSongByNameTextBox.Name = "SearchSongByNameTextBox";
            this.SearchSongByNameTextBox.Size = new System.Drawing.Size(377, 20);
            this.SearchSongByNameTextBox.TabIndex = 9;
            this.SearchSongByNameTextBox.TextChanged += new System.EventHandler(this.SearchSongByNameTextBox_TextChanged);
            // 
            // SearchSongByNameDataGrid
            // 
            this.SearchSongByNameDataGrid.AllowUserToAddRows = false;
            this.SearchSongByNameDataGrid.AllowUserToDeleteRows = false;
            this.SearchSongByNameDataGrid.AllowUserToResizeColumns = false;
            this.SearchSongByNameDataGrid.AllowUserToResizeRows = false;
            this.SearchSongByNameDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SearchSongByNameDataGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.SearchSongByNameDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchSongByNameDataGrid.Location = new System.Drawing.Point(39, 165);
            this.SearchSongByNameDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.SearchSongByNameDataGrid.MultiSelect = false;
            this.SearchSongByNameDataGrid.Name = "SearchSongByNameDataGrid";
            this.SearchSongByNameDataGrid.ReadOnly = true;
            this.SearchSongByNameDataGrid.RowHeadersVisible = false;
            this.SearchSongByNameDataGrid.RowTemplate.Height = 24;
            this.SearchSongByNameDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SearchSongByNameDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SearchSongByNameDataGrid.Size = new System.Drawing.Size(377, 434);
            this.SearchSongByNameDataGrid.TabIndex = 8;
            this.SearchSongByNameDataGrid.SelectionChanged += new System.EventHandler(this.SearchSongByNameDataGrid_SelectionChanged);
            // 
            // SongInformationPanel
            // 
            this.SongInformationPanel.Controls.Add(this.SongAuthorPlaceholder);
            this.SongInformationPanel.Controls.Add(this.SongLevelPlaceholder);
            this.SongInformationPanel.Controls.Add(this.SongNamePlaceholder);
            this.SongInformationPanel.Controls.Add(this.SongLevelLabel);
            this.SongInformationPanel.Controls.Add(this.SongAuthorLabel);
            this.SongInformationPanel.Controls.Add(this.SongNameLabel);
            this.SongInformationPanel.Location = new System.Drawing.Point(5, 17);
            this.SongInformationPanel.Margin = new System.Windows.Forms.Padding(2);
            this.SongInformationPanel.Name = "SongInformationPanel";
            this.SongInformationPanel.Size = new System.Drawing.Size(367, 66);
            this.SongInformationPanel.TabIndex = 13;
            // 
            // SongAuthorPlaceholder
            // 
            this.SongAuthorPlaceholder.AutoSize = true;
            this.SongAuthorPlaceholder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SongAuthorPlaceholder.Location = new System.Drawing.Point(139, 24);
            this.SongAuthorPlaceholder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SongAuthorPlaceholder.Name = "SongAuthorPlaceholder";
            this.SongAuthorPlaceholder.Size = new System.Drawing.Size(10, 13);
            this.SongAuthorPlaceholder.TabIndex = 8;
            this.SongAuthorPlaceholder.Text = "-";
            // 
            // SongLevelPlaceholder
            // 
            this.SongLevelPlaceholder.AutoSize = true;
            this.SongLevelPlaceholder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SongLevelPlaceholder.Location = new System.Drawing.Point(139, 44);
            this.SongLevelPlaceholder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SongLevelPlaceholder.Name = "SongLevelPlaceholder";
            this.SongLevelPlaceholder.Size = new System.Drawing.Size(10, 13);
            this.SongLevelPlaceholder.TabIndex = 7;
            this.SongLevelPlaceholder.Text = "-";
            // 
            // SongNamePlaceholder
            // 
            this.SongNamePlaceholder.AutoSize = true;
            this.SongNamePlaceholder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SongNamePlaceholder.Location = new System.Drawing.Point(139, 4);
            this.SongNamePlaceholder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SongNamePlaceholder.Name = "SongNamePlaceholder";
            this.SongNamePlaceholder.Size = new System.Drawing.Size(10, 13);
            this.SongNamePlaceholder.TabIndex = 6;
            this.SongNamePlaceholder.Text = "-";
            // 
            // SongLevelLabel
            // 
            this.SongLevelLabel.AutoSize = true;
            this.SongLevelLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SongLevelLabel.Location = new System.Drawing.Point(2, 44);
            this.SongLevelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SongLevelLabel.Name = "SongLevelLabel";
            this.SongLevelLabel.Size = new System.Drawing.Size(44, 13);
            this.SongLevelLabel.TabIndex = 2;
            this.SongLevelLabel.Text = "Niveau:";
            // 
            // SongAuthorLabel
            // 
            this.SongAuthorLabel.AutoSize = true;
            this.SongAuthorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SongAuthorLabel.Location = new System.Drawing.Point(2, 24);
            this.SongAuthorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SongAuthorLabel.Name = "SongAuthorLabel";
            this.SongAuthorLabel.Size = new System.Drawing.Size(41, 13);
            this.SongAuthorLabel.TabIndex = 1;
            this.SongAuthorLabel.Text = "Auteur:";
            // 
            // SongNameLabel
            // 
            this.SongNameLabel.AutoSize = true;
            this.SongNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SongNameLabel.Location = new System.Drawing.Point(2, 4);
            this.SongNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SongNameLabel.Name = "SongNameLabel";
            this.SongNameLabel.Size = new System.Drawing.Size(41, 13);
            this.SongNameLabel.TabIndex = 0;
            this.SongNameLabel.Text = "Naam: ";
            // 
            // groupBoxSongDetails
            // 
            this.groupBoxSongDetails.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxSongDetails.Controls.Add(this.SongInformationPanel);
            this.groupBoxSongDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxSongDetails.Location = new System.Drawing.Point(39, 12);
            this.groupBoxSongDetails.Name = "groupBoxSongDetails";
            this.groupBoxSongDetails.Size = new System.Drawing.Size(377, 88);
            this.groupBoxSongDetails.TabIndex = 14;
            this.groupBoxSongDetails.TabStop = false;
            this.groupBoxSongDetails.Text = "Details";
            // 
            // buttonTerug
            // 
            this.buttonTerug.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonTerug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTerug.Location = new System.Drawing.Point(39, 612);
            this.buttonTerug.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTerug.Name = "buttonTerug";
            this.buttonTerug.Size = new System.Drawing.Size(69, 24);
            this.buttonTerug.TabIndex = 15;
            this.buttonTerug.Text = "Terug";
            this.buttonTerug.UseVisualStyleBackColor = false;
            this.buttonTerug.Click += new System.EventHandler(this.buttonTerug_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Vindt hier een lied door een titel of auteur in te typen";
            // 
            // WindowSongViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 647);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTerug);
            this.Controls.Add(this.groupBoxSongDetails);
            this.Controls.Add(this.AddSongButton);
            this.Controls.Add(this.SearchSongByNameTextBox);
            this.Controls.Add(this.SearchSongByNameDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WindowSongViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liederen";
            ((System.ComponentModel.ISupportInitialize)(this.SearchSongByNameDataGrid)).EndInit();
            this.SongInformationPanel.ResumeLayout(false);
            this.SongInformationPanel.PerformLayout();
            this.groupBoxSongDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button AddSongButton;
        private System.Windows.Forms.TextBox SearchSongByNameTextBox;
        public System.Windows.Forms.DataGridView SearchSongByNameDataGrid;
        public System.Windows.Forms.Panel SongInformationPanel;
        public System.Windows.Forms.Label SongAuthorPlaceholder;
        public System.Windows.Forms.Label SongLevelPlaceholder;
        public System.Windows.Forms.Label SongNamePlaceholder;
        private System.Windows.Forms.Label SongLevelLabel;
        private System.Windows.Forms.Label SongAuthorLabel;
        private System.Windows.Forms.Label SongNameLabel;
        private System.Windows.Forms.GroupBox groupBoxSongDetails;
        private System.Windows.Forms.Button buttonTerug;
        private System.Windows.Forms.Label label1;
    }
}