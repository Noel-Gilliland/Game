using UnityEngine;

public class PlayerUpgradeHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spendskillpoint()
    {
        var inventory = InventoryManager.Instance.inventory;

        GameObject upgrade = gameObject;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemId == "skillpoint")
            {
                if (inventory[i].quantity > 1)
                {
                    inventory[i].quantity -= 1;
                    return;
                }
                else
                {
                    Debug.Log("Not enough skill points to spend.");
                    return;
                }
            }
        }
        Debug.Log("Spent 1 skill point.");
    }
}
