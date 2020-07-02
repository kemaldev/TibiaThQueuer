using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public CharacterList CharacterList { get; set; }
        public int CharacterListId { get; set; }
    }
}
