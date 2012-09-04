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
using System.Media;
using System.Collections;

namespace MineSweeper
{

    class Square
    {
        private static class Icons
        {
            public static Icon Bomb = Resources.Bomb;
            public static Icon Clear = Resources.Clear;
            public static Icon RedBomb = Resources.RedBomb;
            public static Icon Wrong = Resources.Wrong;


            private static Icon _Empty = Resources.Empty;
            private static Icon _EmptyHi = Resources.Highlight;
            private static Icon _Marked = Resources.Marked;
            private static Icon _MarkedHi = Resources.MarkedHi;
            private static Icon _Maybe = Resources.Maybe;
            private static Icon _MaybeHi = Resources.MaybeHi;


            public static Icon Empty(Square s)
            {
                return s.HasMouse ? _EmptyHi : _Empty;
            }

            public static Icon Marked(Square s)
            {
                return s.HasMouse ? _MarkedHi : _Marked;
            }

            public static Icon Maybe(Square s)
            {
                return s.HasMouse ? _MaybeHi : _Maybe;
            }
        }

        public event EventHandler Mark;
        public event EventHandler Unmark;

        protected virtual void OnMark(EventArgs e)
        {
            this.Raise(this.Mark, e);
            AppEvents.OnSquareMark(this, e);
        }

        protected virtual void OnUnmark(EventArgs e)
        {
            this.Raise(this.Unmark, e);
            AppEvents.OnSquareUnmark(this, e);
        }

        private bool _causedEndGame;
        public event EventHandler Kaboom;

        protected virtual void OnKaboom(EventArgs e)
        {
            _causedEndGame = true;
            this.Raise(this.Kaboom, e);
        }

        private void Raise(EventHandler h, EventArgs e)
        {
            if (h != null)
            {
                h(this, e);
            }
        }

        private bool _hasMouse;
        public bool HasMouse
        {
            get { return _hasMouse; }
            set { _hasMouse = value; this.Invalidate();  }
        }


        public bool IncorrectMark
        {
            get { return (!this.Mine && this.MarkState == MarkState.Marked); }
        }


        private Grid _parent;
        public Grid Parent
        {
            get { return _parent; }
        }


        private Point _location;
        public Point Location
        {
            get { return _location; }
            set { SetLoc(value); }
        }

        private void SetLoc(Point p)
        {
            _location = p;
            _cr = new Rectangle(p, new Size(24, 24));
        }

        private MarkState _markState;
        public MarkState MarkState
        {
            get { return _markState; }
        }

        private bool _revealed;
        public bool Revealed
        {
            get { return _revealed; }
        }


        private Rectangle _cr;
        public Rectangle ClientRect
        {
            get { return _cr; }
        }

        private bool _mine;
        public bool Mine
        {
            get { return _mine; }
            set { _mine = value; }
        }


        private List<Square> _neighbors;
        public List<Square> Neighbors
        {
            get { return _neighbors; }
        }



        public void Render(Graphics g)
        {
            if (!this.Revealed || ShouldRenderMark())
            {
                RenderHidden(g);
            }
            else
            {
                RenderVisible(g);
            }
        }

        private void RenderVisible(Graphics g)
        {
            if (this.Mine)
            {
                Render(g, _causedEndGame ? Icons.RedBomb : Icons.Bomb);
            }
            else
            {
                if (this.MarkState != MarkState.Marked)
                {
                    Render(g, Icons.Clear);
                    RenderNum(g); 
                }
                else
                {
                    Render(g, Icons.Wrong);
                }
            }
        }

        
        private bool ShouldRenderMark()
        {
            return (this.Mine && this.MarkState == MarkState.Marked);
        }

        private void RenderHidden(Graphics g)
        {
            switch (this.MarkState)
            {
                case MarkState.Empty:
                    Render(g, Icons.Empty(this));
                    break;
                case MarkState.Marked:
                    Render(g, Icons.Marked(this));
                    break;
                case MarkState.Maybe:
                    Render(g, Icons.Maybe(this));
                    break;
            }
        }

        private void RenderNum(Graphics g)
        {
            if (this.AdjacentMines > 0)
            {
                _parent.Numbers.Draw(g, this.ClientRect, this.AdjacentMines);
            }
        }

        public void HandleClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !this.Revealed)
            {
                RotateMark();
            }
            if (e.Button == MouseButtons.Left)
            {
                this.ClearMark();
                if (!this.Mine)
                {
                    this.Reveal();
                }
                else
                {
                    this.OnKaboom(EventArgs.Empty);
                    AppEvents.OnLose(EventArgs.Empty);
                }
            }
        }

        public void ClearMark()
        {
            if (_markState == MarkState.Marked)
            {
                _markState = MarkState.Empty;
                this.OnUnmark(EventArgs.Empty); 
            }
        }

        private void RotateMark()
        {
            _markState = NextMarkState();
            _markState = (MarkState)((int)_markState % ((int)MarkState.Last + 1));
            if (_markState == MarkState.Marked)
            {
                this.OnMark(EventArgs.Empty);
            }
            if (_markState == MarkState.AfterMarked)
            {
                this.OnUnmark(EventArgs.Empty);
            }
            this.Invalidate();
        }

        private MarkState NextMarkState()
        {
            return (MarkState)((int)_markState + 1);
        }

        public void RenderContents()
        {
            _revealed = true;
            this.Invalidate();
        }

        public void Reveal()
        {
            this.RenderContents();
            this.Cascade();
        }

        public void Cascade()
        {
            if (this.AdjacentMines == 0)
            {
                Neighbors.ForEach(delegate(Square sq)
                {
                    if (!sq.Revealed)
                    {
                        sq.Reveal();
                    }
                });
            }
        }

        private bool _calcedAdj;
        private int _adjacentMines;
        public int AdjacentMines
        {
            get
            {
                if (!_calcedAdj)
                {
                    for (int i = 0; i < Neighbors.Count; i++)
                    {
                        if (Neighbors[i].Mine)
                        {
                            _adjacentMines++;
                        }
                    }
                    _calcedAdj = true;
                }
                return _adjacentMines;
            }
        }

        private void Invalidate()
        {
            _parent.Invalidate(this.ClientRect);
        }

        private void Render(Graphics g, Icon i)
        {
            g.DrawIcon(i, _location.X, _location.Y);
            //AlphaCache.Render(g, i, _location);
        }


        public Square(Grid parent)
        {
            _neighbors = new List<Square>();
            _parent = parent;
            AppEvents.GameOver += new EventHandler(AppEvents_GameOver);
        }

        void AppEvents_GameOver(object sender, EventArgs e)
        {
            if (this.Mine || this.IncorrectMark)
            {
                this.RenderContents(); 
            }
        }

        internal void HandleDoubleClick()
        {
            if (this.Revealed)
            {
                if (CountOf<Square>(CorrectMarkedNeighbors()) == this.AdjacentMines)
                {
                    foreach (Square s in UnmarkedNeighbors())
                    {
                        s.Reveal();
                    }
                }
            }
        }

        private IEnumerable<Square> FilterNeighbors(Predicate<Square> pred)
        {
            return Algorithm.Filter<Square>(this.Neighbors, pred);
        }

        private static int CountOf<T>(IEnumerable<T> en)
        {
            int i = 0;
            foreach (T t in en)
            {
                i++;
            }
            return i;
        }

        private IEnumerable<Square> CorrectMarkedNeighbors()
        {
            return Algorithm.Filter<Square>(MarkedNeighbors(),
                delegate(Square s)
                {
                    return !s.IncorrectMark;
                });
        }

        private IEnumerable<Square> MarkedNeighbors()
        {
            return FilterNeighbors(delegate(Square s)
            {
                return (s.MarkState == MarkState.Marked);
            });
        }

        private IEnumerable<Square> UnmarkedNeighbors()
        {
            return FilterNeighbors(delegate(Square s)
            {
                return (!s.Revealed && s.MarkState != MarkState.Marked);
            });
        }

    }
}
