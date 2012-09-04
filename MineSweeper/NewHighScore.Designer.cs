namespace MineSweeper
{
    partial class NewHighScore
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
            this.label1 = new System.Windows.Forms.Label();
            this._name = new System.Windows.Forms.TextBox();
            this._ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter your name.";
            // 
            // _name
            // 
            this._name.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._name.Location = new System.Drawing.Point(19, 47);
            this._name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(300, 23);
            this._name.TabIndex = 1;
            // 
            // _ok
            // 
            this._ok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._ok.Location = new System.Drawing.Point(122, 82);
            this._ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._ok.Name = "_ok";
            this._ok.Size = new System.Drawing.Size(87, 28);
            this._ok.TabIndex = 2;
            this._ok.Text = "&Ok";
            this._ok.UseVisualStyleBackColor = true;
            this._ok.Click += new System.EventHandler(this._ok_Click);
            // 
            // NewHighScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(334, 125);
            this.Controls.Add(this._ok);
            this.Controls.Add(this._name);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NewHighScore";
            this.Text = "Congratulations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _name;
        private System.Windows.Forms.Button _ok;
    }
}