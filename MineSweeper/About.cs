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
using System.Diagnostics;

namespace MineSweeper
{
    public partial class About : Form
    {
        private class LinkSwapper : UserControl 
        {
            private bool _mouse;

            public LinkSwapper()
            {
                this.BackColor = Color.FromArgb(0, Color.White);
                this.Size = Resources.TitleSwap.Size;
                this.Cursor = Cursors.Hand;
                this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                if (_mouse)
                {
                    e.Graphics.DrawImage(Resources.TitleSwap, this.ClientRectangle);
                }
            }

            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                Process.Start("http://mcfunley.com");
            }

            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);
                _mouse = true;
                this.Invalidate();
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                _mouse = false;
                this.Invalidate();
            }
        }

        public About()
        {
            InitializeComponent();
            this.Icon = Resources.Bomb;
            this.BackgroundImage = Resources.Title;
            this.ClientSize = Resources.Title.Size;

            LinkSwapper s = new LinkSwapper();
            s.Location = new Point(46, 107);
            this.Controls.Add(s);
        }

    }
}