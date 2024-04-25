using SolutionModelLib;
using SolutionModelLib.Enums;
using SolutionModelLib.Exceptions;

namespace ShoppingDALLib;

public class CustomerRepository : AbstractRepository<int, Customer>
{
    public override Customer Delete(int key)
    {
        var customer = GetByKey(key);

        items.Remove(customer);
        return customer;
    }

    public override Customer GetByKey(int key)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == key)
                return items[i];
        }

        throw new EntityNotFoundException(Entity.Customer);
    }

    public override Customer Update(Customer item)
    {
        var customer = GetByKey(item.Id);
        if (customer != null)
        {
            customer.Age = item.Age;
            customer.Phone = item.Phone;

            return customer;
        }

        throw new EntityNotFoundException(Entity.Customer);
    }
}