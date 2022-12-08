namespace LockWarden.Domain.Models;

public class User : IReferenceable
{
	public int Id { get; set; }
	public string Name { get; set; } = String.Empty;
	public string Login { get; set; } = String.Empty;
	public string PasswordHash { get; set; } = String.Empty;
	public string Salt { get; set; } = String.Empty;
	public User(string name, string login, string password, string salt)
	{
		Name = name;
		Login = login;
		PasswordHash = password;
		Salt = salt;
	}
}
