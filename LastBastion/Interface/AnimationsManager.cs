using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Audio;

namespace Interface
{
    public class AnimationsManager
    {
        WindowUI _window;
        Dictionary<string, List<string>> _animationList;

        public AnimationsManager(WindowUI window, SpritesManager spritesManager)
        {
            _window = window;
            _animationList = new Dictionary<string, List<string>>();
        }

        public void Initialized()
        {
            List<string> list = new List<string>();
            list.Add("I1");
            list.Add("I2");
            list.Add("I3");
            list.Add("I4");
            list.Add("I5");
            list.Add("I6");
            list.Add("I7");
            list.Add("I8");
            _animationList.Add("I", list);
        }
        public WindowUI Window
        {
            get { return _window; }
            protected set { _window = value; }
        }
        public Dictionary<string, List<string>> AnimationsList
        {
            get { return _animationList; }
            protected set { _animationList = value; }
        }
        public void Play(string name)
        {
            Animation animation = new Animation(this, name);
        }
        public void Play(string name, string text, Color color)
        {
            Animation animation = new Animation(this, name, text, color);
        }
    }
}
