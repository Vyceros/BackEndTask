using BackEndTask.Application.PostService.DTOs;
using BackEndTask.Application.PostServices;
using BackEndTask.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndTask.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetAll()
        {
            var posts = await _postService.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetById(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetByUserId(int userId)
        {
            var posts = await _postService.GetByUserIdAsync(userId);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult<PostDTO>> Create(CreatePostDTO createPostDTO)
        {
            var createdPost = await _postService.CreateAsync(createPostDTO);
            return CreatedAtAction(nameof(GetById), new { id = createdPost.Id }, createdPost);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePostDTO updatePostDTO)
        {
            try
            {
                await _postService.UpdateAsync(id, updatePostDTO);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeleteAsync(id);
            return NoContent();
        }
    }
}