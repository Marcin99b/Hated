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

        public async Task<Guid> AddAsync(Guid userId, Guid postId, string content)
        {
            var post = await _postRepository.GetAsync(postId);
            var comment = new Comment(userId, content);
            post.AddComment(comment);
            await _postRepository.UpdateAsync(post);
            return comment.Id;
        }

        public async Task<CommentDto> GetAsyncFromPost(Guid postId, Guid commentId)
        {
            var comments = await GetAllFromPostAsync(postId);
            return comments.SingleOrDefault(x => x.Id == commentId);
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

