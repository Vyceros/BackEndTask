using BackEndTask.Application.PostService.DTOs;
using BackEndTask.Domain.Entities;

namespace BackEndTask.Application.PostServices;

public interface IPostService
{
    Task<PostDTO> GetByIdAsync(int id);
    Task<IEnumerable<PostDTO>> GetAllAsync();
    Task<IEnumerable<PostDTO>> GetByUserIdAsync(int userId);
    Task<PostDTO> CreateAsync(CreatePostDTO createPostDto);
    Task UpdateAsync(int id, UpdatePostDTO updatePostDto);
    Task DeleteAsync(int id);

}