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
            RunCharacterSelection();
        }

        private void RunCharacterSelection()
        {
            string prompt = "> Please Select Your Character: ";
            string[] options = { "Warrior", "Mage", "Thief", "Exit" };
            MenuPrinter characterSelection = new MenuPrinter(prompt, options);
            int selectedIndex = characterSelection.Run();
            Clear();
            Write("> Please Enter a Name: ");
            string userName = ReadLine().Trim();
            var userCharacter = CharacterFactory.GetCharacter(selectedIndex, userName);
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

