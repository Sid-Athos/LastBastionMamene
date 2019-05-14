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
            StreamWriter writer = new StreamWriter(@"C: \Users\Rosiek\Documents\C_Sharp\LastBastionMamene\LastBastion\Save\Ressources");
            foreach (var item in _game.GetGrid)
            {
                //writer.Write("" + item.Value.StringVec + "" + item.Value.GetName);
                if (item.Value.GetName == "Stone" || item.Value.GetName == "Bush" || item.Value.GetName == "Wood")
                {
                    writer.WriteLine("" + item.Value.GetVec2I + "$$" + item.Value.GetName + "%%");
                }
            }
            writer = new StreamWriter(@"C: \Users\Rosiek\Documents\C_Sharp\LastBastionMamene\LastBastion\Save\Building");
            foreach (var item in _game.GetGrid)
            {
                if (item.Value.GetName == "House" || item.Value.GetName == "Tower" || item.Value.GetName == "Mine" || item.Value.GetName == "Sawmill" || item.Value.GetName == "Farm")
                {
                    writer.WriteLine("" + item.Value.GetName + "$$" + item.Value.GetVec2I + "$$" + item.Value.Building.Life + "$$" + item.Value.Building.MaxLife + "$$" + item.Value.Building.Armor + "%%");
                }
            }
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
