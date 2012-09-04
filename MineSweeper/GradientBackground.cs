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
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace MineSweeper
{
    class GradientBackground
    {
        private Control _target;
        private PathGradientBrush _brush;

        private Color[] _surroundColors;
        public Color[] SurroundColors
        {
            get { return _surroundColors; }
            set { _surroundColors = value; this.GetBrush();  }
        }

        private Color _centerColor;
        public Color CenterColor
        {
            get { return _centerColor; }
            set { _centerColor = value; this.GetBrush(); }
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(_brush, _target.ClientRectangle);
        }

        public GradientBackground(Control target)
        {
            _target = target;
            _target.Resize += new EventHandler(_target_Resize);
            
            _centerColor = Color.AliceBlue;
            this.GetBrush();
        }

        private void DefaultSurround()
        {
            Color c = Color.FromArgb(0x70, Color.Navy);
            Color c2 = Color.FromArgb(0x70, c);
            _surroundColors = new Color[] { _centerColor, c2, c, c2 };
        }

        private void GetBrush()
        {
            if (_surroundColors == null)
            {
                this.DefaultSurround();
            }

            Color c = Color.LightBlue;
            Color l = Color.AliceBlue;
            Point[] pts = new Point[] { 
                Point.Empty, new Point(_target.Width-1, 0), 
                new Point(_target.Width-1, _target.Height-1), new Point(0, _target.Height-1)
            };
            _brush = new PathGradientBrush(pts);
            _brush.SurroundColors = this.SurroundColors;
            _brush.CenterColor = this.CenterColor;
        }

        void _target_Resize(object sender, EventArgs e)
        {
            this.GetBrush();
            _target.Invalidate();
        }
    }
}
