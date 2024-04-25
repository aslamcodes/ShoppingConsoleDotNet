using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Enums;
using SolutionModelLib.Exceptions;

namespace ShoppingBLLib
{
    public class CartService : ICartService
    {
        private CartRepo _cartRepo;

        public CartService(CartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }

        public Cart AddItemstoCart(int id, List<CartItem> cartItems)
        {
            Cart cart = _cartRepo.GetByKey(id);
            if (cart.CartItems.Count < 5 && cartItems.Count < 5 && cartItems.Count + cart.CartItems.Count < 5)
            {
                cart.CartItems.AddRange(cartItems);
            }
            else
            {
                throw new CartFullException();
            }

            return cart;
        }

        public Cart CreateCart(Cart cart)
        {
            Cart createdCart = _cartRepo.Add(cart);

            if (createdCart != null)
            {
                return createdCart;
            }

            throw new DuplicateEntityException(Entity.Cart);
        }

        public Cart DeleteCart(int id)
        {
            Cart deletedCart = _cartRepo.Delete(id);

            if (deletedCart != null)
            {
                return deletedCart;
            }

            throw new EntityNotFoundException(Entity.Cart);
        }

        public (double, string) GetCartTotal(int id)
        {
            string paymentDetails = "";
            double total = 0;
            var cart = _cartRepo.GetByKey(id);

            foreach (var item in cart.CartItems)
            {
                total += (item.Price * item.Quantity);
                if (item.Price <= 100)
                {
                    paymentDetails += $"{item.Product.Name} ==> {item.Price} + 100rs(delivery) X {item.Quantity}\n";
                    total += 100 * item.Quantity;
                }
                else
                {
                    paymentDetails += $"{item.Product.Name} ==> {item.Price} X {item.Quantity}\n";
                }
            }

            if (cart.CartItems.Count == 3 && total > 1500)
            {
                total -= (total) * 0.05;
                paymentDetails += $"\t\tDiscount = -{total * 0.05}\n";
            }

            paymentDetails += $"Total = ${total}";


            return (total, paymentDetails);

        }

        public Cart RemoveItemsFromCart(int id, List<int> cartItemIds)
        {
            var cart = _cartRepo.GetByKey(id);

            foreach (var cartItemId in cartItemIds)
            {
                for (int i = 0; i < cart.CartItems.Count; i++)
                {
                    if (cart.CartItems[i].CartId == cartItemId)
                    {
                        cart.CartItems.RemoveAt(i);
                    }
                }
            }

            return cart;
        }

        public Cart UpdateCart(int id, Cart cart)
        {

            if (cart != null)
            {
                return _cartRepo.Update(cart);
            }
            throw new EntityNotFoundException(Entity.Cart);
        }
    }
}
