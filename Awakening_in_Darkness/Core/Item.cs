using System;

namespace Awakening_in_Darkness.Core
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsTaken { get; protected set; } // Переносим флаг сюда

        public virtual void Take()
        {
            IsTaken = true;
            Logger.Log($"Предмет взят: {Name}");
        }
    }
}