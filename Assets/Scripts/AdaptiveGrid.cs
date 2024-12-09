using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class AdaptiveGrid : MonoBehaviour
{
    [SerializeField] private HorizontalLayoutGroup _rowPrefab;
    [SerializeField] private int _maxItemsInRow = 3;

    public List<T> GenerateGrid<T>(T prefab, int ñount) where T : Object
    {
        List<T> items = new List<T>();
        int rowItemsCount;
        while (ñount > 0)
        {
            if (ñount > _maxItemsInRow)
            {
                rowItemsCount = _maxItemsInRow;
                ñount -= _maxItemsInRow;
            }
            else
            {
                rowItemsCount = ñount;
                ñount = 0;
            }

            var row = Instantiate(_rowPrefab, transform);

            for (int j = 0; j < rowItemsCount; j++)
            {
                T item = Instantiate(prefab, row.transform);
                items.Add(item);
            }

            AdjustRowSpacing(row, rowItemsCount);
        }

        return items;
    }

    public void Clear()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }

    private void AdjustRowSpacing(HorizontalLayoutGroup layoutGroup, int itemsCount)
    {
        float slope = 190f;
        float intercept = -560f;
        float maxSpacing = 10;

        float result = slope * itemsCount + intercept;
        layoutGroup.spacing = Mathf.Min(result, maxSpacing);
    }
}
