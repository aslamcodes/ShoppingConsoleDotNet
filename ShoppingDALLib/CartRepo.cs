using SolutionModelLib;
using SolutionModelLib.Enums;
using SolutionModelLib.Exceptions;

namespace ShoppingDALLib;

public class CartRepo : AbstractRepository<int, Cart>
{
    async public override Task<Cart> Delete(int key)
    {
        Cart customer = await GetByKey(key);

        if (customer != null)
        {
            items.Remove(customer);
            return customer;

        }

        throw new EntityNotFoundException(Entity.Cart);
    }

    public override Task<Cart> Add(Cart item)
    {
        foreach (var cart in items)
        {
            if (cart.Id == item.Id)
            {
                throw new DuplicateEntityException(Entity.Cart);
            }
        }
        return base.Add(item);
    }

    public override Task<Cart> GetByKey(int key)
    {
        foreach (var t in items)
        {
            if (t.Id == key)
                return Task.FromResult(t);
        }

        throw new EntityNotFoundException(Entity.Cart);
    }

    async public override Task<Cart> Update(Cart item)
    {
        Cart customer = await GetByKey(item.Id);
        if (customer != null)
        {
            customer = item;
            return customer;
        }
        throw new EntityNotFoundException(Entity.Cart);
    }

}
