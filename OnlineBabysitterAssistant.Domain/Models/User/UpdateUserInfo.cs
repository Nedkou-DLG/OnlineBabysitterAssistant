using System;
namespace OnlineBabysitterAssistant.Domain.Models.User
{
    public class UpdateUserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

