using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs
{
    public class CharacterListResponseDTO
    {
        public ICollection<TibiaCharacterDTO> TibiaCharacters { get; set; }
        public AccountDTO Account { get; set; }
    }
}
