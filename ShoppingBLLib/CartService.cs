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

        /// <summary>
        /// Adds items to the cart identified by the given ID.
        /// </summary>
        /// <param name="id">The ID of the cart to add items to.</param>
        /// <param name="cartItems">The list of items to add to the cart.</param>
        /// <returns>The updated cart after adding the items.</returns>
        /// <exception cref="CartFullException">Thrown when attempting to add items to a full cart.</exception>
        public async Task<Cart> AddItemstoCartAsync(int id, List<CartItem> cartItems)
        {
            Cart cart = await _cartRepo.GetByKey(id);
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

        /// <summary>
        /// Creates a new cart in the system.
        /// </summary>
        /// <param name="cart">The cart object to be created.</param>
        /// <returns>The newly created cart.</returns>
        /// <exception cref="DuplicateEntityException">Thrown when attempting to create a cart that already exists.</exception>
        public async Task<Cart> CreateCartAsync(Cart cart)
        {
            Cart createdCart = await _cartRepo.Add(cart);

            if (createdCart != null)
            {
                return createdCart;
            }

            throw new DuplicateEntityException(Entity.Cart);
        }

        /// <summary>
        /// Deletes the cart with the specified ID from the system.
        /// </summary>
        /// <param name="id">The ID of the cart to delete.</param>
        /// <returns>The deleted cart.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when the cart with the specified ID is not found.</exception>
        public async Task<Cart> DeleteCartAsync(int id)
        {
            Cart deletedCart = await _cartRepo.Delete(id);

            if (deletedCart != null)
            {
                return deletedCart;
            }

            throw new EntityNotFoundException(Entity.Cart);
        }

        /// <summary>
        /// Calculates the total cost of the items in the cart with the specified ID and provides payment details.
        /// </summary>
        /// <param name="id">The ID of the cart to calculate the total for.</param>
        /// <returns>A tuple containing the total cost and payment details.</returns>
        public async Task<(double, string)> GetCartTotalAsync(int id)
        {
            string paymentDetails = "";
            double total = 0;
            var cart = await _cartRepo.GetByKey(id);

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
        /// <summary>
        /// Removes items from the cart with the specified ID based on the provided list of item IDs.
        /// </summary>
        /// <param name="id">The ID of the cart to remove items from.</param>
        /// <param name="cartItemIds">The list of IDs of items to be removed from the cart.</param>
        /// <returns>The updated cart after removing the specified items.</returns>
        public async Task<Cart> RemoveItemsFromCartAsync(int id, List<int> cartItemIds)
        {
            var cart = await _cartRepo.GetByKey(id);

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

        /// <summary>
        /// Updates the cart with the specified ID using the provided cart object.
        /// </summary>
        /// <param name="id">The ID of the cart to update.</param>
        /// <param name="cart">The updated cart object.</param>
        /// <returns>The updated cart.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when the cart with the specified ID is not found.</exception>
        public async Task<Cart> UpdateCartAsync(int id, Cart cart)
        {

            if (cart != null)
            {
                return await _cartRepo.Update(cart);
            }
            throw new EntityNotFoundException(Entity.Cart);
        }
    }
}
