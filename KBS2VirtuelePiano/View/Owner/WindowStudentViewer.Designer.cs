namespace KBS2VirtuelePiano.View
{
    partial class WindowStudentViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowStudentViewer));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.SearchStudentByNameDataGrid = new System.Windows.Forms.DataGridView();
            this.SearchStudentByNameTextBox = new System.Windows.Forms.TextBox();
            this.EditStudentButton = new System.Windows.Forms.Button();
            this.AddStudentButton = new System.Windows.Forms.Button();
            this.StudentProgressPanel = new System.Windows.Forms.Panel();
            this.chartStudentProgress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SelectDifficultyComboBox = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonTerug = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.WindowOwnerStudentInformationPanel = new System.Windows.Forms.Panel();
            this.StudentLevelLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StudentEmailPlaceholder = new System.Windows.Forms.Label();
            this.StudentEmailLabel = new System.Windows.Forms.Label();
            this.StudentHometownPlaceholder = new System.Windows.Forms.Label();
            this.StudentPostalcodePlaceholder = new System.Windows.Forms.Label();
            this.StudentAddressPlaceholder = new System.Windows.Forms.Label();
            this.StudentAgePlaceholder = new System.Windows.Forms.Label();
            this.StudentGenderPlaceholder = new System.Windows.Forms.Label();
            this.StudentNamePlaceholder = new System.Windows.Forms.Label();
            this.StudentHometownLabel = new System.Windows.Forms.Label();
            this.StudentPostalcodeLabel = new System.Windows.Forms.Label();
            this.StudentAddressLabel = new System.Windows.Forms.Label();
            this.StudentGenderLabel = new System.Windows.Forms.Label();
            this.StudentAgeLabel = new System.Windows.Forms.Label();
            this.StudentNameLabel = new System.Windows.Forms.Label();
            this.groupBoxUserDetails = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.SearchStudentByNameDataGrid)).BeginInit();
            this.StudentProgressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStudentProgress)).BeginInit();
            this.WindowOwnerStudentInformationPanel.SuspendLayout();
            this.groupBoxUserDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchStudentByNameDataGrid
            // 
            this.SearchStudentByNameDataGrid.AllowUserToAddRows = false;
            this.SearchStudentByNameDataGrid.AllowUserToDeleteRows = false;
            this.SearchStudentByNameDataGrid.AllowUserToResizeColumns = false;
            this.SearchStudentByNameDataGrid.AllowUserToResizeRows = false;
            resources.ApplyResources(this.SearchStudentByNameDataGrid, "SearchStudentByNameDataGrid");
            this.SearchStudentByNameDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SearchStudentByNameDataGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.SearchStudentByNameDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchStudentByNameDataGrid.MultiSelect = false;
            this.SearchStudentByNameDataGrid.Name = "SearchStudentByNameDataGrid";
            this.SearchStudentByNameDataGrid.ReadOnly = true;
            this.SearchStudentByNameDataGrid.RowHeadersVisible = false;
            this.SearchStudentByNameDataGrid.RowTemplate.Height = 24;
            this.SearchStudentByNameDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SearchStudentByNameDataGrid.SelectionChanged += new System.EventHandler(this.SearchStudentByNameDataGrid_SelectionChanged);
            // 
            // SearchStudentByNameTextBox
            // 
            this.SearchStudentByNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.SearchStudentByNameTextBox, "SearchStudentByNameTextBox");
            this.SearchStudentByNameTextBox.Name = "SearchStudentByNameTextBox";
            this.SearchStudentByNameTextBox.TextChanged += new System.EventHandler(this.SearchStudentByNameTextBox_TextChanged);
            // 
            // EditStudentButton
            // 
            resources.ApplyResources(this.EditStudentButton, "EditStudentButton");
            this.EditStudentButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.EditStudentButton.Name = "EditStudentButton";
            this.EditStudentButton.UseVisualStyleBackColor = false;
            this.EditStudentButton.Click += new System.EventHandler(this.EditStudentButton_Click);
            // 
            // AddStudentButton
            // 
            resources.ApplyResources(this.AddStudentButton, "AddStudentButton");
            this.AddStudentButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddStudentButton.Name = "AddStudentButton";
            this.AddStudentButton.UseVisualStyleBackColor = false;
            this.AddStudentButton.Click += new System.EventHandler(this.AddStudentButton_Click);
            // 
            // StudentProgressPanel
            // 
            resources.ApplyResources(this.StudentProgressPanel, "StudentProgressPanel");
            this.StudentProgressPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StudentProgressPanel.Controls.Add(this.chartStudentProgress);
            this.StudentProgressPanel.Controls.Add(this.SelectDifficultyComboBox);
            this.StudentProgressPanel.Name = "StudentProgressPanel";
            // 
            // chartStudentProgress
            // 
            resources.ApplyResources(this.chartStudentProgress, "chartStudentProgress");
            this.chartStudentProgress.BackColor = System.Drawing.SystemColors.ControlLight;
            this.chartStudentProgress.BorderlineColor = System.Drawing.Color.Empty;
            this.chartStudentProgress.BorderlineWidth = 0;
            this.chartStudentProgress.BorderSkin.BorderColor = System.Drawing.Color.Empty;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartStudentProgress.ChartAreas.Add(chartArea1);
            this.chartStudentProgress.Cursor = System.Windows.Forms.Cursors.Default;
            this.chartStudentProgress.Name = "chartStudentProgress";
            // 
            // SelectDifficultyComboBox
            // 
            resources.ApplyResources(this.SelectDifficultyComboBox, "SelectDifficultyComboBox");
            this.SelectDifficultyComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SelectDifficultyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectDifficultyComboBox.FormattingEnabled = true;
            this.SelectDifficultyComboBox.Name = "SelectDifficultyComboBox";
            this.SelectDifficultyComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectDifficultyComboBox_SelectedIndexChanged_1);
            // 
            // buttonTerug
            // 
            resources.ApplyResources(this.buttonTerug, "buttonTerug");
            this.buttonTerug.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonTerug.Name = "buttonTerug";
            this.buttonTerug.UseVisualStyleBackColor = false;
            this.buttonTerug.Click += new System.EventHandler(this.buttonTerug_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // WindowOwnerStudentInformationPanel
            // 
            this.WindowOwnerStudentInformationPanel.BackColor = System.Drawing.Color.Transparent;
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentLevelLabel);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.label2);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentEmailPlaceholder);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentEmailLabel);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentHometownPlaceholder);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentPostalcodePlaceholder);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentAddressPlaceholder);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentAgePlaceholder);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentGenderPlaceholder);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentNamePlaceholder);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentHometownLabel);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentPostalcodeLabel);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentAddressLabel);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentGenderLabel);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentAgeLabel);
            this.WindowOwnerStudentInformationPanel.Controls.Add(this.StudentNameLabel);
            resources.ApplyResources(this.WindowOwnerStudentInformationPanel, "WindowOwnerStudentInformationPanel");
            this.WindowOwnerStudentInformationPanel.Name = "WindowOwnerStudentInformationPanel";
            // 
            // StudentLevelLabel
            // 
            resources.ApplyResources(this.StudentLevelLabel, "StudentLevelLabel");
            this.StudentLevelLabel.Name = "StudentLevelLabel";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // StudentEmailPlaceholder
            // 
            resources.ApplyResources(this.StudentEmailPlaceholder, "StudentEmailPlaceholder");
            this.StudentEmailPlaceholder.Name = "StudentEmailPlaceholder";
            // 
            // StudentEmailLabel
            // 
            resources.ApplyResources(this.StudentEmailLabel, "StudentEmailLabel");
            this.StudentEmailLabel.Name = "StudentEmailLabel";
            // 
            // StudentHometownPlaceholder
            // 
            resources.ApplyResources(this.StudentHometownPlaceholder, "StudentHometownPlaceholder");
            this.StudentHometownPlaceholder.Name = "StudentHometownPlaceholder";
            // 
            // StudentPostalcodePlaceholder
            // 
            resources.ApplyResources(this.StudentPostalcodePlaceholder, "StudentPostalcodePlaceholder");
            this.StudentPostalcodePlaceholder.Name = "StudentPostalcodePlaceholder";
            // 
            // StudentAddressPlaceholder
            // 
            resources.ApplyResources(this.StudentAddressPlaceholder, "StudentAddressPlaceholder");
            this.StudentAddressPlaceholder.Name = "StudentAddressPlaceholder";
            // 
            // StudentAgePlaceholder
            // 
            resources.ApplyResources(this.StudentAgePlaceholder, "StudentAgePlaceholder");
            this.StudentAgePlaceholder.Name = "StudentAgePlaceholder";
            // 
            // StudentGenderPlaceholder
            // 
            resources.ApplyResources(this.StudentGenderPlaceholder, "StudentGenderPlaceholder");
            this.StudentGenderPlaceholder.Name = "StudentGenderPlaceholder";
            // 
            // StudentNamePlaceholder
            // 
            resources.ApplyResources(this.StudentNamePlaceholder, "StudentNamePlaceholder");
            this.StudentNamePlaceholder.Name = "StudentNamePlaceholder";
            // 
            // StudentHometownLabel
            // 
            resources.ApplyResources(this.StudentHometownLabel, "StudentHometownLabel");
            this.StudentHometownLabel.Name = "StudentHometownLabel";
            // 
            // StudentPostalcodeLabel
            // 
            resources.ApplyResources(this.StudentPostalcodeLabel, "StudentPostalcodeLabel");
            this.StudentPostalcodeLabel.Name = "StudentPostalcodeLabel";
            // 
            // StudentAddressLabel
            // 
            resources.ApplyResources(this.StudentAddressLabel, "StudentAddressLabel");
            this.StudentAddressLabel.Name = "StudentAddressLabel";
            // 
            // StudentGenderLabel
            // 
            resources.ApplyResources(this.StudentGenderLabel, "StudentGenderLabel");
            this.StudentGenderLabel.Name = "StudentGenderLabel";
            // 
            // StudentAgeLabel
            // 
            resources.ApplyResources(this.StudentAgeLabel, "StudentAgeLabel");
            this.StudentAgeLabel.Name = "StudentAgeLabel";
            // 
            // StudentNameLabel
            // 
            resources.ApplyResources(this.StudentNameLabel, "StudentNameLabel");
            this.StudentNameLabel.Name = "StudentNameLabel";
            // 
            // groupBoxUserDetails
            // 
            resources.ApplyResources(this.groupBoxUserDetails, "groupBoxUserDetails");
            this.groupBoxUserDetails.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxUserDetails.Controls.Add(this.WindowOwnerStudentInformationPanel);
            this.groupBoxUserDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxUserDetails.Name = "groupBoxUserDetails";
            this.groupBoxUserDetails.TabStop = false;
            // 
            // WindowStudentViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTerug);
            this.Controls.Add(this.groupBoxUserDetails);
            this.Controls.Add(this.StudentProgressPanel);
            this.Controls.Add(this.AddStudentButton);
            this.Controls.Add(this.EditStudentButton);
            this.Controls.Add(this.SearchStudentByNameTextBox);
            this.Controls.Add(this.SearchStudentByNameDataGrid);
            this.Name = "WindowStudentViewer";
            ((System.ComponentModel.ISupportInitialize)(this.SearchStudentByNameDataGrid)).EndInit();
            this.StudentProgressPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartStudentProgress)).EndInit();
            this.WindowOwnerStudentInformationPanel.ResumeLayout(false);
            this.WindowOwnerStudentInformationPanel.PerformLayout();
            this.groupBoxUserDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox SearchStudentByNameTextBox;
        private System.Windows.Forms.Button EditStudentButton;
        private System.Windows.Forms.Button AddStudentButton;
        private System.Windows.Forms.Panel StudentProgressPanel;
        public System.Windows.Forms.DataGridView SearchStudentByNameDataGrid;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartStudentProgress;
        public System.Windows.Forms.ComboBox SelectDifficultyComboBox;
        private System.Windows.Forms.Button buttonTerug;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel WindowOwnerStudentInformationPanel;
        public System.Windows.Forms.Label StudentEmailPlaceholder;
        private System.Windows.Forms.Label StudentEmailLabel;
        public System.Windows.Forms.Label StudentHometownPlaceholder;
        public System.Windows.Forms.Label StudentPostalcodePlaceholder;
        public System.Windows.Forms.Label StudentAddressPlaceholder;
        public System.Windows.Forms.Label StudentAgePlaceholder;
        public System.Windows.Forms.Label StudentGenderPlaceholder;
        public System.Windows.Forms.Label StudentNamePlaceholder;
        private System.Windows.Forms.Label StudentHometownLabel;
        private System.Windows.Forms.Label StudentPostalcodeLabel;
        private System.Windows.Forms.Label StudentAddressLabel;
        private System.Windows.Forms.Label StudentGenderLabel;
        private System.Windows.Forms.Label StudentAgeLabel;
        private System.Windows.Forms.Label StudentNameLabel;
        private System.Windows.Forms.GroupBox groupBoxUserDetails;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label StudentLevelLabel;
    }
}