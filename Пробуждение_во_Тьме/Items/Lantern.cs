using System;
using Пробуждение_Во_Тьме.Core;

namespace Пробуждение_Во_Тьме.Items
{
    public class Lantern : Item
    {
        public Lantern()
        {
            Name = "Фонарь";
            Description = "Потускневший латунный фонарь с треснувшим стеклом.";
            OnTake = () =>
            {
                UI.PrintWithColor("Свет фонаря рассеивает тьму.", ConsoleColor.Yellow);
            };
        }
    }
}