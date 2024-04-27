using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Enums;
using SolutionModelLib.Exceptions;

namespace ShoppingBLLib
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository customerRepo = new CustomerRepository();

        public CustomerService()
        {
            customerRepo = new CustomerRepository();
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            var createdCustomer = await customerRepo.Add(customer);

            if (createdCustomer != null)
            {
                return createdCustomer;
            }

            throw new DuplicateEntityException(Entity.Customer);
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var deletedCustomer = await customerRepo.Delete(id);

            if (deletedCustomer != null)
            {
                return deletedCustomer;
            }

            throw new EntityNotFoundException(Entity.Customer);
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var customer = await customerRepo.GetByKey(id);

            if (customer != null)
            {
                return customer;
            }

            throw new EntityNotFoundException(Entity.Customer);
        }

        public async Task<Customer> UpdateCustomerAsync(int id, Customer customer)
        {
            var updatedProduct = await customerRepo.Update(customer);

            return updatedProduct;
        }
    }
}
