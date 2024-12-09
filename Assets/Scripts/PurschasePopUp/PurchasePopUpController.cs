using System;
using UnityEngine;

public class PurchasePopUpController : MonoBehaviour
{
    [SerializeField] private PurchasePopUpView _view;
    private PurchasePopUpModel _model;

    public event Action<PurchasePopUpModel> PurchaseCallback;

    public void Setup(PurchasePopUpModel model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model), "Model can not be null");
        
        _model = model;

        _view.Display(
            _model.Title,
            _model.Description,
            _model.MainIcon,
            _model.GetFinalPrice(),
            _model.BasePrice,
            _model.Discount
        );

        _view.DisplayItems(_model.Items);

        _view.BuyButton.onClick.RemoveAllListeners();
        _view.BuyButton.onClick.AddListener(OnBuyButtonClicked);
    }

    private void OnBuyButtonClicked()
    {
        gameObject.SetActive(false);
        PurchaseCallback?.Invoke(_model);
    }
}
