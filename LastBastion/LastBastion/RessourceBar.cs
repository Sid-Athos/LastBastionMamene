using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Interface;

namespace LastBastion
{
    public class RessourceBar
    {
        Game _game;
        SpritesManager _sprites;
        float xSize;
        float ySize;

        public RessourceBar(Game game, SpritesManager sprites)
        {
            _game = game;
            _sprites = sprites;
            xSize = _game.GetWindow.GetView.Render.Size.X / 2;
            ySize = _game.GetWindow.GetView.Render.Size.Y / 2;
        }

    }

}
