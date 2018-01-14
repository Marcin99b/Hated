using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hated.Core.Domain;
using Hated.Core.Repositories;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        //Create
        public async Task AddAsync(Guid userId, string content)
            => await _postRepository.AddAsync(new Post(userId, content));
        
        //Read
        public async Task<PostDto> GetAsync(Guid id)
        {
            var post = await _postRepository.GetAsync(id);
            if (post == null)
            {
                throw new Exception($"Post with id: {id} isn't exist");
            }

            return _mapper.Map<Post, PostDto>(post);
        }

        public async Task<IEnumerable<PostDto>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return posts.Select(post => _mapper.Map<Post, PostDto>(post));
        }

        //Update
        public async Task UpdateAsync(PostDto updatedPost)
        {
            var post = await _postRepository.GetAsync(updatedPost.Id);
            if (post == null)
            {
                throw new Exception($"Post with id: {updatedPost.Id} isn't exist");
            }
            post.SetContent(updatedPost.Content);
            await _postRepository.UpdateAsync(post);
        }

        //Delete
        public async Task DeleteAsync(Guid id)
        {
            var post = await _postRepository.GetAsync(id);
            if (post == null)
            {
                throw new Exception($"Post with id: {id} isn't exist");
            }
            await _postRepository.RemoveAsync(post);
        }
    }
}
