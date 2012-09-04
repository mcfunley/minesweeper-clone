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
using System.Xml.Serialization;
using MineSweeper.Properties;
using System.Reflection;

namespace MineSweeper
{

    [Serializable]
    public class Score : IComparable, IComparable<Score>
    {
        private TimeSpan _time;

        public TimeSpan Time
        {
            get { return _time; }
            set { _time = value; }
        }

        private int _mines;

        public int Mines
        {
            get { return _mines; }
            set { _mines = value; }
        }

        private int _squares;

        public int Squares
        {
            get { return _squares; }
            set { _squares = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public Score()
        {
            _mines = Settings.Default.Mines;
            _name = Settings.Default.LastWinner;
            _time = TimeSpan.FromSeconds(GameTimer.Default.Ticks);
            _squares = (Settings.Default.Height * Settings.Default.Width);
        }

        public static string GetTitles()
        {
            return string.Format("{0,-15}{1,-10}{2,-10}{3,8}", "Name", "Squares", "Mines", "Time");
        }

        public override string ToString()
        {
            return string.Format("{0,-15}{1,-10}{2,-10}{3,5:mm:ss}", 
                _name, _squares, _mines, new DateTime(_time.Ticks));
        }


        int IComparable.CompareTo(object obj)
        {
            return CompareTo(obj as Score);   
        }


        public int CompareTo(Score other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            // More mines/sq = better score
            int x = MinesPerSquare().CompareTo(other.MinesPerSquare());
            if (x != 0)
            {
                return x;
            }
            // more squares = better score
            x = _squares.CompareTo(other.Squares);
            if (x != 0)
            {
                return x;
            }
            // Lower time = better score
            return other.Time.CompareTo(_time);
        }

        public double MinesPerSquare()
        {
            return (double)_mines / (double)_squares;
        }

    }
}
