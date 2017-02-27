namespace KBS2VirtuelePiano
{
    partial class WindowMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowMain));
            this.timerRepaint = new System.Windows.Forms.Timer(this.components);
            this.TimerFollower = new System.Windows.Forms.Timer(this.components);
            this.panelPiano1 = new KBS2VirtuelePiano.PanelPiano();
            this.panelSong = new KBS2VirtuelePiano.PanelSong();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afsluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geluidVanNotenButton = new System.Windows.Forms.ToolStripMenuItem();
            this.visueleHulpmiddelenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nootLengteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartButton = new System.Windows.Forms.ToolStripMenuItem();
            this.StopButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PauzeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSong.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerRepaint
            // 
            this.timerRepaint.Enabled = true;
            this.timerRepaint.Interval = 1;
            this.timerRepaint.Tick += new System.EventHandler(this.timerRepaint_Tick);
            // 
            // TimerFollower
            // 
            this.TimerFollower.Enabled = true;
            this.TimerFollower.Interval = 1;
            this.TimerFollower.Tick += new System.EventHandler(this.TimerFollower_Tick);
            // 
            // panelPiano1
            // 
            this.panelPiano1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPiano1.Location = new System.Drawing.Point(0, 467);
            this.panelPiano1.Name = "panelPiano1";
            this.panelPiano1.Size = new System.Drawing.Size(1426, 372);
            this.panelPiano1.TabIndex = 1;
            // 
            // panelSong
            // 
            this.panelSong.Controls.Add(this.menuStrip1);
            this.panelSong.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSong.Location = new System.Drawing.Point(0, 0);
            this.panelSong.Margin = new System.Windows.Forms.Padding(0);
            this.panelSong.Name = "panelSong";
            this.panelSong.RenderNoteLength = true;
            this.panelSong.Size = new System.Drawing.Size(1426, 464);
            this.panelSong.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.sToolStripMenuItem,
            this.StartButton,
            this.StopButton,
            this.PauzeButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1426, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afsluitenToolStripMenuItem});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.startToolStripMenuItem.Text = "Bestand";
            // 
            // afsluitenToolStripMenuItem
            // 
            this.afsluitenToolStripMenuItem.Name = "afsluitenToolStripMenuItem";
            this.afsluitenToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.afsluitenToolStripMenuItem.Text = "Afsluiten";
            this.afsluitenToolStripMenuItem.Click += new System.EventHandler(this.afsluitenToolStripMenuItem_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Checked = true;
            this.sToolStripMenuItem.CheckOnClick = true;
            this.sToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geluidVanNotenButton,
            this.visueleHulpmiddelenToolStripMenuItem});
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.sToolStripMenuItem.Text = "Opties";
            // 
            // geluidVanNotenButton
            // 
            this.geluidVanNotenButton.Checked = true;
            this.geluidVanNotenButton.CheckOnClick = true;
            this.geluidVanNotenButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.geluidVanNotenButton.Name = "geluidVanNotenButton";
            this.geluidVanNotenButton.Size = new System.Drawing.Size(188, 22);
            this.geluidVanNotenButton.Text = "Geluid van noten";
            this.geluidVanNotenButton.Click += new System.EventHandler(this.geluidVanNotenButton_Click);
            // 
            // visueleHulpmiddelenToolStripMenuItem
            // 
            this.visueleHulpmiddelenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nootLengteToolStripMenuItem});
            this.visueleHulpmiddelenToolStripMenuItem.Name = "visueleHulpmiddelenToolStripMenuItem";
            this.visueleHulpmiddelenToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.visueleHulpmiddelenToolStripMenuItem.Text = "Visuele hulpmiddelen";
            // 
            // nootLengteToolStripMenuItem
            // 
            this.nootLengteToolStripMenuItem.CheckOnClick = true;
            this.nootLengteToolStripMenuItem.Name = "nootLengteToolStripMenuItem";
            this.nootLengteToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.nootLengteToolStripMenuItem.Text = "Noot lengte";
            this.nootLengteToolStripMenuItem.Click += new System.EventHandler(this.nootLengteToolStripMenuItem_Click);
            // 
            // StartButton
            // 
            this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(32, 24);
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Image = ((System.Drawing.Image)(resources.GetObject("StopButton.Image")));
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(32, 24);
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PauzeButton
            // 
            this.PauzeButton.Image = ((System.Drawing.Image)(resources.GetObject("PauzeButton.Image")));
            this.PauzeButton.Name = "PauzeButton";
            this.PauzeButton.Size = new System.Drawing.Size(32, 24);
            this.PauzeButton.Click += new System.EventHandler(this.PauzeButton_Click);
            // 
            // WindowMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 839);
            this.Controls.Add(this.panelPiano1);
            this.Controls.Add(this.panelSong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WindowMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notenschrift Oefenen";
            this.panelSong.ResumeLayout(false);
            this.panelSong.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelSong panelSong;
        private PanelPiano panelPiano1;
        private System.Windows.Forms.Timer timerRepaint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afsluitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visueleHulpmiddelenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nootLengteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PauzeButton;
        private System.Windows.Forms.ToolStripMenuItem StartButton;
        private System.Windows.Forms.ToolStripMenuItem StopButton;
        private System.Windows.Forms.ToolStripMenuItem geluidVanNotenButton;
        private System.Windows.Forms.Timer TimerFollower;
    }
}