namespace WebSaleAdmin.Models.Responses.Accounts
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }

        public string Username { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string RoleName { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

        public string DeletedAt { get; set; }

        public bool IsActive { get; set; }
    }
}