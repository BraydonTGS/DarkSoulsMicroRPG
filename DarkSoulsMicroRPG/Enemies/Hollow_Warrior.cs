using System;
using DarkSoulsMicroRPG.Interfaces;
using DarkSoulsMicroRPG.Printing;

namespace DarkSoulsMicroRPG.Enemies
{
    public class Hollow_Warrior : ICharacter, IFightable
    {

        public int CharacterId { get; set; }
        public string CharacterArt { get; set; } = ArtAssets.HollowWarrior;
        public ConsoleColor Color { get; set; } = ConsoleColor.DarkCyan;

        public string Name { get; set; } = "Hollow Warrior";
        public int Level { get; set; } = 5;

        public int MaxHealth { get; set; } = 15;
        public int Health { get; set; }

        public Hollow_Warrior()
        {
            Random randomId = new Random();
            CharacterId = randomId.Next(1, 1000);

            Health = MaxHealth;
        }
    }
}

