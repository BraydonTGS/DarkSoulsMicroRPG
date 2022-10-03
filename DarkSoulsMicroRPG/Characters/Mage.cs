using System;
using static System.Console;
using DarkSoulsMicroRPG.Interfaces;
using DarkSoulsMicroRPG.Printing;

namespace DarkSoulsMicroRPG.Characters
{
    public class Mage : ICharacter, IFightable
    {

        public int CharacterId { get; set; }
        public string CharacterArt { get; set; } = ArtAssets.Mage;
        public ConsoleColor Color { get; set; } = ConsoleColor.Blue;
        public string Type { get; set; } = "Mage";

        public string Name { get; set; }
        public int Level { get; set; } = 1;

        public int MaxHealth { get; set; } = 15;
        public int Health { get; set; }

        public Random FightPercent { get; set; }
        public bool IsDead { get => Health <= 0; }
        public bool IsAlive { get => Health > 0; }

        public Mage(string name)
        {
            Random randomId = new Random();
            FightPercent = new Random();
            CharacterId = randomId.Next(1, 1000);

            Name = name;
            Health = MaxHealth;
        }


        public void Attack(ICharacter enemy)
        {
            if (enemy is IFightable myEnemy)
            {
                ConsoleColor previousColor = ForegroundColor;
                ForegroundColor = Color;
                Write("You summon your power and cast a glinstone arrow...");
                int randHit = FightPercent.Next(1, 101);
                if (randHit <= 60)
                {
                    WriteLine(" and it is a direct hit!!!");
                    myEnemy.TakeDamage(60);
                }
                else
                {
                    WriteLine($" {enemy.Name} dodges the attack!");

                }
                ForegroundColor = previousColor;
            }

        }

        public void Fight(ICharacter enemy)
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

