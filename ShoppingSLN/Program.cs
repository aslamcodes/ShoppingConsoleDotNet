using ShoppingDALLib;
using SolutionModelLib;

namespace ShoppingSLN
{
    public class Program
    {


        static void Main(string[] args)
        {

            // Shipping app BL -> Unit Test
            IRepository<int, Customer> customerRepo = new CustomerRepository();
            customerRepo.Add(new Customer(1, "123", 2312));
            customerRepo.Add(new Customer(3, "123", 231));
            customerRepo.Add(new Customer(2, "123", 23123));

            var customers = customerRepo.GetAll().ToList();
            customers = customers.OrderBy(customer => customer).ToList();
            foreach (var item in customers)
            {
                Console.WriteLine(item.Age);
            }


        }


    }


}
