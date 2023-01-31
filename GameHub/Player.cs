using System;
using Newtonsoft.Json;
using System.IO;

namespace GameHub
{
    class Player
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }


        public Player(string name)
        {
            Name = name;
            Wins = 0;
            Losses = 0;
        }

    }
}