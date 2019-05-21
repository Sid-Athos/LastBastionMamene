using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace LastBastion
{
    class Launcher
    {
        Sprite _sprite;
        RenderWindow _window;
        int k;
        bool isOpen;
        bool GameSelectOpen;

        public Launcher()
        {
            _sprite = new Sprite(new Texture("../../../../images/Launcher.jpg"));
            uint lenght = _sprite.Texture.Size.X;
            uint height = _sprite.Texture.Size.Y;
            _window = new RenderWindow(new VideoMode(lenght, height), "Launcher", Styles.Default);
            isOpen = true;
            GameSelectOpen = false;
            _window.SetMouseCursorVisible(false);
            //
            /*
            Music music = new Music("../../../../images/rosiek.wav");
            music.Loop = true;
            music.Play();
            */
            //
            k = 0;
            //
            Menu();
        }
        public void IsKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Z)
            {
                if (k != 0)
                {
                    k--;
                }
            }
            if (e.Code == Keyboard.Key.Up)
            {
                if (k != 0)
                {
                    k--;
                }
            }
            if (e.Code == Keyboard.Key.S)
            {
                if (k != 2)
                {
                    k++;
                }
            }
            if (e.Code == Keyboard.Key.Down)
            {
                if (k != 2)
                {
                    k++;
                }
            }
            if (e.Code == Keyboard.Key.Enter)
            {
                if (k == 0)
                {
                    isOpen = false;
                    _window.Close();
                    Game _game = new Game();
                    _game.Run();
                }
                if (k == 1)
                {
                    isOpen = false;
                    GameSelect();
                }
                if (k == 2)
                {
                    isOpen = false;
                    _window.Close();
                }
            }
        }
        public void Menu()
        {
            Sprite E0 = new Sprite(new Texture("../../../../images/E0L.png"));
            Sprite E1 = new Sprite(new Texture("../../../../images/TitleLauncher.png"));
            //
            E0.Position = new Vector2f(E0.Position.X + 50, E0.Position.Y + 30);
            E1.Position = new Vector2f(E1.Position.X + 1200, E1.Position.Y + 10);
            //
            Font _font = new Font("../../../../images/RINGM___.TTF");
            Text title = new Text();
            title.Font = _font;
            title.DisplayedString = "Last Bastion";
            title.Position = new Vector2f(E1.Position.X + 30, E1.Position.Y + 60);
            title.Color = new Color(0, 0, 0);
            title.CharacterSize = 70;
            Text play = new Text();
            play.Font = _font;
            play.DisplayedString = "New Game";
            play.Position = new Vector2f(245, 250);
            play.Color = new Color(0, 0, 0);
            play.CharacterSize = 70;
            Text load = new Text();
            load.Font = _font;
            load.DisplayedString = "Load Game";
            load.Position = new Vector2f(245, 450);
            load.Color = new Color(0, 0, 0);
            load.CharacterSize = 70;
            Text quit = new Text();
            quit.Font = _font;
            quit.DisplayedString = "Quit";
            quit.Position = new Vector2f(245, 650);
            quit.Color = new Color(0, 0, 0);
            quit.CharacterSize = 70;
            //
            _window.KeyPressed += IsKeyPressed;
            //
            while (isOpen)
            {
                _window.DispatchEvents();
                _window.Clear();
                //
                _window.Draw(_sprite);
                _window.Draw(E0);
                _window.Draw(E1);
                //
                if (k == 0)
                {
                    play.Color = new Color(222, 41, 2);
                    load.Color = new Color(0, 0, 0);
                    quit.Color = new Color(0, 0, 0);
                }
                if (k == 1)
                {
                    play.Color = new Color(0, 0, 0);
                    load.Color = new Color(222, 41, 2);
                    quit.Color = new Color(0, 0, 0);
                }
                if (k == 2)
                {
                    play.Color = new Color(0, 0, 0);
                    load.Color = new Color(0, 0, 0);
                    quit.Color = new Color(222, 41, 2);
                }
                //
                _window.Draw(title);
                _window.Draw(play);
                _window.Draw(load);
                _window.Draw(quit);
                //
                _window.Display();
            }
        }
        public void GameSelect()
        {
            Sprite E0 = new Sprite(new Texture("../../../../images/E0L.png"));
            E0.Position = new Vector2f(E0.Position.X + 590, E0.Position.Y + 30);
            int n = 0;
            int h = 0;
            //
            Font _font = new Font("../../../../images/RINGM___.TTF");
            Text back = new Text();
            back.Font = _font;
            back.DisplayedString = "Return";
            back.Position = new Vector2f(1100, 800);
            back.Color = new Color(0, 0, 0);
            back.CharacterSize = 50;
            Text s1 = new Text();
            s1.Font = _font;
            s1.DisplayedString = "s1";
            s1.Position = new Vector2f(900, 200);
            s1.Color = new Color(0, 0, 0);
            s1.CharacterSize = 50;
            Text s2 = new Text();
            s2.Font = _font;
            s2.DisplayedString = "s2";
            s2.Position = new Vector2f(900, 400);
            s2.Color = new Color(0, 0, 0);
            s2.CharacterSize = 50;
            Text s3 = new Text();
            s3.Font = _font;
            s3.DisplayedString = "s3";
            s3.Position = new Vector2f(900, 600);
            s3.Color = new Color(0, 0, 0);
            s3.CharacterSize = 50;
            Text s4 = new Text();
            s4.Font = _font;
            s4.DisplayedString = "s4";
            s4.Position = new Vector2f(900, 800);
            s4.Color = new Color(0, 0, 0);
            s4.CharacterSize = 50;
            Text s5 = new Text();
            s5.Font = _font;
            s5.DisplayedString = "s5";
            s5.Position = new Vector2f(900, 900);
            s5.Color = new Color(0, 0, 0);
            s5.CharacterSize = 50;
            //
            String[] list = SaveList(@"C:\Users\Rosiek\Documents\C_Sharp\LastBastionMamene\LastBastion\Save\");
            int len = list.Length;
            //
            GameSelectOpen = true;
            _window.DispatchEvents();
            //
            while (GameSelectOpen)
            {
                _window.DispatchEvents();
                _window.Clear();
                //
                _window.Draw(_sprite);
                if (len > 0)
                {
                    if (n + 1 <= len)
                    {
                        _window.Draw(s1);
                    }
                    if (n + 2 <= len)
                    {
                        _window.Draw(s1);
                    }
                    if (n + 3 <= len)
                    {
                        _window.Draw(s1);
                    }
                    if (n + 4 <= len)
                    {
                        _window.Draw(s1);
                    }
                    if (n + 5 <= len)
                    {
                        _window.Draw(s1);
                    }
                }
                _window.Draw(E0);
                _window.Draw(back);
                //
                _window.Display();
            }
        }
        public String[] SaveList(string path)
        {
            String[] list = Directory.GetFiles(path);
            return list;
        }
    }
}
