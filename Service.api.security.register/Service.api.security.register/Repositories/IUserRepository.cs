using Service.api.security.register.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.api.security.register.Repositories
{
    public interface IUserRepository
    {
        Task Save(UserCreationDTO userCreationDTO);
        Task<int> GetTotalRecords();
        Task<List<UserDTO>> GetAllUsers(int page, int records, string searchUser);
    }
}
