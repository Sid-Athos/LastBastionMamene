using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Diagnostics;

namespace LastBastion
{
    class Save
    {
        Game _game;
        string _name;

        public Save(Game game,string name)
        {
            _game = game;
            _name = name;
            //CreateTXT();
            Test();
        }
        public void CreateTXT()
        {
            StreamWriter writer = new StreamWriter(@"C:\Users\Rosiek\Desktop\LastBastion\Save\" + _name);
            foreach (var item in _game.GetGrid)
            {
                writer.Write("" + item.Value.StringVec + "" + item.Value.GetName);
            }
        }
        public void Test()
        {
            //System.Diagnostics.Process.Start("https://www.google.com");
            var pInfo = new ProcessStartInfo()
            {
                FileName = "https://rule34.paheal.net/post/list/Geralt_of_Rivia/1",
                UseShellExecute = true
            };
            Process.Start(pInfo);
        }
    }
}
