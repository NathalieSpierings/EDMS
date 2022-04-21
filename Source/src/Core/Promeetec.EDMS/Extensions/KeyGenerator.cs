using System.Security.Cryptography;
using System.Text;

namespace Promeetec.EDMS.Extensions;

public class KeyGenerator
{
    internal static readonly char[] Chars = "abcdefghjkmnpqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ123456789!@#$%^&*_-=+".ToCharArray();
    internal static readonly char[] PukCodeChars = "ABCDEFGHJKMNPQRSTUVWXYZ123456789".ToCharArray();

    public static string GeneratePukCode(int size)
    {
        byte[] data = new byte[4 * size];
        using (var crypto = new RNGCryptoServiceProvider())
        {
            crypto.GetBytes(data);
        }

        var result = new StringBuilder(size);
        for (int i = 0; i < size; i++)
        {
            var rnd = BitConverter.ToUInt32(data, i * 4);
            var idx = rnd % PukCodeChars.Length;

            result.Append(PukCodeChars[idx]);
        }

        var code = result.ToString();
        string pukCode = "";
        for (int i = 0; i < code.Length; ++i)
        {
            if (i % 4 == 0 && i != 0)
                pukCode += "-" + code[i];
            else
                pukCode += code[i];
        }

        return pukCode;
    }

    public static string GenerateUniqueKey(int size)
    {
        byte[] data = new byte[4 * size];
        using (var crypto = new RNGCryptoServiceProvider())
        {
            crypto.GetBytes(data);
        }

        var result = new StringBuilder(size);
        for (int i = 0; i < size; i++)
        {
            var rnd = BitConverter.ToUInt32(data, i * 4);
            var idx = rnd % Chars.Length;

            result.Append(Chars[idx]);
        }

        return result.ToString();
    }

    public static string CreatePassword(int length)
    {
        const string lower = "abcdefghjkmnopqrstuvwxyz";
        const string upper = "ABCDEFGHJKMNOPQRSTUVWXYZ";
        const string number = "123456789";
        const string special = "!@#$%^&*";

        var middle = length / 2;
        StringBuilder res = new StringBuilder();
        Random rnd = new Random();
        while (0 < length--)
        {
            if (middle == length)
            {
                res.Append(number[rnd.Next(number.Length)]);
            }
            else if (middle - 1 == length)
            {
                res.Append(special[rnd.Next(special.Length)]);
            }
            else
            {
                res.Append(length % 2 == 0 ? lower[rnd.Next(lower.Length)] : upper[rnd.Next(upper.Length)]);
            }
        }

        return res.ToString();
    }
}