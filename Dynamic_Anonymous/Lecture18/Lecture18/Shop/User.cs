namespace Lecture18.Shop
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Cart Cart { get; set; } = null!;
        public decimal Balance { get; set; }
    }
}
