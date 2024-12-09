using UnityEngine;

[CreateAssetMenu(fileName = "ItemIconRegistry", menuName = "ItemIconRegistry")]
public class ItemIconRegistry : ScriptableObject
{
    [SerializeField] private IconEntry[] _iconEntries;

    public Sprite GetIconByName(string name)
    {
        foreach (var entry in _iconEntries)
        {
            if (entry.Name == name)
                return entry.Icon;
        }

        Debug.LogWarning($"Icon for item '{name}' not found in registry!");
        return null;
    }
}
