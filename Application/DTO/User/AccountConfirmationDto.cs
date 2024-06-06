using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.User
{
    public class AccountConfirmationDto
    {
        public string Password { get; internal set; }
        public string PasswordConfirmation { get; internal set; }
        public string TokenConfirmation { get; internal set; }
        public string UserId { get; internal set; }
    }
}
