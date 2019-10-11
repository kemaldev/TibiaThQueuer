using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
