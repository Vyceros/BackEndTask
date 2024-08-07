using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndTask.Application.CommentService.DTOs
{
    public class CommentCreateDTO
    {
        public string CommentBody { get; set; } = string.Empty;
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}