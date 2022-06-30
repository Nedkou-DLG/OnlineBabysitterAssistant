
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Models.Child;

namespace OnlineBabysitterAssistant.Domain.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class BabysitterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsConnectedToParent { get; set; }
        public ICollection<UserModel> Parents { get; set; }
        public ICollection<ChildModel> Children { get; set; }
    }
}
