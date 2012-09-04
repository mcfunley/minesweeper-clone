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
using MineSweeper.Properties;
using System.Windows.Forms;

namespace MineSweeper
{
    class AppEvents
    {
        private static bool _gameInProgress = true;
        public static bool GameInProgress
        {
            get { return _gameInProgress; }
        }

        public static event EventHandler GameOver;
        public static event EventHandler NewGame;
        public static event EventHandler SquareMark;
        public static event EventHandler SquareUnmark;
        public static event EventHandler Win;
        public static event EventHandler Lose;

        internal static void OnLose(EventArgs e)
        {
            OnGameOver(e);
            Raise(Lose, e);
        }

        internal static void OnWin(EventArgs e)
        {
            OnGameOver(e);
            Raise(Win, e);
        }

        internal static void OnGameOver(EventArgs e)
        {
            _gameInProgress = false;
            Raise(GameOver, e);
        }

        internal static void OnNewGame(EventArgs e)
        {
            _gameInProgress = true;
            ResetMarks();
            Raise(NewGame, e);
        }

        public static void ResetMarks()
        {
            AppState.Marks = 0;
            AppState.MarkedMines = 0;
            Raise(SquareUnmark, EventArgs.Empty);
        }

        internal static void OnSquareMark(Square s, EventArgs e)
        {
            AppState.Marks++;
            if (s.Mine)
            {
                AppState.MarkedMines++;
            }
            Raise(s, SquareMark, e);
            if (AppState.MarkedMines == Settings.Default.Mines)
            {
                OnWin(e);
            }
        }

        internal static void OnSquareUnmark(Square s, EventArgs e)
        {
            AppState.Marks--;
            if (s.Mine)
            {
                AppState.MarkedMines--;
            }
            Raise(s, SquareUnmark, e);
        }

        private static void Raise(object sender, EventHandler h, EventArgs e)
        {
            if (h != null)
            {
                h(sender, e);
            }
        }

        private static void Raise(EventHandler h, EventArgs e)
        {
            Raise(null, h, e);
        }
    }
}
