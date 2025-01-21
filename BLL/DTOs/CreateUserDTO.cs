using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CreateUserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }
        public IEnumerable<CreateVoteDto> Votes { get; set; }
    }
}
