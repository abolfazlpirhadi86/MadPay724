using System.Security.Cryptography;
using System.Text;

namespace MadPay724.Common.Helpers
{
    public class Utilities
    {
        public static (byte[], byte[]) PasswordHash(string password)
        {
            using var hamc = new HMACSHA512();
            var passwordSalt = hamc.Key;
            var passwordHash = hamc.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (passwordHash, passwordSalt);
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hamc = new HMACSHA512();
            var computedHash = hamc.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                    return false;
            }

            return true;
        }
    }
}
