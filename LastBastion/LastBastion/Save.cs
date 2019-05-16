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

        public Save(Game game, string name)
        {
            _game = game;
            _name = name;
            //Test();
        }
        public void CreateTXT()
        {
            StreamWriter writer = new StreamWriter(@"C:\Users\Rosiek\Documents\C_Sharp\LastBastionMamene\LastBastion\Save\" + _name);
            writer.WriteLine("<Ressources>");
            foreach (var item in _game.GetGrid)
            {
                //writer.Write("" + item.Value.StringVec + "" + item.Value.GetName);
                if (item.Value.GetName == "Stone" || item.Value.GetName == "Bush" || item.Value.GetName == "Wood")
                {
                    writer.WriteLine("%%" + item.Value.GetVec2I + "$$" + item.Value.GetName + "%%");
                }
            }
            writer.WriteLine("<Building>");
            foreach (var item in _game.GetGrid)
            {
                if (item.Value.Building != null)
                {
                    writer.WriteLine("**" + item.Value.GetName + "$$" + item.Value.GetVec2I + "$$" + item.Value.Building.Life + "$$" + item.Value.Building.MaxLife + "$$" + item.Value.Building.Armor + "$$" + item.Value.Building.Rank + "%%");
                }
            }
            writer.WriteLine("<Setup>");
            writer.WriteLine("%%" + _game.GetTimer + "$$" + _game.Cycle + "%%");
            writer.Close();
            Console.Write("Done");
        }
        public void Test()
        {
            //System.Diagnostics.Process.Start("https://www.google.com");
            var pInfo = new ProcessStartInfo()
            {
                FileName = "https://hugelol.com/lol/138686",
                UseShellExecute = true
            };
            Process.Start(pInfo);
        }
    }
}