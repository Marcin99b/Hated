using System;

namespace Hated.Infrastructure.DTO
{
    public class UpdateByAdminDto
    {
        public Guid AdminId { get; set; }
        public string Comment { get; set; }
        public DateTime ChangeAt { get; set; }
    }
}
