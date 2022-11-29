namespace LockWarden.Domain.Models;

public class Note : IUsable
{
	public DateTime? Deleted { get; set; }
	public int Id { get; set; }
	public string Header { get; set; }
	public string Content { get; set; }
	public int UserId { get; set; }

	public Note(DateTime deleted, int id, string header, string content, int userId)
	{
		Deleted = deleted;
		Id = id;
		Header = header;
		Content = content;
		UserId = userId;
	}
}
