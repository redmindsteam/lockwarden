namespace LockWarden.Domain.Models;

public class Card : IUsable
{
    public int Id { get; set; }
    public DateTime? Deleted { get; set; }
    public string Bank { get; set; }
    public string Number { get; set; }
    public string Pin { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }

    public Card(DateTime deleted,  string bank, string number, string pin, string name, int userId)
    {
        UserId = userId;
        Deleted = deleted;
        Bank = bank;
        Number = number;
        Pin = pin;
        Name = name;
    }
}
