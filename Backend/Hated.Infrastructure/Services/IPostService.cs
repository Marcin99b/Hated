using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public interface IPostService : IService
    {
        Task<Guid> AddAsync(Guid userId, string content);
        Task<DetailPostDto> GetAsync(Guid id);
        Task<IEnumerable<PostDto>> GetAllAsync(int? from, int? number);
        Task UpdateAsync(PostDto updatedPost);
        Task DeleteAsync(Guid id);
    }
}
