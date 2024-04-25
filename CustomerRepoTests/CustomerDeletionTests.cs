using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CustomerRepoTests
{
    public class CustomerDeletionTests
    {
        private CustomerRepository _customerRepository;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new CustomerRepository();

        }

        [Test]
        public void DeleteCustomeruccess()
        {

            _customerRepository.Add(new Customer(1, "123", 12));

            var customer = _customerRepository.Delete(1);

            Assert.That(customer, Is.Not.Null);
            Assert.That(customer.Id, Is.EqualTo(1));
            Assert.Throws<EntityNotFoundException>(() => _customerRepository.Delete(1));
        }

        [Test]
        public void DeleteCustomerFail()
        {
            var exception = Assert.Throws<EntityNotFoundException>(() => _customerRepository.Delete(2));

            Assert.That(exception.Message, Is.EqualTo("Customer not found"));
        }
    }
}