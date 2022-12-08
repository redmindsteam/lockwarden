namespace LockWarden.Domain.Models;

public class Image : IUsable
{
	public int Id { get; set; }
	public DateTime? Deleted { get; set; }
	public string Name { get; set; }
	public string Content { get; set; }
	public int UserId { get; set; }

	public Image(DateTime? deleted, string name, string content, int userId)
	{
		Deleted = deleted;
		Name = name;
		Content = content;
		UserId = userId;
	}
}
