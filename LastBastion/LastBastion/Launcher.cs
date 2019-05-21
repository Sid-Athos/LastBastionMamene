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
        int h;
        int len;
        List<string> list;
        bool isOpen;
        bool GameSelectOpen;
        string murgle;

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
            //
            list = SaveList(@"../../../..\Save\");
            len = list.Count;
            k = 0;
            h = 0;
            //
            _window.KeyPressed += IsKeyPressed;
            Menu();
        }
        public void IsKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Z || e.Code == Keyboard.Key.Up)
            {
                if (murgle == "Menu")
                {
                    if (k != 0)
                    {
                        k--;
                    }
                }
                if (murgle == "Select")
                {
                    if (h != 0)
                    {
                        h--;
                    }
                }
            }
            if (e.Code == Keyboard.Key.S || e.Code == Keyboard.Key.Down)
            {
                if (murgle == "Menu")
                {
                    if (k != 2)
                    {
                        k++;
                    }
                }
                if (murgle == "Select")
                {
                    if (h != len)
                    {
                        h++;
                    }
                }
            }
            if (e.Code == Keyboard.Key.Enter)
            {
                if (murgle == "Menu")
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
                if (murgle == "Select")
                {
                    if (h == len)
                    {
                        GameSelectOpen = false;
                        Menu();
                    }
                }
            }
        }
        public void Menu()
        {
            murgle = "Menu";
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
            isOpen = true;
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
            murgle = "Select";
            Sprite E0 = new Sprite(new Texture("../../../../images/E0L.png"));
            E0.Position = new Vector2f(E0.Position.X + 590, E0.Position.Y + 30);
            int n = 0;
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
            s1.DisplayedString = "erriozijgzej";
            s1.Position = new Vector2f(730, 200);
            s1.Color = new Color(0, 0, 0);
            s1.CharacterSize = 60;
            Text s2 = new Text();
            s2.Font = _font;
            s2.DisplayedString = "aopfjpajfopa";
            s2.Position = new Vector2f(730, 300);
            s2.Color = new Color(0, 0, 0);
            s2.CharacterSize = 60;
            Text s3 = new Text();
            s3.Font = _font;
            s3.DisplayedString = "apozfkpoazkfopa";
            s3.Position = new Vector2f(730, 400);
            s3.Color = new Color(0, 0, 0);
            s3.CharacterSize = 60;
            Text s4 = new Text();
            s4.Font = _font;
            s4.DisplayedString = "aofkopaofpka";
            s4.Position = new Vector2f(730, 500);
            s4.Color = new Color(0, 0, 0);
            s4.CharacterSize = 60;
            Text s5 = new Text();
            s5.Font = _font;
            s5.DisplayedString = "apofkanif";
            s5.Position = new Vector2f(730, 600);
            s5.Color = new Color(0, 0, 0);
            s5.CharacterSize = 60;
            //
            GameSelectOpen = true;
            //
            while (GameSelectOpen)
            {
                _window.DispatchEvents();
                _window.Clear();
                //
                _window.Draw(_sprite);
                _window.Draw(E0);
                if (h == n)
                {
                    s1.Color = new Color(222, 41, 2);
                    s2.Color = new Color(0, 0, 0);
                    back.Color = new Color(0, 0, 0);
                }
                if (h == n + 1)
                {
                    s1.Color = new Color(0, 0, 0);
                    s2.Color = new Color(222, 41, 2);
                    s3.Color = new Color(0, 0, 0);
                    back.Color = new Color(0, 0, 0);
                }
                if (h == n + 2)
                {
                    s2.Color = new Color(0, 0, 0);
                    s3.Color = new Color(222, 41, 2);
                    s4.Color = new Color(0, 0, 0);
                    back.Color = new Color(0, 0, 0);
                }
                if (h == n + 3)
                {
                    s3.Color = new Color(0, 0, 0);
                    s4.Color = new Color(222, 41, 2);
                    s5.Color = new Color(0, 0, 0);
                    back.Color = new Color(0, 0, 0);
                }
                if (h == n + 4)
                {
                    s1.Color = new Color(0, 0, 0);
                    s4.Color = new Color(0, 0, 0);
                    s5.Color = new Color(222, 41, 2);
                    back.Color = new Color(0, 0, 0);
                }
                if (len > 0)
                {
                    if (n + 1 <= len)
                    {
                        s1.DisplayedString = list[n];
                        _window.Draw(s1);
                    }
                    if (n + 2 <= len)
                    {
                        s2.DisplayedString = list[n + 1];
                        _window.Draw(s2);
                    }
                    if (n + 3 <= len)
                    {
                        s3.DisplayedString = list[n + 2];
                        _window.Draw(s3);
                    }
                    if (n + 4 <= len)
                    {
                        s4.DisplayedString = list[n + 3];
                        _window.Draw(s4);
                    }
                    if (n + 5 <= len)
                    {
                        s5.DisplayedString = list[n + 4];
                        _window.Draw(s5);
                    }
                }
                if (h == len)
                {
                    s1.Color = new Color(0, 0, 0);
                    s2.Color = new Color(0, 0, 0);
                    s3.Color = new Color(0, 0, 0);
                    s4.Color = new Color(0, 0, 0);
                    s5.Color = new Color(0, 0, 0);
                    back.Color = new Color(222, 41, 2);
                }
                if (h == n + 5)
                {
                    n = n + 5;
                }
                if (h == n - 1)
                {
                    n = n - 5;
                }
                _window.Draw(back);
                //
                _window.Display();
            }
        }
        public List<string> SaveList(string path)
        {
            String[] directory = Directory.GetFiles(path);
            List<string> list = new List<string>();
            string t1 = "";
            string name = "";
            foreach (var item in directory)
            {
                int len = item.Length;
                name = "";
                t1 = "";
                for (int i = 0; i < len; i++)
                {
                    if (t1 == path)
                    {
                        name += item[i];
                    }
                    else
                    {
                        t1 += item[i];
                    }
                }
                if (name != "")
                {
                    if (!list.Contains(name))
                    {
                        list.Add(name);
                    }
                }
            }
            return list;
        }
    }
}