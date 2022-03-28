using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.api.security.register.DTOs;
using Service.api.security.register.Entities;
using Service.api.security.register.Services;
using System;
using System.Threading.Tasks;


namespace Service.api.security.register.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly int _records = 10;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet()]
        [Route("Search")]
        public async Task<ActionResult<PaginationDTO>> Get(int? page, string searchUser) 
        {
            int _page = page ?? 1;
            int total_records = await _userService.GetTotalRecords();
            int total_pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(total_records / _records)));
            var usersDTO = await _userService.GetAllUsers(_page, _records, searchUser);

            if(usersDTO.Count == 0)
            {
                _logger.LogWarning($"There are no matching records in the database {searchUser}");
                return BadRequest("No results found");
            }

            PaginationDTO paginationDTO = new PaginationDTO()
            {
                Status = Status.SuccessfulInsert,
                Message = "",
                Page = _page,
                PageSize = total_pages,
                CurrentPpage = _page,
                PageQuantity = total_records,
                UsersDTO = usersDTO
            };

            return Ok(paginationDTO);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Post([FromBody] UserCreationDTO userCreationDTO)
        {
            await _userService.Save(userCreationDTO);
            
            return NoContent();
        }
    }
}
