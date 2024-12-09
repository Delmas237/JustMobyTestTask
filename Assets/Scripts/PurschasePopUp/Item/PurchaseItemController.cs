using System;
using UnityEngine;

public class PurchaseItemController : MonoBehaviour
{
    [SerializeField] private PurchaseItemView _view;

    public void Setup(PurchaseItemModel model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model), "Model can not be null");

        _view.Display(model.Icon, model.Count.ToString());
    }
}
