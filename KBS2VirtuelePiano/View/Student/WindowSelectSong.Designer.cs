namespace KBS2VirtuelePiano.View
{
    partial class WindowSelectSong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowSelectSong));
            this.dataGridViewPanel = new System.Windows.Forms.DataGridView();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.NiveauLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPanel
            // 
            this.dataGridViewPanel.AllowUserToAddRows = false;
            this.dataGridViewPanel.AllowUserToDeleteRows = false;
            this.dataGridViewPanel.AllowUserToOrderColumns = true;
            this.dataGridViewPanel.AllowUserToResizeColumns = false;
            this.dataGridViewPanel.AllowUserToResizeRows = false;
            this.dataGridViewPanel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPanel.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPanel.Location = new System.Drawing.Point(13, 82);
            this.dataGridViewPanel.MultiSelect = false;
            this.dataGridViewPanel.Name = "dataGridViewPanel";
            this.dataGridViewPanel.ReadOnly = true;
            this.dataGridViewPanel.RowHeadersVisible = false;
            this.dataGridViewPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPanel.Size = new System.Drawing.Size(522, 224);
            this.dataGridViewPanel.TabIndex = 0;
            this.dataGridViewPanel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPanel_CellClick);
            this.dataGridViewPanel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPanel_CellDoubleClick);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchTextBox.Location = new System.Drawing.Point(13, 56);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(406, 20);
            this.SearchTextBox.TabIndex = 1;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Location = new System.Drawing.Point(378, 324);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Annuleren";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OpenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenButton.Location = new System.Drawing.Point(459, 324);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 3;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = false;
            this.OpenButton.Click += new System.EventHandler(this.OpenSong_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(426, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(109, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchLabel.Location = new System.Drawing.Point(12, 34);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(308, 13);
            this.SearchLabel.TabIndex = 6;
            this.SearchLabel.Text = "Vindt hier een lied door een titel of auteur in te typen";
            // 
            // NiveauLabel
            // 
            this.NiveauLabel.AutoSize = true;
            this.NiveauLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NiveauLabel.Location = new System.Drawing.Point(423, 34);
            this.NiveauLabel.Name = "NiveauLabel";
            this.NiveauLabel.Size = new System.Drawing.Size(56, 13);
            this.NiveauLabel.TabIndex = 7;
            this.NiveauLabel.Text = "Niveau\'s";
            // 
            // WindowSelectSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 359);
            this.Controls.Add(this.NiveauLabel);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.dataGridViewPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WindowSelectSong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lied openen";
            this.Load += new System.EventHandler(this.WindowSelectSong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewPanel;
        public System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OpenButton;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Label NiveauLabel;
    }
}