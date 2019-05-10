using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace Interface
{
    public class ViewUI
    {
        WindowUI _window;
        View _view;
        int _x;
        int _y;

        public ViewUI(WindowUI window,Vector2f initPos)
        {
            _window = window;
            _view = new View(new Vector2f(100, 100), new Vector2f(200, 200));

            _view.Center = initPos;
            _x = 0;
            _y = 0;
        }

        public Vector2f Center => _view.Center;
        public View Render => _view;
        public int X => _x;
        public int Y => _y;

        public void MoveUp(Vector2f position)
        {
            _y -= 1;
            _view.Center = position;
        }
        public void MoveDown(Vector2f position)
        {
            _y += 1;
            _view.Center = position;
        }
        public void MoveLeft(Vector2f position)
        {
            _x -= 1;
            _view.Center = position;
        }
        public void MoveRight(Vector2f position)
        {
            _x += 1;
            _view.Center = position;
        }
    }
}
