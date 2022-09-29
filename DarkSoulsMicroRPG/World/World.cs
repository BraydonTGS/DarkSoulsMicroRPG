using System;
using DarkSoulsMicroRPG.Factory;
using DarkSoulsMicroRPG.Printing;
using static System.Console;
namespace DarkSoulsMicroRPG.World
{
    public class World
    {
        public World()
        {
        }

        public void Run()
        {
            Title = "Dark Souls RPG";
            PrintingText.Loading();
            PrintingText.PrintTitle();
            WriteLine("\n> Press Any Key To Continue...");
            ReadKey();
            RunCharacterSelection();
        }

        private void RunCharacterSelection()
        {
            string prompt = "> Please Select Your Character: ";
            string[] options = { "Warrior", "Mage", "Thief", "Exit" };
            MenuPrinter characterSelection = new MenuPrinter(prompt, options);
            int selectedIndex = characterSelection.Run();
            PrintingText.PrintTitle();
            Write("\n> Please Enter a Name: ");
            string userName = ReadLine().Trim();
            var userCharacter = CharacterFactory.GetCharacter(selectedIndex, userName);
            PrintingText.Loading();
            Clear();
            userCharacter.DisplayInfo();
            ReadKey();
            WriteLine();
        }

        public void ExitGame()
        {
            WriteLine("Press Any Key to Exit");
            ReadKey();
            Environment.Exit(0);
        }
    }
}

