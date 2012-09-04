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
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

namespace MineSweeper
{
    class HallOfFame : Singleton<HallOfFame>
    {
        private bool _dirty;

        private List<Score> _scores;
        public List<Score> Scores
        {
            get { return _scores; }
        }



        public void Init()
        {
            if (!DeserializeScores())
            {
                _scores = new List<Score>();
            }
        }

        private bool DeserializeScores()
        {
            string s = Settings.Default.Scores;
            if (s == null || s.Length == 0)
            {
                return false;
            }
            BinaryFormatter f = CreateFormatter();
            byte[] data;
            if (!SafeGetData(s, out data))
            {
                return false;
            }
            using (MemoryStream ms = new MemoryStream(data))
            {
                try
                {
                    _scores = f.Deserialize(ms) as List<Score>;
                }
                catch (SerializationException)
                {
                    _scores = null;
                }
            }
            return (_scores != null);
        }

        private static bool SafeGetData(string s, out byte[] data)
        {
            try
            {
                data = Convert.FromBase64String(s);
            }
            catch (FormatException)
            {
                data = null;
            }
            return (data != null);
        }

        

        private BinaryFormatter CreateFormatter()
        {
            BinaryFormatter f = new BinaryFormatter();
            f.AssemblyFormat = FormatterAssemblyStyle.Simple;
            f.FilterLevel = TypeFilterLevel.Low;
            f.Context = new StreamingContext(StreamingContextStates.Persistence);
            return f;
        }

        public HallOfFame()
        {
            AppEvents.Win += new EventHandler(AppEvents_Win);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            this.Save();
        }

        private void Save()
        {
            if (_dirty)
            {
                Settings.Default.Scores = SerializeScores();
                Settings.Default.Save();
                _dirty = false;
            }
        }

        private string SerializeScores()
        {
            BinaryFormatter f = CreateFormatter();
            string ret = null;
            using (MemoryStream ms = new MemoryStream())
            {
                f.Serialize(ms, _scores);
                ret = Convert.ToBase64String(ms.ToArray());
            }
            return ret;
        }

        void AppEvents_Win(object sender, EventArgs e)
        {
            _dirty = true;
            (new NewHighScore()).ShowDialog(Program.MainWindow);
            Score s = new Score();
            _scores.Add(s);
            _scores.Sort(delegate(Score s1, Score s2)
            {
                return 0 - s1.CompareTo(s2);
            });
            Trim();
        }

        private void Trim()
        {
            if (_scores.Count > Settings.Default.MaxScores)
            {
                _scores.RemoveAt(_scores.Count - 1);
            }
        }
    }
}
