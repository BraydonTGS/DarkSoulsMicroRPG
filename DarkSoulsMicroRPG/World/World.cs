using System;
using DarkSoulsMicroRPG.Factory;
using DarkSoulsMicroRPG.Interfaces;
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
            // Character Selection Menu //
            string prompt = "> Please Select Your Class: ";
            string[] options = { "Warrior", "Mage", "Thief", "Exit" };
            var characterIndex = PrintingText.PrintCustomMenu(prompt, options);
            // Validation Menu //
            string prompt2 = "> Are you sure you want to procede? ";
            string[] options2 = { "Yes", "No" };
            var yesOrNoIndex = PrintingText.PrintCustomMenu(prompt2, options2);

            if (yesOrNoIndex == 0)
            {
                PrintingText.PrintTitle();
                Write("\n> Please Enter a Name: ");
                PrintingText.Loading();
                string userName = ReadLine().Trim();
                var userCharacter = CharacterFactory.GetCharacter(characterIndex, userName);
                ShowCharacterInfo(userCharacter);
            }
            else
            {
                RunCharacterSelection();
            }
        }

        public void ShowCharacterInfo(ICharacter character)
        {
            Clear();
            PrintingText.PrintTitle();
            PrintingText.DisplayCharacterInfo(character);
            ReadKey();
        }

        public void ExitGame()
        {
            WriteLine("Press Any Key to Exit");
            ReadKey();
            Environment.Exit(0);
        }
    }
}

