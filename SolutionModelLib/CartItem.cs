namespace SolutionModelLib
{
    public class CartItem
    {
        public int CartId { get; set; }//Navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; }//Navigation property
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }

        public CartItem(int cartId, int productId, Product product, int quantity, double price, DateTime priceExpiryDate)
        {
            CartId = cartId;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            PriceExpiryDate = priceExpiryDate;
        }
    }
}
