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
    public partial class Options : Form
    {
        private bool _dirty;
        private bool _save;

        private void SetState(bool dirty, bool save)
        {
            _dirty |= dirty;
            _save |= save;
        }

        public Options()
        {
            InitializeComponent();
            this.Icon = Resources.Bomb;
            _sounds.Checked = Settings.Default.PlaySound;
            _width.Value = Settings.Default.Width;
            _height.Value = Settings.Default.Height;
            _mines.Value = Settings.Default.Mines;
            _dirty = false;
            _save = false;
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void _ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _mines_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.Mines = (int)_mines.Value;
            SetState(true, true);
        }

        private void _height_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.Height = (int)_height.Value;
            SetState(true, true);
        }

        private void _sounds_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.PlaySound = _sounds.Checked;
            SetState(false, true);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (_save)
            {
                Settings.Default.Save();
            }
            if (_dirty)
            {
                AppEvents.OnNewGame(EventArgs.Empty);
            }
        }

        private void _width_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.Width = (int)_width.Value;
            SetState(true, true);
        }

        private void _clearhof_Click(object sender, EventArgs e)
        {
            HallOfFame.Default.Scores.Clear();
            SetState(false, true);
        }

       

    }
}