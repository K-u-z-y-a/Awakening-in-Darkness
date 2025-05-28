using System.Collections.Generic;
using Пробуждение_Во_Тьме.Items;

namespace Пробуждение_Во_Тьме.Core
{
    public static class Player
    {
        public static List<Item> Inventory { get; } = new List<Item>();
        public static int Health { get; set; } = 100;
        public static bool HasItem<T>() where T : Item
        {
            return Inventory.Exists(item => item is T);
        }
        // Добавим метод для поиска предмета по имени
        public static Item GetItem(string name)
        {
            return Inventory.Find(item => item.Name.Equals(name));
        }

    }
}