using Data;
using Functional.Option;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs;
using Models.DTOs.Mappers;
using Models.Responses;
using Models.Responses.Mappers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var characterList = _context.CharacterList
                .Where(charList => charList.CharacterListId == characterListId)
                .Select(
                    charListItem =>
                    CharacterListResponseDTOMapper.MapCharacterListToDTO(charListItem)
                )
                .FirstOrDefault();

            var characterListResponse = CharacterListResponseMapper
                .MapCharacterListDTOToCharacterListResponse(characterList);

            return characterListResponse;
        }

        public async Task<ResponseBase> CreateCharacterListAsync(int accountId)
        {
            var account = _context.Account.Find(accountId);

            if (account == null)
            {
                return ResponseBase.ReturnFailed("Tried to create a character list for an account that did not exist.");
            }

            var characterList = new CharacterList
            {
                Account = account
            };

            _context.CharacterList.Add(characterList);

            var dbSaveResponse = 
                await MapErrorResponseUponDBFailElseSuccess("Error ocurred when trying to create character list.");

            return dbSaveResponse;
        }

        public async Task<ResponseBase> AddTibiaCharacterToListAsync(TibiaCharacter tibiaCharacter, int characterListId)
        {
            if(tibiaCharacter == null)
            {
                return ResponseBase.ReturnFailed("Character provided in request was null.");
            }

            var characterList = _context.CharacterList.Find(characterListId);

            if(characterList == null)
            {
                return ResponseBase.ReturnFailed("Specified character list did not exist.");
            }

            if(characterList.TibiaCharacters == null)
            {
                characterList.TibiaCharacters = new List<TibiaCharacter>();
            }

            characterList.TibiaCharacters.Add(tibiaCharacter);

            var dbResponse = 
                await MapErrorResponseUponDBFailElseSuccess("Error ocurred when trying to add character to list.");
            return dbResponse;
        }

        public async Task<ResponseBase> RemoveCharacterListAsync(int characterListId)
        {
            var characterList = _context.CharacterList
                .Where(charList => charList.CharacterListId == characterListId)
                .FirstOrDefault();

            if (characterList == null)
            {
                return ResponseBase.ReturnFailed("Character list with specified id does not exist.");
            }
            
            characterList.TibiaCharacters.Select(tibiaChar => _context.TibiaCharacter.Remove(tibiaChar));
            characterList.Account.CharacterList = null;


            var removeCharacterFromDBResponse = 
                await MapErrorResponseUponDBFailElseSuccess("Error ocurred when trying to clear related data to character list.");

            if (removeCharacterFromDBResponse.Failed)
            {
                return removeCharacterFromDBResponse;
            }

            _context.CharacterList.Remove(characterList);

            var removeCharacterListFromDBResponse =
                await MapErrorResponseUponDBFailElseSuccess("Error ocurred when trying to delete character list.");

            return removeCharacterFromDBResponse;
        }

        public async Task<ResponseBase> RemoveTibiaCharacterFromListAsync(int tibiaCharacterId, int characterListId)
        {
            var tibiaCharacter = _context.TibiaCharacter.Find(tibiaCharacterId);

            if(tibiaCharacter == null)
            {
                return ResponseBase.ReturnFailed("Character that you tried to delete could not be found.");
            }

            var characterList = _context.CharacterList.Find(characterListId);

            if(characterList == null)
            {
                return ResponseBase.ReturnFailed("Character list with specified id does not exist.");
            }

            characterList.TibiaCharacters.Remove(tibiaCharacter);

            var dbResponse =
                await MapErrorResponseUponDBFailElseSuccess("Error ocurred when trying to delete character from list.");

            return dbResponse;
        }
        private async Task<ResponseBase> MapErrorResponseUponDBFailElseSuccess(string errorMessage)
        {
            try
            {
                await _context.SaveChangesAsync();
                return ResponseBase.ReturnSuccess();
            }
            catch (DbUpdateException ex)
            {
                //log exception

                return ResponseBase.ReturnFailed(errorMessage);
            }
        }
    }
}
