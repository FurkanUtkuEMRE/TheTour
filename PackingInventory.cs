/**************************************************************************************************************************************************************************************
class Pack {
    private List<InventoryItem> items = new List<InventoryItem>();
    private float maxWeight;
    private float maxVolume;

    public Pack(float maxWeight, float maxVolume)
    {
        this.maxWeight = maxWeight;
        this.maxVolume = maxVolume;
    }

    public void AddItem(InventoryItem item)
    {
        if (item.Weight + items.Sum(i => i.Weight) > maxWeight)
        {
            throw new Exception("Pack is too heavy.");
        }

        if (item.Volume + items.Sum(i => i.Volume) > maxVolume)
        {
            throw new Exception("Pack is too full.");
        }

        items.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        items.Remove(item);
    }
}

class InventoryItem
{
    public float Weight { get; protected set; }
    public float Volume { get; protected set; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

class Arrow : InventoryItem { public Arrow() : base(0.1f, 0.05f) { } }
class Bow : InventoryItem { public Bow() : base(1.0f, 4.0f) { } }
class Rope : InventoryItem { public Rope() : base(1.0f, 1.5f) { } }
class Water : InventoryItem { public Water() : base(2.0f, 3.0f) { } }
class Food : InventoryItem { public Food() : base(1.0f, 0.5f) { } }
class Sword : InventoryItem { public Sword() : base(5.0f, 3.0f) { } }
**************************************************************************************************************************************************************************************/