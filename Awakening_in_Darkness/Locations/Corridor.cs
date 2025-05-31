using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Awakening_in_Darkness.Core;
using Awakening_in_Darkness.Items;
using Awakening_in_Darkness.Locations;

namespace Awakening_in_Darkness.Locations
{
    public static class Corridor
    {
        public static void Enter()
        {
            Logger.Log("Игрок вошёл в коридор");
            Console.Clear();

            // Проверка наличия фонаря
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
                    GameOver();
                    return;
                }
            }

            // Обновлённое меню выбора
            UI.ShowChoices(new List<string> {
                "1. Дверь с рунами",
                "2. Дверь с механизмами",
                "3. Вернуться назад"
            });

            HandleChoice(Console.ReadLine());
        }

        private static void HandleChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    AlchemistRoom.Enter(); // Новая локация с призраком
                    break;

                case "2":
                    // Логика для двери с механизмами
                    UI.PrintWithColor("Дверь заперта сложным механизмом.", ConsoleColor.DarkGray);
                    Task.Delay(1500).Wait();
                    Enter();
                    break;

                case "3":
                    StartRoom.Enter();
                    break;

                default:
                    UI.InvalidInput();
                    Enter();
                    break;
            }
        }

        private static void GameOver()
        {
            UI.PrintWithColor("ВЫ ПОГИБЛИ", ConsoleColor.DarkRed);
            UI.PrintWithColor("Тьма поглотила вас...", ConsoleColor.Black);
            Task.Delay(3000).Wait();
            Environment.Exit(0);
        }
    }
}