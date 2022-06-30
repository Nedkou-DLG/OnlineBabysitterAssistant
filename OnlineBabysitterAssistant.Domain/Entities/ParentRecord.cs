using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Domain.Entities
{
    [Table("parents")]
    public class ParentRecord : UserRecord
    {
        public virtual ICollection<BabysitterRecord> Babysitters { get; set; }
        public virtual ICollection<ChildRecord> Children { get; set; }
        public ParentRecord()
        {
            this.Babysitters = new List<BabysitterRecord>();
            this.Children = new List<ChildRecord>();
        }
    }
}
