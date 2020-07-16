using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaMVC.Controllers
{
    public class EncryptationController : Controller
    {
        public string salt { get; set; }

        public EncryptationController () => this.salt = null;

        private byte [] CreateSalt () {
            byte [] salt = new byte [128 / 8];
            RandomNumberGenerator.Create().GetBytes(salt);
            this.salt = Convert.ToBase64String(salt);
            return salt;
        }

        public byte [] ReadSalt (string salt) => Convert.FromBase64String(salt);

        public string getHash (string password, byte [] salt = null) =>
            Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password : password,
                salt : salt ??= CreateSalt(),
                prf : KeyDerivationPrf.HMACSHA256,
                iterationCount : 1000,
                numBytesRequested : 256 / 8 ));
    }
}