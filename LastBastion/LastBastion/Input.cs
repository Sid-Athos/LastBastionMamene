using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace LastBastion
{
    class Input
    {
        Game _game;
        Save _save;

        public Input(Game game)
        {
            _game = game;
            _save = new Save(_game, "test");
        }
        public void IsKeyPressed(object sender, KeyEventArgs e)
        {
            if (_game.GetMenuBuilder.IsOpen)
            {
                if (e.Code == Keyboard.Key.Enter)
                {
                    if (_game.GetMenuBuilder.SelectTarget() != "bad")
                    {
                        if (_game.Map.GetVillage.IsEnoughRessource(_game.GetMenuBuilder.SelectTarget()))
                        {
                            _game.Map.GetVillage.CreateBuilding(_game.GetMenuBuilder.SelectTarget());
                        }
                    }
                }
            }
            switch (e.Code)
            {
                case Keyboard.Key.Space:
                    _game.Pause();
                    break;
                
                case Keyboard.Key.A:
                    _game.Close();
                    break;
            }

            if (!_game.IsStop)
            {
                Console.WriteLine("[{0},{1}]", _game.GetWindow.GetView.X, _game.GetWindow.GetView.Y);
                switch (e.Code)
                {
                    case Keyboard.Key.Z:
                        if (_game.GetGrid.ContainsKey(new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y - 1)))
                        {
                            _game.GetMenuBuilder.ToZero();
                            _game.GetWindow.GetView.MoveUp(_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y - 1)].GetVec2F);
                        }
                        break;
                    case Keyboard.Key.S:
                        if (_game.GetGrid.ContainsKey(new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y + 1)))
                        {
                            _game.GetMenuBuilder.ToZero();
                            _game.GetWindow.GetView.MoveDown(_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X, _game.GetWindow.GetView.Y + 1)].GetVec2F);
                        }
                        break;
                    case Keyboard.Key.Q:
                        if (_game.GetGrid.ContainsKey(new Vector2i(_game.GetWindow.GetView.X - 1, _game.GetWindow.GetView.Y)))
                        {
                            _game.GetMenuBuilder.ToZero();
                            _game.GetWindow.GetView.MoveLeft(_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X - 1, _game.GetWindow.GetView.Y)].GetVec2F);
                        }
                        break;
                    case Keyboard.Key.D:
                        if (_game.GetGrid.ContainsKey(new Vector2i(_game.GetWindow.GetView.X + 1, _game.GetWindow.GetView.Y)))
                        {
                            _game.GetMenuBuilder.ToZero();
                            _game.GetWindow.GetView.MoveRight(_game.GetGrid[new Vector2i(_game.GetWindow.GetView.X + 1, _game.GetWindow.GetView.Y)].GetVec2F);
                        }
                        break;
                    case Keyboard.Key.Up:
                        if (_game.GetWindow.GetView.Render.Size.X > 100)
                        {
                            _game.GetWindow.GetView.Render.Size = new Vector2f(_game.GetWindow.GetView.Render.Size.X - 15, _game.GetWindow.GetView.Render.Size.Y - 15);
                        }
                        break;
                    case Keyboard.Key.Down:
                        if (_game.GetWindow.GetView.Render.Size.X < 400)
                        {
                            _game.GetWindow.GetView.Render.Size = new Vector2f(_game.GetWindow.GetView.Render.Size.X + 15, _game.GetWindow.GetView.Render.Size.Y + 15);
                        }
                        break;
                    case Keyboard.Key.Left:
                        _game.GetMenuBuilder.UWantToMoveToTheLeftInTheMenu();
                        break;
                    case Keyboard.Key.Right:
                        _game.GetMenuBuilder.UWantToMoveToTheRightInTheMenu();
                        break;
                    case Keyboard.Key.Tab:
                        _game.GetMenuBuilder.OpenClose();
                        break;
                    case Keyboard.Key.P:
                        _save.CreateTXT();
                        break;
                    case Keyboard.Key.B:
                        Barbar v1 = new Barbar(_game.GetWindow.GetView.Render.Center.X, _game.GetWindow.GetView.Render.Center.Y, 1.0f, "Barbare", 150, 3, 2, false, 3, 0.001f, _game.Map);
                        break;
                    case Keyboard.Key.C:
                        break;
                    case Keyboard.Key.E:
                        break;
                    case Keyboard.Key.F:
                        break;
                    case Keyboard.Key.G:
                        break;
                    case Keyboard.Key.H:
                        Console.WriteLine(_game.GetWindow.GetView.Render.Size.X);
                        Console.WriteLine(_game.GetWindow.GetView.Render.Size.Y);
                        break;
                    case Keyboard.Key.I:
                        break;
                    case Keyboard.Key.J:
                        break;
                    case Keyboard.Key.K:
                        break;
                    case Keyboard.Key.L:
                        _save.LeauAdd();
                        break;
                    case Keyboard.Key.M:
                        break;
                    case Keyboard.Key.N:
                        break;
                    case Keyboard.Key.O:
                        break;
                    case Keyboard.Key.R:
                        break;
                    case Keyboard.Key.T:
                        break;
                    case Keyboard.Key.U:
                        break;
                    case Keyboard.Key.V:
                        break;
                    case Keyboard.Key.W:
                        break;
                    case Keyboard.Key.X:
                        break;
                    case Keyboard.Key.Y:
                        break;
                    case Keyboard.Key.Num0:
                        break;
                    case Keyboard.Key.Num1:
                        break;
                    case Keyboard.Key.Num2:
                        break;
                    case Keyboard.Key.Num3:
                        break;
                    case Keyboard.Key.Num4:
                        break;
                    case Keyboard.Key.Num5:
                        break;
                    case Keyboard.Key.Num6:
                        break;
                    case Keyboard.Key.Num7:
                        break;
                    case Keyboard.Key.Num8:
                        break;
                    case Keyboard.Key.Num9:
                        break;
                    case Keyboard.Key.Escape:
                        break;
                    case Keyboard.Key.LControl:
                        break;
                    case Keyboard.Key.LShift:
                        break;
                    case Keyboard.Key.LAlt:
                        break;
                    case Keyboard.Key.LSystem:
                        break;
                    case Keyboard.Key.RControl:
                        break;
                    case Keyboard.Key.RShift:
                        break;
                    case Keyboard.Key.RAlt:
                        break;
                    case Keyboard.Key.RSystem:
                        break;
                    case Keyboard.Key.Menu:
                        break;
                    case Keyboard.Key.LBracket:
                        break;
                    case Keyboard.Key.RBracket:
                        break;
                    case Keyboard.Key.Semicolon:
                        break;
                    case Keyboard.Key.Comma:
                        break;
                    case Keyboard.Key.Period:
                        break;
                    case Keyboard.Key.Quote:
                        break;
                    case Keyboard.Key.Slash:
                        break;
                    case Keyboard.Key.Backslash:
                        break;
                    case Keyboard.Key.Tilde:
                        break;
                    case Keyboard.Key.Equal:
                        break;
                    case Keyboard.Key.Hyphen:
                        break;
                    case Keyboard.Key.Space:
                        break;
                    case Keyboard.Key.Backspace:
                        break;
                    case Keyboard.Key.End:
                        break;
                    case Keyboard.Key.Home:
                        break;
                    case Keyboard.Key.Insert:
                        break;
                    case Keyboard.Key.Delete:
                        break;
                    case Keyboard.Key.Add:
                        break;
                    case Keyboard.Key.Subtract:
                        break;
                    case Keyboard.Key.Multiply:
                        break;
                    case Keyboard.Key.Divide:
                        break;
                    case Keyboard.Key.Numpad0:
                        break;
                    case Keyboard.Key.Numpad1:
                        break;
                    case Keyboard.Key.Numpad2:
                        break;
                    case Keyboard.Key.Numpad3:
                        break;
                    case Keyboard.Key.Numpad4:
                        break;
                    case Keyboard.Key.Numpad5:
                        break;
                    case Keyboard.Key.Numpad6:
                        break;
                    case Keyboard.Key.Numpad7:
                        break;
                    case Keyboard.Key.Numpad8:
                        break;
                    case Keyboard.Key.Numpad9:
                        break;
                    case Keyboard.Key.F1:
                        break;
                    case Keyboard.Key.F2:
                        break;
                    case Keyboard.Key.F3:
                        break;
                    case Keyboard.Key.F4:
                        break;
                    case Keyboard.Key.F5:
                        break;
                    case Keyboard.Key.F6:
                        break;
                    case Keyboard.Key.F7:
                        break;
                    case Keyboard.Key.F8:
                        break;
                    case Keyboard.Key.F9:
                        break;
                    case Keyboard.Key.F10:
                        break;
                    case Keyboard.Key.F11:
                        break;
                    case Keyboard.Key.F12:
                        break;
                    case Keyboard.Key.F13:
                        break;
                    case Keyboard.Key.F14:
                        break;
                    case Keyboard.Key.F15:
                        break;
                    case Keyboard.Key.Pause:
                        break;
                    case Keyboard.Key.KeyCount:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
