using System;
using System.Collections.Generic;

namespace Hated.Infrastructure.DTO
{
	public class DetailPostDto
	{
	    public Guid Id { get; set; }
	    public UserDto Author { get; set; }
	    public string Content { get; set; }
	    public IEnumerable<CommentDto> Comments { get; set; }
	    public bool Activated { get; set; }
	    public DateTime ChangedAt { get; set; }
	    public DateTime CreatedAt { get; set; }
    }
}