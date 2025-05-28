using System;
using System.Collections.Generic;
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

            //Console.WriteLine($"Отладка: {choices.Count} вариантов"); // Проверяем количество

            UI.ShowChoices(choices);
            HandleChoice(Console.ReadLine());
        }

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

                            // Добавляем паузу перед обновлением экрана
                            UI.PrintWithColor("Фонарь теперь в вашем инвентаре.", ConsoleColor.Green);
                            UI.WaitForInput();
                        }
                        else
                        {
                            UI.PrintWithColor("Фонарь уже у вас.", ConsoleColor.Gray);
                            UI.WaitForInput(); // Пауза и здесь
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

//Проверка кода