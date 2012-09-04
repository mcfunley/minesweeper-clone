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

namespace MineSweeper
{
    public abstract class CustomButton : Control
    {
        private CbFlags _flags;

        [Flags]
        protected enum CbFlags : int
        {
            Hot = 1,
            Pressed = 2
        }

        public CustomButton()
        {
            _flags = (CbFlags)0;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.GetFlag(CbFlags.Pressed))
            {
                this.DrawPressed(e);
            }
            else if (this.GetFlag(CbFlags.Hot))
            {
                this.DrawHot(e);
            }
            else
            {
                this.DrawNormal(e);
            }
        }

        protected abstract void DrawPressed(PaintEventArgs e);
        protected abstract void DrawNormal(PaintEventArgs e);
        protected abstract void DrawHot(PaintEventArgs e);

        protected bool GetFlag(CbFlags f)
        {
            return (_flags & f) > 0;
        }

        protected void SetFlag(CbFlags f)
        {
            _flags |= f;
        }

        protected void ClearFlag(CbFlags f)
        {
            _flags ^= f;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.SetFlag(CbFlags.Hot);
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.ClearFlag(CbFlags.Hot);
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.SetFlag(CbFlags.Pressed);
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.ClearFlag(CbFlags.Pressed);
            this.Invalidate();
        }
        

    }
}
