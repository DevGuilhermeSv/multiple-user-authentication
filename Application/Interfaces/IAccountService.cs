using Application.DTO;
using Application.DTO.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {

        Task<ServiceResult<LoginResult>> Login(LoginDto loginDto);
    }
}
