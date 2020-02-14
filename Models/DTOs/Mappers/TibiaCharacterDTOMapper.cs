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
            {
                TibiaCharacterId = tibiaCharacter.TibiaCharacterId,
                Name = tibiaCharacter.Name,
                Level = tibiaCharacter.Level,
                Guild = tibiaCharacter.Guild,
                PVPType = tibiaCharacter.PVPType,
                Vocation = tibiaCharacter.Vocation,
                World = tibiaCharacter.World
            };

            return tibiaCharacterDTO;
        }
    }
}
