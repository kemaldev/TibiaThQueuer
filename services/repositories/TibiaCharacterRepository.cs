using Data;
using Models;
using Models.Responses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class TibiaCharacterRepository : ITibiaCharacterRepository
    {
        private TibiaThContext _context;

        public TibiaCharacterRepository(TibiaThContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase> AddTibiaCharacterAsync(TibiaCharacter tibiaCharacter)
        {
            _context.TibiaCharacter.Add(tibiaCharacter);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                //log exception.

                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Failed to add tibia character."
                };
            }

            return new ResponseBase
            {
                Success = true
            };
        }

        public TibiaCharacterResponse GetTibiaCharacter(int tibiaCharacterId)
        {
            var tibiaCharacter = _context.TibiaCharacter.Find(tibiaCharacterId);

            if(tibiaCharacter == null)
            {
                return new TibiaCharacterResponse
                {
                    ErrorMessage = "Tibia character could not be found",
                    Success = false
                };
            }

            return new TibiaCharacterResponse
            {
                Success = true,
                tibiaCharacter = tibiaCharacter
            };
        }

        public async Task<ResponseBase> DeleteTibiaCharacterAsync(int tibiaCharacterId)
        {
            var tibiaCharacter = _context.TibiaCharacter.Find(tibiaCharacterId);

            if(tibiaCharacter == null)
            {
                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Character cannot be deleted because it does not exist."
                };
            }

            _context.TibiaCharacter.Remove(tibiaCharacter);

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
                    ErrorMessage = "Character deletion failed."
                };
            }

            return new ResponseBase
            {
                Success = true
            };
        }

        public async Task<ResponseBase> UpdateTibiaCharacterAsync(int tibiaCharacterId, TibiaCharacter tibiaCharacter)
        {
            if(tibiaCharacter == null)
            {
                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = nameof(tibiaCharacter) + " update request object was null."
                };
            }

            var existingTibiaCharacter = _context.TibiaCharacter.Find(tibiaCharacterId);

            if (existingTibiaCharacter == null)
            {
                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Character cannot be updated because it does not exist."
                };
            }

            existingTibiaCharacter = tibiaCharacter;
            _context.TibiaCharacter.Update(existingTibiaCharacter);

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
                    ErrorMessage = "Error ocurred when trying to update tibia character with id: " + existingTibiaCharacter.TibiaCharacterId
                };
            }

            return new ResponseBase
            {
                Success = true
            };
        }
    }
}
