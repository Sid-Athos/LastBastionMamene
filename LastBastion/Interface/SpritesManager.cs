﻿using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Audio;

namespace Interface
{
    public class SpritesManager
    {
        Dictionary<string, Sprite> _sprites;
        Text _text;
        List<Music> _music;

        public SpritesManager()
        {
            _sprites = new Dictionary<string, Sprite>();
            Font _font = new Font("../../../../images/RINGM___.TTF");
            _text = new Text();
            _text.Font = _font;
            _music = new List<Music>();
            Music music = new Music("../../../../images/rosiek.wav");
            music.Loop = true;
            _music.Add(music);
            music = new Music("../../../../images/war.wav");
            music.Loop = true;
            _music.Add(music);
        }

        public void Initialized()
        {
            Texture texture;

            texture = new Texture("../../../../images/CursorFont.png");
            _sprites.Add("CursorFont", new Sprite(texture));

            texture = new Texture("../../../../images/Comet.png");
            _sprites.Add("Comet", new Sprite(texture));

            texture = new Texture("../../../../images/FrontMenu.png");
            _sprites.Add("FrontMenu", new Sprite(texture));

            texture = new Texture("../../../../images/TowerUp.png");
            _sprites.Add("TowerUp", new Sprite(texture));

            texture = new Texture("../../../../images/TowerBot.png");
            _sprites.Add("TowerBot", new Sprite(texture));

            texture = new Texture("../../../../images/TowerLeft.png");
            _sprites.Add("TowerLeft", new Sprite(texture));

            texture = new Texture("../../../../images/TowerRIght.png");
            _sprites.Add("TowerRight", new Sprite(texture));

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

            texture = new Texture("../../../../images/TopBar.png");
            _sprites.Add("TopBar", new Sprite(texture));

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

            texture = new Texture("../../../../images/Timer.png");
            _sprites.Add("Timer", new Sprite(texture));

            texture = new Texture("../../../../images/Tower.png");
            _sprites.Add("Tower", new Sprite(texture));

            texture = new Texture("../../../../images/castle01.png");
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

            texture = new Texture("../../../../images/LavaWall01.png");
            _sprites.Add("LavaWall", new Sprite(texture));

            texture = new Texture("../../../../images/LavaWall02.png");
            _sprites.Add("LavaWallRight", new Sprite(texture));

            texture = new Texture("../../../../images/LavaWall03.png");
            _sprites.Add("LavaWallLeft", new Sprite(texture));

            texture = new Texture("../../../../images/LavaWall04.png");
            _sprites.Add("LavaWallUp", new Sprite(texture));

            texture = new Texture("../../../../images/LavaWall05.png");
            _sprites.Add("LavaWallDown", new Sprite(texture));

            texture = new Texture("../../../../images/sawmill.png");
            _sprites.Add("Sawmill", new Sprite(texture));

            texture = new Texture("../../../../images/sawmillUp.png");
            _sprites.Add("SawmillUp", new Sprite(texture));

            texture = new Texture("../../../../images/MineUp.png");
            _sprites.Add("MineUp", new Sprite(texture));

            texture = new Texture("../../../../images/FarmUp.png");
            _sprites.Add("FarmUp", new Sprite(texture));

            texture = new Texture("../../../../images/TowerLUP.png");
            _sprites.Add("TowerLUP", new Sprite(texture));

            texture = new Texture("../../../../images/Wall01Up.png");
            _sprites.Add("WallLUP", new Sprite(texture));

            texture = new Texture("../../../../images/LavaWall01Up.png");
            _sprites.Add("LavaWallLUP", new Sprite(texture));

            texture = new Texture("../../../../images/HouseUp.png");
            _sprites.Add("HouseUp", new Sprite(texture));

            texture = new Texture("../../../../images/resourceBar.png");
            _sprites.Add("ResourceBar", new Sprite(texture));

            texture = new Texture("../../../../images/Gobelins.png");
            _sprites.Add("Gobelin", new Sprite(texture));

            texture = new Texture("../../../../images/VillagerIcon.png");
            _sprites.Add("VillagerIcon", new Sprite(texture));

            texture = new Texture("../../../../images/BotBar.png");
            _sprites.Add("BotBar", new Sprite(texture));

            texture = new Texture("../../../../images/Health.png");
            _sprites.Add("HealthIcon", new Sprite(texture));

            texture = new Texture("../../../../images/Armor.png");
            _sprites.Add("ArmorIcon", new Sprite(texture));

            texture = new Texture("../../../../images/Attack.png");
            _sprites.Add("AttackIcon", new Sprite(texture));
        }
        public void Update()
        {
            foreach (var item in _sprites)
            {
                item.Value.Scale = new SFML.System.Vector2f(1f, 1f);
            }
        }
        public Music Music (int n)
        {
            return _music[n];
        }
        public Sprite GetSprite(string name) => _sprites[name];
        public Text Text
        {
            get { return _text; }
            set { _text = value; }
        }
        
    }
}