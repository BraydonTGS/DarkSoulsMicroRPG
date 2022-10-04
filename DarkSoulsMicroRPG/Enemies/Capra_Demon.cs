using System;
using static System.Console;
using DarkSoulsMicroRPG.Interfaces;
using DarkSoulsMicroRPG.Printing;

namespace DarkSoulsMicroRPG.Enemies
{
    public class Capra_Demon : ICharacter, IFightable
    {

        public int CharacterId { get; set; }
        public string CharacterArt { get; set; } = ArtAssets.CapraDemon;
        public ConsoleColor Color { get; set; } = ConsoleColor.DarkYellow;
        public string Type { get; set; } = "Demon";

        public string Name { get; set; } = "Capra Demon";
        public int Level { get; set; } = 10;

        public int Souls { get; set; } = 1000;

        public int MaxHealth { get; set; } = 25;
        public int Health { get; set; }

        public Random FightPercent { get; set; }
        public bool IsDead { get => Health <= 0; }
        public bool IsAlive { get => Health > 0; }

        public Capra_Demon()
        {
            Random randomId = new Random();
            CharacterId = randomId.Next(1, 1000);
            FightPercent = new Random();

            Health = MaxHealth;
        }

        public void Attack(ICharacter player)
        {
            if (player is IFightable myPlayer)
            {
                ConsoleColor previousColor = ForegroundColor;
                ForegroundColor = Color;
                Write($"Capra Demon lunges forward and strikes at {player.Name}...");
                int randHit = FightPercent.Next(1, 101);
                if (randHit <= 25)
                {
                    WriteLine(" and it is a direct hit!!!");
                    myPlayer.TakeDamage(5);
                }
                else
                {
                    WriteLine($" {player.Name} dodges the attack!");

                }
                ForegroundColor = previousColor;
            }
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

