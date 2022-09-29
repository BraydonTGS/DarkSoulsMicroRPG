using System;
using DarkSoulsMicroRPG.Interfaces;
using DarkSoulsMicroRPG.Printing;

namespace DarkSoulsMicroRPG.Enemies
{
    public class Undead_Attact_Dog : ICharacter, IFightable
    {

        public int CharacterId { get; set; }
        public string CharacterArt { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.DarkBlue;

        public string Name { get; set; }
        public int Level { get; set; } = 1;

        public int MaxHealth { get; set; } = 10;
        public int Health { get; set; }

        public Undead_Attact_Dog()
        {
            Random randomId = new Random();
            CharacterId = randomId.Next(1, 1000);

            Health = MaxHealth;

        }
    }
}

