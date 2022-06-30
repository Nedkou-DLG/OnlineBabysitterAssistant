using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using OnlineBabysitterAssistant.Domain.Interfaces;

namespace OnlineBabysitterAssistant.Domain.Entities
{
    [Table("activities")]
    public class ActivityRecord : IEntity
    {
        public ActivityRecord()
        {
            this.CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int ChildId { get; set; }
        public virtual ChildRecord Child { get; set; }
        public DateTime? Time { get; set; }
        public string? Description { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}
