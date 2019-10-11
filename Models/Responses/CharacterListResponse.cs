using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Responses
{
    public class CharacterListResponse : ResponseBase
    {
        public CharacterListResponseDTO CharacterList { get; set; }
    }
}
