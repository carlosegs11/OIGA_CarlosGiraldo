using Service.api.security.register.DTOs;
using Service.api.security.register.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.api.security.register.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Save (UserCreationDTO userCreationDTO)
        {
            await _userRepository.Save(userCreationDTO);
        }

        public async Task<List<UserDTO>> GetAllUsers(int page, int records, string searchUser)
        {
            return await _userRepository.GetAllUsers(page, records, searchUser);
        }

        public async Task<int> GetTotalRecords()
        {
            return await _userRepository.GetTotalRecords();
        }
    }
}
