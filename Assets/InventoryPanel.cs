using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    private Dictionary<ItemData, int> inventory = new();
    [SerializeField] private GameObject inventoryEntryPrefab;

    void OnEnable()
    {
        InitiateItems();
    }

    private void InitiateItems()
    {
        foreach(var item in inventory)
        {
            var entry = Instantiate(inventoryEntryPrefab, this.transform);
            entry.GetComponent<Image>().sprite = item.Key.Icon;
        }
    }

    public void AddItem(ItemData item)
    {
        if(inventory.ContainsKey(item))
        {
            inventory[item]++;
        }
        else
        {
            inventory[item] = 1;
        }
    }
}
