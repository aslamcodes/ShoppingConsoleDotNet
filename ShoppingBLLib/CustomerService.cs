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

        public Customer CreateCustomer(Customer customer)
        {
            var createdCustomer = customerRepo.Add(customer);

            if (createdCustomer != null)
            {
                return createdCustomer;
            }

            throw new DuplicateEntityException(Entity.Customer);
        }

        public Customer DeleteCustomer(int id)
        {
            var deletedCustomer = customerRepo.Delete(id);

            if (deletedCustomer != null)
            {
                return deletedCustomer;
            }

            throw new EntityNotFoundException(Entity.Customer);
        }

        public Customer GetCustomer(int id)
        {
            var customer = customerRepo.GetByKey(id);

            if (customer != null)
            {
                return customer;
            }

            throw new EntityNotFoundException(Entity.Customer);
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            var updatedProduct = customerRepo.Update(customer);

            return updatedProduct;
        }
    }
}
