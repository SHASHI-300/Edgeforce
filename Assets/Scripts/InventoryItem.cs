using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InventoryItem : MonoBehaviour
{
    public ItemData itemData;

    private XRGrabInteractable grabInteractable;
    private Inventory inventory;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        // Press E while holding the object to store it
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabInteractable != null && grabInteractable.isSelected)
            {
                StoreInInventory();
            }
        }
    }

    private void StoreInInventory()
    {
        if (inventory == null || itemData == null)
            return;

        bool added = inventory.AddItem(itemData, 1);

        if (added)
        {
            Debug.Log(itemData.itemName + " stored in inventory");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Inventory Full!");
        }
    }
}