namespace SolutionModelLib.Exceptions
{
    public class CartFullException : Exception
    {
        private readonly string message;

        public CartFullException()
        {
            message = $"Cart full";
        }

        public override string Message => message;
    }
}
