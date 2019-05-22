using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Interface;

namespace LastBastion
{
    public class MenuBuilder
    {
        Game _game;
        SpritesManager _sprites;

        List<Sprite> _spriteBar;

        int _currentPos;
        bool _up;

        public MenuBuilder(Game game,SpritesManager sprites)
        {
            _game = game;
            _sprites = sprites;
            _currentPos = 0;
            _up = false;
            _spriteBar = new List<Sprite>();
        }
        
        public void UpdateList()
        {
            _spriteBar.Clear();
            if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].IsReveal == false)
            {
                _spriteBar.Clear();
            }
            else
            {
                if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Castle")
                {
                    _spriteBar.Clear();
                }
                else
                {
                    if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Empty")
                    {
                        _spriteBar.Add(_sprites.GetSprite("House"));
                        _spriteBar.Add(_sprites.GetSprite("Tower"));
                        _spriteBar.Add(_sprites.GetSprite("Wall"));
                    }
                    if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Stone")
                    {
                        _spriteBar.Add(_sprites.GetSprite("House"));
                        _spriteBar.Add(_sprites.GetSprite("Tower"));
                        _spriteBar.Add(_sprites.GetSprite("Wall"));
                        _spriteBar.Add(_sprites.GetSprite("Mine"));
                    }
                    if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Bush")
                    {
                        _spriteBar.Add(_sprites.GetSprite("House"));
                        _spriteBar.Add(_sprites.GetSprite("Tower"));
                        _spriteBar.Add(_sprites.GetSprite("Wall"));
                        _spriteBar.Add(_sprites.GetSprite("Farm"));
                    }
                    if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Wood")
                    {
                        _spriteBar.Add(_sprites.GetSprite("House"));
                        _spriteBar.Add(_sprites.GetSprite("Tower"));
                        _spriteBar.Add(_sprites.GetSprite("Wall"));
                        _spriteBar.Add(_sprites.GetSprite("Sawmill"));
                    }
                }
            }
        }
        public bool IsOpen => _up;
        public void OpenClose() { _up = !_up; _currentPos = 0; }
        public void ToZero () { _currentPos = 0; }
        public void DrawMenu()
        {
            int right;
            int left;
            if (_currentPos == _spriteBar.Count - 1)
            {
                right = 0;
            }
            else
            {
                right = _currentPos + 1;
            }
            if (_currentPos == 0)
            {
                left = _spriteBar.Count - 1;
            }
            else
            {
                left = _currentPos - 1;
            }
            _game.Sprites.GetSprite("BotBar").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2, _game.GetWindow.GetView.Render.Center.Y + _game.GetWindow.GetView.Render.Size.Y / 2 - 120);
            _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("BotBar"));
            if (_spriteBar.Count != 0)
            {
                //Target Element
                _spriteBar[_currentPos].Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 60, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 60, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _spriteBar[_currentPos].Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_spriteBar[_currentPos]);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Right Element
                _spriteBar[right].Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 185, _game.GetWindow.GetView.Render.Center.Y + 150);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 185, _game.GetWindow.GetView.Render.Center.Y + 150);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _spriteBar[right].Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_spriteBar[right]);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Left Element
                _spriteBar[left].Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 5, _game.GetWindow.GetView.Render.Center.Y + 150);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 5, _game.GetWindow.GetView.Render.Center.Y + 150);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _spriteBar[left].Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_spriteBar[left]);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Icon
                _game.Sprites.GetSprite("VillagerIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("VillagerIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 125, _game.GetWindow.GetView.Render.Center.Y + 158);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("VillagerIcon"));
                _game.Sprites.GetSprite("Bush").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("Bush").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 125, _game.GetWindow.GetView.Render.Center.Y + 176);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Bush"));
                _game.Sprites.GetSprite("Wood").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("Wood").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 125, _game.GetWindow.GetView.Render.Center.Y + 194);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Wood"));
                _game.Sprites.GetSprite("Stone").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("Stone").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 125, _game.GetWindow.GetView.Render.Center.Y + 212);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Stone"));
                //Title
                _game.Sprites.Text.DisplayedString = SelectTarget();
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 80, _game.GetWindow.GetView.Render.Center.Y + 135);
                _game.Sprites.Text.Scale = new Vector2f(0.8f, 0.8f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                //Price
                if (_spriteBar[_currentPos] == _sprites.GetSprite("House"))
                {
                    _game.Sprites.Text.DisplayedString = "0";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "0";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "30";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 187);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "10";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 205);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Farm"))
                {
                    _game.Sprites.Text.DisplayedString = "0";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "0";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "40";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 187);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "10";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 205);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Mine"))
                {
                    _game.Sprites.Text.DisplayedString = "0";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "0";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "40";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 187);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "20";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 205);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Tower"))
                {
                    _game.Sprites.Text.DisplayedString = "0";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "0";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "10";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 187);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "60";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 205);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Sawmill"))
                {
                    _game.Sprites.Text.DisplayedString = "0";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "0";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "50";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 187);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "10";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 205);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Wall"))
                {
                    _game.Sprites.Text.DisplayedString = "0";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "0";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "10";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 187);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "20";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 143, _game.GetWindow.GetView.Render.Center.Y + 205);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                //Description
                _game.Sprites.Text.DisplayedString = "Description";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 135);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                if (_spriteBar[_currentPos] == _sprites.GetSprite("House"))
                {
                    _game.Sprites.Text.DisplayedString = "Increase maximum kingdom";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 165);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = " population by 5 points per rank.";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 175);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Farm"))
                {
                    _game.Sprites.Text.DisplayedString = "Increase maximum kingdom";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 165);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = " production of food ";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 175);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = " by 5 points per rank.";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 185);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Mine"))
                {
                    _game.Sprites.Text.DisplayedString = "Increase maximum kingdom";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 165);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = " production of stone ";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 175);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = " by 5 points per rank.";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 185);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Tower"))
                {
                    _game.Sprites.Text.DisplayedString = "Main defence to protect";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 165);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = " the kingdom from Dracula.";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 175);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Sawmill"))
                {
                    _game.Sprites.Text.DisplayedString = "Increase maximum kingdom";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 165);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = " production of wood ";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 175);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = " by 5 points per rank.";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 185);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Wall"))
                {
                    _game.Sprites.Text.DisplayedString = "Protect the kingdom from";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 165);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = " darkness invaders.";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 175);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                //Stats
                _game.Sprites.Text.DisplayedString = "Stats";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 88, _game.GetWindow.GetView.Render.Center.Y + 135);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                if (_spriteBar[_currentPos] == _sprites.GetSprite("House"))
                {
                    //Icon
                    _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 158);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                    _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 176);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                    _game.Sprites.GetSprite("VillagerIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("VillagerIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 194);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("VillagerIcon"));
                    //Stats
                    _game.Sprites.Text.DisplayedString = "100";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "10";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "+5";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 187);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Farm"))
                {
                    //Icon
                    _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 158);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                    _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 176);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                    _game.Sprites.GetSprite("Bush").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("Bush").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 194);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Bush"));
                    //Stats
                    _game.Sprites.Text.DisplayedString = "100";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "10";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "+5";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 187);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Mine"))
                {
                    //Icon
                    _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 158);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                    _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 176);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                    _game.Sprites.GetSprite("Stone").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("Stone").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 194);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Stone"));
                    //Stats
                    _game.Sprites.Text.DisplayedString = "100";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "10";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "+5";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 187);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Tower"))
                {
                    //Icon
                    _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 158);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                    _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 176);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                    _game.Sprites.GetSprite("AttackIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("AttackIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 194);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("AttackIcon"));
                    //Stats
                    _game.Sprites.Text.DisplayedString = "200";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "20";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "10";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 187);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Sawmill"))
                {
                    //Icon
                    _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 158);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                    _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 176);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                    _game.Sprites.GetSprite("Wood").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("Wood").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 194);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Wood"));
                    //Stats
                    _game.Sprites.Text.DisplayedString = "100";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "10";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "+5";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 187);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Wall"))
                {
                    //Icon
                    _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 158);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                    _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 176);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                    //Stats
                    _game.Sprites.Text.DisplayedString = "300";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = "30";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 63, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
            }
        }
        public void MenuDesc()
        {
            //Font
            _game.Sprites.GetSprite("BotBar").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2, _game.GetWindow.GetView.Render.Center.Y + _game.GetWindow.GetView.Render.Size.Y / 2 - 120);
            _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("BotBar"));
            //Title
            _game.Sprites.Text.DisplayedString = "Event";
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 135);
            _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            _game.Sprites.Text.DisplayedString = "Building";
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 100, _game.GetWindow.GetView.Render.Center.Y + 135);
            _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            _game.Sprites.Text.DisplayedString = "Stats";
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 194, _game.GetWindow.GetView.Render.Center.Y + 135);
            _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            _game.Sprites.Text.DisplayedString = "Description";
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 135);
            _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            //Element
            if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "House")
            {
                //Icon Building
                _game.Sprites.GetSprite("House").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _game.Sprites.GetSprite("House").Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("House"));
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Description
                _game.Sprites.Text.DisplayedString = "Increase maximum kingdom";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 165);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = " population by 5 points per ";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 175);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "rank.";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 185);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                //Icon
                _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 158);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 176);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                _game.Sprites.GetSprite("VillagerIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("VillagerIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 194);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("VillagerIcon"));
                //Stats Text
                _game.Sprites.Text.DisplayedString = "100";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 151);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "10";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 169);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "+5";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 187);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
            }
            if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Farm")
            {
                //Icon Building
                _game.Sprites.GetSprite("Farm").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _game.Sprites.GetSprite("Farm").Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Farm"));
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Description
                _game.Sprites.Text.DisplayedString = "Increase maximum kingdom";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 165);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = " production of food ";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 175);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "by 5 points rank.";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 185);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                //Icon
                _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 158);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 176);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                _game.Sprites.GetSprite("Bush").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("Bush").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 194);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Bush"));
                //Stats Text
                _game.Sprites.Text.DisplayedString = "100";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 151);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "10";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 169);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "+5";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 187);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
            }
            if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Mine")
            {
                //Icon Building
                _game.Sprites.GetSprite("Mine").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _game.Sprites.GetSprite("Mine").Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Mine"));
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Description
                _game.Sprites.Text.DisplayedString = "Increase maximum kingdom";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 165);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = " production of stone ";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 175);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "by 5 points rank.";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 185);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                //Icon
                _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 158);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 176);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                _game.Sprites.GetSprite("Stone").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("Stone").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 194);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Stone"));
                //Stats Text
                _game.Sprites.Text.DisplayedString = "100";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 151);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "10";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 169);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "+5";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 187);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
            }
            if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Sawmill")
            {
                //Icon Building
                _game.Sprites.GetSprite("Sawmill").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _game.Sprites.GetSprite("Sawmill").Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Sawmill"));
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Description
                _game.Sprites.Text.DisplayedString = "Increase maximum kingdom";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 165);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = " production of wood ";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 175);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "by 5 points rank.";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 185);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                //Icon
                _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 158);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 176);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                _game.Sprites.GetSprite("Wood").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("Wood").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 194);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Wood"));
                //Stats Text
                _game.Sprites.Text.DisplayedString = "100";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 151);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "10";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 169);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "+5";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 187);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
            }
            if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Tower")
            {
                //Icon Building
                _game.Sprites.GetSprite("Tower").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _game.Sprites.GetSprite("Tower").Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Tower"));
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Description
                _game.Sprites.Text.DisplayedString = "Main defence to protect";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 165);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = " the kingdom from Dracula. ";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 175);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                //Icon
                _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 158);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 176);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                _game.Sprites.GetSprite("AttackIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("AttackIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 194);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("AttackIcon"));
                //Stats Text
                _game.Sprites.Text.DisplayedString = "200";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 151);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "20";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 169);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "10";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 187);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
            }
            if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Wall")
            {
                //Icon Building
                _game.Sprites.GetSprite("Wall").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _game.Sprites.GetSprite("Wall").Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Wall"));
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Description
                _game.Sprites.Text.DisplayedString = "Protect the kingdom from";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 165);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = " darkness invaders. ";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 24, _game.GetWindow.GetView.Render.Center.Y + 175);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                //Icon
                _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 158);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 190, _game.GetWindow.GetView.Render.Center.Y + 176);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                //Stats Text
                _game.Sprites.Text.DisplayedString = "300";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 151);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = "30";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 214, _game.GetWindow.GetView.Render.Center.Y + 169);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
            }
        }
        public void UWantToMoveToTheRightInTheMenu()
        {
            if (_currentPos == _spriteBar.Count - 1)
            {
                _currentPos = 0;
            }
            else
            {
                _currentPos++;
            }
        }
        public void UWantToMoveToTheLeftInTheMenu()
        {
            if (_currentPos == 0)
            {
                _currentPos = _spriteBar.Count - 1;
            }
            else
            {
                _currentPos--;
            }
        }
        public String SelectTarget()
        {
            if (_spriteBar.Count > 0)
            {
                if (_spriteBar[_currentPos] == _sprites.GetSprite("House"))
                {
                    return "House";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Farm"))
                {
                    return "Farm";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Mine"))
                {
                    return "Mine";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Tower"))
                {
                    return "Tower";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Sawmill"))
                {
                    return "Sawmill";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("Wall"))
                {
                    return "Wall";
                }
            }
            return "bad";
        }
        public void UpdateTopBar()
        {
            float t = _game.GetWindow.GetView.Render.Size.X / 10f;
            _game.Sprites.GetSprite("TopBar").Scale = new Vector2f(_game.GetWindow.GetView.Render.Size.X / _game.Sprites.GetSprite("TopBar").Scale.X, ((0.1f * _game.GetWindow.GetView.Render.Size.Y) / _game.Sprites.GetSprite("TopBar").Scale.Y)/39f);
            _game.Sprites.GetSprite("TopBar").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X/2, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("TopBar"));
            _game.Sprites.GetSprite("Bush").Scale = new Vector2f(2.5f, 2.5f);
            _game.Sprites.GetSprite("Bush").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 4 * t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Bush"));
            _game.Sprites.GetSprite("Wood").Scale = new Vector2f(2.5f, 2.5f);
            _game.Sprites.GetSprite("Wood").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 6 * t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Wood"));
            _game.Sprites.GetSprite("Stone").Scale = new Vector2f(2.5f, 2.5f);
            _game.Sprites.GetSprite("Stone").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 8 * t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Stone"));
            _game.Sprites.GetSprite("VillagerIcon").Scale = new Vector2f(2.5f, 2.5f);
            _game.Sprites.GetSprite("VillagerIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 2* t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("VillagerIcon"));
            //
            _game.Sprites.Text.DisplayedString = _game.Map.GetVillage.StoneStock.ToString();
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 8.8f * t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.Sprites.Text.Scale = new Vector2f(1f,1f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            _game.Sprites.Text.DisplayedString = _game.Map.GetVillage.FoodStock.ToString();
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 4.8f * t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.Sprites.Text.Scale = new Vector2f(1f, 1f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            _game.Sprites.Text.DisplayedString = _game.Map.GetVillage.WoodStock.ToString();
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 6.8f * t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.Sprites.Text.Scale = new Vector2f(1f, 1f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
        }
    }
}