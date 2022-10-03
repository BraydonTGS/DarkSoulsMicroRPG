using System;
using System.Drawing;
using DarkSoulsMicroRPG.Characters;
using DarkSoulsMicroRPG.Enemies;
using DarkSoulsMicroRPG.Factory;
using DarkSoulsMicroRPG.Interfaces;
using DarkSoulsMicroRPG.Printing;
using static System.Console;
namespace DarkSoulsMicroRPG.World
{
    public class World
    {
        private List<ICharacter> Characters;
        public ICharacter MyCharacter;
        public ICharacter CurrentEnemy;

        public World()
        {
            Characters = new List<ICharacter>();
        }
        // Start of the Program //
        public void Run()
        {
            Title = "Dark Souls RPG";
            PrintingText.DsIntro();
            PrintingText.Continue();
            PrintingText.Loading();
            PrintingText.PrintTitle();
            NewGameMenu();
        }

        // To Add Main Menu - New Game - View Lore - Exit //
        // Create a Typing Animation Method //

        public void NewGameMenu()
        {
            PrintingText.PrintTitle();
            string prompt = "> Menu Selection";
            string[] options = { "New Game", "Dark Souls Lore", "Exit" };
            var menuIndex = PrintingText.PrintCustomMenu(prompt, options);
            if (menuIndex == 0)
            {
                RunCharacterSelection();
            }
            else if (menuIndex == 1)
            {
                PrintingText.PrintTitle();
                PrintingText.Lore();
                PrintingText.Continue();
                PrintingText.Loading();
                NewGameMenu();
            }
            else
            {
                ExitGame();
            }
        }

        // Choose Your Character //
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
                Characters.Add(userCharacter);
                MyCharacter = userCharacter;
                ShowCharacterInfo();
            }
            else
            {
                RunCharacterSelection();
            }
        }

        // Display Character Info //
        public void ShowCharacterInfo()
        {
            PrintingText.PrintTitle();
            PrintingText.Loading();
            PrintingText.PrintTitle();
            PrintingText.DisplayCharacterInfo(MyCharacter);
            PrintingText.Continue();
            MainCharacterMenu();
        }

        // Main Menu for the Character "HUB" //
        public void MainCharacterMenu()
        {
            PrintingText.PrintTitle();
            PrintingText.Loading();
            string prompt = @"After arrving to Firelink shrine you decide to rest at the bonefire...

In the morning you decide to...";
            string[] options = { " travel to the Undead Burg", "travel to the Undead Parish", "travel to Blighttown", "give up" };
            var userDecision = PrintingText.PrintCustomMenu(prompt, options);

            switch (userDecision)
            {
                case 0:
                    UndeadBurg();
                    break;
                case 1:
                    UndeadParish();
                    break;
                case 2:
                    Blighttown();
                    break;
                case 3:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }

        public void UndeadBurg()
        {
            PrintingText.Loading();
            PrintingText.PrintTitle();
            ICharacter capraDemon = new Capra_Demon();
            Characters.Add(capraDemon);
            CurrentEnemy = capraDemon;
            PrintingText.UndeadBurg(MyCharacter);
            PrintingText.DisplayCharacterInfo(capraDemon);
            Fight();
            ReadKey();
            MainCharacterMenu();


        }

        public void UndeadParish()
        {
            PrintingText.Loading();
            PrintingText.PrintTitle();
            ICharacter hollowWarrior = new Hollow_Warrior();
            Characters.Add(hollowWarrior);
            CurrentEnemy = hollowWarrior;
            PrintingText.DisplayCharacterInfo(hollowWarrior);
            ReadKey();
            MainCharacterMenu();
        }

        public void Blighttown()
        {
            PrintingText.Loading();
            PrintingText.PrintTitle();
            ICharacter undeadDog = new Undead_Attact_Dog();
            Characters.Add(undeadDog);
            CurrentEnemy = undeadDog;
            PrintingText.DisplayCharacterInfo(undeadDog);
            ReadKey();
            MainCharacterMenu();
        }

        public void Fight()
        {
            string prompt = $"You are facing {CurrentEnemy.Name}. What Would You Like to do? ";
            string[] options = { "Fight", "Run Away" };
            var userDecision = PrintingText.PrintCustomMenu(prompt, options);

            if (userDecision == 0)
            {

            }
            else if (userDecision == 2)
            {
                WriteLine($"You try to excape, but you are no match for the {CurrentEnemy.Name}");
                PrintingText.Loading();
                PrintingText.PrintYouDied();
            }

        }

        // Exit //
        public void ExitGame()
        {
            PrintingText.Exit();
            ReadKey();
            PrintingText.Loading();
            PrintingText.PrintYouDied();
            ReadKey();
            Environment.Exit(0);
        }
    }
}

