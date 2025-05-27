using System;
using Пробуждение_Во_Тьме.Core;
using Пробуждение_Во_Тьме.Items; // Добавили для доступа к Lantern
using Пробуждение_Во_Тьме.Locations; // Добавили для StartRoom

namespace Пробуждение_Во_Тьме.Locations
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

            UI.ShowChoices(
                "1. Дверь с рунами",
                "2. Дверь с механизмами",
                "3. Поговорить с призраком",  // Новая опция
                "4. Вернуться назад"
);

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