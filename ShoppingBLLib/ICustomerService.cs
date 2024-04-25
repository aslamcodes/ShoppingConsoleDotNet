using SolutionModelLib;

namespace ShoppingBLLib
{
    public interface ICustomerService
    {
        Customer GetCustomer(int id);

        Customer UpdateCustomer(int id, Customer customer);

        Customer DeleteCustomer(int id);

        Customer CreateCustomer(Customer customer);
    }
}
