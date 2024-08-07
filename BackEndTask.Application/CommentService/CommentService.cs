using BackEndTask.Application.CommentService;
using BackEndTask.Application.CommentService.DTOs;
using BackEndTask.Domain.Entities;
using BackEndTask.Domain.Repositories;

namespace BackEndTask.Application.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<CommentDTO> GetByIdAsync(int id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        if (comment == null)
        {
            throw new ArgumentException("Comment not found");
        }
        return MapToDto(comment);
    }

    public async Task<IEnumerable<CommentDTO>> GetAllAsync()
    {
        var comments = await _commentRepository.GetAllAsync();
        if (comments == null)
        {
            throw new ArgumentException("No comments found");
        }
        return comments.Select(MapToDto);
    }

    public async Task<IEnumerable<CommentDTO>> GetByPostIdAsync(int postId)
    {
        var comments = await _commentRepository.GetByPostIdAsync(postId);
        if (comments == null)
        {
            throw new ArgumentException("Post not found");
        }
        return comments.Select(MapToDto);
    }

    public async Task<CommentDTO> CreateAsync(CommentCreateDTO createCommentDto)
    {
        var comment = new Comment
        {
            CommentBody = createCommentDto.CommentBody,
            PostId = createCommentDto.PostId,
            UserId = createCommentDto.UserId,
            CreatedAt = DateTime.Now
        };

        var createdComment = await _commentRepository.AddAsync(comment);
        return MapToDto(createdComment);
    }

    public async Task UpdateAsync(int id, CommentUpdateDTO updateCommentDto)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        if (comment == null)
        {
            throw new ArgumentException("Comment not found");
        }

        comment.CommentBody = updateCommentDto.CommentBody;
        await _commentRepository.UpdateAsync(comment);
    }

    public async Task DeleteAsync(int id)
    {
        await _commentRepository.DeleteAsync(id);
    }

    private CommentDTO MapToDto(Comment comment)
    {
        return new CommentDTO
        {
            Id = comment.Id,
            CommentBody = comment.CommentBody,
            PostId = comment.PostId,
            UserId = comment.UserId,
            CreatedAt = comment.CreatedAt
        };
    }
}