using SolutionModelLib;

namespace ShoppingBLLib
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerAsync(int id);

        Task<Customer> UpdateCustomerAsync(int id, Customer customer);

        Task<Customer> DeleteCustomerAsync(int id);

        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}
