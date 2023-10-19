namespace BVZ.BVZ.Domain.DomainExceptions
{
     public class DomainOperationFailedException : Exception
    {
        public DomainOperationFailedException(string message) : base(message)
        {
        }
    }
}
