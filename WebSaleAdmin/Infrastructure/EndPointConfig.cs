namespace WebSaleAdmin.Infrastructure
{
    public static class EndPointConfig
    {
        private const string BaseEndpoint = "http://localhost:9000/api";
        public const string BaseAccountEndpoint = "/Account";
        public static string AccountLogin = $"{BaseEndpoint}{BaseAccountEndpoint}";
        public static string AccountRegister = $"{BaseEndpoint}{BaseAccountEndpoint}/register";
    }
}