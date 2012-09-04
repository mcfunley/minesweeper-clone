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
using System.ComponentModel;

namespace MineSweeper
{
    class Grid : UserControl
    {
        private bool _firstClick;

        private PropertyChangedEventHandler _propEv; 
        private void SuspendProps()
        {
            Settings.Default.PropertyChanged -= _propEv;
        }
        private void WatchProps()
        {
            Settings.Default.PropertyChanged += _propEv;
        }

        private delegate void ForEachSqFun(int x, int y);

        private Square[,] _squares;
        private Square[] _allSquares;

        private Numbers _numbers;
        public Numbers Numbers
        {
            get { return _numbers; }
        }

        public void Redim(int w, int h, int minecount)
        {
            this.SuspendProps();
            Settings.Default.Width = w;
            Settings.Default.Height = h;
            Settings.Default.Mines = minecount;
            Settings.Default.Save();
            this.WatchProps();
            this.Restore();
        }

        void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Width":
                case "Height":
                case "Mines":
                    this.Restore();
                    break;
                default:
                    break;
            }
        }

        private void Restore()
        {
            int w = Settings.Default.Width;
            int h = Settings.Default.Height;
            _squares = new Square[w, h];
            _allSquares = new Square[w * h];
            this.Size = new Size(w * 24, h * 24);
            AppEvents.OnNewGame(EventArgs.Empty);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Init();
        }

        private void Init()
        {
            this.MakeSquares();
            this.SetNeighbors();
            _firstClick = true;
            this.Invalidate();
        }

        private void SetMines(Square first)
        {
            foreach (Square s in this.ShuffleSquares(Settings.Default.Mines, first))
            {
                s.Mine = true;
            }
        }

        private IEnumerable<Square> ShuffleSquares(int count, Square first)
        {
            List<Square> sq = new List<Square>(_allSquares);
            int c = 0; 
            while (c++ < count)
            {
                int i = -1;
                while (true)
                {
                    i = Program.Rand.Next(sq.Count - 1);
                    if (sq[i] != first)
                    {
                        break;
                    }
                }
                yield return sq[i];
                sq.RemoveAt(i);
            }
        }

        private void MakeSquares()
        {
            int i = 0;
            ForEachSq(delegate(int x, int y)
            {
                Square sq = new Square(this);
                _allSquares[i++] = sq;
                sq.Location = ChildLocation(x, y);
                _squares[x, y] = sq;
            });
        }

        
        private void SetNeighbors()
        {
            ForEachSq(delegate(int x, int y)
            {
                Square s = SqNum(x, y);
                int ly = Settings.Default.Height - 1;
                int lx = Settings.Default.Width - 1;
                List<Square> l = s.Neighbors;
                if (x > 0)
                {
                    l.Add(SqNum(x - 1, y));
                    if (y > 0)
                    {
                        l.Add(SqNum(x - 1, y - 1));
                    }
                    if (y < ly)
                    {
                        l.Add(SqNum(x - 1, y + 1));
                    }
                }
                if (x < lx)
                {
                    l.Add(SqNum(x + 1, y));
                    if (y > 0)
                    {
                        l.Add(SqNum(x + 1, y - 1));
                    }
                    if (y < ly)
                    {
                        l.Add(SqNum(x + 1, y + 1));
                    }
                }
                if (y > 0)
                {
                    l.Add(SqNum(x, y - 1));
                }
                if (y < ly)
                {
                    l.Add(SqNum(x, y + 1));
                }
            });
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (AppEvents.GameInProgress)
            {
                EnsureTimer();
                Point p = PointToClient(Control.MousePosition);
                Square s = SqAt(p);
                HandleFirstClick(s);
                s.HandleDoubleClick();
            }
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (AppEvents.GameInProgress)
            {
                EnsureTimer();
                Square s = SqAt(e.Location);
                HandleFirstClick(s);
                s.HandleClick(e); 
            }
        }

        private void HandleFirstClick(Square s)
        {
            if (_firstClick)
            {
                this.SetMines(s);
                _firstClick = false;
            }
        }

        private static void EnsureTimer()
        {
            if (!GameTimer.Default.IsRunning)
            {
                GameTimer.Default.Start();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ForEachSq(delegate(Square s)
            {
                if (e.ClipRectangle.IntersectsWith(s.ClientRect))
                {
                    s.Render(e.Graphics);
                }
            });
        }

        public Square SqAt(Point p)
        {
            return SqAt(p.X, p.Y);
        }

        public Square SqAt(int x, int y)
        {
            return _squares[x / 24, y / 24];
        }
        
        public Square SqNum(int x, int y)
        {
            return _squares[x, y];
        }

        private void ForEachSq(ForEachSqFun f)
        {
            for (int x = 0; x < Settings.Default.Width; x++)
            {
                for (int y = 0; y < Settings.Default.Height; y++)
                {
                    f(x, y);
                }
            }
        }

        private void ForEachSq(Action<Square> f)
        {
            ForEachSq(delegate(int x, int y)
            {
                f(_squares[x, y]);
            });
        }

        private Square _underCursor;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Square s = this.SqAt(e.Location);
            if (s != _underCursor)
            {
                if (_underCursor != null)
                {
                    _underCursor.HasMouse = false;
                }
                _underCursor = s;
                _underCursor.HasMouse = true;
            }
        }

        private Point ChildLocation(int x, int y)
        {
            return new Point(x * 24, y * 24);
        }

        public Grid()
        {
            this.BackColor = Color.FromArgb(0, Color.White);
             _numbers = new Numbers(this);

             this.Restore();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.UserPaint | 
                ControlStyles.OptimizedDoubleBuffer, 
                true);

            _propEv = new PropertyChangedEventHandler(PropertyChanged);
            AppEvents.NewGame += new EventHandler(AppEvents_NewGame);
            this.WatchProps();
        }

        void AppEvents_NewGame(object sender, EventArgs e)
        {
            this.Init();
        }


    }
}
