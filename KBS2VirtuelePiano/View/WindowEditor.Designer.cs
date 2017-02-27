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
            this.AddRow = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.WindowPanelEditor = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.authorTextfield = new System.Windows.Forms.TextBox();
            this.levelSelectBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titelSongTextField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AddRow
            // 
            this.AddRow.Location = new System.Drawing.Point(12, 12);
            this.AddRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddRow.Name = "AddRow";
            this.AddRow.Size = new System.Drawing.Size(160, 34);
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
            this.WindowPanelEditor.Location = new System.Drawing.Point(12, 52);
            this.WindowPanelEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WindowPanelEditor.Name = "WindowPanelEditor";
            this.WindowPanelEditor.Size = new System.Drawing.Size(1340, 710);
            this.WindowPanelEditor.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(1026, 13);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(161, 33);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Opslaan";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(1193, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(159, 34);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Annuleren";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // authorTextfield
            // 
            this.authorTextfield.Location = new System.Drawing.Point(178, 18);
            this.authorTextfield.Name = "authorTextfield";
            this.authorTextfield.Size = new System.Drawing.Size(156, 22);
            this.authorTextfield.TabIndex = 4;
            this.authorTextfield.Text = "Auteur";
            // 
            // levelSelectBox
            // 
            this.levelSelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelSelectBox.FormattingEnabled = true;
            this.levelSelectBox.Location = new System.Drawing.Point(431, 18);
            this.levelSelectBox.Name = "levelSelectBox";
            this.levelSelectBox.Size = new System.Drawing.Size(138, 24);
            this.levelSelectBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Level: ";
            // 
            // titelSongTextField
            // 
            this.titelSongTextField.Location = new System.Drawing.Point(590, 18);
            this.titelSongTextField.Name = "titelSongTextField";
            this.titelSongTextField.Size = new System.Drawing.Size(319, 22);
            this.titelSongTextField.TabIndex = 7;
            this.titelSongTextField.Text = "Titel liedje";
            // 
            // WindowEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 785);
            this.Controls.Add(this.titelSongTextField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.levelSelectBox);
            this.Controls.Add(this.authorTextfield);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.WindowPanelEditor);
            this.Controls.Add(this.AddRow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WindowEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notenschrift invoeren";
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
        private System.Windows.Forms.ComboBox levelSelectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titelSongTextField;
    }
}

