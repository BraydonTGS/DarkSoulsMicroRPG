﻿using System;
using DarkSoulsMicroRPG.Interfaces;
using DarkSoulsMicroRPG.Printing;

namespace DarkSoulsMicroRPG.Enemies
{
    public class Capra_Demon : ICharacter, IFightable
    {

        public int CharacterId { get; set; }
        public string CharacterArt { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.DarkYellow;

        public string Name { get; set; }
        public int Level { get; set; } = 10;

        public int MaxHealth { get; set; } = 20;
        public int Health { get; set; }

        public Capra_Demon()
        {
            Random randomId = new Random();
            CharacterId = randomId.Next(1, 1000);

            Health = MaxHealth;
        }
    }
}

