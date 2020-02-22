using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Responses
{
    public class TibiaCharacterResponse : ResponseBase
    {
        public TibiaCharacterDTO tibiaCharacter { get; set; }

        public static TibiaCharacterResponse SuccessfulResponse(TibiaCharacterDTO tibiaCharacter)
        {
            return new TibiaCharacterResponse
            {
                Success = true,
                tibiaCharacter = tibiaCharacter
            };
        }
    }
}
