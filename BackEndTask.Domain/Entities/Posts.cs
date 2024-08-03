using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndTask.Domain.Entities
{
    public class Posts : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string PostBody { get; set; } = string.Empty;
        public int UserId { get; set; }

        public int CommentsId { get; set; }
        public ICollection<Comments>? Comments { get; set; }
    }
}