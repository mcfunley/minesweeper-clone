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

namespace MineSweeper
{
    class NumberLabel : Label
    {
        private int _digits;
        public int Digits
        {
            get { return _digits; }
            set { _digits = value; }
        }


        public NumberLabel()
        {
            this.ForeColor = AppColors.Text;
            this.AutoSize = true;
            this.BackColor = Color.FromArgb(40, ControlPaint.Dark(Color.Navy));
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("Tahoma", 14, FontStyle.Bold);
        }

        protected void Set(TimeSpan val)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<TimeSpan>(Set), val);
                return;
            }
            DateTime t = new DateTime(val.Ticks);
            this.Text = t.ToString("mm:ss");
        }

        protected void Set(int val)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(Set), val);
                return;
            }
            this.Text = LeadZeros(val);
        }

        private string LeadZeros(int val)
        {
            if (val < 0)
            {
                return val.ToString();
            }
            string m = val.ToString();
            while (m.Length < this.Digits)
            {
                m = "0" + m;
            }
            return m;
        }

    }
}
