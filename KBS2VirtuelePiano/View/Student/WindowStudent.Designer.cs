using KBS2VirtuelePiano.View;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace KBS2VirtuelePiano.View
{
    partial class WindowStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowStudent));
            this.timerRepaint = new System.Windows.Forms.Timer(this.components);
            this.TimerFollower = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selecteerBestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemShowProgress = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.logUitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afsluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geluidVanNotenButton = new System.Windows.Forms.ToolStripMenuItem();
            this.visueleHulpmiddelenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nootLengteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tempoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStart = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStop = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPause = new System.Windows.Forms.ToolStripMenuItem();
            this.panelPiano = new KBS2VirtuelePiano.View.PanelPiano();
            this.panelSong = new KBS2VirtuelePiano.View.PanelSong();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerRepaint
            // 
            this.timerRepaint.Enabled = true;
            this.timerRepaint.Interval = 10;
            this.timerRepaint.Tick += new System.EventHandler(this.timerRepaint_Tick);
            // 
            // TimerFollower
            // 
            this.TimerFollower.Enabled = true;
            this.TimerFollower.Interval = 1;
            this.TimerFollower.Tick += new System.EventHandler(this.TimerFollower_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.sToolStripMenuItem,
            this.buttonStart,
            this.buttonStop,
            this.buttonPause});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1426, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selecteerBestandToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItemShowProgress,
            this.toolStripSeparator1,
            this.logUitToolStripMenuItem,
            this.afsluitenToolStripMenuItem});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.startToolStripMenuItem.Text = "Bestand";
            // 
            // selecteerBestandToolStripMenuItem
            // 
            this.selecteerBestandToolStripMenuItem.Name = "selecteerBestandToolStripMenuItem";
            this.selecteerBestandToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.selecteerBestandToolStripMenuItem.Text = "Lied openen";
            this.selecteerBestandToolStripMenuItem.Click += new System.EventHandler(this.openLiedToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // toolStripMenuItemShowProgress
            // 
            this.toolStripMenuItemShowProgress.Name = "toolStripMenuItemShowProgress";
            this.toolStripMenuItemShowProgress.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItemShowProgress.Text = "Mijn voortgang";
            this.toolStripMenuItemShowProgress.Click += new System.EventHandler(this.toolStripMenuItemShowProgress_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // logUitToolStripMenuItem
            // 
            this.logUitToolStripMenuItem.Name = "logUitToolStripMenuItem";
            this.logUitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.logUitToolStripMenuItem.Text = "Uitloggen";
            this.logUitToolStripMenuItem.Click += new System.EventHandler(this.logUitToolStripMenuItem_Click);
            // 
            // afsluitenToolStripMenuItem
            // 
            this.afsluitenToolStripMenuItem.Name = "afsluitenToolStripMenuItem";
            this.afsluitenToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.afsluitenToolStripMenuItem.Text = "Afsluiten";
            this.afsluitenToolStripMenuItem.Click += new System.EventHandler(this.afsluitenToolStripMenuItem_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Checked = true;
            this.sToolStripMenuItem.CheckOnClick = true;
            this.sToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geluidVanNotenButton,
            this.visueleHulpmiddelenToolStripMenuItem,
            this.tempoToolStripMenuItem});
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
            // tempoToolStripMenuItem
            // 
            this.tempoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.xToolStripMenuItem1,
            this.xToolStripMenuItem4,
            this.xToolStripMenuItem2,
            this.xToolStripMenuItem3,
            this.toolStripMenuItem2});
            this.tempoToolStripMenuItem.Name = "tempoToolStripMenuItem";
            this.tempoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.tempoToolStripMenuItem.Text = "Tempo";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.xToolStripMenuItem.Text = "0.25x";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem1
            // 
            this.xToolStripMenuItem1.Name = "xToolStripMenuItem1";
            this.xToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.xToolStripMenuItem1.Text = "0.5x";
            this.xToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem4
            // 
            this.xToolStripMenuItem4.Name = "xToolStripMenuItem4";
            this.xToolStripMenuItem4.Size = new System.Drawing.Size(100, 22);
            this.xToolStripMenuItem4.Text = "0.75x";
            this.xToolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem2
            // 
            this.xToolStripMenuItem2.Checked = true;
            this.xToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xToolStripMenuItem2.Name = "xToolStripMenuItem2";
            this.xToolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.xToolStripMenuItem2.Text = "1x";
            this.xToolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem3
            // 
            this.xToolStripMenuItem3.Name = "xToolStripMenuItem3";
            this.xToolStripMenuItem3.Size = new System.Drawing.Size(100, 22);
            this.xToolStripMenuItem3.Text = "2x";
            this.xToolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem2.Text = "4x";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonStart.Image = ((System.Drawing.Image)(resources.GetObject("buttonStart.Image")));
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(32, 24);
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(32, 24);
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPause.Image = ((System.Drawing.Image)(resources.GetObject("buttonPause.Image")));
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(32, 24);
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // panelPiano
            // 
            this.panelPiano.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPiano.Location = new System.Drawing.Point(0, 519);
            this.panelPiano.Margin = new System.Windows.Forms.Padding(0);
            this.panelPiano.Name = "panelPiano";
            this.panelPiano.Size = new System.Drawing.Size(1426, 331);
            this.panelPiano.TabIndex = 1;
            // 
            // panelSong
            // 
            this.panelSong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSong.Location = new System.Drawing.Point(0, 28);
            this.panelSong.Margin = new System.Windows.Forms.Padding(0);
            this.panelSong.Name = "panelSong";
            this.panelSong.RenderNoteLength = false;
            this.panelSong.Size = new System.Drawing.Size(1426, 491);
            this.panelSong.TabIndex = 0;
            // 
            // WindowStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 849);
            this.Controls.Add(this.panelPiano);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelSong);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1164, 851);
            this.Name = "WindowStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notenschrift Oefenen";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        public PanelSong panelSong;
        public PanelPiano panelPiano;
        private System.Windows.Forms.Timer timerRepaint;
        private System.Windows.Forms.Timer TimerFollower;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem startToolStripMenuItem;
        private ToolStripMenuItem selecteerBestandToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemShowProgress;
        private ToolStripMenuItem afsluitenToolStripMenuItem;
        private ToolStripMenuItem logUitToolStripMenuItem;
        private ToolStripMenuItem sToolStripMenuItem;
        private ToolStripMenuItem geluidVanNotenButton;
        private ToolStripMenuItem visueleHulpmiddelenToolStripMenuItem;
        private ToolStripMenuItem nootLengteToolStripMenuItem;
        public ToolStripMenuItem tempoToolStripMenuItem;
        public ToolStripMenuItem xToolStripMenuItem;
        public ToolStripMenuItem xToolStripMenuItem1;
        public ToolStripMenuItem xToolStripMenuItem2;
        public ToolStripMenuItem xToolStripMenuItem3;
        public ToolStripMenuItem toolStripMenuItem2;
        public ToolStripMenuItem buttonStart;
        public ToolStripMenuItem buttonStop;
        public ToolStripMenuItem buttonPause;
        public ToolStripMenuItem xToolStripMenuItem4;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
    }
}