namespace SolutionModelLib
{
    public class Customer(int id, string phone, int age): IComparable<Customer>
    {
        public int Id { get; set; } = id;
        public string Phone { get; set; } = phone;
        public int Age { get; set; } = age;

        public int CompareTo(Customer? other)
        {
            return Age.CompareTo(other.Id);
        }
        
      
    }
  
}
