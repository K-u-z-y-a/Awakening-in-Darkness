using System;
using System.Threading;
using Awakening_in_Darkness.Core;

namespace Awakening_in_Darkness.Items
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