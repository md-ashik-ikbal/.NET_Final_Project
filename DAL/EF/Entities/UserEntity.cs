using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Entities
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<VoteEntity> Votes { get; set; }
    }
}
