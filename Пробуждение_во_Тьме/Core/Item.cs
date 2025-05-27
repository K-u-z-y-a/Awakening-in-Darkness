using System;

namespace Пробуждение_Во_Тьме.Core
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Action OnTake { get; set; }

        public virtual void Take()
        {
            OnTake?.Invoke();
            Logger.Log($"Предмет взят: {Name}");
        }
    }
}