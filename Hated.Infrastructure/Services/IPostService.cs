﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    interface IPostService
    {
        Task AddAsync(Guid userId, string content);
        Task<PostDto> GetAsync(Guid id);
        Task<IEnumerable<PostDto>> GetAllAsync();
        Task UpdateAsync(PostDto updatedPost);
        Task DeleteAsync(Guid id);
    }
}
