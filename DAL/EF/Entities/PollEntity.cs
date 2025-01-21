using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        // Foreign key to UserEntity
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual ICollection<OptionEntity> Options { get; set; }
        public virtual ICollection<VoteEntity> Votes { get; set; }
    }
}
