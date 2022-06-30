
using OnlineBabysitterAssistant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Domain.Models.User
{
    public class AuthenticateUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public UserType Type { get; set; }


        public AuthenticateUser(UserRecord user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Username = user.UserName;
            Email = user.Email;
            Type = user.Type;
            Token = token;
        }
    }
}
