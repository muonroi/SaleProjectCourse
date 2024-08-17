namespace WebSaleAdmin.Infrastructure
{
    public static class EndPointConfig
    {
        private const string BaseEndpoint = "http://localhost:9000/api";
        public const string BaseAccountEndpoint = "/Account";

        public static string AccountLogin = $"{BaseEndpoint}{BaseAccountEndpoint}";
        public static string AccountRegister = $"{BaseEndpoint}{BaseAccountEndpoint}/register";
        public static string AccountStatistic = $"{BaseEndpoint}{BaseAccountEndpoint}/account-status";
        public static string AccountUpdateInfo = $"{BaseEndpoint}{BaseAccountEndpoint}";
        public static string AccountList = $"{BaseEndpoint}{BaseAccountEndpoint}";
        public static string RoleList = $"{BaseEndpoint}{BaseAccountEndpoint}/roles-list";
        public static string AssignRole = $"{BaseEndpoint}{BaseAccountEndpoint}/role-assign";
        public static string ManageRole = $"{BaseEndpoint}{BaseAccountEndpoint}/role";
        public static string DeleteAccount = $"{BaseEndpoint}{BaseAccountEndpoint}?username={{0}}";
        public static string LockAccount = $"{BaseEndpoint}{BaseAccountEndpoint}/lock";

        public static string BaseUserEndpoint = $"/User";
        public static string UserEditInfo = $"{BaseEndpoint}{BaseUserEndpoint}?username={{0}}";
    }
}