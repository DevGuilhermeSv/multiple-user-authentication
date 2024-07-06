using Application.DTO.User;

namespace Application.DTO.Manager;

public record ManagerDto()
{
    public RegisterUserDto RegisterUserDto { get; set; }
}