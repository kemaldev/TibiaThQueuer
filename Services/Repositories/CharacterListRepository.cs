using Data;
using Models;
using Models.DTOs;
using Models.Responses;
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
                    new CharacterListResponseDTO
                    {
                        TibiaCharacters = charListItem.TibiaCharacters.Select(
                            tibiaChar => new TibiaCharacterDTO
                            {
                                TibiaCharacterId = tibiaChar.TibiaCharacterId,
                                Name = tibiaChar.Name,
                                Level = tibiaChar.Level,
                                PVPType = tibiaChar.PVPType,
                                Vocation = tibiaChar.Vocation,
                                World = tibiaChar.World
                            })
                        .ToList(),

                        Account = new AccountDTO
                        {
                            AccountId = charListItem.Account.AccountId,
                            Email = charListItem.Account.Email,
                            Password = charListItem.Account.Password,
                            UserName = charListItem.Account.UserName
                        }
                    }
                )
                .FirstOrDefault();

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

        public async Task<ResponseBase> CreateCharacterListAsync(int accountId)
        {
            var account = _context.Account.Find(accountId);

            if (account == null)
            {
                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Tried to create a character list for an account that did not exist."
                };
            }

            var characterList = new CharacterList
            {
                Account = account
            };

            _context.CharacterList.Add(characterList);

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
                    ErrorMessage = "Error ocurred when trying to create character list."
                };
            }

            return new ResponseBase
            {
                Success = true
            };
        }

        public async Task<ResponseBase> AddTibiaCharacterToListAsync(TibiaCharacter tibiaCharacter, int characterListId)
        {
            if(tibiaCharacter == null)
            {
                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Character provided in request was null."
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

            if(characterList.TibiaCharacters == null)
            {
                characterList.TibiaCharacters = new List<TibiaCharacter>();
            }
            characterList.TibiaCharacters.Add(tibiaCharacter);

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

        public async Task<ResponseBase> RemoveCharacterListAsync(int characterListId)
        {
            var characterList = _context.CharacterList
                .Where(charList => charList.CharacterListId == characterListId)
                .Select(charList => new CharacterList
                {
                    AccountId = charList.AccountId,
                    Account = charList.Account,
                    CharacterListId = charList.CharacterListId,
                    TibiaCharacters = charList.TibiaCharacters
                })
                .FirstOrDefault();

            if (characterList == null)
            {
                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Character list with specified id does not exist."
                };
            }
            
            characterList.TibiaCharacters.Select(tibiaChar => _context.TibiaCharacter.Remove(tibiaChar));
            characterList.Account.CharacterList = null;

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
                    ErrorMessage = "Error ocurred when trying to clear related data to character list."
                };
            }

            _context.CharacterList.Remove(characterList);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //log exception

                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Error ocurred when trying to delete character list."
                };
            }

            return new ResponseBase
            {
                Success = true
            };
        }

        public async Task<ResponseBase> RemoveTibiaCharacterFromListAsync(int tibiaCharacterId, int characterListId)
        {
            var tibiaCharacter = _context.TibiaCharacter.Find(tibiaCharacterId);

            if(tibiaCharacter == null)
            {
                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Character that you tried to delete could not be found."
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

            characterList.TibiaCharacters.Remove(tibiaCharacter);

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
