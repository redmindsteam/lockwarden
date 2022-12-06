namespace LockWarden.Domain.Models;

public class Image : IUsable
{
	public DateTime? Deleted { get; set; }
	public int Id { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }

    public Image(DateTime deleted, int id, string name, string content, int userId)
    {
        Deleted = deleted;
        Id = id;
        Name = name;
        Content = content;
        UserId = userId;
    }
}
