using SolutionModelLib.Enums;

namespace SolutionModelLib.Exceptions
{
    public class DuplicateEntityException : Exception
    {
        private readonly string message;

        public DuplicateEntityException(Entity entity)
        {
            message = $"Already a {entity} exists with same signature";
        }

        public override string Message => message;
    }
}
