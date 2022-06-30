
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBabysitterAssistant.Domain.Entities;

namespace OnlineBabysitterAssistant.Domain.Models.User
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
    }
}
