using Domain.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothesBackend.Services
{
    public static class HashPasswordService
    {
        public static string HashPassword(User user, string password)
        {
            var hash = new PasswordHasher<User>();

            var newPass = hash.HashPassword(user, password);
            return newPass;
        }
        public static bool VerifyPassword(User user, string providedPw)
        {
            var hash = new PasswordHasher<User>();
            String userPassword = Encoding.ASCII.GetString(user.Password);
            var verify = hash.VerifyHashedPassword(user, userPassword, providedPw);
            return verify == PasswordVerificationResult.Success;
        }

        public static bool VerifyPassword(User user, string password, string providedPw)
        {
            var hash = new PasswordHasher<User>();
            var verify = hash.VerifyHashedPassword(user, password, providedPw);
            return verify == PasswordVerificationResult.Success;
        }
    }
}
