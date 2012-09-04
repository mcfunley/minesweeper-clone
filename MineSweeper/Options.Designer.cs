namespace MineSweeper
{
    partial class Options
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
            this._ok = new System.Windows.Forms.Button();
            this._sounds = new System.Windows.Forms.CheckBox();
            this._clearhof = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._mines = new System.Windows.Forms.NumericUpDown();
            this._height = new System.Windows.Forms.NumericUpDown();
            this._width = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._width)).BeginInit();
            this.SuspendLayout();
            // 
            // _ok
            // 
            this._ok.Location = new System.Drawing.Point(148, 168);
            this._ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._ok.Name = "_ok";
            this._ok.Size = new System.Drawing.Size(87, 27);
            this._ok.TabIndex = 0;
            this._ok.Text = "&Close";
            this._ok.UseVisualStyleBackColor = true;
            this._ok.Click += new System.EventHandler(this._ok_Click);
            // 
            // _sounds
            // 
            this._sounds.AutoSize = true;
            this._sounds.Location = new System.Drawing.Point(247, 51);
            this._sounds.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._sounds.Name = "_sounds";
            this._sounds.Size = new System.Drawing.Size(94, 20);
            this._sounds.TabIndex = 1;
            this._sounds.Text = "&Play sounds";
            this._sounds.UseVisualStyleBackColor = true;
            this._sounds.CheckedChanged += new System.EventHandler(this._sounds_CheckedChanged);
            // 
            // _clearhof
            // 
            this._clearhof.Location = new System.Drawing.Point(247, 92);
            this._clearhof.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._clearhof.Name = "_clearhof";
            this._clearhof.Size = new System.Drawing.Size(121, 28);
            this._clearhof.TabIndex = 2;
            this._clearhof.Text = "Clear High Scores";
            this._clearhof.UseVisualStyleBackColor = true;
            this._clearhof.Click += new System.EventHandler(this._clearhof_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._mines);
            this.panel1.Controls.Add(this._height);
            this.panel1.Controls.Add(this._width);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(12, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 118);
            this.panel1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Number of Mines";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Width";
            // 
            // _mines
            // 
            this._mines.Location = new System.Drawing.Point(129, 81);
            this._mines.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._mines.Maximum = new decimal(new int[] {
            899,
            0,
            0,
            0});
            this._mines.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._mines.Name = "_mines";
            this._mines.Size = new System.Drawing.Size(64, 23);
            this._mines.TabIndex = 0;
            this._mines.Tag = "";
            this._mines.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._mines.ValueChanged += new System.EventHandler(this._mines_ValueChanged);
            // 
            // _height
            // 
            this._height.Location = new System.Drawing.Point(129, 44);
            this._height.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._height.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this._height.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this._height.Name = "_height";
            this._height.Size = new System.Drawing.Size(64, 23);
            this._height.TabIndex = 0;
            this._height.Tag = "";
            this._height.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this._height.ValueChanged += new System.EventHandler(this._height_ValueChanged);
            // 
            // _width
            // 
            this._width.Location = new System.Drawing.Point(129, 8);
            this._width.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._width.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this._width.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this._width.Name = "_width";
            this._width.Size = new System.Drawing.Size(64, 23);
            this._width.TabIndex = 0;
            this._width.Tag = "";
            this._width.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this._width.ValueChanged += new System.EventHandler(this._width_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Custom Grid Settings";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::MineSweeper.Properties.Resources.Options;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(380, 209);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._clearhof);
            this.Controls.Add(this._sounds);
            this.Controls.Add(this._ok);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Text = "Options";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _ok;
        private System.Windows.Forms.CheckBox _sounds;
        private System.Windows.Forms.Button _clearhof;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown _mines;
        private System.Windows.Forms.NumericUpDown _height;
        private System.Windows.Forms.NumericUpDown _width;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}