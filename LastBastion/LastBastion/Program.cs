using System;
using SFML.Audio;
using SFML.Graphics;
using Interface;

namespace LastBastion
{
    class Program
    {
        static void Main(string[] args)
        {
            Game _game = new Game();
            _game.Run();
        }
    }
}
