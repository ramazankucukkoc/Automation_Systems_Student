namespace Core.CrossCuttingConcerns.Types
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message)
            : base(message) { }
    }


}
