using BLL.DTO;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces.IEFServices
{
    public interface IEFRoleService
    {
        Task<string> CreateRole(RoleDTO role);
        Task AppointRole(int userId, string role);
        Task<IList<string>> GetRoleById(int id);
    }
}
