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
using System.Drawing;
using MineSweeper.Properties;

namespace MineSweeper
{
    class NewGameButton : Control
    {
        private bool _lost;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(96, Color.Navy)), 
                new Rectangle(0, 0, this.Width-1, this.Height-1));
            e.Graphics.DrawIcon((_lost ? Resources.Sad: Resources.Smiley), 4, 4);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            AppEvents.OnNewGame(EventArgs.Empty);
        }

        public NewGameButton()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.SupportsTransparentBackColor,
                true);
            this.BackColor = Color.FromArgb(0, Color.White);
            this.Size = new Size(42, 42);

            AppEvents.Lose += new EventHandler(AppEvents_Lose);
            AppEvents.NewGame += new EventHandler(AppEvents_NewGame);
            this.SetBack();
        }

        void AppEvents_NewGame(object sender, EventArgs e)
        {
            _lost = false;
            GameStateChange(sender, e);
        }

        private void AppEvents_Lose(object sender, EventArgs e)
        {
            _lost = true;
            GameStateChange(sender, e);
        }

        void GameStateChange(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.SetBack(Color.FromArgb(0x90, Color.White));
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.SetHotBg();
        }

        private void SetHotBg()
        {
            this.SetBack(Color.FromArgb(0x40, Color.White));
            this.Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.SetHotBg();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.SetBack();
            this.Invalidate();
        }

        private void SetBack()
        {
            this.SetBack(Color.FromArgb(0x22, Color.White));
        }

        private void SetBack(Color c)
        {
            this.BackColor = c;
        }



    }
}
