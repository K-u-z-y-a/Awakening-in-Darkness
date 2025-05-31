namespace Awakening_in_Darkness.Core
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsTaken { get; private set; }
        public virtual void Drop() => IsTaken = false;

        public virtual void Take()
        {
            IsTaken = true;
            Logger.Log($"Предмет взят: {Name}");
        }
    }
}