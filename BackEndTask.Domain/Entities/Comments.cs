using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndTask.Domain.Entities
{
    public class Comments : BaseEntity
    {
        public string CommentBody { get; set; } = string.Empty;
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}