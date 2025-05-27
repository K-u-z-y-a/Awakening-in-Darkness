using System.Collections.Generic;

namespace Пробуждение_Во_Тьме.Core
{
    public static class Player
    {
        public static List<string> Inventory { get; } = new List<string>();
        public static int Health { get; set; } = 100;
    }
}