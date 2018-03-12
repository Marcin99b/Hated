using System;

namespace Hated.Core.Domain
{
    public class UpdateByAdmin
    {
        public Guid AdminId { get; protected set; }
        public string Comment { get; protected set; }
        public DateTime ChangeAt { get; protected set; }

        public UpdateByAdmin(Guid adminId, string comment)
        {
            AdminId = adminId;
            Comment = comment;
            ChangeAt = DateTime.UtcNow;
        }
    }
}
