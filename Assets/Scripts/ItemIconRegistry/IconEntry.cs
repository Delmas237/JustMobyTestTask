using System;
using UnityEngine;

[Serializable]
public struct IconEntry
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public string Name => _name;
    public Sprite Icon => _icon;
}
