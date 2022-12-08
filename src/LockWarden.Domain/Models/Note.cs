namespace LockWarden.Domain.Models;

public class Note : IUsable
{
	public int Id { get; set; }
	public DateTime? Deleted { get; set; }
    public string Header { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }

    public Note(int id, DateTime deleted,  string header, string content, int userId)
    {
        Deleted = deleted;
        Id = id;
        Header = header;
        Content = content;
        UserId = userId;
    }
}
