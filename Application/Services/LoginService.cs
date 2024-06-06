using Application.DTO;
using Application.DTO.Login;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Services
{
    public class AccountService  : IAccountService
    {
        private IUserService _userService;
        private readonly JWTSchemeOptions _jwtSchemeOptions;
        public async Task<ServiceResult<LoginResult>> Login(LoginDto loginDto)
        {
            var user = await _userService.GetByEmail(loginDto.Email);
               if(user is null) return ServiceResult<LoginResult>.FailResult("User not found");

            if (await _userService._userManager.IsEmailConfirmedAsync(user) == false)
            {
                return ServiceResult<LoginResult>.FailResult("Email not confirmed");
            }

            if (await _userService._userManager.CheckPasswordAsync(user, loginDto.Password!) == false)
            {
                return ServiceResult<LoginResult>.FailResult("Invalid Password");
            }

            var authClaims = await GenerateClaim(user);
            var token = GetToken(authClaims);
            var tokenSerialized = new JwtSecurityTokenHandler().WriteToken(token);
            return ServiceResult<LoginResult>.SucessResult(new() { Token = tokenSerialized, ValidTo = token.ValidTo }, null);
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            if (_jwtSchemeOptions.SigningKeys is not null && _jwtSchemeOptions.SigningKeys.Length > 0)
            {
                var value = _jwtSchemeOptions.SigningKeys[0].Value;
                if (!string.IsNullOrEmpty(value))
                {
                    var secretKey = Convert.FromBase64String(value);
                    var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: _jwtSchemeOptions.ValidIssuer,
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: signingCredentials
                        );

                    return token;
                }
                throw new NullReferenceException("SigningKey value can not be null");
            }
            throw new Exception("Signinkeys was not defined");


        }
        private async Task<List<Claim>> GenerateClaim(User user)
        {
            var claims = new List<Claim>
                {
                    new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new (ClaimTypes.Email, user.Email),
                    new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var userRoles = await _userService._userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
                claims.Add(new(ClaimTypes.Role, userRole));

            var validAudiences = _jwtSchemeOptions.ValidAudiences;

            foreach (var aud in validAudiences)
                claims.Add(new(JwtRegisteredClaimNames.Aud, aud));

            return claims;
        }
    }
}
