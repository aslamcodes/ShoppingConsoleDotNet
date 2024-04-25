
using SolutionModelLib.Enums;

namespace SolutionModelLib.Exceptions
{
    public partial class EntityNotFoundException : Exception
    {
        private readonly string message;
        public EntityNotFoundException(Entity entity)
        {
            message = $"{entity} not found";
        }

        public override string Message => message;
    }
}
