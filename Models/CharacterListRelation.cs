using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CharacterListRelation
    {
        public int TibiaCharacterId { get; set; }
        public TibiaCharacter TibiaCharacter { get; set; }
        public int CharacterListId { get; set; }
        public CharacterList CharacterList { get; set; }
    }
}
