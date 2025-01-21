using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CreatePollDto
    {
        public int PollId { get; set; }
        public string Question { get; set; }
        public DateTime EndDateTime { get; set; }
        public int UserId { get; set; } // Just the UserId, not the whole User object

        // You can include these if you want to return options and votes in the DTO
        public List<CreateOptionDto> Options { get; set; }
        public List<CreateVoteDto> Votes { get; set; }
    }
}
