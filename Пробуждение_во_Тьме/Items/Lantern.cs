using System;
using Пробуждение_Во_Тьме.Core;
using Пробуждение_Во_Тьме.Locations;

namespace Пробуждение_Во_Тьме.Items
{
    public static class Lantern
    {
        public static bool IsTaken { get; private set; }

        public static void Take()
        {
            if (!IsTaken)
            {
                Logger.Log("Игрок поднял фонарь");

                IsTaken = true;
                Player.Inventory.Add("Фонарь");
                UI.PrintWithColor("Вы подняли фонарь. Теперь в руках слабый, но верный свет.", ConsoleColor.Yellow);
            }
            else
            {
                UI.PrintWithColor("Фонарь уже у вас.", ConsoleColor.Gray);
            }
            UI.WaitForInput();
            StartRoom.Enter("возврат после фонаря");
        }
    }
}