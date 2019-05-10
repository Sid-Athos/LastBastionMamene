using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;

namespace Interface
{
    public class SpritesManager
    {
        Dictionary<string, Sprite> _sprites;

        public SpritesManager()
        {
            _sprites = new Dictionary<string, Sprite>();
        }

        public void Initialized()
        {
            Texture texture;

            texture = new Texture("../../../../images/CursorFont.png");
            _sprites.Add("CursorFont", new Sprite(texture));

            texture = new Texture("../../../../images/CursorBoard.png");
            _sprites.Add("CursorBoard", new Sprite(texture));

            texture = new Texture("../../../../images/Tile.png");
            _sprites.Add("Tile", new Sprite(texture));

            texture = new Texture("../../../../images/Cloud.png");
            _sprites.Add("Cloud", new Sprite(texture));

            texture = new Texture("../../../../images/HideFont.png");
            _sprites.Add("HideFont", new Sprite(texture));

            texture = new Texture("../../../../images/TileWinter.png");
            _sprites.Add("TileWinter", new Sprite(texture));

            texture = new Texture("../../../../images/Cursor.png");
            _sprites.Add("Cursor", new Sprite(texture));

            texture = new Texture("../../../../images/wood.png");
            _sprites.Add("Wood", new Sprite(texture));

            texture = new Texture("../../../../images/Stone.png");
            _sprites.Add("Stone", new Sprite(texture));

            texture = new Texture("../../../../images/Bush.png");
            _sprites.Add("Bush", new Sprite(texture));

            texture = new Texture("../../../../images/woodWinter.png");
            _sprites.Add("WoodWinter", new Sprite(texture));

            texture = new Texture("../../../../images/BushWinter.png");
            _sprites.Add("BushWinter", new Sprite(texture));

            texture = new Texture("../../../../images/House.png");
            _sprites.Add("House", new Sprite(texture));

            texture = new Texture("../../../../images/castle.png");
            _sprites.Add("Castle", new Sprite(texture));

            texture = new Texture("../../../../images/sawmill.png");
            _sprites.Add("Sawmill", new Sprite(texture));
        }

        public Sprite GetSprite(string name) => _sprites[name];
    }
}
