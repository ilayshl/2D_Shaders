using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField] private Inventory inventoryManager;
    [SerializeField] private RectTransform itemsHolder;
    [SerializeField] private GameObject inventoryEntryPrefab;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        InitiateItemsToUI();
        inventoryManager.LogInventory();
    }

    private void OnDisable() {
        RemoveItemsFromUI();
    }

    public void SetActive(bool value)
    {
        animator.SetBool("isActive", value);
        isActive = !isActive;
    }

    public void InitiateItemsToUI()
    {
        foreach(var item in inventoryManager.inventory)
        {
            var entry = Instantiate(inventoryEntryPrefab, itemsHolder);
            entry.GetComponent<Image>().sprite = item.Key.Icon;
            entry.GetComponentInChildren<TextMeshProUGUI>().text = item.Value.ToString();
        }
    }

    public void RemoveItemsFromUI()
    {
        foreach(Transform item in itemsHolder.transform)
        {
            Destroy(item.gameObject);
        }
    }
}
