using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Image[] slotIcons;
    [SerializeField] private Button[] slotButtons;

    private void Start()
    {
        inventory.OnInventoryChanged += UpdateUI;

        // Connect each button to its own inventory slot
        for (int i = 0; i < slotButtons.Length; i++)
        {
            int slotIndex = i;

            slotButtons[i].onClick.AddListener(() =>
            {
                RemoveSlot(slotIndex);
            });
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slotIcons.Length; i++)
        {
            if (i >= inventory.Slots.Length)
                continue;

            if (inventory.Slots[i].IsEmpty)
            {
                slotIcons[i].enabled = false;
                slotButtons[i].gameObject.SetActive(false);
            }
            else
            {
                slotIcons[i].enabled = true;
                slotIcons[i].sprite =
                    inventory.Slots[i].item.icon;

                slotButtons[i].gameObject.SetActive(true);
            }
        }
    }

    public void RemoveSlot(int slotIndex)
    {
        if (slotIndex < 0 ||
            slotIndex >= inventory.Slots.Length)
            return;

        if (inventory.Slots[slotIndex].IsEmpty)
            return;

        ItemData item =
            inventory.Slots[slotIndex].item;

        // Remove THIS slot
        bool removed =
            inventory.RemoveItem(slotIndex);

        if (removed && item.itemPrefab != null)
        {
            Camera cam = Camera.main;

            if (cam != null)
            {
                Vector3 dropPosition =
                    cam.transform.position +
                    cam.transform.forward * 1.5f;

                Instantiate(
                    item.itemPrefab,
                    dropPosition,
                    Quaternion.identity
                );
            }
        }
    }

    private void OnDestroy()
    {
        if (inventory != null)
            inventory.OnInventoryChanged -= UpdateUI;
    }
}