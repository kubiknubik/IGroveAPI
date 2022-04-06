using System.Text;

namespace Shared.Utils.Extensions
{
    public static class HashExtension
    {
        public static string HashPassword(this string password, string seed)
        {
            return sha256(password + seed);
        }

        static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
