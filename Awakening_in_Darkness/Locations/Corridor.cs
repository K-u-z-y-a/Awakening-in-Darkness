using System;
using System.Collections.Generic;
using Awakening_in_Darkness.Core;
using Awakening_in_Darkness.Items; // Добавили для доступа к Lantern
using Awakening_in_Darkness.Locations; // Добавили для StartRoom

namespace Awakening_in_Darkness.Locations
{
    public static class Corridor
    {
        public static void Enter()
        {
            Logger.Log("Игрок вошёл в коридор"); // Добавили логирование входа
            Console.Clear();

            if (Player.HasItem<Lantern>())
            {
                UI.PrintWithColor("С фонарём вы видите:\n- Три двери с символами\n- Кровавые следы", ConsoleColor.DarkRed);
            }
            else
            {
                UI.PrintWithColor("Вы спотыкаетесь в темноте! (-10 HP)", ConsoleColor.Red);
                Player.Health -= 10;
                if (Player.Health <= 0)
                {
                    Logger.Log("Игрок погиб!");
                    GameOver(); // Можно добавить этот метод
                }
                Logger.Log($"Игрок получил урон. Текущее здоровье: {Player.Health}"); // Логируем урон
            }

            UI.ShowChoices(new List<string> {
                "1. Дверь с рунами",
                "2. Дверь с механизмами",
                "3. Поговорить с призраком",  // Новая опция
                "4. Вернуться назад"
            });

            HandleChoice(Console.ReadLine());
        }

        private static void GameOver()
        {
            throw new NotImplementedException();
        }

        private static void HandleChoice(string choice)
        {
            switch (choice)
            {
                case "3":
                    Npcs.AlchemistGhost.Initialize();
                    Enter();
                    break;
            }
        }
    }
}