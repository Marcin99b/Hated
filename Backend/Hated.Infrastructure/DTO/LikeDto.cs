using System;

namespace Hated.Infrastructure.DTO
{
    public class LikeDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
