using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hated.Core.Domain;
using Hated.Core.Repositories;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Extensions;

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
        public async Task<Guid> AddAsync(Guid userId, string content)
        {
            content.PostContentValidation();
            var post = new Post(userId, content);
            await _postRepository.AddAsync(post);
            return post.Id;
        }
        
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

        public async Task<IEnumerable<PostDto>> GetAllAsync(int? from, int? number)
        {
            var posts = from != null && number != null ? 
                await _postRepository.GetAllAsync((int)from, (int)number) 
                : await _postRepository.GetAllAsync();
            return posts.Select(x => _mapper.Map<Post, PostDto>(x));
        }

        //Update
        public async Task UpdateAsync(PostDto updatedPost)
        {
            updatedPost.Content.PostContentValidation();
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
