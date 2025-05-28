using System;
using System.Threading;
using Пробуждение_Во_Тьме.Core;

namespace Пробуждение_Во_Тьме.Items
{
    public class Lantern : Item
    {
        public Lantern()
        {
            Name = "Фонарь";
            Description = "Потускневший латунный фонарь.";
        }

        public override void Take()
        {
            base.Take();
            UI.PrintWithColor(">> Фонарь мягко загорается в ваших руках, освещая мрачные стены.",
                            ConsoleColor.Yellow);
            Thread.Sleep(1500); // Задержка для драматизма
        }
    }
}