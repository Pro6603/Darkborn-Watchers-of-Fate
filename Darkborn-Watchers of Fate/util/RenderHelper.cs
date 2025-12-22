using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using game.Player;
using game.Weapon;
using static System.Net.Mime.MediaTypeNames;

namespace util.RenderHelper
{
    internal class RenderHelper
    {
        public void RenderInventory(Inventory inventory)
        {
            List<String> inventoryContentsItem = new List<String>();
            foreach (Item item in inventory.OwnedItems)
            {
                inventoryContentsItem.Add(item.Name);
                Console.WriteLine(item.Amount.ToString() + "x " + item.Name);
            }

            List<String> inventoryContentsWeapon = new List<String>();
            foreach (var weapon in inventory.OwnedWeapons)
            {
                inventoryContentsWeapon.Add(weapon.Name);
            }

            List<String> inventoryContentsSpells = new List<String>();
            foreach (var spell in inventory.OwnedSpells)
            {
                inventoryContentsSpells.Add(spell.Name);
            }

            inventoryContentsItem.
        }


        /// <summary>
        /// Renders the weapon information, where the color of the weapon name is dependent on the rarity of the weapon.
        /// </summary>
        public void RenderWeaponContextCustomPosition(Weapon weapon, int StartLeft, int StartTop)
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

        public void RenderWeaponContext(Weapon weapon)
        {
            double mainLeft = Console.WindowWidth / 2 / 1.6;
            double mainRight = Console.WindowWidth / 2 * 1.5;
            int mainWidth = (int)(mainRight - mainLeft + 1);

            int boxWidth = (int)(mainWidth * 0.35);
            int innerWidth = boxWidth - 2;

            int startX = (Console.WindowWidth * 5 / 6);
            int startY = 1;

            if (startX + boxWidth > Console.WindowWidth)
            {
                startX = Console.WindowWidth - boxWidth - 1;
            }

            List<string> descriptionLines = WrapText(weapon.Description, innerWidth);
            int boxHeight = descriptionLines.Count + 7;

            DrawBox(startX, startY, boxWidth, boxHeight);

            ConsoleColor originalColor = Console.ForegroundColor;

            Console.SetCursorPosition(startX + 1, startY + 1);
            Console.ForegroundColor = GetRarityColor(weapon);
            string name = weapon.Name.Length > innerWidth ? weapon.Name.Substring(0, innerWidth) : weapon.Name;
            Console.Write(name);
            Console.ForegroundColor = originalColor;

            for (int i = 0; i < descriptionLines.Count; i++)
            {
                Console.SetCursorPosition(startX + 1, startY + 2 + i);
                Console.Write(descriptionLines[i]);
            }

            int statsY = startY + 2 + descriptionLines.Count + 1;

            Console.SetCursorPosition(startX + 1, statsY);
            Console.ForegroundColor = ConsoleColor.Red;
            string damageText = $"Damage: {weapon.Damage}";
            Console.Write(damageText.Length > innerWidth ? damageText.Substring(0, innerWidth) : damageText);

            double durabilityRatio = (double)weapon.Durability / weapon.MaxDurability;

            ConsoleColor durabilityColor;
            if (durabilityRatio <= 0.0)
                durabilityColor = ConsoleColor.Gray;
            else if (durabilityRatio <= 0.2)
                durabilityColor = ConsoleColor.DarkRed;
            else if (durabilityRatio <= 0.4)
                durabilityColor = ConsoleColor.Red;
            else if (durabilityRatio <= 0.6)
                durabilityColor = ConsoleColor.DarkYellow;
            else if (durabilityRatio <= 0.8)
                durabilityColor = ConsoleColor.Yellow;
            else
                durabilityColor = ConsoleColor.Green;

            Console.SetCursorPosition(startX + 1, statsY + 1);
            Console.ForegroundColor = durabilityColor;
            string durabilityText = $"Durability: {weapon.Durability}/{weapon.MaxDurability}";
            Console.Write(durabilityText.Length > innerWidth ? durabilityText.Substring(0, innerWidth) : durabilityText);

            Console.SetCursorPosition(startX + 1, startY + boxHeight - 2);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"[id {weapon.ID}]");
            Console.ForegroundColor = originalColor;
        }

        private ConsoleColor GetRarityColor(Weapon weapon)
        {
            return weapon.getRarity(weapon) switch
            {
                Weapon.Rarity.COMMON => ConsoleColor.DarkGray,
                Weapon.Rarity.UNCOMMON => ConsoleColor.Gray,
                Weapon.Rarity.RARE => ConsoleColor.Green,
                Weapon.Rarity.EPIC => ConsoleColor.Magenta,
                Weapon.Rarity.LEGENDARY => ConsoleColor.DarkYellow,
                Weapon.Rarity.MYTHIC => ConsoleColor.Red,
                _ => Console.ForegroundColor
            };
        }

        private List<string> WrapText(string text, int maxWidth)
        {
            List<string> lines = new List<string>();
            for (int i = 0; i < text.Length; i += maxWidth)
            {
                int length = Math.Min(maxWidth, text.Length - i);
                lines.Add(text.Substring(i, length));
            }
            return lines;
        }

        private void DrawBox(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(x, y); Console.Write("╔");
            Console.SetCursorPosition(x + width, y); Console.Write("╗");
            Console.SetCursorPosition(x, y + height - 1); Console.Write("╚");
            Console.SetCursorPosition(x + width, y + height - 1); Console.Write("╝");

            for (int i = 1; i < width; i++)
            {
                Console.SetCursorPosition(x + i, y); Console.Write("═");
                Console.SetCursorPosition(x + i, y + height - 1); Console.Write("═");
            }

            for (int j = 1; j < height - 1; j++)
            {
                Console.SetCursorPosition(x, y + j); Console.Write("║");
                Console.SetCursorPosition(x + width, y + j); Console.Write("║");

                Console.SetCursorPosition(x + 1, y + j);
                Console.Write(new string(' ', width - 1));
            }
        }

        public void RenderStamina(Player player)
        {
            ConsoleColor current = Console.ForegroundColor;

            int barWidth = Console.WindowWidth / 4;
            int x = 0;
            int y = Console.WindowHeight - 2;

            Console.SetCursorPosition(x + 2, y - 4);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"STAMINA ({player.STAMINA})");

            Console.SetCursorPosition(x + 2, y - 3);

            Console.ForegroundColor = ConsoleColor.Blue;

            int filled = (int)(barWidth * (player.STAMINA / 25.0));

            for (int i = 0; i < filled; i++)
                Console.Write("█");

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            for (int i = filled; i < barWidth; i++)
                Console.Write("░");

            Console.ResetColor();
        }

        public void RenderHP(Player player)
        {
            int barWidth = Console.WindowWidth / 4;
            int x = 0;
            int y = Console.WindowHeight - 2;

            Console.SetCursorPosition(x + 2, y - 1);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"HP ({player.HP}%):");

            Console.SetCursorPosition(x + 2, y);

            Console.ForegroundColor = ConsoleColor.Red;

            int filled = (int)(barWidth * (player.HP / 100.0));

            for (int i = 0; i < filled; i++)
                Console.Write("█");

            Console.ForegroundColor = ConsoleColor.DarkRed;

            for (int i = filled; i < barWidth; i++)
                Console.Write("░");

            Console.ResetColor();
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

        public void RenderNewWeaponText(Weapon weapon)
        {
            RenderHeaderText($"NEW WEAPON: {weapon.Name} - Damage: {weapon.Damage} | Durability: {weapon.Durability}", true, false, false, -1, 3000, true);
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
                string final_text = $@"{text}";
                Console.SetCursorPosition(GetHalfWidht(final_text, true), windowHeightToRender);
                Console.WriteLine(final_text);
                Thread.Sleep(duration);

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


        public string RenderDialogueTB(
    string source,
    string dialogue,
    string answer1,
    string answer2,
    string answer3,
    int correctAnswer,
    bool animated)
        {
            if (dialogue.Length > 420)
                return "Error: Dialogue length exceeds 420 chars!";

            double leftCorner = Console.WindowWidth / 2 / 1.6;
            double rightCorner = Console.WindowWidth / 2 * 1.5;
            int width = (int)(rightCorner - leftCorner + 1);
            int innerWidth = width - 3;

            List<string> chunks = new List<string>();
            for (int i = 0; i < dialogue.Length; i += innerWidth)
            {
                int size = Math.Min(innerWidth, dialogue.Length - i);
                chunks.Add(dialogue.Substring(i, size));
            }

            int boxHeight = Math.Max(7, chunks.Count + 3);
            int top = Math.Max(0, Console.WindowHeight - boxHeight - 1);
            int bottom = top + boxHeight - 1;

            for (int y = top; y <= bottom; y++)
            {
                for (int x = (int)leftCorner; x <= (int)rightCorner; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                }
            }

            Console.SetCursorPosition((int)leftCorner, top); Console.Write("╔");
            Console.SetCursorPosition((int)rightCorner, top); Console.Write("╗");
            Console.SetCursorPosition((int)leftCorner, bottom); Console.Write("╚");
            Console.SetCursorPosition((int)rightCorner, bottom); Console.Write("╝");

            for (int x = 1; x < width; x++)
            {
                Console.SetCursorPosition((int)leftCorner + x, top); Console.Write("═");
                Console.SetCursorPosition((int)leftCorner + x, bottom); Console.Write("═");
            }

            for (int y = 1; y < boxHeight - 1; y++)
            {
                Console.SetCursorPosition((int)leftCorner, top + y); Console.Write("║");
                Console.SetCursorPosition((int)rightCorner, top + y); Console.Write("║");
            }

            source = CapitalizeFirstLetter(source);
            Console.SetCursorPosition((int)leftCorner + 1, top - 1);
            Console.Write($"{source}:");

            for (int j = 0; j < chunks.Count; j++)
            {
                int cursorX = (int)leftCorner + 2;
                int cursorY = top + 1 + j;
                if (cursorY >= bottom) break;

                Console.SetCursorPosition(cursorX, cursorY);
                WriteDialogue(chunks[j], animated);
            }

            int answerY = bottom - 2;
            List<string> options = new List<string>();
            if (!string.IsNullOrWhiteSpace(answer1)) options.Add($"1- {answer1}");
            if (!string.IsNullOrWhiteSpace(answer2)) options.Add($"2- {answer2}");
            if (!string.IsNullOrWhiteSpace(answer3)) options.Add($"3- {answer3}");

            Console.SetCursorPosition((int)leftCorner + 2, answerY);
            Console.Write("Choose: " + string.Join(" | ", options));

            string Answer;
            while (true)
            {
                Console.SetCursorPosition((int)leftCorner + 2, answerY + 1);
                Console.Write("-> ");
                Answer = Console.ReadLine()?.Trim();

                if (Answer == "1" || Answer == "2" || Answer == "3")
                    break;

                Console.SetCursorPosition((int)leftCorner + 2, answerY);
                Console.Write("Choose: " + string.Join(" | ", options));
            }

            if (Answer == correctAnswer.ToString())
                return "correct";
            else
                return Answer;
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

        void SlowWrite(string text, int delay)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
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

        public void RenderLoadingScreen(int duration, int centerTopOffset)
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
                Console.SetCursorPosition(startX, startY + i + centerTopOffset);
                Console.WriteLine(lines[i]);
            }
        }
    }
}
