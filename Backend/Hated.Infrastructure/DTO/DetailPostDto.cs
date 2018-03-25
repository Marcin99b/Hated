using System;
using System.Collections.Generic;
using Hated.Core.Domain;

namespace Hated.Infrastructure.DTO
{
	public class DetailPostDto
	{
	    public string Id { get; set; }
	    public UserDto Author { get; set; }
	    public string Title { get; set; }
	    public string Content { get; set; }
	    public IEnumerable<CommentDto> Comments { get; set; }
	    public int CountLikes { get; set; }
        public bool Activated { get; set; }
	    public IEnumerable<UpdateByAdminDto> UpdatesByAdmins { get; set; }
        public DateTime ChangedAt { get; set; }
	    public DateTime CreatedAt { get; set; }
    }
}