using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CustomerRepoTests
{
    public class CustomerRetrieval
    {
        private CustomerRepository _customerRepository;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new CustomerRepository();
            _customerRepository.Add(new Customer(1, "123", 12));
        }

        [Test]
        public void GetCustomerSuccess()
        {
            var customer = _customerRepository.GetByKey(1);

            Assert.That(customer, Is.Not.Null);
            Assert.That(customer.Id, Is.EqualTo(1));


        }

        [Test]
        public void GetCustomerFail()
        {
            var exception = Assert.Throws<EntityNotFoundException>(() => _customerRepository.GetByKey(2));

            Assert.That(exception.Message, Is.EqualTo("Customer not found"));
        }
    }
}