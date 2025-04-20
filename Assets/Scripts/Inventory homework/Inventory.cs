using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<ItemTypes, string> store = new();

    void Start()
    {
        AddItem();
        LogStore();
    }

    
    void Update()
    {
        
    }

    private void AddItem()
    {
        store.Add(ItemTypes.Passive, "First item of Passive type.");
        store.Add(ItemTypes.Consumable, "Third item!!!!");
        store.Add(ItemTypes.Active, "Second Item!!!!!");
    }

    private void LogStore()
    {
        foreach(ItemTypes key in store.Keys)
        {
            Debug.Log($"\n{key}, {store[key]}");
        }
        
    }

}

public enum ItemTypes
{
    Passive,
    Active,
    Consumable,
    Cards,
    Pills,
    Trinket,
}
