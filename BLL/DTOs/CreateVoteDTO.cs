using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CreateVoteDto
    {
        public int VoteId { get; set; }

        public bool IsAnonymous { get; set; }

        // Include only the necessary properties from the related entities
        public int UserId { get; set; }
        public string Username { get; set; }  // You can include additional user information if needed
        public int OptionId { get; set; }
        public string OptionDescription { get; set; }  // Assuming OptionEntity has a Description or Name property
        public int PollId { get; set; }
        public string PollTitle { get; set; }  // Assuming PollEntity has a Title or similar property
    }
}
