using SolutionModelLib;

namespace ShoppingBLLib
{
    public interface ICartService
    {
        Cart CreateCart(Cart cart);

        Cart UpdateCart(int id, Cart cart);

        Cart DeleteCart(int id);

        Cart AddItemstoCart(int id, List<CartItem> cartItems);

        Cart RemoveItemsFromCart(int id, List<int> cartItemIds);

        (double, string) GetCartTotal(int id);
    }
}
