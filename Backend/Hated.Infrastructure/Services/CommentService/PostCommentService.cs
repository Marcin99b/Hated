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
    public class PostCommentService : IPostCommentService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostCommentService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(Guid userId, string postId, string content)
        {
            var post = await _postRepository.GetAsync(postId);
            var comment = new Comment(userId, content);
            post.AddComment(comment);
            await _postRepository.UpdateAsync(post);
            return comment.Id;
        }

        public async Task<CommentDto> GetAsyncFromPost(string postId, Guid commentId)
        {
            var post = await _postRepository.GetAsync(postId);
            if (post == null)
            {
                throw new Exception($"Post with id: {postId} isn't exists");
            }
            var comments = post.Comments.Select(x => _mapper.Map<Comment, CommentDto>(x));
            return comments.FirstOrDefault(x => x.Id == commentId);
        }

        public async Task<IEnumerable<CommentDto>> GetAllFromPostAsync(string postId, int from, int number)
        {
            var post = await _postRepository.GetAsync(postId);
            if (post == null)
            {
                throw new Exception($"Post with id: {postId} isn't exists");
            }
            return post.Comments
                .Paginate(from, number)
                .Select(x => _mapper.Map<Comment, CommentDto>(x));
        }

        public async Task UpdateAsync(string postId, CommentDto updatedComment)
        {
            var post = await _postRepository.GetAsync(postId);
            var comment = post.GetComment(updatedComment.Id);
            comment.SetContent(updatedComment.Content);
            post.UpdateComment(comment);
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeleteAsync(string postId, Guid commentId)
        {
            var post = await _postRepository.GetAsync(postId);
            var comment = post.GetComment(commentId);
            post.DeleteComment(comment);
            await _postRepository.UpdateAsync(post);
        }
    }
}

