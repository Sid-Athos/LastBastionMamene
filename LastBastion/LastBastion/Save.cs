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
            CreateTXT();
        }
        public void CreateTXT()
        {
            StreamWriter writer = new StreamWriter(@"C:\Users\Rosiek\Desktop\LastBastion\Save\" + _name);
            foreach (var item in _game.GetGrid)
            {
                writer.Write("" + item.Value.StringVec + "" + item.Value.GetName);
            }
        }
    }
}
