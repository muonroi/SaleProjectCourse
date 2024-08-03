namespace WebSaleAdmin.Models.Requests.Accounts
{
    public class RegisterAccountWithRoleRequest : RegisterRequest
    {
        public long RoleId { get; set; }
    }
}