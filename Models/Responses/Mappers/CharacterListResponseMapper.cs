using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Responses.Mappers
{
    public static class CharacterListResponseMapper
    {
        public static CharacterListResponse MapCharacterListDTOToCharacterListResponse(CharacterListResponseDTO characterListResponseDTO)
        {
            if (characterListResponseDTO == null)
            {
                return new CharacterListResponse
                {
                    Success = false,
                    ErrorMessage = "Character list with provided id did not exist."
                };
            }

            return new CharacterListResponse
            {
                Success = true,
                CharacterList = characterListResponseDTO
            };
        }

    }
}
