using System;
using Пробуждение_Во_Тьме.Core;
using Пробуждение_Во_Тьме.Items;

namespace Пробуждение_Во_Тьме.Locations
{
    public static class StartRoom
    {
        public static void Enter(string reason = "начало игры")
        {
            Logger.Log($"Игрок в стартовой комнате. Причина: {reason}");

            Console.Clear();
            UI.PrintWithColor("Вы просыпаетесь в темноте...", ConsoleColor.DarkYellow);

            UI.ShowChoices(
                "1. Взять фонарь",
                "2. Осмотреть символы",
                "3. Выйти в дверь"
            );

            HandleChoice(Console.ReadLine());
        }

        private static void HandleChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    if (!Player.HasItem<Lantern>())
                    {
                        var lantern = new Lantern();
                        lantern.Take();
                        Player.Inventory.Add(lantern);
                    }
                    else
                    {
                        UI.PrintWithColor("Фонарь уже у вас.", ConsoleColor.Gray);
                    }
                    break;
                case "2": ExamineSymbols(); break;
                case "3": Corridor.Enter(); break;
                default: UI.InvalidInput(); Enter(); break;
            }
        }

        private static void ExamineSymbols()
        {
            UI.PrintWithColor("Символы напоминают:\n- алхимические руны\n- глаз в треугольнике", ConsoleColor.Cyan);
            UI.WaitForInput();
            Enter();
        }
    }
}