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
        Task<ResponseBase> AddTibiaCharacterToListAsync(TibiaCharacter tibiaCharacter, Account account, int characterListId);
        Task<ResponseBase> RemoveTibiaCharacterFromListAsync(TibiaCharacter tibiaCharacter, int characterListId);
    }
}
