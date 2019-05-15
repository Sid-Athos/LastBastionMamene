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
        SpritesManager _sprites;
        Input _input;
        Map _map;
        MenuBuilder _menu;
        //Mouse
        Vector2f _cursorPosition;
        // Timer And Stop
        int _countTimer;
        int _sec;
        bool MinutePass = true;
        bool _pause;
        int _cycle;
        int _lastProd;
        //Random
        Random _random = new Random();

        public void Run()
        {
            _input = new Input(this);

            _sprites = new SpritesManager();
            _sprites.Initialized();

            _grid = new Dictionary<Vector2i, Hut>();
            CreateGrid(50,50);

            _window = new WindowUI(_sprites,_grid[new Vector2i(0,0)].GetVec2F);

            _countTimer = 300;
            _lastProd = _countTimer;
            _sec = DateTime.Now.Second;
            _pause = true;
            
            _map = new Map(this);
            _menu = new MenuBuilder(this, _sprites);

            _window.Render.SetMouseCursorVisible(false);
            _window.Render.KeyPressed += _input.IsKeyPressed;
            _window.Render.MouseMoved += MoveCursor;

            Gameloop();
        }
        public void Gameloop()
        {
            while (_window.Render.IsOpen)
            {
                _window.Render.DispatchEvents();
                _window.Render.Clear();

                if (_pause)
                {
                    TimerUpdate();
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
                    Console.WriteLine(_map.GetVillage.StoneStock);
                    Console.WriteLine(_map.GetVillage.FoodStock);
                    Console.WriteLine(_map.GetVillage.WoodStock);
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
            _map.ZoneReveal();
            _map.PrintMist();
            _window.PrintCursor();
            if (!_pause)
            {
                _map.SamourailDeCoke();
                // Draw menu
            }
            //UI
            if (_menu.IsOpen)
            {
                _menu.UpdateList();
                _menu.DrawMenu();
            }
        }

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
        public void Pause() { _pause = !_pause; }
        public bool IsStop => !_pause;
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
            if (_countTimer == 361)
            {
                _cycle++;
                _countTimer = 1;
            }
        }

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
    }
}
