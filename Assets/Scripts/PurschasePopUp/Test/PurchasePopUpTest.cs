using System;
using System.Collections.Generic;
using UnityEngine;

public class PurchasePopUpTest : MonoBehaviour
{
    [Serializable]
    private struct TestItemData
    {
        [SerializeField] private string _name;
        [SerializeField] private int _ñount;

        public string Name => _name;
        public int Count => _ñount;
    }

    [Header("Input")]
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private string _mainIconName;
    [SerializeField] private float _price;
    [SerializeField, Range(0, 1)] private float _discount;
    [SerializeField] private List<TestItemData> _itemsPresets;
    [Space(10)]
    [SerializeField, Min(1)] private int _minItemsCount;
    [SerializeField, Min(1)] private int _maxItemsCount;
    [SerializeField, Min(1)] private int _defaultItemsCount;
    [Space(10)]
    [SerializeField] private PurchasePopUpController _purchasePopUpController;
    [SerializeField] private CountSelector _countSelector;
    [Space(10)]
    [SerializeField] private ItemIconRegistry _itemIconRegistry;

    private void Start()
    {
        _countSelector.Initialize(_minItemsCount, _maxItemsCount, _defaultItemsCount);
    }

    public void Open()
    {
        List<PurchaseItemModel> items = new List<PurchaseItemModel>();
        int itemsCount = _countSelector.SelectedCount;
        for (int i = 0; i < itemsCount; i++)
        {
            Sprite itemIcon = _itemIconRegistry.GetIconByName(_itemsPresets[i].Name);
            PurchaseItemModel itemModel = new PurchaseItemModel(itemIcon, _itemsPresets[i].Count);
            items.Add(itemModel);
        }

        Sprite icon = _itemIconRegistry.GetIconByName(_mainIconName);
        PurchasePopUpModel model = new PurchasePopUpModel(_title, _description, icon, _price, _discount, items);

        _purchasePopUpController.PurchaseCallback += Purchase;

        _purchasePopUpController.Setup(model);
        _purchasePopUpController.gameObject.SetActive(true);
    }

    private void Purchase(PurchasePopUpModel model)
    {
        Debug.Log($"Ïîêóïêà çàâåðøåíà: {model.GetFinalPrice()}$");
        _purchasePopUpController.PurchaseCallback -= Purchase;
    }
}
