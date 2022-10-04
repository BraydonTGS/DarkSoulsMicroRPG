using System;
using static System.Console;
using DarkSoulsMicroRPG.Interfaces;
using DarkSoulsMicroRPG.Printing;

namespace DarkSoulsMicroRPG.Enemies
{
    public class Hollow_Warrior : ICharacter, IFightable
    {

        public int CharacterId { get; set; }
        public string CharacterArt { get; set; } = ArtAssets.HollowWarrior;
        public ConsoleColor Color { get; set; } = ConsoleColor.DarkCyan;
        public string Type { get; set; } = "Warrior";

        public string Name { get; set; } = "Hollow Warrior";
        public int Level { get; set; } = 5;

        public int Souls { get; set; } = 1000;

        public int MaxHealth { get; set; } = 15;
        public int Health { get; set; }

        public Random FightPercent { get; set; }
        public bool IsDead { get => Health <= 0; }
        public bool IsAlive { get => Health > 0; }

        public Hollow_Warrior()
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
                Write($"The Hollow Warrior charges forward and slashes at {player.Name}...");
                int randHit = FightPercent.Next(1, 101);
                if (randHit <= 90)
                {
                    WriteLine(" and it is a direct hit!!!");
                    myPlayer.TakeDamage(2);
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

