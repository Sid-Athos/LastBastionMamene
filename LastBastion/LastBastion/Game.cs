using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using Interface;

namespace LastBastion
{
    public class Game
    {
        //Attribut
        WindowUI _window;
        Dictionary<Vector2i, Hut> _grid;
        Dictionary<string, Building> _sampleBuilding;
        SpritesManager _sprites;
        Input _input;
        EventCycle _event;
        Map _map;
        MenuBuilder _menu;
        StopMenu _stopMenu;
        //Mouse
        Vector2f _cursorPosition;
        // Timer And Stop
        int _countTimer;
        int _sec;
        bool MinutePass = true;
        bool _pause;
        int _cycle;
        int _lastProd;
        //Turn
        string _turn;
        //Random
        Random _random = new Random();
        //Music
        bool _isPlayMusic;

        public Game()
        {

        }

        public void Run()
        {
            _input = new Input(this);
            _sprites = new SpritesManager();
            _sprites.Initialized();

            _grid = new Dictionary<Vector2i, Hut>();
            CreateGrid(50,50);

            _window = new WindowUI(_sprites,_grid[new Vector2i(0,0)].GetVec2F);

            _countTimer = 0;
            _cycle = 1;
            _turn = "PlayerTurn";
            _lastProd = _countTimer;
            _sec = DateTime.Now.Second;
            _pause = true;
            _isPlayMusic = false;
            
            _map = new Map(this);
            _menu = new MenuBuilder(this, _sprites);
            _stopMenu = new StopMenu(this);
            _event = new EventCycle(this);
            _sampleBuilding = InitializeBuildingSample();
            
            _window.Render.SetMouseCursorVisible(false);
            _window.Render.KeyPressed += _input.IsKeyPressed;
            _window.Render.MouseMoved += MoveCursor;

            Gameloop();
        }

        public void Gameloop()
        {
            while (_window.Render.IsOpen)
            {
                _map.TimerUpdate();
                _window.Render.DispatchEvents();
                _window.Render.Clear();

                //Console.WriteLine(_grid[new Vector2i(GetWindow.GetView.X, GetWindow.GetView.Y)].GetName);

                if (_turn == "PlayerTurn")
                {
                    if (_pause)
                    {
                        TimerUpdate();
                    }
                }
                if (_countTimer == 0 && _isPlayMusic == false)
                {
                    _sprites.Music(0).Play();
                    _isPlayMusic = true;
                }
                if (_countTimer == 60 && _isPlayMusic == true)
                {
                    _sprites.Music(0).Stop();
                    _isPlayMusic = false;
                }
                _sprites.Update();
                //Mouse.SetPosition(new Vector2i((int)_cursorPosition.X,(int)_cursorPosition.Y));
                //Update
                _window.Render.SetView(_window.GetView.Render);
                DrawUpdate();
                if (_countTimer != _lastProd && _countTimer%3 == 0)
                {
                    _map.GetVillage.RessourceProd();
                    _lastProd = _countTimer;
                }
                //End Update

                _window.Render.Display();
            }
        }
        public void DrawUpdate()
        {
            _map.PrintMap();
            _map.GetVillage.DrawCastle();
            _map.GetVillage.DrawBuilding();
            _map.GetVillage.WallRenderer();
            if (_map.BarbCount > 0)
            {
                foreach(var n in _map.BarList)
                {
                    n.Update();
                }
            }
            _map.ZoneReveal();
            _map.PrintMist();
            _window.PrintCursor();
            _event.Update();
            //UI
            if (_turn == "PlayerTurn")
            {
                if (_menu.IsOpen)
                {
                    _menu.UpdateList();
                    _menu.DrawMenu();
                }
                else
                {
                    _menu.MenuDesc();
                }
                _menu.UpdateTopBar();
            }
            if (!_pause)
            {
                _map.SamouraïDeCoke();
                _stopMenu.Update();
                // Draw menu
            }
        }
        public string Turn => _turn;
        public string Event => _event.Event;
        public string EventDesc => _event.EventDescription;
        public int RandomNumber(int min, int max) => _random.Next(min, max);
        public void Close() { _window.Render.Close(); }
        public WindowUI GetWindow => _window;
        public Dictionary<Vector2i, Hut> GetGrid => _grid;
        public Random GetRDM => _random;
        public Vector2f CursorPosition => _cursorPosition;
        public SpritesManager Sprites => _sprites;
        public MenuBuilder GetMenuBuilder => _menu;
        public Map Map => _map;
        public int Cycle => _cycle;

        //Timer And Stop
        public int GetTimer => _countTimer;
        public void Pause() { _pause = !_pause; _stopMenu.Deploy(); }
        public bool IsStop => !_pause;
        public StopMenu StopMenu => _stopMenu;
        public void TimerUpdate()
        {
            if (DateTime.Now.Second == 1 && MinutePass == true)
            {
                _sec = 1;
                _countTimer += 2;
                MinutePass = false;
            }
            else
            {
                if (_sec < DateTime.Now.Second)
                {
                    _sec = DateTime.Now.Second;
                    _countTimer++;
                }
                if (DateTime.Now.Second == 2 && MinutePass == false)
                {
                    MinutePass = true;
                }
            }
            if (_countTimer == 61)
            {
                _countTimer = 1;
                _turn = "WaveTurn";
                /*
                _cycle++;
                Console.WriteLine(_cycle);
                */
            }
        }
        //Test Cursor
        public void MoveCursor(object sender, MouseMoveEventArgs e)
        {
            _cursorPosition = new Vector2f((float)e.X, (float)e.Y);
        }

        public void CreateGrid(int x, int y)
        {
            int l = -1 * (x / 2);
            for (float i = 0; i < 50 * 15; i += 15)
            {
                int h = -1 * (y / 2);
                for (float j = 0f; j < 50 * 15; j += 15)
                {
                    Hut NewH = new Hut(this,new Vector2f(i, j), "[ " + l + " ; " + h + " ]", new Vector2i(l, h));
                    _grid.Add(new Vector2i(l, h), NewH);
                    h++;
                }
                l++;
            }
        }

        public List<Vector2f> InTheMistOfPandaria(int n)
        {
            List<Vector2f> list = new List<Vector2f>();
            List<Vector2f> returnList = new List<Vector2f>();
            foreach (var item in _grid)
            {
                if (!item.Value.IsReveal)
                {
                    list.Add(item.Value.GetVec2F);
                }
            }
            for (int i = 0; i < n; i++)
            {
                int rdm = RandomNumber(0, list.Count);
                returnList.Add(list[rdm]);
            }
            return returnList;
        }
        public Dictionary<string, Building> InitializeBuildingSample()
        {
            Dictionary<string, Building> returnValue = new Dictionary<string, Building>();
            //House Lv1
            House house = new House(0f, 0f, 5, 1, _map);
            returnValue.Add("House", house);
            //House Lv2
            House house1 = new House(0f, 0f, 5, 1, _map);
            house1.Upgrade();
            returnValue.Add("House Lv2", house1);
            //House Lv3
            House house2 = new House(0f, 0f, 5, 1, _map);
            house2.Upgrade();
            house2.Upgrade();
            returnValue.Add("House Lv3", house2);
            //Sawmill Lv1
            Sawmill sawmill = new Sawmill(0f,0f,_map);
            returnValue.Add("Sawmill", sawmill);
            //Sawmill Lv2
            Sawmill sawmill1 = new Sawmill(0f, 0f, _map);
            sawmill1.Upgrade();
            returnValue.Add("Sawmill Lv2", sawmill1);
            //Sawmill Lv3
            Sawmill sawmill2 = new Sawmill(0f, 0f, _map);
            sawmill2.Upgrade();
            sawmill2.Upgrade();
            returnValue.Add("Sawmill Lv3", sawmill2);
            //Farm Lv1
            Farm farm = new Farm(0f, 0f, _map);
            returnValue.Add("Farm", farm);
            //Farm Lv2
            Farm farm1 = new Farm(0f, 0f, _map);
            farm1.Upgrade();
            returnValue.Add("Farm Lv2", farm1);
            //Farm Lv3
            Farm farm2 = new Farm(0f, 0f, _map);
            farm2.Upgrade();
            farm2.Upgrade();
            returnValue.Add("Farm Lv3", farm2);
            //Mine Lv1
            Mine mine = new Mine(0f, 0f, _map);
            returnValue.Add("Mine", mine);
            //Mine Lv2
            Mine mine1 = new Mine(0f, 0f, _map);
            mine1.Upgrade();
            returnValue.Add("Mine Lv2", mine1);
            //Mine Lv3
            Mine mine2 = new Mine(0f, 0f, _map);
            mine2.Upgrade();
            mine2.Upgrade();
            returnValue.Add("Mine Lv3", mine2);
            //Wall Lv1
            Wall wall = new Wall(0f,0f,_map);
            returnValue.Add("Wall",wall);
            //Tower Lv1
            Tower tower = new Tower(0f,0f,200,200,10,20,1,1,_map);
            returnValue.Add("Tower",tower);
            return returnValue;
        }
        public Dictionary<string, Building> SamplerBuilding => _sampleBuilding;
    }
}
