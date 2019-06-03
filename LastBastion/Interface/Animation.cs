using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;

namespace Interface
{
    class Animation
    {
        AnimationsManager _manager;
        float _timer;
        float _lastAdd;
        string _name;
        Color _color;

        public Animation(AnimationsManager manager, string name)
        {
            _timer = 0.0f;
            _lastAdd = 0.0f;
            _name = name;
            _manager = manager;
            Play();
        }
        public Animation(AnimationsManager manager, string name, string text, Color color)
        {
            _timer = 0.0f;
            _lastAdd = 0.0f;
            _name = name;
            _color = color;
            _manager = manager;
            Play(text);
        }
        public void UpdateTimer()
        {
            float timePass = DateTime.Now.Millisecond / 1000f;
            if (timePass < _lastAdd)
            {
                float diff = 1 - _lastAdd + timePass;
                _timer = _timer + diff;
                _lastAdd = timePass;
            }
            else
            {
                _timer = _timer + (timePass - _lastAdd);
                _lastAdd = timePass;
            }
        }
        public void Play()
        {
            int t = 1;
            if (_manager.AnimationsList.ContainsKey(_name))
            {
                while (t != _manager.AnimationsList[_name].Count + 1)
                {
                    _manager.Window.Render.Clear();

                    UpdateTimer();
                    Sprite sprite = new Sprite(new Texture("../../../../images/" + _name + t + ".png"));
                    sprite.Position = new Vector2f(_manager.Window.GetView.Render.Center.X - _manager.Window.GetView.Render.Size.X / 2, _manager.Window.GetView.Render.Center.Y - _manager.Window.GetView.Render.Size.Y / 2);
                    _manager.Window.Render.Draw(sprite);
                    if (_timer > 0.2f * t)
                    {
                        t++;
                    }

                    _manager.Window.Render.Display();
                }
            }
        }
        public void Play(string f)
        {
            int t = 1;
            Text text = (new SpritesManager()).Text;
            text.DisplayedString = f;
            text.Position = new Vector2f(_manager.Window.GetView.Render.Center.X - TextSize(f), _manager.Window.GetView.Render.Center.Y);
            text.Color = _color;
            text.CharacterSize = 40;
            if (_manager.AnimationsList.ContainsKey(_name))
            {
                while (t != _manager.AnimationsList[_name].Count + 1)
                {
                    _manager.Window.Render.Clear();

                    UpdateTimer();
                    Sprite sprite = new Sprite(new Texture("../../../../images/" + _name + t + ".png"));
                    sprite.Position = new Vector2f(_manager.Window.GetView.Render.Center.X - _manager.Window.GetView.Render.Size.X / 2, _manager.Window.GetView.Render.Center.Y - _manager.Window.GetView.Render.Size.Y / 2);
                    _manager.Window.Render.Draw(sprite);
                    _manager.Window.Render.Draw(text);
                    if (_timer > 0.2f * t)
                    {
                        t++;
                    }

                    _manager.Window.Render.Display();
                }
            }
        }
        public int TextSize(string text)
        {
            return 11 * text.Length;
        }
    }
}
