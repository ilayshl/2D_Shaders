using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemName;
    public string Name { get => itemName; }
    [SerializeField] private Sprite icon;
    public Sprite Icon { get => icon; }
    [SerializeField] private GameObject prefab;
    public GameObject Prefab { get => prefab; }

}
