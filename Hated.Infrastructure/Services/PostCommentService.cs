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
    public class PostCommentService : IPostCommentService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostCommentService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(Guid userId, Guid postId, string content)
        {
            var post = await _postRepository.GetAsync(postId);
            var comment = new Comment(userId, content);
            post.AddComment(comment);
            await _postRepository.UpdateAsync(post);
        }

        public async Task<CommentDto> GetAsync(Guid id)
        {
            var posts = await _postRepository.GetAllAsync();
            var comment = posts.SelectMany(x => x.Comments).SingleOrDefault(x => x.Id == id);
            if (comment == null)
            {
                throw new Exception($"Comment with id: {id} isn't exist");
            }
            return _mapper.Map<Comment, CommentDto>(comment);
        }

        public async Task<IEnumerable<CommentDto>> GetAllFromPostAsync(Guid postId)
        {
            var post = await _postRepository.GetAsync(postId);
            if (post == null)
            {
                throw new Exception($"Post with id: {postId} isn't exist");
            }
            return post.Comments.Select(x => _mapper.Map<Comment, CommentDto>(x));
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return posts.SelectMany(x => x.Comments).Select(x => _mapper.Map<Comment, CommentDto>(x));
        }

        public async Task UpdateAsync(Guid postId, CommentDto updatedComment)
        {
            var post = await _postRepository.GetAsync(postId);
            var comment = post.GetComment(updatedComment.Id);
            comment.SetContent(updatedComment.Content);
            post.UpdateComment(comment);
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeleteAsync(Guid postId, Guid commentId)
        {
            var post = await _postRepository.GetAsync(postId);
            var comment = post.GetComment(commentId);
            post.DeleteComment(comment);
            await _postRepository.UpdateAsync(post);
        }
    }
}

