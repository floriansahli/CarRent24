namespace CarRent24.Common
{
    public class DomainException : Exception
    {
        public DomainException(string code, string message) : base(message)
        {

        }
    }
}
