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

        public int Souls { get; set; } = 1000;

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
            if (enemy is IFightable myEnemy)
            {
                ConsoleColor previousColor = ForegroundColor;
                ForegroundColor = Color;
                Write("You charge forward and swing your Great Sword with two hands...");
                int randHit = FightPercent.Next(1, 101);
                if (randHit <= 70)
                {
                    WriteLine(" and it is a direct hit!!!");
                    myEnemy.TakeDamage(4);
                }
                else
                {
                    WriteLine($" {enemy.Name} dodges the attack!");

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

