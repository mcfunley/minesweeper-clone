namespace MineSweeper
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this._menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._options = new System.Windows.Forms.ToolStripMenuItem();
            this._scores = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._beginner = new System.Windows.Forms.ToolStripMenuItem();
            this._intermediate = new System.Windows.Forms.ToolStripMenuItem();
            this._hard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._exit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._about = new System.Windows.Forms.ToolStripMenuItem();
            this._menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menu
            // 
            this._menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this._menu.Location = new System.Drawing.Point(0, 0);
            this._menu.Name = "_menu";
            this._menu.Size = new System.Drawing.Size(292, 24);
            this._menu.TabIndex = 0;
            this._menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newGame,
            this.toolStripSeparator2,
            this._options,
            this._scores,
            this.toolStripSeparator1,
            this._beginner,
            this._intermediate,
            this._hard,
            this.toolStripSeparator3,
            this._exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // _newGame
            // 
            this._newGame.Name = "_newGame";
            this._newGame.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this._newGame.Size = new System.Drawing.Size(167, 22);
            this._newGame.Text = "&New Game";
            this._newGame.Click += new System.EventHandler(this._newGame_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // _options
            // 
            this._options.Name = "_options";
            this._options.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this._options.Size = new System.Drawing.Size(167, 22);
            this._options.Text = "&Options...";
            this._options.Click += new System.EventHandler(this._options_Click);
            // 
            // _scores
            // 
            this._scores.Name = "_scores";
            this._scores.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this._scores.Size = new System.Drawing.Size(167, 22);
            this._scores.Text = "Best &Times...";
            this._scores.Click += new System.EventHandler(this._scores_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // _beginner
            // 
            this._beginner.Name = "_beginner";
            this._beginner.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._beginner.Size = new System.Drawing.Size(167, 22);
            this._beginner.Text = "Greenhorn";
            this._beginner.Click += new System.EventHandler(this._beginner_Click);
            // 
            // _intermediate
            // 
            this._intermediate.Name = "_intermediate";
            this._intermediate.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this._intermediate.Size = new System.Drawing.Size(167, 22);
            this._intermediate.Text = "Mediocre";
            this._intermediate.Click += new System.EventHandler(this._intermediate_Click);
            // 
            // _hard
            // 
            this._hard.Name = "_hard";
            this._hard.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this._hard.Size = new System.Drawing.Size(167, 22);
            this._hard.Text = "Herculean";
            this._hard.Click += new System.EventHandler(this._hard_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // _exit
            // 
            this._exit.Name = "_exit";
            this._exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._exit.Size = new System.Drawing.Size(167, 22);
            this._exit.Text = "E&xit";
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._about});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // _about
            // 
            this._about.Name = "_about";
            this._about.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this._about.Size = new System.Drawing.Size(139, 22);
            this._about.Text = "&About";
            this._about.Click += new System.EventHandler(this._about_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this._menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menu;
            this.Name = "Main";
            this.Text = "Minesweeper++";
            this._menu.ResumeLayout(false);
            this._menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _options;
        private System.Windows.Forms.ToolStripMenuItem _scores;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _exit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _about;
        private System.Windows.Forms.ToolStripMenuItem _newGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _beginner;
        private System.Windows.Forms.ToolStripMenuItem _intermediate;
        private System.Windows.Forms.ToolStripMenuItem _hard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

    }
}

