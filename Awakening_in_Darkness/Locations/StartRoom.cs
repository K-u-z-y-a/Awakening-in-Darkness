using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Awakening_in_Darkness.Core;
using Awakening_in_Darkness.Items;

namespace Awakening_in_Darkness.Locations
{
    public static class StartRoom
    {
        private const int ShortPause = 1500;
        private const int LongPause = 2500;

        public static async void Enter(string reason = "начало игры")
        {
            Logger.Log($"Игрок в стартовой комнате. Причина: {reason}");
            Console.Clear();

            // Первая пауза перед началом
            //await Task.Delay(LongPause);

            // Вывод описания комнаты с паузами
            //await PrintRoomDescription();

            // Показ доступных действий
            await ShowAvailableActions();
        }

        private static async Task PrintRoomDescription()
        {
            UI.PrintWithColor("Вы просыпаетесь в темноте.", ConsoleColor.DarkYellow);
            await Task.Delay(ShortPause);

            UI.PrintWithColor("Холодный камень под спиной, в воздухе — запах сырости и чего-то... металлического.", ConsoleColor.Gray);
            await Task.Delay(ShortPause);
            UI.PrintWithColor("Голова гудит, в висках стучит. Кто я?\n", ConsoleColor.Gray);
            await Task.Delay(LongPause);

            UI.PrintWithColor("Вокруг:\n", ConsoleColor.DarkYellow);
            await Task.Delay(ShortPause);

            UI.PrintWithColor("    Тусклый свет фонаря на полу.", ConsoleColor.Gray);
            await Task.Delay(ShortPause);
            UI.PrintWithColor("    Стены, покрытые странными символами.", ConsoleColor.Gray);
            await Task.Delay(ShortPause);
            UI.PrintWithColor("    Дверь, чуть приоткрытая... из-за нее тянет сквозняком.\n", ConsoleColor.Gray);
            await Task.Delay(LongPause);
        }

        private static async Task ShowAvailableActions()
        {
            var choices = new List<string>();

            // Проверяем наличие фонаря в инвентаре
            if (!Player.HasItem<Lantern>())
            {
                choices.Add("1. Взять фонарь");
            }

            choices.Add("2. Осмотреть символы");
            choices.Add("3. Выйти в дверь");

            UI.PrintWithColor("Что делать?\n", ConsoleColor.DarkYellow);
            await Task.Delay(ShortPause);
            UI.ShowChoices(choices);

            await HandleChoice(Console.ReadLine());
        }

        private static async Task HandleChoice(string choice)
        {
            switch (choice)
            {
                case "1" when !Player.HasItem<Lantern>():
                    var lantern = new Lantern();
                    lantern.Take();
                    Player.Inventory.Add(lantern);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n░░░░░░░░░░░░░░░░░░░░░░░░░");
                    Console.WriteLine("░ ФОНАРЬ ДОБАВЛЕН В ИНВЕНТАРЬ ░");
                    Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░");
                    Console.ResetColor();
                    await Task.Delay(1500);

                    // Возвращаемся в комнату без полного рестарта
                    await ShowAvailableActions();
                    break;

                case "2":
                    await ExamineSymbols();
                    await ShowAvailableActions();
                    break;

                case "3":
                    Corridor.Enter();
                    break;

                default:
                    UI.InvalidInput();
                    await ShowAvailableActions();
                    break;
            }
        }

        private static async Task ExamineSymbols()
        {
            UI.PrintWithColor("Символы напоминают:\n- алхимические руны\n- глаз в треугольнике", ConsoleColor.Cyan);
            await Task.Delay(ShortPause);
            UI.WaitForInput();
        }
    }
}