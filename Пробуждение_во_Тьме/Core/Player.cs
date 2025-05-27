using System.Collections.Generic;

namespace Пробуждение_Во_Тьме.Core
{
    public static class Player
    {
        public static List<Item> Inventory { get; } = new List<Item>();

        public static bool HasItem<T>() where T : Item
        {
            return Inventory.Exists(item => item is T);
        }
        public static int Health { get; set; } = 100;
    }
    
}