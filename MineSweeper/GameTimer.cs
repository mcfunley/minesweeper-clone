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
using System.Timers;

namespace MineSweeper
{
    class GameTimer : Singleton<GameTimer>
    {
        private Timer _val;

        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
        }


        private int _ticks;
        public int Ticks
        {
            get { return _ticks; }
        }
        

        public event EventHandler Tick;
        protected void OnTick(EventArgs e)
        {
            _ticks++;
            EventHandler h = Tick;
            if (h != null)
            {
                h(this, e);
            }
        }
        

        public void Reset()
        {
            _val.Stop();
            _ticks = -1;    // ontick will set it to 0
            _isRunning = false;
            this.OnTick(EventArgs.Empty);
        }

        public void Start()
        {
            this.Reset();
            _isRunning = true;
            _val.Start();
        }

        public GameTimer()
        {
            _val = new Timer(1000.0);
            AppEvents.GameOver += new EventHandler(AppEvents_GameOver);
            AppEvents.NewGame += new EventHandler(AppEvents_NewGame);
            _val.Elapsed += new ElapsedEventHandler(_val_Elapsed);           
        }

        void AppEvents_NewGame(object sender, EventArgs e)
        {
            this.Reset();
        }

        void AppEvents_GameOver(object sender, EventArgs e)
        {
            _isRunning = false;
            _val.Stop();
        }

        void _val_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.OnTick(e);
        }

    }
}
