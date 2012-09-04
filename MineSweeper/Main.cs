/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

	Copyright (c) 2006, Dan McKinley
	All rights reserved.

	Redistribution and use in source and binary forms, with or without modification, 
	are permitted provided that the following conditions are met:

	-	Redistributions of source code must retain the above copyright notice, 
		this list of conditions and the following disclaimer. 
		
	-	Redistributions in binary form must reproduce the above copyright notice, 
		this list of conditions and the following disclaimer in the documentation 
		and/or other materials provided with the distribution. 
	
	-	The name of Dan McKinley may not be used to endorse or promote products 
		derived from this software without specific prior written permission. 
		
	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
	AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
	IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
	ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
	LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
	CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
	SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
	INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
	CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
	ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
	POSSIBILITY OF SUCH DAMAGE.

 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MineSweeper.Properties;

namespace MineSweeper
{
    public partial class Main : Form
    {
        private Grid _grid;
        private ControlPanel _ctrl;

        public Main()
        {
            InitializeComponent();
            _grid = new Grid();
            _grid.Resize += new EventHandler(g_Resize);
            this.Controls.Add(_grid);
            MakeControlPanel();
            
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = true;
            this.MaximizeBox = false;
            g_Resize(null, null);
            this.MainMenuStrip.BackColor = Color.FromArgb(0, Color.White);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
            this.BackColor = Color.FromArgb(0xea, 0xea, 0xee);
        }


        private void MakeControlPanel()
        {
            _ctrl = new ControlPanel();
            _ctrl.Top = SystemInformation.MenuHeight;
            _ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            _ctrl.Height = 50;
            _ctrl.Width = this.ClientRectangle.Width;
            this.Controls.Add(_ctrl);
        }
        

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _ctrl.Width = this.ClientRectangle.Width;
        }


        void g_Resize(object sender, EventArgs e)
        {
            this.SuspendLayout();
            Size sz = new Size(_grid.Width, _ctrl.Bottom + _grid.Height);
            this.ClientSize = sz;
            _grid.Top = _ctrl.Bottom;
        }

        private void _exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _newGame_Click(object sender, EventArgs e)
        {
            AppEvents.OnNewGame(EventArgs.Empty);
        }

        private void _scores_Click(object sender, EventArgs e)
        {
            (new BestTimes()).ShowDialog(this);
        }

        private void _beginner_Click(object sender, EventArgs e)
        {
            _grid.Redim(10, 10, 15);
        }

        private void _intermediate_Click(object sender, EventArgs e)
        {
            _grid.Redim(16, 16, 40);
        }

        private void _hard_Click(object sender, EventArgs e)
        {
            _grid.Redim(20, 20, 60);
        }

        private void _about_Click(object sender, EventArgs e)
        {
            (new About()).ShowDialog(this);
        }

        private void _options_Click(object sender, EventArgs e)
        {
            (new Options()).ShowDialog(this);
        }
    }
}