using Data;
using Models;
using Models.Requests;
using Models.Responses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class CharacterListRepository : ICharacterListRepository
    {
        private readonly TibiaThContext _context;

        public CharacterListRepository(TibiaThContext context)
        {
            _context = context;
        }

        public CharacterListResponse GetCharacterList(int characterListId)
        {
            var characterList = _context.CharacterList.Find(characterListId);

            if(characterList == null)
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
                CharacterList = characterList
            };
        }

        public async Task<ResponseBase> AddTibiaCharacterToListAsync(AddTibiaCharacterToListRequest request, int characterListId)
        {
            if(request.TibiaCharacter == null || request.Account == null)
            {
                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Either character or account request information was invalid."
                };
            }

            var characterList = _context.CharacterList.Find(characterListId);

            if(characterList == null)
            {
                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Specified character list did not exist."
                };
            }

            characterList.TibiaCharacters.Add(request.TibiaCharacter);
            characterList.Account = request.Account;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                //log exception

                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Error ocurred when trying to add character to list."
                };
            }

            return new ResponseBase
            {
                Success = true
            };
        }

        public async Task<ResponseBase> RemoveTibiaCharacterFromListAsync(TibiaCharacter tibiaCharacter, int characterListId)
        {
            if(tibiaCharacter == null)
            {
                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = nameof(tibiaCharacter) + " was null in request."
                };
            }

            var characterList = _context.CharacterList.Find(characterListId);

            if(characterList == null)
            {
                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Character list with specified id does not exist."
                };
            }

            _context.CharacterList.Remove(characterList);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                //log exception

                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Error ocurred when trying to delete character from list."
                };
            }

            return new ResponseBase
            {
                Success = true
            };
        }
    }
}
