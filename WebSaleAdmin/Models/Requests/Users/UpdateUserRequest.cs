﻿namespace WebSaleAdmin.Models.Requests.Users
{
    public class UpdateUserRequest
    {
        public string Fullname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}