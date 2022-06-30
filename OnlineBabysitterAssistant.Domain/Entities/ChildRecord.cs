using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using OnlineBabysitterAssistant.Domain.Interfaces;

namespace OnlineBabysitterAssistant.Domain.Entities
{
    [Table("Children")]
    public class ChildRecord : IEntity
    {
        public ChildRecord()
        {
            this.CreatedDate = DateTime.Now;
            this.ActivityRecords = new List<ActivityRecord>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public int ParentId { get; set; }
        public virtual ParentRecord Parent { get; set; }

        public int? BabysitterId { get; set; }
        public virtual BabysitterRecord Babysitter { get; set; }

        public virtual ICollection<ActivityRecord> ActivityRecords { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}
