namespace BackEndTask.Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public ICollection<Posts>? Posts { get; set; }
    public ICollection<Comments>? Comments { get; set; }

}