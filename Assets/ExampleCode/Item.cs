namespace ExampleCode
{
    /// <summary>
    /// This is a mock-data class representing a generic game item,
    /// Used to showcase the debugger usage in the inventory class.
    /// </summary>
    public class Item 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }

        public override string ToString()
        {
            return "ITEM!";
        }
    }
}
