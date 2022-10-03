using System;
using static System.Console;
using DarkSoulsMicroRPG.Interfaces;
using DarkSoulsMicroRPG.Printing;

namespace DarkSoulsMicroRPG.Enemies
{
    public class Undead_Attact_Dog : ICharacter, IFightable
    {

        public int CharacterId { get; set; }
        public string CharacterArt { get; set; } = ArtAssets.UndeadDog;
        public ConsoleColor Color { get; set; } = ConsoleColor.DarkBlue;
        public string Type { get; set; } = "Beast";

        public string Name { get; set; } = "Undead Dog";
        public int Level { get; set; } = 1;

        public int MaxHealth { get; set; } = 10;
        public int Health { get; set; }

        public Random FightPercent { get; set; }
        public bool IsDead { get => Health <= 0; }
        public bool IsAlive { get => Health > 0; }

        public Undead_Attact_Dog()
        {
            Random randomId = new Random();
            CharacterId = randomId.Next(1, 1000);
            FightPercent = new Random();

            Health = MaxHealth;
        }

        public void Attack(ICharacter player)
        {

        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
    }
}

