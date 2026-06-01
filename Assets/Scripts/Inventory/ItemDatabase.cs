using UnityEngine;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
    public static Dictionary<string, ItemData> Items;

    [System.Serializable]
    private class ItemList
    {
        public List<ItemData> items;
    }

    void Awake()
    {
        LoadItems();
    }

    void LoadItems()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("items");

        string wrappedJson = "{ \"items\": " + jsonFile.text + "}";

        ItemList itemList = JsonUtility.FromJson<ItemList>(wrappedJson);

        Items = new Dictionary<string, ItemData>();

        foreach (var item in itemList.items)
        {
            Items[item.id] = item;
        }

        Debug.Log("Loaded " + Items.Count + " items.");
    }
}
