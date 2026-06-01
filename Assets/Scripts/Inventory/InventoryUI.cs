using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject slotPrefab;

    /*public void Refresh()
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        foreach (var slot in InventoryManager.Instance.inventory)
        {
            GameObject obj = Instantiate(slotPrefab, contentParent);

            ItemData item =
                ItemDatabase.Items[slot.itemId];

            TMP_Text text =
                obj.GetComponentInChildren<TMP_Text>();

            text.text =
                item.name + " x" + slot.quantity;
        }
    }
    */
    public GameObject inventoryPanel;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(
                !inventoryPanel.activeSelf
            );
        }

        //if (inventoryPanel.activeSelf)
            //Refresh();
    }
}
