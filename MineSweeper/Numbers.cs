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
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    class Numbers
    {
        private static Brush[] _brushes = new Brush[] {
            new SolidBrush(Color.FromArgb(0xdd, Color.Navy)),
            new SolidBrush(Color.FromArgb(0xdd, Color.Firebrick)),
            new SolidBrush(Color.FromArgb(0xdd, Color.DarkGreen)),
            new SolidBrush(Color.FromArgb(0xdd, Color.Chocolate)),
            new SolidBrush(Color.FromArgb(0xdd, Color.DarkOrchid)),
            new SolidBrush(Color.FromArgb(0xdd, Color.Gold)),
            new SolidBrush(Color.FromArgb(0xdd, Color.DarkMagenta)),
            new SolidBrush(Color.FromArgb(0xdd, Color.DarkOrange))
        };
        private static Font _font = new Font("Tahoma", 8, FontStyle.Bold);

        private CenteredText[] _nums = new CenteredText[8];
        

        public void Draw(Graphics g, Rectangle r, int n)
        {
            _nums[n].Draw(g, _brushes[n-1], r);
        }

        public Numbers(Control c)
        {
            c.HandleCreated += new EventHandler(c_HandleCreated);
        }

        void c_HandleCreated(object sender, EventArgs e)
        {
            IWin32Window win = (IWin32Window)sender;
            for (int i = 0; i < _nums.Length; i++)
            {
                _nums[i] = new CenteredText(i.ToString(), win, _font, new Size(24, 24));
            }
        }

    }
}
