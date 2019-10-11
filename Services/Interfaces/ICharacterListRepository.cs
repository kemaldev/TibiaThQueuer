using Models;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICharacterListRepository
    {
        CharacterListResponse GetCharacterList(int characterListId);
        Task<ResponseBase> CreateCharacterListAsync(int accountId);
        Task<ResponseBase> RemoveCharacterListAsync(int characterListId);
        Task<ResponseBase> AddTibiaCharacterToListAsync(TibiaCharacter tibiaCharacter, int characterListId);
        Task<ResponseBase> RemoveTibiaCharacterFromListAsync(int tibiaCharacterId, int characterListId);
    }
}
