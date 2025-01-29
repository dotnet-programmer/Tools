using System.IO;
using System.Security.Cryptography;

namespace CalculateChecksum;

internal static class CheckSum
{
	public static string CalculateMD5(string filename)
	{
		using (var md5 = MD5.Create())
		using (var stream = File.OpenRead(filename))
		return Convert.ToHexStringLower(md5.ComputeHash(stream));
	}

	public static string CalculateSHA1(string filename)
	{
		using (var sha1 = SHA1.Create())
		using (var stream = File.OpenRead(filename))
		return Convert.ToHexStringLower(sha1.ComputeHash(stream));
	}

	public static string CalculateSHA256(string filename)
	{
		using (var sha256 = SHA256.Create())
		using (var stream = File.OpenRead(filename))
		return Convert.ToHexStringLower(sha256.ComputeHash(stream));
	}

	public static string CalculateSHA384(string filename)
	{
		using (var sha384 = SHA384.Create())
		using (var stream = File.OpenRead(filename))
		return Convert.ToHexStringLower(sha384.ComputeHash(stream));
	}

	public static string CalculateSHA512(string filename)
	{
		using (var sha512 = SHA512.Create())
		using (var stream = File.OpenRead(filename))
		return Convert.ToHexStringLower(sha512.ComputeHash(stream));
	}
}