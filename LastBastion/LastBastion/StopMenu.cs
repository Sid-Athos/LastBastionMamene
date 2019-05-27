using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace LastBastion
{
    class StopMenu
    {
        Game _game;
        Vector2f _positionMenu;

        public StopMenu(Game game)
        {
            _game = game;
            _positionMenu = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.Sprites.GetSprite("FrontMenu").Texture.Size.X / 2, _game.GetWindow.GetView.Render.Center.Y - _game.Sprites.GetSprite("FrontMenu").Texture.Size.Y / 2);
        }
        public void Update()
        {
            //Background
            _game.Sprites.GetSprite("FrontMenu").Scale = new Vector2f(1f, 2f);
            _game.Sprites.GetSprite("FrontMenu").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.Sprites.GetSprite("FrontMenu").Texture.Size.X / 2, _game.GetWindow.GetView.Render.Center.Y - 200);
            _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("FrontMenu"));
            //Title
            _game.Sprites.Text.DisplayedString = "Last Bastion";
            _game.Sprites.Text.Position = new Vector2f(_game.Sprites.GetSprite("FrontMenu").Position.X, _game.Sprites.GetSprite("FrontMenu").Position.Y);
            _game.Sprites.Text.Scale = new Vector2f(0.5f, 0.5f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
        }
    }
}
