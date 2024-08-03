using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Business.DTOs.User;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Domain.Enums;
using Core.Services.ServiceClasses;
using Core.Services.ServiceExtension;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services.ServiceManager;

public class UserAuthenticationManager : IUserAuthenticationService
{

           private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IHashingService _hashingService;
        private readonly RoleRepository _roleRepository;
        private readonly UserRepository _userRepository;

        public UserAuthenticationManager(IConfiguration configuration, IUserService userService, IMapper mapper, IHashingService hashingService, RoleRepository roleRepository, UserRepository userRepository)
        {
            _configuration = configuration;
            _userService = userService;
            _mapper = mapper;
            _hashingService = hashingService;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public async Task<string> Login(UserAuthentication userAuthentication)
        {
            var user = await _userService.GetByEmail(userAuthentication.Email);
            if (user == null || !_hashingService.VerifyPassword(userAuthentication.Password, user.Password))
            {
                return string.Empty;
            }

            if (user.Roles == null || !user.Roles.Any())
            {
                Console.WriteLine("User roles are null or empty");
                return string.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            foreach (var userRole in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.RoleName));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    public async Task Register(UserRegistration userRegistration)
    {
        var userCreateDto = new UserCreateDto
        {
            Name = userRegistration.Name,
            Email = userRegistration.Email,
            Password = userRegistration.Password,
            PhoneNumber = userRegistration.PhoneNumber,
            Address = userRegistration.Address,
            RoleIds = new List<int> { (await _roleRepository.GetItems()).FirstOrDefault(r => r.RoleName == "User")?.Id ?? 0 }
        };

        var createdUser = await _userService.PostItem(userCreateDto);

        // foreach (var roleId in userCreateDto.RoleIds)
        // {
        //     var userRole = new UserRole
        //     {
        //         UserId = createdUser.Id,
        //         RoleId = roleId,
        //         CreatedBy = "system",
        //         UpdatedBy = "system",
        //         Deleted = false
        //     };
        //     await _userRepository.AddUserRole(userRole);
        // } 
    }
}
        
        

