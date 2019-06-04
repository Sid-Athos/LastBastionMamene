using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace LastBastion
{
    public class Village
    {
        Map _map;
        Building _castle;
        List<Hut> _nearby;
        SpellBook _book = new SpellBook();
<<<<<<< HEAD
=======
        Bestiary _beasts = new Bestiary();

>>>>>>> classes
        string _buildingName; 
        int _area;
        uint _foodStock;
        uint _stoneStock;
        uint _woodStock;
        uint _villagerStock;
        Dictionary<string, Dictionary<string, string>> _prices;

        internal SpellBook Spells => _book;
        internal Bestiary Beasts => _beasts;

        public Village(Map map)
        {
            _map = map; 
            _nearby = new List<Hut>();
            _buildingName = "Empty";
            _area = 3;
            _woodStock = 150;
            _foodStock = 150;
            _stoneStock = 150;
            _villagerStock = 5;
            SetCastle();
            SetNearby();
            _prices = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> _towerCosts = new Dictionary<string, string>();
            _towerCosts.Add("Wood", "10");
            _towerCosts.Add("Stones", "60");
            _towerCosts.Add("Food", "0");
            _towerCosts.Add("Villager"," 2");
            _towerCosts.Add("Description", "Tour de défense, livrée avec deux archers.");
            _prices.Add("Tower", _towerCosts);
            Dictionary<string, string> _thunderCosts = new Dictionary<string, string>();
            _thunderCosts.Add("Wood", "250");
            _thunderCosts.Add("Stones", "360");
            _thunderCosts.Add("Food", "30");
            _thunderCosts.Add("Villager", " 2");
            _thunderCosts.Add("Description", "Tour de défense, livrée avec 4 archers. Peut paralyser vos ennemis pendant 10 secondes.");
            _prices.Add("ThunderTower", _thunderCosts);
            Dictionary<string, string> _cataCosts = new Dictionary<string, string>();
            _cataCosts.Add("Wood", "150");
            _cataCosts.Add("Stones", "500");
            _cataCosts.Add("Food", "30");
            _cataCosts.Add("Villager", " 2");
            _cataCosts.Add("Description", "Tour de défense, livrée avec 4 archers. Équipée d'une catapulte pouvant écraser vos ennemis.");
            _prices.Add("Catapult Tower", _cataCosts);
            Dictionary<string, string> _houseCosts = new Dictionary<string, string>();
            _houseCosts.Add("Wood", "10");
            _houseCosts.Add("Stones", "60");
            _houseCosts.Add("Food", "0");
            _houseCosts.Add("Villager", "2");
            _prices.Add("House", _towerCosts);
            Dictionary<string, string> _farmCosts = new Dictionary<string, string>();
            _farmCosts.Add("Wood", "40");
            _farmCosts.Add("Stones", "10");
            _farmCosts.Add("Food", "0");
            _farmCosts.Add("Villager", "2");
            _farmCosts.Add("Description", "Permet de produire de la nourriture.");
            _prices.Add("Farm", _farmCosts);
            Dictionary<string, string> _wallCosts = new Dictionary<string, string>();
            _wallCosts.Add("Wood", "10");
            _wallCosts.Add("Stones", "20");
            _wallCosts.Add("Food", "0");
            _wallCosts.Add("Villager", "0");
            _wallCosts.Add("Description", "Murs indestructibles.");
            _prices.Add("Wall", _wallCosts);
            Dictionary<string, string> _mineCosts = new Dictionary<string, string>();
            _mineCosts.Add("Wood", "40");
            _mineCosts.Add("Stones", "20");
            _mineCosts.Add("Food", "0");
            _mineCosts.Add("Villager", "2");
            _mineCosts.Add("Description", "Permet de produire des pierres pour construire.");
            _prices.Add("Mine", _mineCosts);
            Dictionary<string, string> _mineCosts2 = new Dictionary<string, string>();
            _mineCosts2.Add("Wood", "40");
            _mineCosts2.Add("Stones", "20");
            _mineCosts2.Add("Food", "0");
            _mineCosts2.Add("Villager", "2");
            _mineCosts2.Add("Description", "Permet de produire des pierres pour construire.");
            _prices.Add("Mine Lv2", _mineCosts2);
            Dictionary<string, string> _mineCosts3 = new Dictionary<string, string>();
            _mineCosts3.Add("Wood", "40");
            _mineCosts3.Add("Stones", "20");
            _mineCosts3.Add("Food", "0");
            _mineCosts3.Add("Villager", "2");
            _mineCosts3.Add("Description", "Permet de produire des pierres pour construire.");
            _prices.Add("Mine Lv3", _mineCosts3);
            Dictionary<string, string> _millCosts = new Dictionary<string, string>();
            _millCosts.Add("Wood", "50");
            _millCosts.Add("Stones", "10");
            _millCosts.Add("Food", "0");
            _millCosts.Add("Villager", "2");
            _millCosts.Add("Description", "Permet de produire du bois pour construire.");
            _prices.Add("Sawmill", _millCosts);
            Dictionary<string, string> _mill2Costs = new Dictionary<string, string>();
            _mill2Costs.Add("Wood", "250");
            _mill2Costs.Add("Stones", "310");
            _mill2Costs.Add("Food", "0");
            _mill2Costs.Add("Villager", "5");
            _mill2Costs.Add("Description", "Permet de produire du bois pour construire.");
            _prices.Add("Sawmill Lv2", _mill2Costs);
            Dictionary<string, string> _mill3Costs = new Dictionary<string, string>();
            _mill3Costs.Add("Wood", "950");
            _mill3Costs.Add("Stones", "410");
            _mill3Costs.Add("Food", "0");
            _mill3Costs.Add("Villager", "15");
            _mill3Costs.Add("Description", "Permet de produire du bois pour construire.");
            _prices.Add("Sawmill Lv3", _mill3Costs);
            Dictionary<string, string> _hLv2 = new Dictionary<string, string>();
            _hLv2.Add("Wood", "150");
            _hLv2.Add("Stones", "210");
            _hLv2.Add("Food", "5");
            _hLv2.Add("Villager", "0");
            _hLv2.Add("Description", "Une maison rudimentaire mais confortable.");
            _prices.Add("House Lv2", _hLv2);
            Dictionary<string, string> _hLv3 = new Dictionary<string, string>();
            _hLv3.Add("Wood", "550");
            _hLv3.Add("Stones", "910");
            _hLv3.Add("Food", "15");
            _hLv3.Add("Villager", "0");
            _hLv3.Add("Description", "Pavillon avec vue sur les gobelins");
            _prices.Add("House Lv3", _hLv3);
        }

        public Dictionary<string,Dictionary<string,string>> Costs => _prices;

        // For development purpose only
        public void IncreaseRessources()
        {
            _woodStock += 5000;
            _foodStock += 5000;
            _stoneStock += 5000;
            _villagerStock += 5000;
        }

        public SpellBook Sb => _book;

        public void RessourceProd()
        {
            foreach(var item in _map.GetGame.GetGrid )
            {
                if(item.Value.GetName == "Farm")
                {
                    _foodStock += (5 * item.Value.Building.Rank);
                    if (_foodStock > 9999)
                    {
                        _foodStock = 9999;
                    }
                }
                if (item.Value.GetName == "Sawmill")
                {
                    _woodStock += (5 * item.Value.Building.Rank);
                    if (_woodStock > 9999)
                    {
                        _woodStock = 9999;
                    }
                }
                if (item.Value.GetName == "Mine")
                {
                    _stoneStock += (5 * item.Value.Building.Rank);
                    if(_stoneStock > 9999)
                    {
                        _stoneStock = 9999;
                    }
                }
                if (item.Value.GetName == "House")
                {
                    if(item.Value.Building.Rank <= 2)
                    {
                        _foodStock -= 1;
                    }
                    else
                    {
                        _foodStock -= 2;
                    }
                    if (_foodStock > 9999)
                    {
                        _foodStock = 9999;
                    }
                }
            }
        }

        bool IsTowerBuyable => Wood >= 10 && Stones >= 60;
      

        bool IsWallBuyable => Wood >= 10 && Stones >= 20;
        

        void BuyWall()
        {
            Wood -= 10;
            Stones -= 20;
        }

        internal uint Villagers => _villagerStock;

        bool IsHouseBuyable => Wood >= 30 && Stones >= 10;

        void BuyHouse()
        {
            Wood -= 30;
            Stones -= 10;
        }

        bool IsMineBuyable => Wood >= 40 && Stones >= 20;
        

        void BuyMine()
        {
            Wood -= 40;
            Stones -= 20;
        }
        
        bool IsFarmBuyable =>Wood >= 40 && Stones >= 10;
        

       void BuyFarm()
        {
            Wood -= 40;
            Stones -= 10;
        }

        bool IsSawMillBuyable => Wood >= 50 && Stones >= 10;
        

        void BuySawMill()
        {
            Wood -= 50;
            Stones -= 10;
        }

        internal uint Wood
        {
            get { return _woodStock; }
            set { _woodStock = value; }
        }

        internal uint Stones
        {
            get { return _stoneStock; }
            set { _stoneStock = value; }
        }

        internal uint Food
        {
            get { return _foodStock; }
            set { _foodStock = value; }
        }

        void BuyTower()
        {
            Wood -= 10;
            Stones -= 60;
        }

        public void SetCastle()
        {
            _map.GetGame.GetGrid[new Vector2i(-1, 0)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(-1, 0)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(-1, 1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(-1, 1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(-1, -1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(-1, -1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(0, 0)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(0, 0)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(0, 1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(0, 1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(0, -1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(0, -1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(1, 0)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(1, 0)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(1, 1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(1, 1)].IsReveal = true;
            _map.GetGame.GetGrid[new Vector2i(1, -1)].SetName = "Castle";
            _map.GetGame.GetGrid[new Vector2i(1, -1)].IsReveal = true;
            GetMap.Castle(new Castle(0f, 0f, 750, 750, 0,5,1,0f,0, GetMap,"Castle","Votre résidence")) ;
        }

        public void SetNearby()
        {
            for (int i = -1 * _area + 1; i < _area; i++)
            {
                for (int j = -1 * _area + 1; j < _area; j++)
                {
                    if (!_map.GetGame.GetGrid[new Vector2i(i, j)].IsBusy())
                    {
                        _nearby.Add(_map.GetGame.GetGrid[new Vector2i(i, j)]);
                    }
                }
            }
        }

        public void CreateBuilding(string name)
        {

            switch (name)
                {
                    case "House":
                    if (IsHouseBuyable)
                    {
                        BuyHouse();
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = name;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = 
                            new House(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y,150,150,0,1,0,0f,0, GetMap,name,"Une habitation");
                    }
                    break;
                    case "Sawmill":
                    if(IsSawMillBuyable)
                    {
                        BuySawMill();
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = name;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = 
                            new Sawmill(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y, 150, 150, 0, 1, 0, 0f, 0, GetMap, name, "Une habitation");
                    }
                    break;
                    case "Mine":
                    if(IsMineBuyable)
                    {
                        BuyMine();
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = name;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = 
                            new Mine(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y, 150, 150, 0, 1, 0, 0f, 0, GetMap, name, "Carrière, permet de produire des pierres.");
                    }
                    break;
                    case "Farm":
                    if(IsFarmBuyable)
                    {
                        BuyFarm();
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = name;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = 
                            new Farm(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y, 150, 150, 0, 1, 0, 0f, 0, GetMap, name, "Une ferme pour produire de la nourriture");
                    }
                    break; 
                    case "Tower":
                    if(IsTowerBuyable)
                    { 
                        BuyTower();
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = name;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = 
                            new Tower(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y, 350, 350, 7, 2, 0, 30f, 2, GetMap, name, "Une habitation");
                    }
                    break;
                    case "Wall":
                    if(IsWallBuyable)
                    {
                        BuyWall();
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].SetName = name;
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building = 
                            new Wall(_map.GetGame.GetWindow.GetView.Render.Center.X, _map.GetGame.GetWindow.GetView.Render.Center.Y, 200, 200, 20, 1, 20, 0f, 0, GetMap,name,"Une tour capable de vous défendre de vos assaillants");
                    }
                    break;
                    case "House LV2":
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building.Upgrade();
                        _map.GetVillage._villagerStock += 5;
                    break;
                    case "House LV3":
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building.Upgrade();
                        _map.GetVillage._villagerStock += 5;
                    break;
                    default:
                        _map.GetGame.GetGrid[new Vector2i(_map.GetGame.GetWindow.GetView.X, _map.GetGame.GetWindow.GetView.Y)].Building.Upgrade();
                    break;

            }
        }


        public List<Hut> RebuildeMegaGreatConstructor()
        {
            List<Hut> newList = new List<Hut>();
            foreach (var item in _nearby)
            {
                newList.Add(item);
            }
            return newList;
        }

        public void DrawBuilding()
        {
            foreach (var item in _map.GetGame.GetGrid)
            {
                if (item.Value.IsBusy())
                {
                    if (item.Value.GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("Wall").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Wall"));
                    }
                    if (item.Value.GetName == "Mine")
                    {
                        _map.GetGame.Sprites.GetSprite("Mine").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Mine"));
                    }
                    if (item.Value.GetName == "House")
                    {
                        _map.GetGame.Sprites.GetSprite("House").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("House"));
                    }
                    if (item.Value.GetName == "Farm")
                    {
                        _map.GetGame.Sprites.GetSprite("Farm").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Farm"));
                    }
                    if (item.Value.GetName == "Sawmill")
                    {
                        _map.GetGame.Sprites.GetSprite("Sawmill").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Sawmill"));
                    }
                    if (item.Value.GetName == "Stone")
                    {
                        _map.GetGame.Sprites.GetSprite("Stone").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Stone"));
                    }
                    if (item.Value.GetName == "Wood")
                    {
                        if (_map.GetGame.GetTimer >= 180)
                        {
                            _map.GetGame.Sprites.GetSprite("WoodWinter").Position = item.Value.GetVec2F;
                            _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WoodWinter"));
                        }
                        else
                        {
                            _map.GetGame.Sprites.GetSprite("Wood").Position = item.Value.GetVec2F;
                            _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Wood"));
                        }
                    }
                    if (item.Value.GetName == "Bush")
                    {
                        if (_map.GetGame.GetTimer >= 180)
                        {
                            _map.GetGame.Sprites.GetSprite("BushWinter").Position = item.Value.GetVec2F;
                            _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("BushWinter"));
                        }
                        else
                        {
                            _map.GetGame.Sprites.GetSprite("Bush").Position = item.Value.GetVec2F;
                            _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Bush"));
                        }
                    }
                }
            }
        }
        public void WallRenderer()
        {
            foreach (var item in _map.GetGame.GetGrid)
            {
                if (item.Value.GetName == "Wall")
                {
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X-1,item.Key.Y)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("WallLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallLeft"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X - 1, item.Key.Y)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("WallLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallLeft"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("WallRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("WallRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y+1)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("WallDown").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallDown"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y + 1)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("WallDown").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallDown"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y-1)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("WallUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallUp"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y - 1)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("WallUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("WallUp"));
                    }
                }
                if (item.Value.GetName == "Tower")
                {
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X - 1, item.Key.Y)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerLeft"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X - 1, item.Key.Y)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerLeft").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerLeft"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X + 1, item.Key.Y)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerRight").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerRight"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y + 1)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerBot").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerBot"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y + 1)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerBot").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerBot"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y - 1)].GetName == "Wall")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerUp"));
                    }
                    if (_map.GetGame.GetGrid[new Vector2i(item.Key.X, item.Key.Y - 1)].GetName == "Tower")
                    {
                        _map.GetGame.Sprites.GetSprite("TowerUp").Position = item.Value.GetVec2F;
                        _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("TowerUp"));
                    }
                }
            }
        }
        public void DrawCastle()
        {
            _map.GetGame.Sprites.GetSprite("Castle").Position = _map.GetGame.GetGrid[new Vector2i(-1, -1)].GetVec2F;
            _map.GetGame.GetWindow.Render.Draw(_map.GetGame.Sprites.GetSprite("Castle"));
        }

        public int Area => _area;

        public Map GetMap => _map;
    }
}
