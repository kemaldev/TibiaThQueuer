using Models;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITibiaCharacterRepository
    {
        Task<ResponseBase> AddTibiaCharacter(TibiaCharacter tibiaCharacter);

        TibiaCharacterResponse GetTibiaCharacter(int tibiaCharacterId);
        Task<ResponseBase> UpdateTibiaCharacter(int tibiaCharacterId, TibiaCharacter tibiaCharacter);
        Task<ResponseBase> DeleteTibiaCharacter(int tibiaCharacterId);
    }
}
