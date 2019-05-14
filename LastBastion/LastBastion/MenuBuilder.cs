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
                    }
                    if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Stone")
                    {
                        _spriteBar.Add(_sprites.GetSprite("House"));
                        _spriteBar.Add(_sprites.GetSprite("Tower"));
                        _spriteBar.Add(_sprites.GetSprite("Mine"));
                    }
                    if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Bush")
                    {
                        _spriteBar.Add(_sprites.GetSprite("House"));
                        _spriteBar.Add(_sprites.GetSprite("Tower"));
                        _spriteBar.Add(_sprites.GetSprite("Farm"));
                    }
                    if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Wood")
                    {
                        _spriteBar.Add(_sprites.GetSprite("House"));
                        _spriteBar.Add(_sprites.GetSprite("Tower"));
                        _spriteBar.Add(_sprites.GetSprite("Sawmill"));
                    }
                }
            }
        }
        public bool IsOpen => _up;
        public void OpenClose() { _up = !_up; }
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
            if (_spriteBar.Count != 0)
            {
                _spriteBar[_currentPos].Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 7, _game.GetWindow.GetView.Render.Center.Y + 40);
                _sprites.GetSprite("IconFont").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 7, _game.GetWindow.GetView.Render.Center.Y + 40);
                _sprites.GetSprite("IconFont").Scale = new Vector2f(2f, 2f);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 7, _game.GetWindow.GetView.Render.Center.Y + 40);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(2f, 2f);
                _spriteBar[_currentPos].Scale = new Vector2f(2f, 2f);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconFont"));
                _game.GetWindow.Render.Draw(_spriteBar[_currentPos]);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));

                _spriteBar[right].Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 27, _game.GetWindow.GetView.Render.Center.Y + 40);
                _sprites.GetSprite("IconFont").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 27, _game.GetWindow.GetView.Render.Center.Y + 40);
                _sprites.GetSprite("IconFont").Scale = new Vector2f(1f, 1f);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 27, _game.GetWindow.GetView.Render.Center.Y + 40);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(1f, 1f);
                _spriteBar[right].Scale = new Vector2f(1f, 1f);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconFont"));
                _game.GetWindow.Render.Draw(_spriteBar[right]);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));

                _spriteBar[left].Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 25, _game.GetWindow.GetView.Render.Center.Y + 40);
                _sprites.GetSprite("IconFont").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 25, _game.GetWindow.GetView.Render.Center.Y + 40);
                _sprites.GetSprite("IconFont").Scale = new Vector2f(1f, 1f);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 25, _game.GetWindow.GetView.Render.Center.Y + 40);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(1f, 1f);
                _spriteBar[left].Scale = new Vector2f(1f, 1f);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconFont"));
                _game.GetWindow.Render.Draw(_spriteBar[left]);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
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
            return "Empty";
        }
    }
}
