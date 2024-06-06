using Application.DTO;
using Application.DTO.User;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Application.Interfaces
{
    public interface IUserService
    {
        UserManager<User> _userManager => this._userManager;
        Task<ServiceResult<User>> UserRegister(RegisterUserDto registerDto);
        Task<ServiceResult<User>> ResetPassword(AccountConfirmationDto confirmationDto);
        Task RegisterRole(string userEmail, RolesEnum role);
        Task<User?> GetById(Guid id);
        Task<User?> GetByEmail(string email);
        Task<UserResult> GetUserInformation(Guid userId);
        Task<ServiceResult<ResetPasswordResult>> GetPasswordConfirmation(string userId);
    }
}
