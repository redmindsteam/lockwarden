namespace LockWarden.Domain.Models;

public class Card : IUsable
{
	public DateTime Deleted { get; set; }
	public int UserId { get; set; }
	public int Id { get; set; }
	public string Bank { get; set; }
	public string Number { get; set; }
	public string Pin { get; set; }
	public string Name { get; set; }

	public Card(DateTime deleted, int userId, int id, string bank, string number, string pin, string name)
	{
		Deleted = deleted;
		UserId = userId;
		Id = id;
		Bank = bank;
		Number = number;
		Pin = pin;
		Name = name;
	}
}
