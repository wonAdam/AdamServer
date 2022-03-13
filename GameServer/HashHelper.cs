using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class HashSalt
    {
        public string Hash { get; set; }
        public string Salt { get; set; }
    }

    internal class HashHelper
    {
        internal static int Iteration = 9999;
        internal static HashSalt Hash(string HashTarget)
        {
//            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
//            byte[] SaltBytes = new byte[128 / 8];
//#pragma warning disable SYSLIB0023 // Type or member is obsolete
//            using (var RNPSCP = new RNGCryptoServiceProvider())
//#pragma warning restore SYSLIB0023 // Type or member is obsolete
//            {
//                RNPSCP.GetNonZeroBytes(SaltBytes);
//            }
//            string GenSalt = Convert.ToBase64String(SaltBytes);
//            // derive a 256-bit subkey (use HMACSHA256 with 9,999 iterations)
//            string Hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
//                password: HashTarget,
//                salt: SaltBytes,
//                prf: KeyDerivationPrf.HMACSHA256,
//                iterationCount: Iteration,
//                numBytesRequested: 256 / 8));

//            return new HashSalt(){ Hash = Hashed, Salt = GenSalt };

            var SaltBytes = new byte[256];
#pragma warning disable SYSLIB0023 // Type or member is obsolete
            var Provider = new RNGCryptoServiceProvider();
#pragma warning restore SYSLIB0023 // Type or member is obsolete
            Provider.GetNonZeroBytes(SaltBytes);
            var GenSalt = Convert.ToBase64String(SaltBytes);

            var Rfc2898DeriveBytes = new Rfc2898DeriveBytes(HashTarget, SaltBytes, Iteration);
            var HashedPassword = Convert.ToBase64String(Rfc2898DeriveBytes.GetBytes(256));

            return new HashSalt { Hash = HashedPassword, Salt = GenSalt };
        }

        internal static bool Verify(string VerifyTarget, HashSalt InHashSalt)
        {
            var SaltBytes = Convert.FromBase64String(InHashSalt.Salt); 
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(VerifyTarget, SaltBytes, Iteration);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == InHashSalt.Hash;
        }
    }
}
