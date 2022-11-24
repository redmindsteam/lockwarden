namespace LockWarden.Domain.Models;

public interface IUsable : IReferenceable
{
	public DateTime Deleted { get; set; }
	public int UserId { get; set; }
}