using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Interface;

namespace LastBastion
{
    internal class MenuBuilder
    {
        Game _game;
        SpritesManager _sprites;

        List<Sprite> _spriteBar;

        int _currentPos;
        bool _up;

        internal MenuBuilder(Game game,SpritesManager sprites)
        {
            _game = game;
            _sprites = sprites;
            _currentPos = 0;
            _up = false;
            _spriteBar = new List<Sprite>();
        }
        
        internal void UpdateList()
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
                    else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Stone")
                    {
                        _spriteBar.Add(_sprites.GetSprite("House"));
                        _spriteBar.Add(_sprites.GetSprite("Tower"));
                        _spriteBar.Add(_sprites.GetSprite("Wall"));
                        _spriteBar.Add(_sprites.GetSprite("Mine"));
                    }
                    else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Bush")
                    {
                        _spriteBar.Add(_sprites.GetSprite("House"));
                        _spriteBar.Add(_sprites.GetSprite("Tower"));
                        _spriteBar.Add(_sprites.GetSprite("Wall"));
                        _spriteBar.Add(_sprites.GetSprite("Farm"));
                    }
                    else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Wood")
                    {
                        _spriteBar.Add(_sprites.GetSprite("House"));
                        _spriteBar.Add(_sprites.GetSprite("Tower"));
                        _spriteBar.Add(_sprites.GetSprite("Wall"));
                        _spriteBar.Add(_sprites.GetSprite("Sawmill"));
                    }
                    else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Wall")
                    {
                        _spriteBar.Add(_sprites.GetSprite("LavaWall"));
                    }
                    else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "House")
                    {
                        if(_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank < 3)
                        {
                            _spriteBar.Add(_sprites.GetSprite("HouseUp"));
                        }
                    }
                    else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Mine")
                    {
                        if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank < 3)
                        {
                            _spriteBar.Add(_sprites.GetSprite("MineUp"));
                        }
                    }
                    else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Sawmill")
                    {
                        if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank < 3)
                        {
                            _spriteBar.Add(_sprites.GetSprite("SawmillUp"));
                        }
                    }
                    else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Farm")
                    {
                        if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank < 3)
                        {
                            _spriteBar.Add(_sprites.GetSprite("FarmUp"));
                        }
                    }
                }
            }
        }
        internal bool IsOpen => _up;
        internal void OpenClose() { _up = !_up; _currentPos = 0; }
        internal void ToZero () { _currentPos = 0; }
        internal void DrawMenu()
        {
            _game.Sprites.Text.Color = new Color(255, 255, 255);
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
                if (_currentPos < _spriteBar.Count && _currentPos >= 0)
                {
                    //Target Element
                    _spriteBar[_currentPos].Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 95, _game.GetWindow.GetView.Render.Center.Y + 165);
                    _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 95, _game.GetWindow.GetView.Render.Center.Y + 165);
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
                    _game.Sprites.GetSprite("VillagerIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 158);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("VillagerIcon"));
                    _game.Sprites.GetSprite("Bush").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("Bush").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 176);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Bush"));
                    _game.Sprites.GetSprite("Wood").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("Wood").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 194);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Wood"));
                    _game.Sprites.GetSprite("Stone").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("Stone").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 90, _game.GetWindow.GetView.Render.Center.Y + 212);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Stone"));
                    //Title
                    _game.Sprites.Text.DisplayedString = SelectTarget();
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 80, _game.GetWindow.GetView.Render.Center.Y + 135);
                    _game.Sprites.Text.Scale = new Vector2f(0.8f, 0.8f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    //Price
                    _game.Sprites.Text.DisplayedString = _game.SamplerBuilding[SelectTarget()].VillagerCost.ToString();
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 70, _game.GetWindow.GetView.Render.Center.Y + 151);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = _game.SamplerBuilding[SelectTarget()].FoodCost.ToString();
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 70, _game.GetWindow.GetView.Render.Center.Y + 169);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = _game.SamplerBuilding[SelectTarget()].WoodCost.ToString();
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 70, _game.GetWindow.GetView.Render.Center.Y + 187);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    _game.Sprites.Text.DisplayedString = _game.SamplerBuilding[SelectTarget()].StoneCost.ToString();
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 70, _game.GetWindow.GetView.Render.Center.Y + 205);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    //Description Title
                    _game.Sprites.Text.DisplayedString = "Description";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 135);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    //Description
                    _game.Sprites.Text.DisplayedString = _game.SamplerBuilding[SelectTarget()].Description.ToString();
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 165);
                    _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                    //Stats
                    _game.Sprites.Text.DisplayedString = "Stats";
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 88, _game.GetWindow.GetView.Render.Center.Y + 135);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                else
                {
                    _currentPos = 0;
                }
            }
        }

        internal void MenuDesc()
        {
            _game.Sprites.Text.Color = new Color(255, 255, 255);
            //Font
            _game.Sprites.GetSprite("BotBar").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2, _game.GetWindow.GetView.Render.Center.Y + _game.GetWindow.GetView.Render.Size.Y / 2 - 120);
            _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("BotBar"));
            //Title
            _game.Sprites.Text.DisplayedString = "Event Cycle " + _game.Cycle;
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 135);
            _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            //Event description
            _game.Sprites.Text.DisplayedString = _game.EventDesc;
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 248, _game.GetWindow.GetView.Render.Center.Y + 175);
            _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            //Hut name
            if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Empty")
            {
                _game.Sprites.Text.DisplayedString = "Tile";
            }
            else
            {
                _game.Sprites.Text.DisplayedString = _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName;
            }
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 100, _game.GetWindow.GetView.Render.Center.Y + 135);
            _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building != null)
            {
                _game.Sprites.Text.DisplayedString = "Stats";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 174, _game.GetWindow.GetView.Render.Center.Y + 135);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
            }
            _game.Sprites.Text.DisplayedString = "Description";
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 44, _game.GetWindow.GetView.Render.Center.Y + 135);
            _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Castle")
            {
                //Icon Building
                _game.Sprites.GetSprite("Castle").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _game.Sprites.GetSprite("Castle").Scale = new Vector2f(1.35f, 1.35f);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Castle"));
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Description
                _game.Sprites.Text.DisplayedString = "Your main place for survive";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 44, _game.GetWindow.GetView.Render.Center.Y + 165);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
            }
            else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Stone")
            {
                //Icon Building
                _game.Sprites.GetSprite("Stone").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _game.Sprites.GetSprite("Stone").Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("Stone"));
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Description
                _game.Sprites.Text.DisplayedString = "Have no building in this place.\n Try to recolt ressources.";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 44, _game.GetWindow.GetView.Render.Center.Y + 165);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
            }
            else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Bush")
            {
                //Icon Building
                _game.Sprites.GetSprite("Bush").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _game.Sprites.GetSprite("Bush").Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("Bush"));
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Description
                _game.Sprites.Text.DisplayedString = "Have no building in this place.\n Try to recolt ressources.";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 44, _game.GetWindow.GetView.Render.Center.Y + 165);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
            }
            else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].GetName == "Wood")
            {
                //Icon Building
                _game.Sprites.GetSprite("Wood").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _game.Sprites.GetSprite("Wood").Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("Wood"));
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Description
                _game.Sprites.Text.DisplayedString = "Have no building in this place.\n Try to recolt ressources.";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 44, _game.GetWindow.GetView.Render.Center.Y + 165);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
            }
            else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building == null)
            {
                //Icon Building
                _game.Sprites.GetSprite("Tile").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _game.Sprites.GetSprite("Tile").Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_sprites.GetSprite("Tile"));
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Description
                _game.Sprites.Text.DisplayedString = "Have no Building in this place";
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 44, _game.GetWindow.GetView.Render.Center.Y + 165);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
            }
            else
            {
                //Icon Building
                _game.Sprites.GetSprite(_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Name).Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 105, _game.GetWindow.GetView.Render.Center.Y + 165);
                _sprites.GetSprite("IconBoard").Scale = new Vector2f(4f, 4f);
                _game.Sprites.GetSprite(_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Name).Scale = new Vector2f(4f, 4f);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite(_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Name));
                _game.GetWindow.Render.Draw(_sprites.GetSprite("IconBoard"));
                //Description
                _game.Sprites.Text.DisplayedString = _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Description;
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - 44, _game.GetWindow.GetView.Render.Center.Y + 165);
                _game.Sprites.Text.Scale = new Vector2f(0.3f, 0.3f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                //Icon
                _game.Sprites.GetSprite("HealthIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("HealthIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 165, _game.GetWindow.GetView.Render.Center.Y + 160);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("HealthIcon"));
                _game.Sprites.GetSprite("ArmorIcon").Scale = new Vector2f(1.4f, 1.4f);
                _game.Sprites.GetSprite("ArmorIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 165, _game.GetWindow.GetView.Render.Center.Y + 188);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("ArmorIcon"));
                //Stats Text
                _game.Sprites.Text.DisplayedString = _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Life + "/" + _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.MaxLife;
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 189, _game.GetWindow.GetView.Render.Center.Y + 160);
                _game.Sprites.Text.Scale = new Vector2f(0.5f, 0.5f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                _game.Sprites.Text.DisplayedString = _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Armor.ToString();
                _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 189, _game.GetWindow.GetView.Render.Center.Y + 188);
                _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                _game.GetWindow.Render.Draw(_game.Sprites.Text);
                if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Name == "House")
                {
                    _game.Sprites.GetSprite("VillagerIcon").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("VillagerIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 165, _game.GetWindow.GetView.Render.Center.Y + 218);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("VillagerIcon"));
                    _game.Sprites.Text.DisplayedString = "+" + 5 * _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank;
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 189, _game.GetWindow.GetView.Render.Center.Y + 211);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Name == "Sawmill")
                {
                    _game.Sprites.GetSprite("Wood").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("Wood").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 165, _game.GetWindow.GetView.Render.Center.Y + 218);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Wood"));
                    _game.Sprites.Text.DisplayedString = "+" + 5 * _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank;
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 189, _game.GetWindow.GetView.Render.Center.Y + 211);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Name == "Farm")
                {
                    _game.Sprites.GetSprite("Bush").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("Bush").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 165, _game.GetWindow.GetView.Render.Center.Y + 218);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Bush"));
                    _game.Sprites.Text.DisplayedString = "+" + 5 * _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank;
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 189, _game.GetWindow.GetView.Render.Center.Y + 211);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Name == "Mine")
                {
                    _game.Sprites.GetSprite("Stone").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("Stone").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 165, _game.GetWindow.GetView.Render.Center.Y + 218);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Stone"));
                    _game.Sprites.Text.DisplayedString = "+" + 5 * _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank;
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 189, _game.GetWindow.GetView.Render.Center.Y + 211);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
                else if (_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Name == "Tower")
                {
                    _game.Sprites.GetSprite("Stone").Scale = new Vector2f(1.4f, 1.4f);
                    _game.Sprites.GetSprite("Stone").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 165, _game.GetWindow.GetView.Render.Center.Y + 218);
                    _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Stone"));
                    _game.Sprites.Text.DisplayedString = "+" + 5 * _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank;
                    _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X + 189, _game.GetWindow.GetView.Render.Center.Y + 211);
                    _game.Sprites.Text.Scale = new Vector2f(0.7f, 0.7f);
                    _game.GetWindow.Render.Draw(_game.Sprites.Text);
                }
            }
        }
        internal void UWantToMoveToTheRightInTheMenu()
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
        internal void UWantToMoveToTheLeftInTheMenu()
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
        internal String SelectTarget()
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
                if (_spriteBar[_currentPos] == _sprites.GetSprite("LavaWall"))
                {
                    return "LavaWall";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("HouseUp") && _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X,_game.GetWindow.GetView.Y)].Building.Rank == 1)
                {
                    return "House Lv2";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("HouseUp") && _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank == 2)
                {
                    return "House Lv3";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("FarmUp") && _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank == 1)
                {
                    return "Farm Lv2";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("FarmUp") && _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank == 2)
                {
                    return "Farm Lv3";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("MineUp") && _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank == 1)
                {
                    return "Mine Lv2";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("MineUp") && _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank == 2)
                {
                    return "Mine Lv3";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("TowerLUP"))
                {
                    return "TowerUp";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("SawmillUp") && _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank == 1)
                {
                    return "Sawmill Lv2";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("SawmillUp") && _game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y)].Building.Rank == 2)
                {
                    return "Sawmill Lv3";
                }
                if (_spriteBar[_currentPos] == _sprites.GetSprite("WallLUP"))
                {
                    return "WallUp";
                }
            }
            return "bad";
        }
        internal void UpdateTopBar()
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
            _game.Sprites.GetSprite("VillagerIcon").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 1.5f * t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("VillagerIcon"));
            _game.Sprites.GetSprite("Timer").Scale = new Vector2f(2.5f, 2.5f);
            _game.Sprites.GetSprite("Timer").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 , _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Timer"));

            _game.Sprites.Text.DisplayedString = _game.Map.GetVillage.Stone.ToString();
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 8.8f * t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.Sprites.Text.Scale = new Vector2f(1f,1f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            _game.Sprites.Text.DisplayedString = _game.Map.GetVillage.Food.ToString();
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 4.8f * t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.Sprites.Text.Scale = new Vector2f(1f, 1f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            _game.Sprites.Text.DisplayedString = _game.Map.GetVillage.Wood.ToString();
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 6.8f * t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.Sprites.Text.Scale = new Vector2f(1f, 1f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            _game.Sprites.Text.DisplayedString = _game.Map.GetVillage.Villager.ToString() + "/" + _game.Map.GetVillage.MaxVillager;
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 2.2f * t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.Sprites.Text.Scale = new Vector2f(0.9f, 0.9f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            _game.Sprites.Text.DisplayedString = _game.GetTimer.ToString();
            _game.Sprites.Text.Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.GetWindow.GetView.Render.Size.X / 2 + 0.8f * t, _game.GetWindow.GetView.Render.Center.Y - _game.GetWindow.GetView.Render.Size.Y / 2);
            _game.Sprites.Text.Scale = new Vector2f(0.9f, 0.9f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
        }
    }
}