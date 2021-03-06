﻿using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.DTOs.Mappers
{
    public static class CharacterListResponseDTOMapper
    {
        public static CharacterListResponseDTO MapCharacterListToDTO(CharacterList characterList)
        {
            var characterListResponseDTO = new CharacterListResponseDTO
            {
                TibiaCharacters = characterList.CharacterListRelations
                .Select(characterRelation => TibiaCharacterDTOMapper.MapTibiaCharacterToTibiaCharacterDTO(characterRelation.TibiaCharacter))
                .ToList(),

                Account = AccountDTOMapper.MapAccountToAccountDTO(characterList.Account)
            };

            return characterListResponseDTO;
        }

    }
}
