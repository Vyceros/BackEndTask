using BackEndTask.Application.CommentService.DTOs;
using BackEndTask.Domain.Entities;

namespace BackEndTask.Application.CommentService;

public interface ICommentService
{
    Task<CommentDTO> GetByIdAsync(int id);
    Task<IEnumerable<CommentDTO>> GetAllAsync();
    Task<IEnumerable<CommentDTO>> GetByPostIdAsync(int postId);
    Task<CommentDTO> CreateAsync(CommentCreateDTO createCommentDto);
    Task UpdateAsync(int id, CommentUpdateDTO updateCommentDto);
    Task DeleteAsync(int id);
}