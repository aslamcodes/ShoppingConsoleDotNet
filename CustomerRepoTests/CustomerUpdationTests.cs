using ShoppingDALLib;
using SolutionModelLib;
using SolutionModelLib.Exceptions;

namespace CustomerRepoTests
{
    public class CustomerUpdationTests
    {
        private CustomerRepository _customerRepository;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new CustomerRepository();
            _customerRepository.Add(new Customer(1, "123", 12));
        }

        [Test]
        public void UpdateCustomerSuccess()
        {
            var customer = _customerRepository.GetByKey(1);

            customer.Age = 112;

            var updatedCustomer = _customerRepository.Update(customer);

            Assert.That(updatedCustomer, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(updatedCustomer.Id, Is.EqualTo(1));
                Assert.That(updatedCustomer.Age, Is.EqualTo(112));
            });

        }

        [Test]
        public void UpdateCustomerFail()
        {
            var exception = Assert.Throws<EntityNotFoundException>(() => _customerRepository.Update(_customerRepository.GetByKey(2)));

            Assert.That(exception.Message, Is.EqualTo("Customer not found"));
        }
    }
}