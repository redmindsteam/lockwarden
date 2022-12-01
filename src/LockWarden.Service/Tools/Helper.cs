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
}
