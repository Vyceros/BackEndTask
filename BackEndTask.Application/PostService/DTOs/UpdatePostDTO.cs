using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndTask.Application.PostService.DTOs
{
    public class UpdatePostDTO
    {
        public string Title { get; set; } = string.Empty;
        public string PostBody { get; set; } = string.Empty;
    }
}