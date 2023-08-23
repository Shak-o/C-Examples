namespace Lecture18.Shop
{
    public class TechShop
    {
        public List<Item> ItemsToSell { get; set; } = null!;

        public delegate void SellItem(int itemId);

        public event SellItem ItemSold = null!;

        public void OnItemsSold(List<Item> items)
        {
            foreach (var item in items.ToList())
            {
                ItemsToSell.Remove(item);
                ItemSold.Invoke(item.Id);
            }
        }

        public void SellItems(User user)
        {
            var totalPrice = user.Cart.CartItems.Sum(x => x.Price);
            user.Balance -= totalPrice;

            OnItemsSold(user.Cart.CartItems);
        }
    }
}
