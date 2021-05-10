using ShopClothesBackend.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShopClothes.Test.Services
{
    public class HashPassword
    {
        [Fact]
        public void TestHashPassword()
        {
            var user = new Domain.Domain.User();
            var hashPw = HashPasswordService.HashPassword(user, "1234");

            var convertToByte = Encoding.ASCII.GetBytes(hashPw);

            var strPass = Encoding.ASCII.GetString(convertToByte);

            var verify = HashPasswordService.VerifyPassword(user, strPass, "1234");

            Assert.True(verify);
        }
    }
}
