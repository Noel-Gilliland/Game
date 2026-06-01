using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<InventorySlot> inventory = new();

    public int maxSlots = 20;

    void Awake()
    {
        Instance = this;
    }

    public bool AddItem(string itemId, int amount = 1)
    {
        if (!ItemDatabase.Items.ContainsKey(itemId))
        {
            Debug.LogWarning("Item does not exist: " + itemId);
            return false;
        }

        ItemData item = ItemDatabase.Items[itemId];

        // Stack existing items
        if (item.stackable)
        {
            foreach (var slot in inventory)
            {
                if (slot.itemId == itemId &&
                    slot.quantity < item.maxStack)
                {
                    slot.quantity += amount;
                    return true;
                }
            }
        }

        // Add new slot
        if (inventory.Count >= maxSlots)
        {
            Debug.Log("Inventory Full");
            return false;
        }

        inventory.Add(new InventorySlot(itemId, amount));
        return true;
    }

    public void RemoveItem(string itemId, int amount = 1)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemId == itemId)
            {
                inventory[i].quantity -= amount;

                if (inventory[i].quantity <= 0)
                    inventory.RemoveAt(i);

                return;
            }
        }
    }

    public void listitems()
    {
        foreach (var slot in inventory)
        {
            Debug.Log("Item: " + slot.itemId + " Quantity: " + slot.quantity);
        }
    }

}