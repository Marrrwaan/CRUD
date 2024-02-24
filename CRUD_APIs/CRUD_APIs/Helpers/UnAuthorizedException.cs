namespace CRUD_APIs.Helpers
{
    public class UnAuthorizedException : ApplicationException
    {
        public UnAuthorizedException()
        {
        }
        public UnAuthorizedException(string message) : base(message)
        {
        }

        public static void ThrowIfNull(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new UnAuthorizedException("Token is empty");
            }
        }
    }
}