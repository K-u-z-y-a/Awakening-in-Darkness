using System;

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

        public static void ShowChoices(System.Collections.Generic.List<string> choices1, params string[] choices)
        {
            Console.WriteLine("\nЧто делаем?");
            foreach (var choice in choices)
            {
                Console.WriteLine(choice);
            }
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

        public static void ShowInventory()
        {
            Console.WriteLine("\nИнвентарь:");
            foreach (var item in Player.Inventory)
            {
                Console.WriteLine($"- {item.Name}: {item.Description}");
            }
        }
    }
}