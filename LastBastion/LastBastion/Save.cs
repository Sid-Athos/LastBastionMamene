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
using SFML.System;

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
            //Test();
            //AddRessToGrid("%%[Vector2i] X(17) Y(-1)$$Stone%%");
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
                    writer.WriteLine("$$" + item.Value.GetVec2I + "$$" + item.Value.GetName + "%%");
                }
            }
            writer.WriteLine("<Building>");
            foreach (var item in _game.GetGrid)
            {
                if (item.Value.Building != null)
                {
                    writer.WriteLine("$$" + item.Value.GetVec2I + "$$" + item.Value.Building.Life + "$$" + item.Value.Building.MaxLife + "$$" + item.Value.Building.Armor + "$$" + item.Value.Building.Rank + "$$" + item.Value.GetName + "%%");
                }
            }
            writer.WriteLine("<Setup>");
            writer.WriteLine("$$" + _game.GetTimer + "$$" + _game.Cycle + "$$" + _game.Map.GetVillage.FoodStock + "$$" + _game.Map.GetVillage.StoneStock + "$$" + _game.Map.GetVillage.WoodStock + "%%");
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
        
        public void LeauAdd()
        {
            ZuperCleanMap();
            _game.Map.GetVillage.SetCastle();
            String[] lines = File.ReadAllLines(@"C:\Users\Rosiek\Documents\C_Sharp\LastBastionMamene\LastBastion\Save\" + _name);
            string part = "";
            foreach (var item in lines)
            {
                if (item  == "<Ressources>")
                {
                    part = "<Ressources>";
                }
                if (part == "<Ressources>")
                {
                    AddRessToGrid(item);
                }
                if (item == "<Building>")
                {
                    part = "<Building>";
                }
                if (part == "<Building>")
                {
                    AddBuildToGrid(item);
                }
                if (item == "<Setup>")
                {
                    part = "<Setup>";
                }
            }
        }
        public void ZuperCleanMap()
        {
            foreach (var item in _game.GetGrid)
            {
                item.Value.Building = null;
                item.Value.SetName = "Empty";
                item.Value.IsReveal = false;
            }
        }
        public void AddBuildToGrid(string line)
        {
            //$$House$$[Vector2i] X(-2) Y(2)$$100$$100$$10$$1%%
            int len = line.Length;
            string t1 = "";
            string x = "";
            string y = "";
            string life = "";
            string maxLife = "";
            string armor = "";
            string rank = "";
            for (int i = 0; i < len; i++)
            {
                if (t1 == "$$[Vector2i] X(")
                {
                    if (line[i] == '-' ||
                        line[i] == '0' ||
                        line[i] == '1' ||
                        line[i] == '2' ||
                        line[i] == '3' ||
                        line[i] == '4' ||
                        line[i] == '5' ||
                        line[i] == '6' ||
                        line[i] == '7' ||
                        line[i] == '8' ||
                        line[i] == '9')
                    {
                        x += line[i];
                    }
                    else
                    {
                        t1 += line[i];
                    }
                }
                else if (t1 == "$$[Vector2i] X() Y(")
                {
                    if (line[i] == '-' ||
                        line[i] == '0' ||
                        line[i] == '1' ||
                        line[i] == '2' ||
                        line[i] == '3' ||
                        line[i] == '4' ||
                        line[i] == '5' ||
                        line[i] == '6' ||
                        line[i] == '7' ||
                        line[i] == '8' ||
                        line[i] == '9')
                    {
                        y += line[i];
                    }
                    else
                    {
                        t1 += line[i];
                    }
                }
                else if (t1 == "$$[Vector2i] X() Y()$$")
                {
                    if (line[i] == '-' ||
                        line[i] == '0' ||
                        line[i] == '1' ||
                        line[i] == '2' ||
                        line[i] == '3' ||
                        line[i] == '4' ||
                        line[i] == '5' ||
                        line[i] == '6' ||
                        line[i] == '7' ||
                        line[i] == '8' ||
                        line[i] == '9')
                    {
                        life += line[i];
                    }
                    else
                    {
                        t1 += line[i];
                    }

                }
                else if (t1 == "$$[Vector2i] X() Y()$$$$")
                {
                    if (line[i] == '-' ||
                        line[i] == '0' ||
                        line[i] == '1' ||
                        line[i] == '2' ||
                        line[i] == '3' ||
                        line[i] == '4' ||
                        line[i] == '5' ||
                        line[i] == '6' ||
                        line[i] == '7' ||
                        line[i] == '8' ||
                        line[i] == '9')
                    {
                        maxLife += line[i];
                    }
                    else
                    {
                        t1 += line[i];
                    }
                }
                else if (t1 == "$$[Vector2i] X() Y()$$$$$$")
                {
                    if (line[i] == '-' ||
                        line[i] == '0' ||
                        line[i] == '1' ||
                        line[i] == '2' ||
                        line[i] == '3' ||
                        line[i] == '4' ||
                        line[i] == '5' ||
                        line[i] == '6' ||
                        line[i] == '7' ||
                        line[i] == '8' ||
                        line[i] == '9')
                    {
                        armor += line[i];
                    }
                    else
                    {
                        t1 += line[i];
                    }
                }
                else if (t1 == "$$[Vector2i] X() Y()$$$$$$$$")
                {
                    if (line[i] == '-' ||
                        line[i] == '0' ||
                        line[i] == '1' ||
                        line[i] == '2' ||
                        line[i] == '3' ||
                        line[i] == '4' ||
                        line[i] == '5' ||
                        line[i] == '6' ||
                        line[i] == '7' ||
                        line[i] == '8' ||
                        line[i] == '9')
                    {
                        rank += line[i];
                    }
                    else
                    {
                        t1 += line[i];
                    }
                }
                else
                {
                    t1 += line[i];
                }
            }
            int X = StringToInt(x);
            int Y = StringToInt(y);
            /*
            uint Life = StringToUInt(life);
            uint MaxLife = StringToUInt(maxLife);
            uint Armor = StringToUInt(armor);
            uint Rank = StringToUInt(rank);
            */
            Console.WriteLine(new Vector2i(X, Y));
            if (_game.GetGrid.ContainsKey(new Vector2i(X, Y)))
            {
                if (line.Contains("Mine"))
                {
                    _game.GetGrid[new Vector2i(X, Y)].SetBuilding("Mine");
                    //_game.GetGrid[new Vector2i(X, Y)].Building = new Mine(X, Y, Life, MaxLife, Armor, Rank);
                }
                if (line.Contains("Farm"))
                {
                    _game.GetGrid[new Vector2i(X, Y)].SetBuilding("Farm");
                    //_game.GetGrid[new Vector2i(X, Y)].Building = new Farm(X, Y, Life, MaxLife, Armor, Rank);
                }
                if (line.Contains("Sawmill"))
                {
                    _game.GetGrid[new Vector2i(X, Y)].SetBuilding("Sawmill");
                    //_game.GetGrid[new Vector2i(X, Y)].Building = new Sawmill(X, Y, Life, MaxLife, Armor, Rank);
                }
                if (line.Contains("House"))
                {
                    _game.GetGrid[new Vector2i(X, Y)].SetBuilding("House");
                    //_game.GetGrid[new Vector2i(X, Y)].Building = new House(X, Y, Life, MaxLife, Armor, Rank, 5);
                }
                if (line.Contains("Tower"))
                {
                    _game.GetGrid[new Vector2i(X, Y)].SetBuilding("Tower");
                    //_game.GetGrid[new Vector2i(X, Y)].Building = new Tower(X,Y,Life,MaxLife,10,Armor,1,Rank);
                }
                if (line.Contains("Wall"))
                {
                    _game.GetGrid[new Vector2i(X, Y)].SetBuilding("Wall");
                    //_game.GetGrid[new Vector2i(X, Y)].Building = new Wall(X, Y, Life, MaxLife, Armor, Rank);
                }
            }
        }
        public void AddRessToGrid(string line)
        {
            //$$[Vector2i] X(-25) Y(-12)$$Bush%%
            int len = line.Length;
            string t1 = "";
            string t2 = "";
            string x = "";
            string y = "";
            for (int i = 0; i < len; i++)
            {
                if (t1 == "$$[Vector2i] X(" )
                {
                    if (line[i] == '-' || 
                        line[i] == '0' || 
                        line[i] == '1' || 
                        line[i] == '2' || 
                        line[i] == '3' || 
                        line[i] == '4' || 
                        line[i] == '5' || 
                        line[i] == '6' || 
                        line[i] == '7' ||
                        line[i] == '8' || 
                        line[i] == '9' )
                    {
                        x += line[i];
                    }
                    else
                    {
                        t1 += line[i];
                    }
                }
                else if(t1 == "$$[Vector2i] X() Y(")
                {
                    if (line[i] == '-' ||
                        line[i] == '0' ||
                        line[i] == '1' ||
                        line[i] == '2' ||
                        line[i] == '3' ||
                        line[i] == '4' ||
                        line[i] == '5' ||
                        line[i] == '6' ||
                        line[i] == '7' ||
                        line[i] == '8' ||
                        line[i] == '9')
                    {
                        y += line[i];
                    }
                    else
                    {
                        t1 += line[i];
                    }
                }
                else
                {
                    t1 += line[i];
                }
            }
            int X = StringToInt(x);
            int Y = StringToInt(y);
            
            if (_game.GetGrid.ContainsKey(new Vector2i(X,Y)))
            {
                if (line.Contains("Stone"))
                {
                    _game.GetGrid[new Vector2i(X, Y)].SetName = "Stone";
                }
                if (line.Contains("Bush"))
                {
                    _game.GetGrid[new Vector2i(X, Y)].SetName = "Bush";
                }
                if (line.Contains("Wood"))
                {
                    _game.GetGrid[new Vector2i(X, Y)].SetName = "Wood";
                }
            }
        }
        public int StringToInt(string intagueur)
        {
            int len = intagueur.Length;
            int x = 0;
            int s = 1;
            int k = 0;
            if (len > 0)
            {
                if (intagueur[0] == '-')
                {
                    s = -1;
                    k++;
                }
            }
            for (int i = k; i < len; i++)
            {
                if (x == 0)
                {
                    x += CharToInt(intagueur[i]);
                }
                else
                {
                    x = x * 10 + CharToInt(intagueur[i]);
                }
            }
            return s * x;
        }
        /*
        public uint StringToUInt(string intagueur)
        {
            int len = intagueur.Length;
            uint x = 0;
            for (int i = 0; i < len; i++)
            {
                if (x == 0)
                {
                    x += CharToInt(intagueur[i]);
                }
                else
                {
                    x = x * 10 + CharToInt(intagueur[i]);
                }
            }
            return x;
        }
        */
        public int CharToInt(char n)
        {
            switch ((int)n)
            {
                case 48:
                    return 0;
                case 49:
                    return 1;
                case 50:
                    return 2;
                case 51:
                    return 3;
                case 52:
                    return 4;
                case 53:
                    return 5;
                case 54:
                    return 6;
                case 55:
                    return 7;
                case 56:
                    return 8;
                case 57:
                    return 9;
                default:
                    return 0;
            }
        }
        
    }
}
