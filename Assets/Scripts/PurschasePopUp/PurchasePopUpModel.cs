using System.Collections.Generic;
using UnityEngine;

public class PurchasePopUpModel
{
    public readonly string Title;    
    public readonly string Description;
    public readonly Sprite MainIcon;
    public readonly float BasePrice;
    public readonly float Discount;

    public readonly List<PurchaseItemModel> Items;

    public PurchasePopUpModel(string title, string description, Sprite mainIcon, float basePrice, float discount, List<PurchaseItemModel> items)
    {
        Title = title;
        Description = description;
        MainIcon = mainIcon;
        BasePrice = basePrice;
        Discount = discount;
        Items = items;
    }

    public float GetFinalPrice()
    {
        return BasePrice - BasePrice * Discount;
    }
}
