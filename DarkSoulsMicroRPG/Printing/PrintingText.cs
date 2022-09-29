using System;
using System.Drawing;
using System.Xml.Linq;
using DarkSoulsMicroRPG.Interfaces;
using static System.Console;
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

        // Loading //
        public static void Loading()
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            Write("\n> Loading Please Wait");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Write(".");
            }
            ForegroundColor = previousColor;
        }

    }
}

