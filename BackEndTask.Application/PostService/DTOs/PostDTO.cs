using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTask.Application.CommentService.DTOs;

namespace BackEndTask.Application.PostService.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostBody { get; set; }
        public int UserId { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}