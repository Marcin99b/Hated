using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hated.Core.Domain;
using Hated.Core.Repositories;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Extensions;

namespace Hated.Infrastructure.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IUserRepository userRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //Create
        public async Task<string> AddAsync(Guid userId, string title, string content)
        {
            content.PostContentValidation();
            var post = new Post(userId, title, content);
            await _postRepository.AddAsync(post);
            return post.Id;
        }
        
        //Read
        public async Task<DetailPostDto> GetAsync(string id, int commentsFrom, int commentsNumber)
        {
            var post = await _postRepository.GetAsync(id);
            if (post == null)
            {
                throw new Exception($"Post with id: {id} isn't exist");
            }
            var user = await _userRepository.GetAsync(post.UserId);
            var userDto = _mapper.Map<User, UserDto>(user);
            var detailPost = _mapper.Map<Post, DetailPostDto>(post);
            detailPost.Comments = post.Comments
                .Paginate(commentsFrom, commentsNumber)
                .Select(x => _mapper.Map<Comment, CommentDto>(x));
            detailPost.Author = userDto;
            return detailPost;
        }

        public async Task<IEnumerable<PostDto>> GetAllAsync(int from = 0, int number = 100)
        {
            number = number > 100 ? 100 : number;
            var posts = await _postRepository.GetAllAsync(from, number);

            var postsDto = new List<PostDto>();
            foreach (var post in posts)
            {
                var user = await _userRepository.GetAsync(post.UserId);
                var postDto = _mapper.Map<Post, PostDto>(post);
                postDto.Author = _mapper.Map<User, UserDto>(user);
                postsDto.Add(postDto);
            }
            return postsDto;
        }

        //Update
        public async Task UpdateAsync(string postId, string title, string content)
        {
            content.PostContentValidation();
            var post = await _postRepository.GetAsync(postId);
            if (post == null)
            {
                throw new Exception($"Post with id: {postId} isn't exist");
            }
            post.SetTitle(title);
            post.SetContent(content);
            await _postRepository.UpdateAsync(post);
        }

        //Update
        public async Task UpdateByAdminAsync(string postId, string title, string content, Guid adminId, string comment)
        {
            content.PostContentValidation();
            var post = await _postRepository.GetAsync(postId);
            if (post == null)
            {
                throw new Exception($"Post with id: {postId} isn't exist");
            }
            post.SetTitle(title);
            post.SetContent(content);
            post.UpdateByAdmin(adminId, comment);
            await _postRepository.UpdateAsync(post);
        }

        //Delete
        public async Task DeleteAsync(string id)
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
