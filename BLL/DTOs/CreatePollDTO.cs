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
        public bool IsAnonymous { get; set; }

        // Optionally, include related options and votes (you can use DTOs for these entities too)
        public IEnumerable<OptionDto> Options { get; set; }
        public int VoteCount { get; set; }  // You can include the count of votes if needed
    }
}
