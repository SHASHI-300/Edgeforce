using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public bool isStackable;
    public int maxStackSize = 1;

    public GameObject itemPrefab;
}