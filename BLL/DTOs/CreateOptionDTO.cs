using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OptionDto
    {
        public int OptionId { get; set; }
        public string Text { get; set; }
        public int VoteCount { get; set; }

        // Optionally, you could include the related Poll's information if required
        public int PollId { get; set; }
        public string PollQuestion { get; set; }  // Include the question text from the related PollEntity
    }
}
