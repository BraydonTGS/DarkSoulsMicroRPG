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
            PrintingText.DsIntro();
            PrintingText.Continue();
            Clear();
            PrintingText.Loading();
            PrintingText.PrintTitle();
            PrintingText.Continue();
            RunCharacterSelection();
        }

        private void RunCharacterSelection()
        {

            // Character Selection Menu //
            string prompt = "> Please Select Your Class: ";
            string[] options = { "Warrior", "Mage", "Thief" };
            var characterIndex = PrintingText.PrintCustomMenu(prompt, options);

            // Validation Menu //
            string prompt2 = "> Are you sure you want to procede? ";
            string[] options2 = { "Yes", "No" };
            var yesOrNoIndex = PrintingText.PrintCustomMenu(prompt2, options2);

            if (yesOrNoIndex == 0)
            {
                PrintingText.PrintTitle();
                PrintingText.Loading();
                PrintingText.PrintTitle();
                ForegroundColor = ConsoleColor.Red;
                Write("\n> Please Enter a Name: ");
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
            PrintingText.PrintTitle();
            PrintingText.Loading();
            PrintingText.PrintTitle();
            PrintingText.DisplayCharacterInfo(character);
            PrintingText.Continue();
            MainCharacterMenu(character);
        }

        public void MainCharacterMenu(ICharacter character)
        {
            PrintingText.PrintTitle();
            PrintingText.Loading();
            string prompt = @"After arrving to Firelink shrine you decide to rest at the bonefire...

In the morning you decide to...";
            string[] options = { " travel to the Undead Burg", "travel to the Undead Parish", "travel to Blighttown" };
            var userDecision = PrintingText.PrintCustomMenu(prompt, options);

        }

        public void ExitGame()
        {
            WriteLine("Press Any Key to Exit");
            ReadKey();
            Environment.Exit(0);
        }
    }
}

