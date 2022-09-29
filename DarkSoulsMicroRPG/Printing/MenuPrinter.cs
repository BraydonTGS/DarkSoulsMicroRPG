using System;
using static System.Console;
namespace DarkSoulsMicroRPG.Printing
{
    public class MenuPrinter
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public MenuPrinter(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        // Rendering The Menu //
        private void DisplayOptions()
        {
            WriteLine();
            WriteLine(Prompt);

            for (int i = 0; i < Options.Length; i++)
            {
                string currentChoice = Options[i];
                string prefix;


                if (i == SelectedIndex)
                {
                    prefix = "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"\n{prefix} > {currentChoice} <");

            }
            ResetColor();
        }

        // Running the Menu //
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                PrintingText.PrintTitle();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                // Update Selected Index //
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    // Checking Out of Bounds //
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                // Update Selected Index //
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    // Checking Out of Bounds //
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }
}


