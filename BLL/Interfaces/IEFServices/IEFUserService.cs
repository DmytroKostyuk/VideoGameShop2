using BLL.DTO;
using DAL.Entities;
using System.Threading.Tasks;

namespace BLL.Interfaces.IEFServices
{
    public interface IEFUserService
    {
        Task<string> Register(UserRegisterDTO user);

        Task<string> Login(UserLoginDTO user);

        Task<string> Logout();

        Task<string> Create(UserCreateDTO user);

        Task<string> Edit(UserEditDTO user);

        Task<string> Delete(int id);

        Task<string> ChangePassword(UserChangePasswordDTO user);

        Task<string> BuildToken(User user);
    }
}
