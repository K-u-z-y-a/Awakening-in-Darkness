using System;

namespace Пробуждение_Во_Тьме.Core
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