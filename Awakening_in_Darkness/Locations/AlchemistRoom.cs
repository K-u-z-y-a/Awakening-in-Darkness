using System;
using System.Threading.Tasks;
using Awakening_in_Darkness.Core;
using Awakening_in_Darkness.Npcs;

namespace Awakening_in_Darkness.Locations
{
    public static class AlchemistRoom
    {
        public static void Enter()
        {
            Console.Clear();

            // Описание комнаты
            UI.PrintWithColor("Комната алхимика:", ConsoleColor.DarkMagenta);
            UI.PrintWithColor("Столы, заставленные склянками, странные приборы...", ConsoleColor.Gray);
            UI.PrintWithColor("И полупрозрачная фигура у котла.\n", ConsoleColor.Cyan);

            Task.Delay(1500).Wait();

            // Запуск диалога
            AlchemistGhost.Initialize();

            // После диалога возвращаемся в коридор
            Corridor.Enter();
        }
    }
}