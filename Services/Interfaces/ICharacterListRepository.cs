using Models;
using Models.Requests;
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
        Task<ResponseBase> AddTibiaCharacterToListAsync(AddTibiaCharacterToListRequest request, int characterListId);
        Task<ResponseBase> RemoveTibiaCharacterFromListAsync(TibiaCharacter tibiaCharacter, int characterListId);
    }
}
