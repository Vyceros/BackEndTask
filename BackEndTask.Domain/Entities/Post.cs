namespace BackEndTask.Domain.Entities;

public class Post : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string PostBody { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User User { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();
}