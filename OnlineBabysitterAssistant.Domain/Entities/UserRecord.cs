using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using OnlineBabysitterAssistant.Domain.Interfaces;

namespace OnlineBabysitterAssistant.Domain.Entities
{
    [Table("Users")]
    public class UserRecord : IEntity
    {
        public UserRecord()
        {
            this.CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}
