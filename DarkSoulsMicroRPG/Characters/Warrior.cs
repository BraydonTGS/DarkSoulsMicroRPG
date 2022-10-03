using System;
using static System.Console;
using DarkSoulsMicroRPG.Interfaces;
using DarkSoulsMicroRPG.Printing;

namespace DarkSoulsMicroRPG.Characters
{
    public class Warrior : ICharacter, IFightable
    {

        public int CharacterId { get; set; }
        public string CharacterArt { get; set; } = ArtAssets.Warrior;
        public ConsoleColor Color { get; set; } = ConsoleColor.Cyan;
        public string Type { get; set; } = "Warrior";

        public string Name { get; set; }
        public int Level { get; set; } = 1;

        public int MaxHealth { get; set; } = 25;
        public int Health { get; set; }

        public Random FightPercent { get; set; }
        public bool IsDead { get => Health <= 0; }
        public bool IsAlive { get => Health > 0; }

        public Warrior(string name)
        {
            Random randomId = new Random();
            CharacterId = randomId.Next(1, 1000);
            FightPercent = new Random();

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

