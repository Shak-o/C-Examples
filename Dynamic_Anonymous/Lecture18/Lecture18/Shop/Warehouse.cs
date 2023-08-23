namespace Lecture18.Shop
{
    public class Warehouse
    {
        public List<Item> StoredItems { get; set; } = null!;

        public void RemoveStoredItem(int itemId)
        {
            var toRemove = StoredItems.FirstOrDefault(x => x.Id == itemId);

            if (toRemove != null)
                StoredItems.Remove(toRemove);
        }
    }
}
