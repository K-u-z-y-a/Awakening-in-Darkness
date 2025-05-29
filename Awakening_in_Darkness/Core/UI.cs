using System;
using System.Collections.Generic;
using System.Text;

namespace Awakening_in_Darkness.Core
{
    public static class UI
    {
        public static void PrintWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void WaitForInput()
        {
            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }

        public static void InvalidInput()
        {
            PrintWithColor("Неверный ввод!", ConsoleColor.Red);
        }

        internal static void ShowChoices(object choices)
        {
            throw new NotImplementedException();
        }

        public static void ShowChoices(List<string> choices)
        {
            Console.OutputEncoding = Encoding.UTF8;

            DrawBoxTop("Действия");
            foreach (var choice in choices)
            {
                Console.WriteLine($"  ◉ {choice}");
            }
            DrawBoxBottom();
            Console.Write("Ваш выбор: ");
        }

        private static void DrawBoxTop(string title)
        {
            Console.WriteLine($"┌{new string('─', title.Length + 2)}┐");
            Console.WriteLine($"│ {title} │");
            Console.WriteLine($"├{new string('─', 28)}┤");
        }

        private static void DrawBoxBottom()
        {
            Console.WriteLine($"└{new string('─', 28)}┘");
        }
        public static void PrintCentered(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            int padding = (Console.WindowWidth - text.Length) / 2;
            Console.WriteLine(text.PadLeft(padding + text.Length));
            Console.ResetColor();
        }
        public static void DrawMenuBox(string title, List<string> items)
        {
            int width = Console.WindowWidth - 4;
            string border = new string('═', width);

            PrintCentered($"╔{border}╗");
            PrintCentered($"║ {title.PadRight(width - 2)} ║");
            PrintCentered($"╠{border}╣");

            foreach (var item in items)
            {
                PrintCentered($"║ {item.PadRight(width - 2)} ║");
            }

            PrintCentered($"╚{border}╝");
        }
    }
}