using UnityEngine;

using System;

[Serializable]
public class InventorySlot
{
    public string itemId;
    public int quantity;

    public InventorySlot(string id, int amount)
    {
        itemId = id;
        quantity = amount;
    }
}
