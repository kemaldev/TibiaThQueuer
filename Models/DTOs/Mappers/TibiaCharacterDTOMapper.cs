using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs.Mappers
{
    public static class TibiaCharacterDTOMapper
    {
        public static TibiaCharacterDTO MapTibiaCharacterToTibiaCharacterDTO(TibiaCharacter tibiaCharacter)
        {
            var tibiaCharacterDTO = new TibiaCharacterDTO
            (
                name: tibiaCharacter.Name,
                vocation: tibiaCharacter.Vocation,
                guild: tibiaCharacter.Guild,
                level: tibiaCharacter.Level,
                world: tibiaCharacter.World
            );

            return tibiaCharacterDTO;
        }
    }
}
