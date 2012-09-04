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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MineSweeper
{
    public partial class ControlPanel : UserControl
    {
        private NewGameButton _newgame;
        private MineCounter _mineCtr;
        private TimeLabel _time;

        public ControlPanel()
        {
            this.SuspendLayout();
            _newgame = new NewGameButton();
            this.Controls.Add(_newgame);

            _mineCtr = new MineCounter();
            this.Controls.Add(_mineCtr);

            _time = new TimeLabel();
            this.Controls.Add(_time);
            this.ResumeLayout();

            InitializeComponent();
            this.BackColor = Color.FromArgb(0, Color.White);
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            this.SuspendLayout();
            this.PlaceNgButton();
            int c = this.Height / 2;
            int cl = this.Width / 5;
            int cr = this.Width - cl;
            _mineCtr.Location = new Point(cl - _mineCtr.Width / 2, c - _mineCtr.Height / 2);
            _time.Location = new Point(cr - _time.Width / 2, c - _time.Height / 2);
            this.ResumeLayout();
        }

        private void PlaceNgButton()
        {
            int cy = this.Height / 2;
            int cx = this.Width / 2;
            _newgame.Location = new Point(cx - _newgame.Width / 2, cy - _newgame.Height / 2);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.PerformLayout();
        }

    }
}
