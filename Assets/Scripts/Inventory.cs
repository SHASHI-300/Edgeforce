using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int slotCount = 5;

    private InventorySlot[] slots;

    public InventorySlot[] Slots => slots;

    public event Action OnInventoryChanged;

    private void Awake()
    {
        slots = new InventorySlot[slotCount];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new InventorySlot(null, 0);
        }
    }

    public bool AddItem(ItemData item, int amount)
    {
        if (item == null || amount <= 0)
            return false;

        // First try to add to an existing stack.
        if (item.isStackable)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item == item &&
                    slots[i].quantity < item.maxStackSize)
                {
                    int space =
                        item.maxStackSize - slots[i].quantity;

                    int amountToAdd =
                        Mathf.Min(amount, space);

                    slots[i].quantity += amountToAdd;
                    amount -= amountToAdd;

                    if (amount <= 0)
                    {
                        OnInventoryChanged?.Invoke();
                        return true;
                    }
                }
            }
        }

        // Put remaining items into empty slots.
        while (amount > 0)
        {
            int emptySlot = FindEmptySlot();

            if (emptySlot == -1)
            {
                OnInventoryChanged?.Invoke();
                return false;
            }

            int amountToAdd = item.isStackable
                ? Mathf.Min(amount, item.maxStackSize)
                : 1;

            slots[emptySlot].item = item;
            slots[emptySlot].quantity = amountToAdd;

            amount -= amountToAdd;

            // Non-stackable item occupies one slot.
            if (!item.isStackable)
                break;
        }

        OnInventoryChanged?.Invoke();
        return true;
    }
    public bool RemoveItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= slots.Length)
            return false;

        if (slots[slotIndex].IsEmpty)
            return false;

        slots[slotIndex].Clear();

        OnInventoryChanged?.Invoke();

        return true;
    }
    private int FindEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsEmpty)
                return i;
        }

        return -1;
    }
}