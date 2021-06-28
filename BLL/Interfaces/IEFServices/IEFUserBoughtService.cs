using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces.IEFServices
{
    public interface IEFUserBoughtService
    {
        Task AddUserBought(UserBoughtDTO userBought);

        Task UpdateUserBought(UserBoughtDTO userBought);

        Task DeleteUserBought(int Id);

        Task<UserBoughtDTO> GetUserBoughtById(int Id);

        Task<IEnumerable<UserBoughtDTO>> GetAllUserBoughts();
    }
}
