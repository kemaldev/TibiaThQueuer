using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CharacterList
    {
        public int CharacterListId { get; set; }
        public ICollection<TibiaCharacter> TibiaCharacters { get; set; }
        public Account Account { get; set; }
    }
}
