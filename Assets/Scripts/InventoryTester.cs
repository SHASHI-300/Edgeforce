using UnityEngine;

public class InventoryTester : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemData gun;
    [SerializeField] private ItemData ammo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventory.AddItem(gun, 1);
            PrintInventory();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventory.AddItem(ammo, 10);
            PrintInventory();
        }
    }

    private void PrintInventory()
    {
        foreach (var slot in inventory.Slots)
        {
            if (slot.IsEmpty)
                Debug.Log("Empty");
            else
                Debug.Log(slot.item.itemName + " x " + slot.quantity);
        }
    }
    public void RemoveGun()
    {
        // Remove gun from inventory
        bool removed = inventory.RemoveItem(0);

        if (!removed)
            return;

        // Spawn gun back into the scene
        if (gun != null && gun.itemPrefab != null)
        {
            Instantiate(
                gun.itemPrefab,
                Camera.main.transform.position + Camera.main.transform.forward * 1.0f,
                Camera.main.transform.rotation
            );
        }

        PrintInventory();
    }
}