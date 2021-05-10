using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Avatar { get; set; }
    }
}
