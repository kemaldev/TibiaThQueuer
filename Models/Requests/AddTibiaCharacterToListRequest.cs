using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests
{
    public class AddTibiaCharacterToListRequest
    {
        public TibiaCharacter TibiaCharacter { get; set; }
        public Account Account { get; set; }
    }
}
