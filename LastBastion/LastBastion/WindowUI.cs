using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace Interface
{
    public class WindowUI
    {
        RenderWindow _window;
        ViewUI _view;
        SpritesManager _sprites;

        public WindowUI(SpritesManager sprites,Vector2f initPos)
        {
            _sprites = sprites;
            _window = new RenderWindow(new VideoMode(1500, 1500), "Last Bastion", Styles.Default);
            _view = new ViewUI(this,initPos);
        }

        public RenderWindow Render => _window;
        public ViewUI GetView => _view;

        public void PrintCursor()
        {
            _sprites.GetSprite("CursorFont").Color = new Color(255, 255, 255, 128);
            _sprites.GetSprite("CursorFont").Position = _view.Center;
            _sprites.GetSprite("CursorBoard").Position = _view.Center;
            _window.Draw(_sprites.GetSprite("CursorFont"));
            _window.Draw(_sprites.GetSprite("CursorBoard"));
        }
    }
}
