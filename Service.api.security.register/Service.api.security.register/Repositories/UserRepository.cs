using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Service.api.security.register.DTOs;
using Service.api.security.register.Entities;
using Service.api.security.register.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.api.security.register.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task Save (UserCreationDTO userCreationDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userCreationDTO);
                _context.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("An error occurred with the insertion of the user.");
            }
        }

        public async Task<int> GetTotalRecords()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<List<UserDTO>> GetAllUsers(int page, int records, string searchUser)
        {
            try
            {
                List<UserDTO> usersDTO = new();
                var AllUsers = await _context.Users.Select(x => new
                {
                    FullName = x.FullName,
                    Username = x.UserName,
                    Search = x.FullName + " " + x.UserName
                }).ToListAsync();

                var users = AllUsers.Where(x => x.Search.Contains(NormalizeText.TrimPunctuation(NormalizeText.RemoveDiacritics(searchUser)), System.StringComparison.OrdinalIgnoreCase))
                                    .Skip((page - 1) * records)
                                    .Take(records)
                                    .OrderBy(x => x.FullName);

                var filterUsers = users.Select(x => new UserDTO
                {
                    FullName = x.FullName,
                    UserName = x.FullName
                }).ToList();

                if (filterUsers.Count == 0)
                {
                    return usersDTO;
                }
                usersDTO = _mapper.Map<List<UserDTO>>(filterUsers);
                return usersDTO;
            }
            catch (Exception)
            {
                throw new Exception("An error occurred with the user query.");
            }
        }
    }
}
