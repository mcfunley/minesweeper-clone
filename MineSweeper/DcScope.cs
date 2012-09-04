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
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;

namespace MineSweeper
{
    class DcScope : DisposableBase
    {
        private IntPtr _hdc;
        private IWin32Window _win;
        private Graphics _graphics;

        public IntPtr Hdc
        {
            get { return _hdc; }
        }

        public DcScope(Graphics g)
        {
            _graphics = g;
            _hdc = _graphics.GetHdc();
        }

        public DcScope(IWin32Window win)
        {
            _hdc = NativeMethods.GetDC(win.Handle);
            _win = win;
            if (_hdc == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public Graphics GetGraphics()
        {
            if (_graphics != null)
            {
                return _graphics;
            }
            return Graphics.FromHdc(_hdc);
        }

        protected override void Dispose()
        {
            if (_hdc != IntPtr.Zero)
            {
                if (_win != null)
                {
                    NativeMethods.ReleaseDC(_win.Handle, _hdc); 
                }
                if (_graphics != null)
                {
                    _graphics.ReleaseHdc();
                }
            }
        }
    }
}
