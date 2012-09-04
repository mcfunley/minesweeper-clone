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

namespace MineSweeper
{
    public partial class BestTimes : Form
    {
        private Font _font;

        public BestTimes()
        {
            InitializeComponent();
            this.Click += new EventHandler(BestTimes_Click);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
            _font = new Font("Courier New", 8.5F);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            const int l = 40;
            const int t = 75;

            int h = (int)(_font.Height * 1.5);
            int i = 1;
            e.Graphics.DrawString(Score.GetTitles(), new Font(_font, FontStyle.Underline), 
                Brushes.Navy, new Point(l, t));                     

            IEnumerator<Score> sen = HallOfFame.Default.Scores.GetEnumerator();
            for (int y = t+h; y < this.Height-50 && sen.MoveNext(); y += h)
            {
                Score score = sen.Current;
                string s = string.Format("{0,2}. {1}", i++, score);
                e.Graphics.DrawString(s, _font, Brushes.Navy, new PointF(l, y));
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        void BestTimes_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}