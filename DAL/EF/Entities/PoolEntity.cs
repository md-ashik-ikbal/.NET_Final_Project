using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Entities
{
    public class PollEntity
    {
        [Key]
        public int PollId { get; set; }
        public string Question { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool IsAnonymous { get; set; }

        public virtual ICollection<OptionEntity> Options { get; set; }
        public virtual ICollection<VoteEntity> Votes { get; set; }
    }
}
