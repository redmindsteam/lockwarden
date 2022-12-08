using System.Security.Cryptography;
using System.Text;

namespace LockWarden.Service.Tools;

public class Helper
{
	public static string ArrayToString(byte[] arr)
	{
		StringBuilder res = new StringBuilder();
		for(int i = 0; i < arr.Length; i++)
		{
			res.Append($"{arr[i]:X2}");
		}
		return res.ToString().ToLower();
	}
	public static int ToSeed(string passw)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(passw);
		int result = BitConverter.ToInt32(SHA256.Create().ComputeHash(bytes));
		return result;
	}
	public static string ImageToString(string path)
	{
		var img = File.ReadAllBytes(path);
		return Convert.ToBase64String(img);
	}
	public static void StringToImage(string str, string path)
	{
		var img = Convert.FromBase64String(str);
		File.WriteAllBytes(path, img);
	}
	public static bool Validate(Valid operand, string s)
	{
		switch((int)operand)
		{
			case 1:
				return ValidUsername(s);
			case 2:
				return ValidNumber(s, 16);
			case 3:
				return ValidNumber(s, 4);
			case 4:
				return ValidText(s);
			case 5:
				return ValidPath(s);
			default:
				return false;
		}
	}
	private static bool ValidUsername(string pasw)
	{
		return !(pasw.Contains(" ") || pasw.Length == 0 || pasw.Contains("	"));

	}
	private static bool ValidNumber(string number, int len)
	{
		if(number.Length != len)
			return false;
		foreach(char ch in number)
		{
			if(ch < 48 || ch > 57)
				return false;
		}
		return true;
	}
	private static bool ValidText(string text)
	{
		return text.Length < 0;
	}
	private static bool ValidPath(string path)
	{
		var fil = new FileInfo(path);
		var can = new string[] { ".png", ".jpg", ".bmp" };
		return fil.Exists && can.Contains(fil.Extension);
	}
}
public enum Valid
{
	UserPasswordOrName = 1,
	CardNumber = 2,
	CardPin = 3,
	Text = 4,
	ImagePath=5,
}