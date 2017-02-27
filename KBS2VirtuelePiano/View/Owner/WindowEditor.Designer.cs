namespace KBS2VirtuelePiano.View
{
    partial class WindowEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowEditor));
            this.AddRow = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.WindowPanelEditor = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.authorTextfield = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titelSongTextField = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddRow
            // 
            this.AddRow.Location = new System.Drawing.Point(9, 10);
            this.AddRow.Margin = new System.Windows.Forms.Padding(2);
            this.AddRow.Name = "AddRow";
            this.AddRow.Size = new System.Drawing.Size(120, 28);
            this.AddRow.TabIndex = 0;
            this.AddRow.Text = "Rij toevoegen";
            this.AddRow.UseVisualStyleBackColor = true;
            this.AddRow.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WindowPanelEditor
            // 
            this.WindowPanelEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WindowPanelEditor.AutoScroll = true;
            this.WindowPanelEditor.BackColor = System.Drawing.Color.White;
            this.WindowPanelEditor.Location = new System.Drawing.Point(9, 42);
            this.WindowPanelEditor.Margin = new System.Windows.Forms.Padding(2);
            this.WindowPanelEditor.Name = "WindowPanelEditor";
            this.WindowPanelEditor.Size = new System.Drawing.Size(1005, 577);
            this.WindowPanelEditor.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(770, 11);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(121, 27);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Opslaan";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(895, 10);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(119, 28);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Annuleren";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // authorTextfield
            // 
            this.authorTextfield.Location = new System.Drawing.Point(134, 15);
            this.authorTextfield.Margin = new System.Windows.Forms.Padding(2);
            this.authorTextfield.Name = "authorTextfield";
            this.authorTextfield.Size = new System.Drawing.Size(118, 20);
            this.authorTextfield.TabIndex = 4;
            this.authorTextfield.Text = "Auteur";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Level: ";
            // 
            // titelSongTextField
            // 
            this.titelSongTextField.Location = new System.Drawing.Point(442, 15);
            this.titelSongTextField.Margin = new System.Windows.Forms.Padding(2);
            this.titelSongTextField.Name = "titelSongTextField";
            this.titelSongTextField.Size = new System.Drawing.Size(240, 20);
            this.titelSongTextField.TabIndex = 7;
            this.titelSongTextField.Text = "Titel liedje";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(325, 15);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(73, 20);
            this.numericUpDown1.TabIndex = 8;
            // 
            // WindowEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 638);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.titelSongTextField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.authorTextfield);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.WindowPanelEditor);
            this.Controls.Add(this.AddRow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WindowEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notenschrift invoeren";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddRow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel WindowPanelEditor;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox authorTextfield;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titelSongTextField;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

