using System;
using UnityEngine;

public class TestInventory : MonoBehaviour
{
    void Start()
    {
        
        InventoryManager.Instance.AddItem("gold", 25);
       
        InventoryManager.Instance.AddItem("skillpoint", 5);
        InventoryManager.Instance.listitems();
        
    }
}
