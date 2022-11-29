namespace LockWarden.Domain.Models;

public class User : IReferenceable
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Login { get; set; }
	public string PasswordHash { get; set; }
	public string Salt { get; set; }

	public User(string name, string login, string password, string salt)
	{
		Name = name;
		Login = login;
		PasswordHash = password;
		Salt = salt;
	}
}
