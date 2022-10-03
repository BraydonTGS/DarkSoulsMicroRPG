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
            string prompt = @"After arrving to Firelink shrine you decide to spend the night...

In the morning you...";
            string[] options = { " Travel to the Undead Burg", "Travel to the Undead Parish", "Travel to Blighttown", "Rest At Bonfire", "Display Status", "Give Up" };
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
                    RestAtBonfire();
                    break;
                case 4:
                    DisplayStatus();
                    break;
                case 5:
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
            if (CurrentEnemy is IFightable enemy)
            {
                if (enemy.IsDead)
                {
                    string prompt = $"You have already defeated {CurrentEnemy.Name}";
                    PrintingText.PrintMePlease(prompt);
                    PrintingText.Continue();
                    MainCharacterMenu();
                }
            }
            ICharacter capraDemon = new Capra_Demon();
            Characters.Add(capraDemon);
            CurrentEnemy = capraDemon;
            PrintingText.UndeadBurg(MyCharacter);
            ReadKey();
            PrintingText.DisplayCharacterInfo(capraDemon);
            ReadKey();
            FightPrompt();
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

        public void RestAtBonfire()
        {
            // Maybe I can add logic for how many times you can rest // 
            PrintingText.Loading();
            PrintingText.PrintTitle();
            string prompt = $"\nYou rest at the Bonfire replenshing your estus...\n";
            PrintingText.PrintMePlease(prompt);
            MyCharacter.Health = MyCharacter.MaxHealth;
            PrintingText.DisplayCharacterInfo(MyCharacter);
            PrintingText.Continue();
            MainCharacterMenu();
        }

        public void FightPrompt()
        {
            string prompt = $"You are facing {CurrentEnemy.Name}. What Would You Like to do? ";
            string[] options = { "Attack", "Run Away" };
            var userDecision = PrintingText.PrintCustomMenu(prompt, options);

            if (userDecision == 0)
            {
                BattleGround();
            }
            else if (userDecision == 1)
            {
                if (MyCharacter is IFightable main)
                {
                    int rnd = main.FightPercent.Next(1, 101);

                    if (rnd <= 0)
                    {
                        PrintingText.PrintTitle();
                        PrintingText.Loading();
                        string input = $"\n\nYou try to excape,\n\nbut you are no match for the {CurrentEnemy.Name}";
                        PrintingText.PrintMePlease(input);
                        ReadKey();
                        Clear();
                        PrintingText.PrintYouDied();
                        ExitGame();
                        ReadKey();
                    }

                    else
                    {
                        PrintingText.PrintTitle();
                        PrintingText.Loading();
                        string input = $"\n\nYou dodge the incoming attacks and rush to the ladder.\n\nOn your way up the {CurrentEnemy.Name} slashes you in the back and you take 4 points of damage.\n\nYou excape with your humanity and make it back to FireLink";
                        main.TakeDamage(4);
                        PrintingText.PrintMePlease(input);
                        ReadKey();
                        MainCharacterMenu();
                        ReadKey();
                    }
                }

            }

        }

        public void BattleGround()
        {
            if (MyCharacter is IFightable character && CurrentEnemy is IFightable enemy)
            {

                while (character.IsAlive && enemy.IsAlive)
                {
                    PrintingText.PrintTitle();
                    PrintingText.DisplayHealth(MyCharacter);
                    PrintingText.DisplayHealth(CurrentEnemy);

                    character.Attack(CurrentEnemy);
                    PrintingText.Continue();

                    if (character.IsDead || enemy.IsDead)
                    {
                        break;
                    }

                    PrintingText.PrintTitle();
                    PrintingText.DisplayHealth(MyCharacter);
                    PrintingText.DisplayHealth(CurrentEnemy);

                    enemy.Attack(MyCharacter);
                    PrintingText.Continue();
                }

                if (enemy.IsDead)
                {
                    PrintingText.PrintTitle();
                    PrintingText.DisplayCharacterInfo(MyCharacter);
                    string prompt = $"{CurrentEnemy.Name} is dead, rest at a bonfire to replenish your estus... ";
                    PrintingText.PrintMePlease(prompt);
                    PrintingText.Continue();
                    MainCharacterMenu();
                }

                if (character.IsDead)
                {
                    PrintingText.PrintTitle();
                    PrintingText.Loading();
                    PrintingText.PrintYouDied();
                    PrintingText.Continue();
                    ReadKey();
                    ExitGame();
                }


            }
        }

        public void DisplayStatus()
        {
            PrintingText.Loading();
            PrintingText.PrintTitle();
            PrintingText.DisplayCharacterInfo(MyCharacter);
            PrintingText.Continue();
            MainCharacterMenu();
        }

        // Exit //
        public void ExitGame()
        {
            PrintingText.PrintTitle();
            PrintingText.Exit();
            ReadKey();
            PrintingText.Loading();
            Environment.Exit(0);
        }
    }
}

