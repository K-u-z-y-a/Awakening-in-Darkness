using System;
using System.Collections.Generic;
using System.Threading;
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

            var choices = new List<string> {
        "1. Взять фонарь",
        "2. Осмотреть символы",
        "3. Выйти в дверь"
    };


            UI.ShowChoices(choices);
            HandleChoice(Console.ReadLine());
        }
        //Проверка кода
        private static void HandleChoice(string choice)
        {
            try
            {
                switch (choice)
                {
                    case "1":
                        if (!Player.HasItem<Lantern>())
                        {
                            var lantern = new Lantern();
                            lantern.Take();
                            Player.Inventory.Add(lantern);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.WriteLine("░ ФОНАРЬ ДОБАВЛЕН В ИНВЕНТАРЬ ░");
                            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ResetColor();
                            Thread.Sleep(1500);
                        }
                        break;
                    case "2": ExamineSymbols(); break;
                    case "3": Corridor.Enter(); break;
                    default: UI.InvalidInput(); Enter(); break;
                }
            }
            finally
            {
                Enter(); // Всегда возвращаемся в комнату после действия
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
