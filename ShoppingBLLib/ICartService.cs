using SolutionModelLib;

namespace ShoppingBLLib
{
    public interface ICartService
    {
        Task<Cart> CreateCartAsync(Cart cart);

        Task<Cart> UpdateCartAsync(int id, Cart cart);

        Task<Cart> DeleteCartAsync(int id);

        Task<Cart> AddItemstoCartAsync(int id, List<CartItem> cartItems);

        Task<Cart> RemoveItemsFromCartAsync(int id, List<int> cartItemIds);

        Task<(double, string)> GetCartTotalAsync(int id);
    }
}
