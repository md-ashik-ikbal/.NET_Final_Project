using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LoginDTO
    {
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }
    }
}
