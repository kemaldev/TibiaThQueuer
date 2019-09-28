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
        Task<ResponseBase> AddTibiaCharacterAsync(TibiaCharacter tibiaCharacter);

        TibiaCharacterResponse GetTibiaCharacter(int tibiaCharacterId);
        Task<ResponseBase> UpdateTibiaCharacterAsync(int tibiaCharacterId, TibiaCharacter tibiaCharacter);
        Task<ResponseBase> DeleteTibiaCharacterAsync(int tibiaCharacterId);
    }
}
