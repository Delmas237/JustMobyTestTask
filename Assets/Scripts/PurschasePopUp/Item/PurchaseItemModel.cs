using UnityEngine;

public class PurchaseItemModel
{
    public readonly Sprite Icon;
    public readonly int Count;

    public PurchaseItemModel(Sprite icon, int count)
    {
        Icon = icon;
        Count = count;
    }
}
