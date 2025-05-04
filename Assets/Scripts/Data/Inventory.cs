using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<ItemData, int> _inventory = new();
    public Dictionary<ItemData, int> inventory {get => _inventory;}

    public void AddItem(ItemData item)
    {
        if(_inventory.ContainsKey(item))
        {
            _inventory[item]++;
            Debug.Log(_inventory[item]+ " was updated to be " + _inventory[item] + ".");
        }
        else
        {
            _inventory[item] = 1;
            Debug.Log(_inventory[item]+ " was added to the inventory.");
        }
    }
    
    public void RemoveItem(ItemData item)
    {
        if(_inventory.ContainsKey(item))
        {
            _inventory.Remove(item);
        }
        else
        {
            Debug.Log("Error: Nothing to remove.");
        }
    }

    public void LogInventory()
    {
        Debug.Log("Inventory: ");
        foreach(ItemData key in inventory.Keys)
        {
            Debug.Log($"{key}, {inventory[key]}\n");
        }
        
    }

}
