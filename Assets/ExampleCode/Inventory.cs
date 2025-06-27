using UnityEngine;

namespace ExampleCode
{
    /// <summary>
    /// This is an example inventory class used to showcase the debugger usage, 
    /// Each of the included methods showcase a different error: logical, runtime, compilation.
    /// </summary>
    public class Inventory : MonoBehaviour
    {
        private Item[] _mockItems;
        private void Start()
        {
            _mockItems = CreateItems(50);
            TestItems();
        }

        private Item[] CreateItems(int amount)
        {
            var items = new Item[amount];
            for (int i = 0; i < amount; i++)
            {
                items[i] = new Item
                {
                    ID = i,
                    Name = "Item_" + i.ToString(),
                    Value = i * 1.5f * amount
                };
                items[i].Description = "This is an item called " + items[i].Name;
            }

            Debug.Log($"Created {amount} items as mock data");
            return items;
        }

        private void TestItems()
        {
            for (int i = 0; i < _mockItems.Length; i++)
            {
                if (_mockItems[i].ID > 10)
                {
                    //Debug.Log("ID is bigger then 100");
                }
                else
                {
                    Debug.Log("ID Validated");
                }
            }
        }
    }
}
