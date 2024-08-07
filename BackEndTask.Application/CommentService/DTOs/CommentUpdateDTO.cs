using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndTask.Application.CommentService.DTOs
{
    public class CommentUpdateDTO
    {
        public int Id { get; set; }
        public string CommentBody { get; set; } = string.Empty;
    }
}