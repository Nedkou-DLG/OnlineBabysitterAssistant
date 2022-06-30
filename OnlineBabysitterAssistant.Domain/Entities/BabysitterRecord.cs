using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBabysitterAssistant.Domain.Entities
{
    [Table("babysitters")]
    public class BabysitterRecord : UserRecord
    {
        public virtual ICollection<ParentRecord> Parents { get; set; }
        public virtual ICollection<ChildRecord> Children { get; set; }

        public BabysitterRecord()
        {
            this.Parents = new List<ParentRecord>();
            this.Children = new List<ChildRecord>();
        }
    }
}
