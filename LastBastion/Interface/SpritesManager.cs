using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;

namespace Interface
{
    public class SpritesManager
    {
        Dictionary<string, Sprite> _sprites;
        Text _text;

        public SpritesManager()
        {
            _sprites = new Dictionary<string, Sprite>();
            Font _font = new Font("../../../../images/RINGM___.TTF");
            _text = new Text();
            _text.Font = _font; 
        }

        public void Initialized()
        {
            Texture texture;

            texture = new Texture("../../../../images/CursorFont.png");
            _sprites.Add("CursorFont", new Sprite(texture));

            texture = new Texture("../../../../images/IconFont.png");
            _sprites.Add("IconFont", new Sprite(texture));

            texture = new Texture("../../../../images/IconBoard.png");
            _sprites.Add("IconBoard", new Sprite(texture));

            texture = new Texture("../../../../images/HousIcon.jpg");
            _sprites.Add("HouseIcon", new Sprite(texture));

            texture = new Texture("../../../../images/CursorBoard.png");
            _sprites.Add("CursorBoard", new Sprite(texture));

            texture = new Texture("../../../../images/Tile.png");
            _sprites.Add("Tile", new Sprite(texture));

            texture = new Texture("../../../../images/Cloud.png");
            _sprites.Add("Cloud", new Sprite(texture));

            texture = new Texture("../../../../images/Mine.png");
            _sprites.Add("Mine", new Sprite(texture));

            texture = new Texture("../../../../images/Farm.png");
            _sprites.Add("Farm", new Sprite(texture));

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

            texture = new Texture("../../../../images/Tower.png");
            _sprites.Add("Tower", new Sprite(texture));

            texture = new Texture("../../../../images/castle.png");
            _sprites.Add("Castle", new Sprite(texture));

            texture = new Texture("../../../../images/Wall01.png");
            _sprites.Add("Wall", new Sprite(texture));

            texture = new Texture("../../../../images/Wall02.png");
            _sprites.Add("WallRight", new Sprite(texture));

            texture = new Texture("../../../../images/Wall03.png");
            _sprites.Add("WallLeft", new Sprite(texture));

            texture = new Texture("../../../../images/Wall04.png");
            _sprites.Add("WallUp", new Sprite(texture));

            texture = new Texture("../../../../images/Wall05.png");
            _sprites.Add("WallDown", new Sprite(texture));

            texture = new Texture("../../../../images/sawmill.png");
            _sprites.Add("Sawmill", new Sprite(texture));
        }
        public void Update()
        {
            foreach (var item in _sprites)
            {
                item.Value.Scale = new SFML.System.Vector2f(1f, 1f);
            }
        }
        public Sprite GetSprite(string name) => _sprites[name];
        public Text GetText => _text;
    }
}
