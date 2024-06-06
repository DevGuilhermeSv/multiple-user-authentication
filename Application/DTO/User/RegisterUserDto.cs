using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.User
{
    public class RegisterUserDto
    {
        public string Email { get; internal set; }
        public string Name { get; internal set; }
        public string Username { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string Password { get; internal set; }
        public string PasswordConfirmation { get; internal set; }
    }
}
