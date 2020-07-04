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
                world: tibiaCharacter.World,
                comment: string.Empty
            );

            return tibiaCharacterDTO;
        }

        public static TibiaCharacterDTO ToTibiaCharacterDTO(this TibiaCharacterQuery charQuery)
        {
            var charData = charQuery.Characters.Data;

            return new TibiaCharacterDTO(
                charData.Name, 
                charData.Vocation, 
                charData.Guild.Name, 
                charData.Level, 
                charData.World, 
                charData.Comment);
        }
    }
}
