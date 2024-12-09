using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountSelector : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    public int SelectedCount => int.Parse(_dropdown.options[_dropdown.value].text);

    public void Initialize(int min, int max, int @default)
    {
        _dropdown.ClearOptions();
        var options = new List<string>();
        for (int i = min; i <= max; i++)
        {
            options.Add(i.ToString());
        }
        _dropdown.AddOptions(options);
        _dropdown.value = @default - min;
    }
}
