using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using game.Weapon;
using static System.Net.Mime.MediaTypeNames;

namespace util.RenderHelper
{
    internal class RenderHelper
    {

        /// <summary>
        /// Renders the weapon information, where the color of the weapon name is dependent on the rarity of the weapon.
        /// </summary>
        public void RenderWeaponContext(Weapon weapon, int StartLeft, int StartTop)
        {
            if (weapon.isWeaponContextComplete(weapon))
            {
                (int currL, int currT) = Console.GetCursorPosition();

                // current
                ConsoleColor color = Console.ForegroundColor;          

                Console.SetCursorPosition(StartLeft, StartTop);

                Console.ForegroundColor = weapon.getRarity(weapon) switch
                {
                    Weapon.Rarity.COMMON => ConsoleColor.DarkGray,
                    Weapon.Rarity.UNCOMMON => ConsoleColor.Gray,
                    Weapon.Rarity.RARE => ConsoleColor.Green,
                    Weapon.Rarity.EPIC => ConsoleColor.Magenta,
                    Weapon.Rarity.LEGENDARY => ConsoleColor.DarkYellow,
                    Weapon.Rarity.MYTHIC => ConsoleColor.Red,
                    _ => Console.ForegroundColor
                };

                Console.WriteLine($"{weapon.Name} ->");
                Console.ForegroundColor = color;

                Console.SetCursorPosition(StartLeft, StartTop + 1);

                Console.WriteLine(weapon.Description);

                Console.SetCursorPosition(StartLeft, StartTop + 2);

                Console.Write($"Damage: {weapon.Damage}" + " | " + $"Cooldown: {weapon.Cooldown}");

                Console.SetCursorPosition(StartLeft, StartTop + 3);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"[ ID: {weapon.ID} ]");
                Console.ForegroundColor = color;

                Console.SetCursorPosition(currL, currT); 
            }
        }

        /// <summary>
        /// Renders a string in the middle of the screen, fitted to the strings lenght.
        /// </summary>
        public void RenderCenteredText(string text, int centerTopOffset, bool infoBox)
        {
            int windowHeight = Console.WindowHeight;
            int windowWidht = Console.WindowWidth;

            int centerWindowHeight = windowHeight / 2;
            int centerWindowWidht = windowWidht / 2;

            centerWindowHeight -= centerTopOffset;

            centerWindowWidht -= text.Length / 2;
            Console.SetCursorPosition(centerWindowWidht, centerWindowHeight);

            if (infoBox)
            {
                Console.Write("* " + text + " *");
            }
            else
            {
                Console.Write(text);
            }
        }

        /// <summary>
        /// Renders a temporary header message at the top of the console.
        /// </summary>
        public void RenderHeaderText(string text, bool isInfo, bool isHint, bool isNormal, int topOffset, int duration, bool animatedFadeOut)
        {

            (int oldCursorPosWidht, int oldCursorPosHeight) = Console.GetCursorPosition();

            if (topOffset > 0) { return; }

            int windowHeightToRender = Console.WindowTop - topOffset;
            int halfWidht;

            ConsoleColor currentColor = Console.ForegroundColor;

            if (isInfo == true && isHint == false && isNormal == false)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                string final_text = $@"[INFO] -> {text} <- [INFO]";
                Console.SetCursorPosition(GetHalfWidht(final_text, true), windowHeightToRender);
                Console.WriteLine(final_text);
                Thread.Sleep(duration);

                // here, i need to go to iterate trough each point of the final_text string, and replace it by ""
                if (animatedFadeOut == false)
                {
                    Console.SetCursorPosition(GetHalfWidht(final_text, true), windowHeightToRender);
                    Console.Write(new string(' ', final_text.Length));
                    Console.ForegroundColor = currentColor;
                } 
                else if (animatedFadeOut == true)
                {
                    int startX = GetHalfWidht(final_text, true);
                    int y = windowHeightToRender;

                    for (int i = 0; i < final_text.Length; i++)
                    {
                        Console.SetCursorPosition(startX + i, y);
                        Console.Write(' ');   
                        Thread.Sleep(20);     
                    }

                    Console.ForegroundColor = currentColor;
                }
                
            }
            else if (isInfo == false && isNormal == false && isHint == true)
            {
                string final_text = $@"[HINT] -> {text} <- [HINT]";
                Console.SetCursorPosition(GetHalfWidht(final_text, true), windowHeightToRender);
                Console.WriteLine(final_text);
                Thread.Sleep(duration);

                // here, i need to go to iterate trough each point of the final_text string, and replace it by ""
                if (animatedFadeOut == false)
                {
                    Console.SetCursorPosition(GetHalfWidht(final_text, true), windowHeightToRender);
                    Console.Write(new string(' ', final_text.Length));
                    Console.ForegroundColor = currentColor;
                }
                else if (animatedFadeOut == true)
                {
                    int startX = GetHalfWidht(final_text, true);
                    int y = windowHeightToRender;

                    for (int i = 0; i < final_text.Length; i++)
                    {
                        Console.SetCursorPosition(startX + i, y);
                        Console.Write(' ');
                        Thread.Sleep(20);
                    }

                    Console.ForegroundColor = currentColor;
                }
            }
            else if (isInfo == false && isNormal == true && isHint == false)
            {
                string final_text = $@"-> {text} <-";
                Console.SetCursorPosition(GetHalfWidht(final_text, true), windowHeightToRender);
                Console.WriteLine(final_text);
                Thread.Sleep(duration);

                // here, i need to go to iterate trough each point of the final_text string, and replace it by ""
                if (animatedFadeOut == false)
                {
                    Console.SetCursorPosition(GetHalfWidht(final_text, true), windowHeightToRender);
                    Console.Write(new string(' ', final_text.Length));
                    Console.ForegroundColor = currentColor;
                }
                else if (animatedFadeOut == true)
                {
                    int startX = GetHalfWidht(final_text, true);
                    int y = windowHeightToRender;

                    for (int i = 0; i < final_text.Length; i++)
                    {
                        Console.SetCursorPosition(startX + i, y);
                        Console.Write(' ');
                        Thread.Sleep(20);
                    }

                    Console.ForegroundColor = currentColor;
                }
            }

            Console.SetCursorPosition(oldCursorPosWidht, oldCursorPosHeight);
        }

        /// <summary>
        /// Private, a helper method to get the accurate half widht of the consoles visible window
        /// </summary>
        /// <param name="accurate">wheather to subtract the lenght of the text divided by 2 from the window widht</param>
        /// <returns></returns>
        private int GetHalfWidht(string text, bool accurate)
        {
            int windowWidht = Console.WindowWidth;
            int centerWindowWidht = windowWidht / 2;

            centerWindowWidht = windowWidht / 2;
            centerWindowWidht -= text.Length / 2;

            return centerWindowWidht;
        }

        private (int centerWindowWidht, int centerWindowHeight) GetCenter()
        {
            int windowHeight = Console.WindowHeight;
            int windowWidht = Console.WindowWidth;

            int centerWindowHeight = windowHeight / 2;
            int centerWindowWidht = windowWidht / 2;

            return (centerWindowWidht, centerWindowHeight);
        }


        public string RenderDialogueTB(string source ,string Dialogue, string answer_1, string answer_2, string answer_3, int correct_answer, bool animated)
        {
            if (Dialogue.Length > 420) { return "Error: Dialogue lenght exeeds 420 chars!"; }

            (int r, int _WindowHeightTopEntrypoint) = DialogueTBentrypoint();


            // general + 1
            int WindowHeightBottomEntrypoint = _WindowHeightTopEntrypoint + 5;

            int WindowHeightTopEntrypoint = WindowHeightBottomEntrypoint - 9;

            double RightCorner = Console.WindowWidth / 2 * 1.5;
            double LeftCorner = Console.WindowWidth / 2 / 1.6;

            int width = (int)(RightCorner - LeftCorner + 1);
            int height = WindowHeightBottomEntrypoint - WindowHeightTopEntrypoint + 1;

            for (int y = WindowHeightTopEntrypoint + 1; y < WindowHeightBottomEntrypoint; y++)
            {
                for (int x = (int)LeftCorner + 1; x < (int)RightCorner; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                }
            }

            source = CapitalizeFirstLetter(source);

            Console.SetCursorPosition((int)LeftCorner + 1, WindowHeightTopEntrypoint - 1);
            Console.Write($"{source}" + ":");
            Console.SetCursorPosition((int)LeftCorner, WindowHeightTopEntrypoint);
            Console.Write("╔"); // Top-Left
            Console.SetCursorPosition((int)RightCorner, WindowHeightTopEntrypoint);
            Console.Write("╗"); // Top-Right
            Console.SetCursorPosition((int)LeftCorner, WindowHeightBottomEntrypoint);
            Console.Write("╚"); // Bottom-Left
            Console.SetCursorPosition((int)RightCorner, WindowHeightBottomEntrypoint);
            Console.Write("╝"); // Bottom-Right

            for (int x = 1; x < width; x++)
            {
                Console.SetCursorPosition((int)LeftCorner + x, WindowHeightTopEntrypoint);
                Console.Write("═");
                Console.SetCursorPosition((int)LeftCorner + x, WindowHeightBottomEntrypoint);
                Console.Write("═");
            }

            for (int y = 1; y < height; y++)
            {
                Console.SetCursorPosition((int)LeftCorner, WindowHeightTopEntrypoint + y);
                Console.Write("║");
                Console.SetCursorPosition((int)RightCorner, WindowHeightTopEntrypoint + y);
                Console.Write("║");
            }

            string dialogue = Dialogue;

            int innerWidth = (int)(RightCorner - LeftCorner - 3);
            int chunkSize = innerWidth + 1;

            List<string> chunks = new List<string>();

            for (int i = 0; i < dialogue.Length; i += chunkSize)
            {
                int size = Math.Min(chunkSize, dialogue.Length - i);
                chunks.Add(dialogue.Substring(i, size));
            }

            for (int j = 0; j < chunks.Count; j++)
            {
                int cursorX = (int)LeftCorner + 2;
                int cursorY = WindowHeightTopEntrypoint + 1 + j;

                if (cursorY >= WindowHeightBottomEntrypoint)
                    break;

                Console.SetCursorPosition(cursorX, cursorY);
                WriteDialogue(chunks[j], animated);
            }

            int answerY = WindowHeightBottomEntrypoint - 3;

            Console.SetCursorPosition((int)LeftCorner + 2, answerY);
            List<string> options = new List<string>();

            if (!string.IsNullOrWhiteSpace(answer_1))
                options.Add($"1- {answer_1}");

            if (!string.IsNullOrWhiteSpace(answer_2))
                options.Add($"2- {answer_2}");

            if (!string.IsNullOrWhiteSpace(answer_3))
                options.Add($"3- {answer_3}");

            Console.Write("Choose:  " + string.Join(" | ", options));



            Console.SetCursorPosition((int)LeftCorner + 2, answerY + 1);
            string Answer;
            while (true)
            {
                Console.Write("-> ");
                Answer = Console.ReadLine()?.Trim(); // remove whitespace

                if (Answer == "1" || Answer == "2" || Answer == "3")
                    break; // valid input, exit loop

                Console.SetCursorPosition((int)LeftCorner + 2, answerY);

                Console.Write("Choose:  " + string.Join(" | ", options));
                Console.SetCursorPosition((int)LeftCorner + 2, answerY + 1);
            }


            if (Answer == correct_answer.ToString() && Answer != "")
            {
                return "correct";
            }
            else
            {
                return Answer;
            }
        }

        string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        void WriteDialogue(string text, bool animated)
        {
            if (!animated)
            {
                Console.Write(text);
                return;
            }

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
        }

        /// <summary>
        /// Returns the top left corner, of where to render a dialogue textbox.
        /// </summary>
        /// <returns>(int) Dwindowidht, (int) DwindowHeight</returns>
        private (int DwindowWidht, int DwindowHeight) DialogueTBentrypoint()
        {
            (int windowWidht, int windowHeight) = GetCenter();

            double DwindowHeight = windowHeight;
            double DwindowWidht = windowWidht;

            DwindowHeight *= 2;
            DwindowWidht /= 2 / 1.3;

            return ((int)DwindowWidht, (int)DwindowHeight);
        }

        public void RenderLoadingScreen(int duration)
        {
            Console.Clear();
            string loadingScreen = @$"
                                                                                      
  ▄▄▄                                                        ▄▄    ▄▄▄▄▄▄▄            
 █▀██  ██  ██▀▀     █▄       █▄                             ██    █▀██▀▀▀     █▄      
   ██  ██  ██      ▄██▄      ██          ▄                 ▄██▄     ██       ▄██▄     
   ██  ██  ██ ▄▀▀█▄ ██ ▄███▀ ████▄ ▄█▀█▄ ████▄▄██▀█   ▄███▄ ██      ███▀▄▀▀█▄ ██ ▄█▀█▄
   ██▄ ██▄ ██ ▄█▀██ ██ ██    ██ ██ ██▄█▀ ██   ▀███▄   ██ ██ ██    ▄ ██  ▄█▀██ ██ ██▄█▀
   ▀████▀███▀▄▀█▄██▄██▄▀███▄▄██ ██▄▀█▄▄▄▄█▀  █▄▄██▀  ▄▀███▀▄██    ▀██▀ ▄▀█▄██▄██▄▀█▄▄▄
                                                            ██                        
                                                           ▀▀                         
";

            string[] lines = loadingScreen
                .Trim('\n', '\r')
                .Split('\n');

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            int artWidth = lines.Max(line => line.Length);
            int artHeight = lines.Length;

            int startX = Math.Max(0, (windowWidth - artWidth) / 2);
            int startY = Math.Max(0, (windowHeight - artHeight) / 2);

            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(startX, startY + i);
                Console.WriteLine(lines[i]);
            }
        }
    }
}
