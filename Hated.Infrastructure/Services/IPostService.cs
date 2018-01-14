using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Core.Domain;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public interface IPostService
    {
        Task AddAsync(Guid userId, string content);
        Task<PostDto> GetAsync(Guid id);
        Task<IEnumerable<PostDto>> GetAllAsync();
        Task UpdateAsync(PostDto updatedPost);
        Task DeleteAsync(Guid id);
    }
}
