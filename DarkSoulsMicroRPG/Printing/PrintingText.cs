using System;
using System.Drawing;
using System.Xml.Linq;
using DarkSoulsMicroRPG.Interfaces;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;

namespace DarkSoulsMicroRPG.Printing
{
    public static class PrintingText
    {
        // Game Title //
        public static void PrintTitle()
        {
            Clear();
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;

            WriteLine(@"▓█████▄  ▄▄▄       ██▀███   ██ ▄█▀     ██████  ▒█████   █    ██  ██▓      ██████    
▒██▀ ██▌▒████▄    ▓██ ▒ ██▒ ██▄█▒    ▒██    ▒ ▒██▒  ██▒ ██  ▓██▒▓██▒    ▒██    ▒    
░██   █▌▒██  ▀█▄  ▓██ ░▄█ ▒▓███▄░    ░ ▓██▄   ▒██░  ██▒▓██  ▒██░▒██░    ░ ▓██▄      
░▓█▄   ▌░██▄▄▄▄██ ▒██▀▀█▄  ▓██ █▄      ▒   ██▒▒██   ██░▓▓█  ░██░▒██░      ▒   ██▒   
░▒████▓  ▓█   ▓██▒░██▓ ▒██▒▒██▒ █▄   ▒██████▒▒░ ████▓▒░▒▒█████▓ ░██████▒▒██████▒▒   
 ▒▒▓  ▒  ▒▒   ▓▒█░░ ▒▓ ░▒▓░▒ ▒▒ ▓▒   ▒ ▒▓▒ ▒ ░░ ▒░▒░▒░ ░▒▓▒ ▒ ▒ ░ ▒░▓  ░▒ ▒▓▒ ▒ ░   
 ░ ▒  ▒   ▒   ▒▒ ░  ░▒ ░ ▒░░ ░▒ ▒░   ░ ░▒  ░ ░  ░ ▒ ▒░ ░░▒░ ░ ░ ░ ░ ▒  ░░ ░▒  ░ ░   
 ░ ░  ░   ░   ▒     ░░   ░ ░ ░░ ░    ░  ░  ░  ░ ░ ░ ▒   ░░░ ░ ░   ░ ░   ░  ░  ░     
   ░          ░  ░   ░     ░  ░            ░      ░ ░     ░         ░  ░      ░     
 ░                                                                                  ");
            ForegroundColor = previousColor;
        }
        // You Died //
        public static void PrintYouDied()
        {
            Clear();
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;

            WriteLine(@"▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄ 
 ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌
  ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌
  ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌
  ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓ 
   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒ 
 ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒ 
 ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░ 
 ░ ░         ░ ░     ░           ░     ░     ░  ░   ░    
 ░ ░                           ░                  ░      ");

            ForegroundColor = previousColor;
        }

        // Display Character Info //
        public static void DisplayCharacterInfo(ICharacter character)
        {
            WriteLine();
            ForegroundColor = character.Color;
            WriteLine($"----------> {character.Type} <----------");
            WriteLine($"Name: {character.Name}");
            WriteLine($"\n{character.CharacterArt}\n");
            WriteLine($"{character.Name}'s Health: ({character.Health}/{character.MaxHealth})");
            WriteLine("-------------------------------->");
            ResetColor();
        }

        // Printing a Custom Menu //
        public static int PrintCustomMenu(string prompt, string[] options)
        {
            MenuPrinter selection = new MenuPrinter(prompt, options);
            int index = selection.Run();
            return index;
        }

        // Press Enter to Continue //
        public static void Continue()
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            Write("\n> Press Any Key To Continue... ");
            ReadKey();
            WriteLine();
            ForegroundColor = previousColor;
        }

        // Loading //
        public static void Loading()
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            Write("\n> Loading Please Wait");
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(750);
                Write(".");
            }
            ForegroundColor = previousColor;
        }

        // Dark Souls Intro Testing Print //
        public static void DsIntro()
        {
            string intro = "Thou who art Undead, art chosen...\n\nIn thine exodus from the Undead Asylum,\n\nmaketh pilgrimage to the land of Ancient Lords...\n\nWhen thou ringeth the Bell of Awakening,\n\nthe fate of the Undead thou shalt know.";
            PrintMePlease(intro);
        }

        // Dark Souls Lore //
        public static void Lore()
        {

            string lore = "\nIn the Age of Ancients,\n\nThe world was unformed, shrouded by fog\n\nA land of grey crags, archtrees, and everlasting dragons\n\nBut then there was Fire\n\nAnd with Fire came Disparity. Heat and cold, life and death, and of course... Light and Dark.\n\nThen, from the Dark, They came\n\nAnd found the Souls of Lords within the flame.\n\nNito, the first of the dead\n\nThe Witch of Izalith, and her daughters of chaos\n\nGwyn, the Lord of Sunlight, and his faithful knights\n\nAnd the furtive pygmy, so easily forgotten\n\nWith the Strength of Lords, they challenged the dragons.\n\nGwyn's mighty bolts peeled apart their stone scales\n\nThe witches weaved great firestorms\n\nNito unleashed a miasma of death and disease\n\nAnd Seath the Scaleless betrayed his own, and the dragons were no more\n\nThus began the Age of Fire\n\nBut soon, the flames will fade, and only Dark will remain\n\nEven now, there are only embers, and man sees not light, but only endless nights\n\nAnd amongst the living are seen, carriers of the accursed Darksign.\n\n-Prologue, Dark Souls";

            PrintMePlease(lore);
        }

        public static void Exit()
        {
            string exit = "> Press Any Key To Exit...";
            PrintMePlease(exit);
        }

        // Method for Printing one character at at time //
        public static void PrintMePlease(string input)
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < input.Length; i++)
            {
                Write(input[i]);
                Thread.Sleep(75);

                // Skip to the End of the String //
                if (KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Write(input.Substring(i + 1));
                        break;
                    }
                }
            }
            WriteLine();
            ForegroundColor = previousColor;
        }

    }
}

