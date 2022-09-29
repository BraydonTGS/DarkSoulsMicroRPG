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

        public string Name { get; set; }
        public int Level { get; set; } = 1;

        public int MaxHealth { get; set; } = 15;
        public int Health { get; set; }

        public Mage(string name)
        {
            Random randomId = new Random();
            CharacterId = randomId.Next(1, 1000);

            Name = name;
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

