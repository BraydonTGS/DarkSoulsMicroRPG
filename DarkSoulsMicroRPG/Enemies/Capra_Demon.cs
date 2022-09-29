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

        public string Name { get; set; } = "Capra Demon";
        public int Level { get; set; } = 10;

        public int MaxHealth { get; set; } = 20;
        public int Health { get; set; }

        public Capra_Demon()
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

