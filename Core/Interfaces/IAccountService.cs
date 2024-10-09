using Core.Dtos;

namespace Core.Interfaces
{
    public interface IAccountService
    {
        Task Login(LoginDto model);
        Task Register(RegisterDto model);
        Task Logout();
    }
}
