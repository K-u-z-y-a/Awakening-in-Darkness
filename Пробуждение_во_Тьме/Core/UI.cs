using System;
using System.Collections.Generic;
using System.Text;

namespace Пробуждение_Во_Тьме.Core
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
    }
}