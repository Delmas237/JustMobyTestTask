using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchasePopUpView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private Image _mainIcon;
    [Space(10)]
    [SerializeField] private AdaptiveGrid _adaptiveGrid;
    [SerializeField] private PurchaseItemController _itemPrefab;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI _finalPriceText;
    [SerializeField] private TextMeshProUGUI _basePriceText;
    [Space(5)]
    [SerializeField] private Transform _finalPriceTextBaseDot;
    [SerializeField] private Transform _finalPriceTextDiscountDot;
    [Space(10)]
    [SerializeField] private GameObject _discountRoot;
    [SerializeField] private TextMeshProUGUI _discountText;
    [Space(10)]
    [SerializeField] private Button _buyButton;

    public Button BuyButton => _buyButton;

    public void Display(string title, string description, Sprite mainIcon, float finalPrice, float basePrice, float discount)
    {
        _titleText.text = title;
        _descriptionText.text = description;
        _mainIcon.sprite = mainIcon;

        if (discount > 0)
        {
            _basePriceText.text = $"${basePrice:F2}";
            _finalPriceText.transform.position = _finalPriceTextDiscountDot.transform.position;
            _discountRoot.SetActive(true);
        }
        else
        {
            _basePriceText.text = string.Empty;
            _finalPriceText.transform.position = _finalPriceTextBaseDot.transform.position;
            _discountRoot.SetActive(false);
        }

        _finalPriceText.text = $"${finalPrice:F2}";
        _discountText.text = $"-{Mathf.RoundToInt(discount * 100)}%";
    }

    public void DisplayItems(List<PurchaseItemModel> itemModels)
    {
        _adaptiveGrid.Clear();
        List<PurchaseItemController> itemControllers = _adaptiveGrid.GenerateGrid(_itemPrefab, itemModels.Count);

        for (int i = 0; i < itemModels.Count; i++)
        {
            itemControllers[i].Setup(itemModels[i]);
        }
    }
}
