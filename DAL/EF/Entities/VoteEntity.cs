using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Entities
{
    public class VoteEntity
    {
        [Key]
        public int VoteId { get; set; }

        public bool IsAnonymous { get; set; }

        // Foreign Key to UserEntity
        [ForeignKey("User")] // This refers to the navigation property "User", not the entity class name
        public int UserId { get; set; }

        // Navigation property to UserEntity
        public UserEntity User { get; set; } // Navigation property pointing to UserEntity

        // Foreign Key to OptionEntity
        [ForeignKey("Option")]
        public int OptionId { get; set; }
        public virtual OptionEntity Option { get; set; }

        // Foreign Key to PollEntity
        [ForeignKey("Poll")]
        public int PollId { get; set; }
        public virtual PollEntity Poll { get; set; }
    }

}
