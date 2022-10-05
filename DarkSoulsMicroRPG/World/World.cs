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
        private List<ICharacter> Enemies;
        public ICharacter MyCharacter;
        public ICharacter CurrentEnemy;

        public World()
        {
            Characters = new List<ICharacter>();
            Enemies = new List<ICharacter>();
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
            string[] options = { " Travel to the Undead Burg", "Travel to the Undead Parish", "Travel to Blighttown", "Ring Bell of Awakening", "Rest At Bonfire", "Display Status", "Give Up" };
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
                    RingBellOfAwakening();
                    break;
                case 4:
                    RestAtBonfire();
                    break;
                case 5:
                    DisplayStatus();
                    break;
                case 6:
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
            var burgEnemy = Enemies.FirstOrDefault(enm => enm.Name == "Capra Demon");
            if (burgEnemy is IFightable enemy)
            {
                if (enemy.IsDead)
                {
                    string prompt = $"\nYou have already defeated {CurrentEnemy.Name}";
                    PrintingText.PrintMePlease(prompt);
                    PrintingText.Continue();
                    MainCharacterMenu();
                }
            }
            ICharacter capraDemon = new Capra_Demon();
            Enemies.Add(capraDemon);
            CurrentEnemy = capraDemon;
            PrintingText.UndeadBurg(MyCharacter);
            PrintingText.Continue();
            PrintingText.PrintTitle();
            PrintingText.DisplayCharacterInfo(capraDemon);
            PrintingText.Continue();
            ReadKey();
            FightPrompt();
        }

        public void UndeadParish()
        {
            PrintingText.Loading();
            PrintingText.PrintTitle();
            var parishEnemy = Enemies.FirstOrDefault(enm => enm.Name == "Hollow Warrior");
            if (parishEnemy is IFightable enemy)
            {
                if (enemy.IsDead)
                {
                    string prompt = $"\nYou have already defeated {CurrentEnemy.Name}";
                    PrintingText.PrintMePlease(prompt);
                    PrintingText.Continue();
                    MainCharacterMenu();
                }
            }
            ICharacter hollowWarrior = new Hollow_Warrior();
            Enemies.Add(hollowWarrior);
            CurrentEnemy = hollowWarrior;
            PrintingText.UndeadParish(MyCharacter);
            PrintingText.Continue();
            PrintingText.PrintTitle();
            PrintingText.DisplayCharacterInfo(hollowWarrior);
            PrintingText.Continue();
            FightPrompt();
        }

        public void Blighttown()
        {
            PrintingText.Loading();
            PrintingText.PrintTitle();
            var blightEnemy = Enemies.FirstOrDefault(enm => enm.Name == "Undead Dog");
            if (blightEnemy is IFightable enemy)
            {
                if (enemy.IsDead)
                {
                    string prompt = $"\nYou have already defeated the {CurrentEnemy.Name}";
                    PrintingText.PrintMePlease(prompt);
                    PrintingText.Continue();
                    MainCharacterMenu();
                }
            }
            ICharacter undeadDog = new Undead_Attact_Dog();
            Enemies.Add(undeadDog);
            CurrentEnemy = undeadDog;
            PrintingText.Blighttown(MyCharacter);
            PrintingText.Continue();
            PrintingText.PrintTitle();
            PrintingText.DisplayCharacterInfo(undeadDog);
            PrintingText.Continue();
            FightPrompt();
        }

        public void RestAtBonfire()
        {
            if (MyCharacter.Souls == 0)
            {
                PrintingText.Loading();
                PrintingText.PrintTitle();
                string prompt1 = $"\nThe fire was extinguished... you can no longer rest here...\n";
                PrintingText.PrintMePlease(prompt1);
                PrintingText.DisplayCharacterInfo(MyCharacter);
                PrintingText.Continue();

            }
            else
            {
                PrintingText.Loading();
                PrintingText.PrintTitle();
                string prompt = $"\nYou rest at the Bonfire replenshing your estus...\n";
                PrintingText.PrintMePlease(prompt);
                MyCharacter.Health = MyCharacter.MaxHealth;
                PrintingText.DisplayCharacterInfo(MyCharacter);
                PrintingText.Continue();

            }
            MyCharacter.Souls -= 500;
            MainCharacterMenu();
        }

        public void RingBellOfAwakening()
        {
            int DeadCounter = 0;
            foreach (var boss in Enemies)
            {
                if (boss is IFightable miniBoss)
                {
                    if (miniBoss.IsDead)
                    {
                        DeadCounter++;
                    }
                }
            }
            while (DeadCounter < 3)
            {
                PrintingText.Loading();
                PrintingText.PrintTitle();
                string prompt = $"\n You must defeat 3 enemies before you can ring the bell...";
                PrintingText.PrintMePlease(prompt);
                PrintingText.Continue();
                MainCharacterMenu();

            }
            PrintingText.Loading();
            PrintingText.PrintTitle();
            PrintingText.PrintYouWon();
            PrintingText.Continue();
            StartANewGame();
            ReadKey();
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
                    string prompt = $"\n{CurrentEnemy.Name} is dead, rest at a bonfire to replenish your estus... ";
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
                    StartANewGame();

                }
            }
        }

        // Display Character Status in Game //
        public void DisplayStatus()
        {
            PrintingText.Loading();
            PrintingText.PrintTitle();
            PrintingText.DisplayCharacterInfo(MyCharacter);
            PrintingText.Continue();
            MainCharacterMenu();
        }

        public void StartANewGame()
        {
            PrintingText.Loading();
            PrintingText.PrintTitle();

            string prompt = "> Would you like to play again? ";
            string[] options = { "Yes", "No" };

            var selectedIndex = PrintingText.PrintCustomMenu(prompt, options);

            if (selectedIndex == 0)
            {
                World newWorld = new World();
                newWorld.Run();
            }
            else if (selectedIndex == 1)
            {
                ExitGame();
            }
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

