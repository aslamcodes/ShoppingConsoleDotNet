namespace SolutionModelLib
{
    public class Cart(int id, int customerId, Customer customer, List<CartItem> cartItems)
    {
        public int Id { get; set; } = id;
        public int CustomerId { get; set; } = customerId;
        public Customer Customer { get; set; } = customer;

        public List<CartItem> CartItems { get; set; } = cartItems;

        public override bool Equals(object? obj)
        {
            return obj is Cart cart &&
                   Id == cart.Id &&
                   CustomerId == cart.CustomerId;
        }
    }
}
