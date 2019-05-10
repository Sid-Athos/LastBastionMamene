using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace Interface
{
    public class MapUI
    {
        SpritesManager _sprites;
        RenderWindow _window;

        public MapUI(SpritesManager sprites, RenderWindow window)
        {
            _sprites = sprites;
            _window = window;
        }

        public void Print(string name, Vector2f position)
        {
            _sprites.GetSprite(name).Scale = new Vector2f(_sprites.GetSprite(name).Scale.X, _sprites.GetSprite(name).Scale.Y);
            _sprites.GetSprite(name).Position = position;
            _window.Draw(_sprites.GetSprite(name));
        }
        public void Print(string name, Vector2f position, bool gg)
        {
            _sprites.GetSprite(name).Scale = new Vector2f(_sprites.GetSprite(name).Scale.X, _sprites.GetSprite(name).Scale.Y);
            _sprites.GetSprite(name).Position = position;
            _sprites.GetSprite(name).Color = new Color(255, 255, 255, 240);
            _window.Draw(_sprites.GetSprite(name));
        }
    }
}
