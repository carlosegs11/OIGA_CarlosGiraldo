using Service.api.security.register.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.api.security.register.Services
{
    public interface IUserService
    {
        Task Save(UserCreationDTO userCreationDTO);
        Task<List<UserDTO>> GetAllUsers(int page, int records, string searchUser);
        Task<int> GetTotalRecords();
    }
}
