using FirstMvcProject.Domain.Dtos;
using FirstMvcProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FirstMvcProject.Application.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AccountService(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async ValueTask<bool> Login(LoginDto loginDto)
        {
                try
                {
                    var user = _userManager.Users.FirstOrDefault(x => x.Email == loginDto.Email);
                    if (user == null)
                    {
                        return false;
                    }
                    await _signInManager.SignInAsync(user, true);
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
        }

        public async ValueTask<bool> Registor(RegistorDto registorDto)
        {
            var registor = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == registorDto.Email);
            if (registor != null)
            {
                return false;
            }

            var user = new User()
            {
                UserName = registorDto.Name,
                Email = registorDto.Email,
                

            };
            var result = await _userManager.CreateAsync(user, registorDto.Password);
            var createRole = await _roleManager.CreateAsync(new Role() { Name = registorDto.Role });
            var Roleresult = await _userManager.AddToRoleAsync(user, registorDto.Role);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
            }
            return true;
        }
    }
}
