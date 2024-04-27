using SolutionModelLib;
using SolutionModelLib.Enums;
using SolutionModelLib.Exceptions;

namespace ShoppingDALLib;

public class CustomerRepository : AbstractRepository<int, Customer>
{
    async public override Task<Customer> Delete(int key)
    {
        var customer = await GetByKey(key);

        items.Remove(customer);

        return customer;
    }

    public override Task<Customer> GetByKey(int key)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == key)
                return Task.FromResult(items[i]);
        }

        throw new EntityNotFoundException(Entity.Customer);
    }

    async public override Task<Customer> Update(Customer item)
    {
        var customer = await GetByKey(item.Id);

        if (customer != null)
        {
            customer.Age = item.Age;
            customer.Phone = item.Phone;

            return customer;
        }

        throw new EntityNotFoundException(Entity.Customer);
    }
}