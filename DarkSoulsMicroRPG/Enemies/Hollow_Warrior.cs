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

        // Display Character Info //
        public void DisplayInfo()
        {
            WriteLine();
            ForegroundColor = Color;
            WriteLine($"--- {Name} ---");
            WriteLine($"\n{CharacterArt}\n");
            WriteLine($"Health: {Health}");
            WriteLine("----------------");
            ResetColor();
        }
    }
}

