using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private Inventory inventoryManager;
    [SerializeField] private GameObject inventoryEntryPrefab;

    private void OnEnable()
    {
        InitiateItemsToUI();
        inventoryManager.LogInventory();
    }

    private void OnDisable() {
        RemoveItemsFromUI();
    }

    private void InitiateItemsToUI()
    {
        foreach(var item in inventoryManager.inventory)
        {
            var entry = Instantiate(inventoryEntryPrefab, this.transform);
            entry.GetComponent<Image>().sprite = item.Key.Icon;
            entry.GetComponentInChildren<TextMeshProUGUI>().text = item.Value.ToString();
        }
    }

    private void RemoveItemsFromUI()
    {
        foreach(Transform item in transform)
        {
            Destroy(item.gameObject);
        }
    }
}
