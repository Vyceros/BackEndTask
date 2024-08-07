using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTask.Application.CommentService.DTOs;
using BackEndTask.Application.PostService.DTOs;
using BackEndTask.Application.PostServices;
using BackEndTask.Domain.Entities;
using BackEndTask.Domain.Repositories;

namespace BackEndTask.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostDTO> GetByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post is null)
            {
                throw new ArgumentException("Post not found");
            }
            return MapToDTO(post);
        }

        public async Task<IEnumerable<PostDTO>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            if (posts is null)
            {
                throw new ArgumentException("No posts found");
            }
            return posts.Select(MapToDTO);
        }

        public async Task<IEnumerable<PostDTO>> GetByUserIdAsync(int userId)
        {
            var posts = await _postRepository.GetByUserIdAsync(userId);
            return posts.Select(MapToDTO);
        }

        public async Task<PostDTO> CreateAsync(CreatePostDTO createPostDTO)
        {
            var post = new Post
            {
                Title = createPostDTO.Title,
                PostBody = createPostDTO.PostBody,
                UserId = createPostDTO.UserId
            };

            var createdPost = await _postRepository.AddAsync(post);
            return MapToDTO(createdPost);
        }

        public async Task UpdateAsync(int id, UpdatePostDTO updatePostDTO)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
            {
                throw new ArgumentException("Post not found");
            }

            post.Title = updatePostDTO.Title;
            post.PostBody = updatePostDTO.PostBody;
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeleteAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }

        private PostDTO MapToDTO(Post post)
        {
            return new PostDTO
            {
                Id = post.Id,
                Title = post.Title,
                PostBody = post.PostBody,
                UserId = post.UserId,
                Comments = post.Comments.Select(c => new CommentDTO
                {
                    Id = c.Id,
                    CommentBody = c.CommentBody,
                    PostId = c.PostId,
                    UserId = c.UserId,
                    CreatedAt = c.CreatedAt
                }).ToList()
            };
        }
    }
}