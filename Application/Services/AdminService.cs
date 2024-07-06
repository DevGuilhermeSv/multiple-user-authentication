using Application.DTO;
using Application.DTO.Admin;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Interfaces;

namespace Application.Services;

public class AdminService: IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IUserService _userService;
    public AdminService(IAdminRepository adminRepository, IUserService userService)
    {
        _adminRepository = adminRepository;
        _userService = userService;
    }

    public async Task<ServiceResult<Admin>> CreateAdmin(AdminDto adminDto)
    {
        var userResult = await _userService.UserRegister(adminDto.RegisterUserDto);
        if (!userResult.Success)
            return ServiceResult<Admin>.FailResult("Fail at register user");
        await _userService.RegisterRole(userResult.Data!.Email!, Roles.Admin);

        var admin = new Admin()
        {
            UserId = userResult.Data.Id
        };
        _adminRepository.Add(admin);
        return ServiceResult<Admin>.SucessResult(admin,"User Registered with success");
    }

    public ServiceResult<Admin> GetAdminById(Guid id)
    {
        var result = _adminRepository.GetById(id);
        return result is not null? ServiceResult<Admin>.SucessResult( result,null) : ServiceResult<Admin>.FailResult("User not found");
        
    }

    public ServiceResult<IList<Admin>> GetAdmin()
    {
        var result = _adminRepository.GetAll().ToList();
        return result.Any()? ServiceResult<IList<Admin>>.SucessResult( result.ToList(),null) : ServiceResult<IList<Admin>>.FailResult("User not found");

    }
}