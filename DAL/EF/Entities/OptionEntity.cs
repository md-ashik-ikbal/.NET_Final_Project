using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Entities
{
    public class OptionEntity
    {
        [Key]
        public int OptionId { get; set; }
        public string Text { get; set; }
        public int VoteCount { get; set; }

        [ForeignKey("Poll")]
        public int PollId { get; set; }
        public virtual PollEntity Poll { get; set; }

        public virtual ICollection<VoteEntity> Votes { get; set; }
    }

}
