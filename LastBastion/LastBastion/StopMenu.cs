﻿using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Graphics;

namespace LastBastion
{
    public class StopMenu
    {
        Game _game;
        Vector2f _positionMenu;
        int _target;

        public StopMenu(Game game)
        {
            _game = game;
            _target = 0;
            _positionMenu = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.Sprites.GetSprite("FrontMenu").Texture.Size.X / 2, _game.GetWindow.GetView.Render.Center.Y - _game.Sprites.GetSprite("FrontMenu").Texture.Size.Y / 2);
        }
        public void Deploy()
        {
            _target = 0;
        }
        public void Update()
        {
            //Background
            _game.Sprites.GetSprite("FrontMenu").Scale = new Vector2f(1f, 2f);
            _game.Sprites.GetSprite("FrontMenu").Position = new Vector2f(_game.GetWindow.GetView.Render.Center.X - _game.Sprites.GetSprite("FrontMenu").Texture.Size.X / 2, _game.GetWindow.GetView.Render.Center.Y - 200);
            _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("FrontMenu"));
            //Title
            _game.Sprites.Text.DisplayedString = "Last Bastion";
            _game.Sprites.Text.Position = new Vector2f(_game.Sprites.GetSprite("FrontMenu").Position.X + 5, _game.Sprites.GetSprite("FrontMenu").Position.Y + 10);
            _game.Sprites.Text.Color = new Color(0,0,0);
            _game.Sprites.Text.Scale = new Vector2f(0.8f, 0.8f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            //Save
            _game.Sprites.Text.Color = new Color(0, 0, 0);
            if (_target == 0)
            {
                _game.Sprites.Text.Color = new Color(222, 41, 2);
            }
            _game.Sprites.Text.DisplayedString = "Save Game";
            _game.Sprites.Text.Position = new Vector2f(_game.Sprites.GetSprite("FrontMenu").Position.X + 15, _game.Sprites.GetSprite("FrontMenu").Position.Y + 150);
            _game.Sprites.Text.Scale = new Vector2f(0.8f, 0.8f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
            //Quit
            _game.Sprites.Text.Color = new Color(0,0,0);
            if (_target == 1)
            {
                _game.Sprites.Text.Color = new Color(222, 41, 2);
            }
            _game.Sprites.Text.DisplayedString = "Return To Menu";
            _game.Sprites.Text.Position = new Vector2f(_game.Sprites.GetSprite("FrontMenu").Position.X + 5, _game.Sprites.GetSprite("FrontMenu").Position.Y + 220);
            _game.Sprites.Text.Scale = new Vector2f(0.6f, 0.6f);
            _game.GetWindow.Render.Draw(_game.Sprites.Text);
        }
        public int Target
        {
            get { return _target; }
            set { _target = value; }
        }
    }
}