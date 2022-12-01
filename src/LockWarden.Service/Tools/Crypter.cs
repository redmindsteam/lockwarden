using System.Security.Cryptography;
using System.Text;

namespace LockWarden.Service.Tools;

public class Crypter
{
	public static string Ciphr(string s, int seed, Crypt operand)
	{
		Random rndm = new Random(seed);
		StringBuilder sb = new StringBuilder();
		foreach(char c in s)
		{
			sb.Append((char)(c + (int)operand * rndm.Next(-100, 100)));
		}
		return sb.ToString();
	}
	public static (string hash, string salt) Hash(string pasw)
	{
		string salt = Guid.NewGuid().ToString();
		return (ComputeHash(pasw, salt), salt);
	}
	private static string ComputeHash(string pasw, string salt)
	{
		pasw += salt;
		byte[] inBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(pasw));
		string hashed = Helper.ArrayToString(inBytes);
		return hashed;
	}
	public static bool Verify(string correct, string check, string salt)
	{
		string hashedCheck = ComputeHash(check, salt);
		return correct == hashedCheck;
	}
}
public enum Crypt
{
	Encrypt = 1,
	Decrypt = -1,
}