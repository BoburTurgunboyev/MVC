using FirstMvcProject.Domain.Dtos;

namespace FirstMvcProject.Application.Services.AccountServices
{
    public interface IAccountService
    {
        public ValueTask<bool> Login(LoginDto loginDto);
        public ValueTask<bool> Registor(RegistorDto registorDto);
    }
}
