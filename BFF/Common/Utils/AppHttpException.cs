public class AppHttpException : Exception
{
    public int StatusCode { get; }

    public AppHttpException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}