
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

using Application.DTO.User;
using Application.DTO;

namespace Application.service
{
    public class UserService : IUserService
    {
        public UserManager<User> _userManager { get; private set; }
        private RoleManager<IdentityRole> _roleManager;
        private string Error;
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly IAdminRepository _adminRepository;

        public UserService(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            IManagerRepository managerRepository,
            IClientRepository clientRepository,
            IAdminRepository adminRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _managerRepository = managerRepository;
            _clientRepository = clientRepository;
            _adminRepository = adminRepository;
        }


        /// <summary>
        /// Register a new User without Password
        /// </summary>
        /// <param name="registerDto"> The Dto used to manage new users.</param>
        /// <returns>
        /// Returns a IdentityResult from new User registered on system withou account confirmation
        /// </returns>
        public async Task<ServiceResult<User>> UserRegister(RegisterUserDto registerDto)
        {
            var userExists = await _userManager.FindByEmailAsync(registerDto.Email);

            if (userExists != null)
            {
                Error = "User is already registered";
            }

            var user = new User()
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                UserName = registerDto.Username,
                PhoneNumber = registerDto.PhoneNumber
            };
            if (ValidadePassword(registerDto.Password, registerDto.PasswordConfirmation))
            {
                var result = await _userManager.CreateAsync(user, registerDto.Password);

                if (result.Succeeded)
                {
                    return ServiceResult<User>.SucessResult(user, null);
                }
            }

           
            return ServiceResult<User>.FailResult(Error);

        }

        public async Task<ServiceResult<User>> ResetPassword(AccountConfirmationDto confirmationDto)
        {
            var user = await _userManager.FindByIdAsync(confirmationDto.UserId);
            if (user != null)
            {
                if (ValidadePassword(confirmationDto.Password, confirmationDto.PasswordConfirmation))
                {

                    var passResult = await _userManager.ResetPasswordAsync(user, confirmationDto.TokenConfirmation, confirmationDto.Password);
                    if (passResult.Succeeded)
                    {
                        await _userManager.UpdateAsync(user);
                        return ServiceResult<User>.SucessResult(user, "Password reseted with success");

                    }
                    Error = passResult.ToString();
                }
                Error = "Invalid Password";
            }
            Error = "User not found";

            return ServiceResult<User>.FailResult(Error);
        }

        public async Task RegisterRole(string userEmail, string role)
        {

            if (await _roleManager.RoleExistsAsync(role))
            {
                User user = await _userManager.FindByEmailAsync(userEmail);
                if (user == null) { throw new Exception("User not found"); }
                await _userManager.AddToRoleAsync(user, role);
            }
            else throw new Exception("Role undefined");
        }

        private bool ValidadePassword(string password, string passwordConfirmation)
        {

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordConfirmation)) return false;

            if (!password.Equals(passwordConfirmation)) return false;

            return true;

        }

        public async Task<ServiceResult<ResetPasswordResult>> GetPasswordConfirmation(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return ServiceResult<ResetPasswordResult>.FailResult("User not found");

            await _userManager.UpdateAsync(user);

            var passwdToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = new ResetPasswordResult()
            {
                ResetPasswordToken = passwdToken
            };
            return ServiceResult<ResetPasswordResult>.SucessResult(result,null);
            
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<UserResult> GetUserInformation(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null) throw new ArgumentException("User not fouding");
            var role = await _userManager.GetRolesAsync(user);

            UserResult userResult = _mapper.Map<UserResult>(user);
            userResult.Role = role;

            userResult.Id = GetEntityId(role[0], userId);

            return userResult;

        }
        private Guid GetEntityId(string role, Guid id)
        {
            if (role == Roles.Admin)
            {
                return _adminRepository.GetById(id).Id;
            }
            if (role == Roles.Manager)
            {
                return _managerRepository.GetById(id).Id;
            }
            if (role == Roles.Client)
            {
                return _clientRepository.GetById(id).Id;
            }
            throw new ArgumentException("Role undefined");
        }

    }
}
