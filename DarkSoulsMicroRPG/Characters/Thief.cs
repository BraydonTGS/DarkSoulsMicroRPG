using System;
using static System.Console;
using DarkSoulsMicroRPG.Interfaces;
using DarkSoulsMicroRPG.Printing;

namespace DarkSoulsMicroRPG.Characters
{
    public class Thief : ICharacter, IFightable
    {

        public int CharacterId { get; set; }
        public string CharacterArt { get; set; } = ArtAssets.Thief;
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
        public string Type { get; set; } = "Thief";

        public string Name { get; set; }
        public int Level { get; set; } = 1;

        public int MaxHealth { get; set; } = 20;
        public int Health { get; set; }

        public bool IsDead { get => Health <= 0; }
        public bool IsAlive { get => Health > 0; }

        public Thief(string name)
        {
            Random randomId = new Random();
            CharacterId = randomId.Next(1, 1000);

            Name = name;
            Health = MaxHealth;
        }

        public void Attack(ICharacter enemy)
        {

        }

        public void TakeDamage(int damage)
        {

        }

    }
}

