using Service.api.security.register.Entities;
using System.Collections.Generic;

namespace Service.api.security.register.DTOs
{
    public class PaginationDTO
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int CurrentPpage { get; set; }
        public string Sort { get; set; }
        public string SortDirection { get; set; }
        public string Filter { get; set; }
        public int PageQuantity { get; set; }
        public List<UserDTO> UsersDTO { get; set; }
    }
}
