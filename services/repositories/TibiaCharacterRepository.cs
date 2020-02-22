using Common.Helpers;
using Data;
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

            var response = await ResponseBaseMapper.MapErrorResponseUponDBFailElseSuccess("Failed to add tibia character.", _context);

            return response;
        }

        public TibiaCharacterResponse GetTibiaCharacter(int tibiaCharacterId)
        {
            var tibiaCharacter = GetTibiaCharacterFromDb(tibiaCharacterId);

            if(tibiaCharacter == null)
            {
                return (TibiaCharacterResponse) ResponseBase.ReturnFailed("Tibia character could not be found");
            }

            return TibiaCharacterResponse.SuccessfulResponse(tibiaCharacter);
        }

        public async Task<ResponseBase> DeleteTibiaCharacterAsync(int tibiaCharacterId)
        {
            var tibiaCharacter = _context.TibiaCharacter.Find(tibiaCharacterId);

            if(tibiaCharacter == null)
            {
                return ResponseBase.ReturnFailed("Character cannot be deleted because it does not exist.");
            }

            _context.TibiaCharacter.Remove(tibiaCharacter);

            var response = await ResponseBaseMapper.MapErrorResponseUponDBFailElseSuccess("Character deletion failed.", _context);

            return response;
        }

        public async Task<ResponseBase> UpdateTibiaCharacterAsync(int tibiaCharacterId, TibiaCharacter requestedTibiaCharacter)
        {
            if(requestedTibiaCharacter == null)
            {
                return ResponseBase.ReturnFailed($"{ nameof(requestedTibiaCharacter) } update request object was null.");
            }

            var existingTibiaCharacter = _context.TibiaCharacter.Find(tibiaCharacterId);

            if (existingTibiaCharacter == null)
            {
                return ResponseBase.ReturnFailed("Character cannot be updated because it does not exist.");
            }

            existingTibiaCharacter = MapUpdateRequest(existingTibiaCharacter, requestedTibiaCharacter);
            _context.TibiaCharacter.Update(existingTibiaCharacter);

            var response = await ResponseBaseMapper
                .MapErrorResponseUponDBFailElseSuccess(
                $"Error ocurred when trying to update tibia character with id: {existingTibiaCharacter.TibiaCharacterId}", 
                _context);

            return response;
        }

        private TibiaCharacter MapUpdateRequest(TibiaCharacter existingCharacter, TibiaCharacter requestCharacter)
        {
            if (!string.IsNullOrWhiteSpace(requestCharacter.Name))
            {
                existingCharacter.Name = requestCharacter.Name;
            }

            if (requestCharacter.Level != 0)
            {
                existingCharacter.Level = requestCharacter.Level;
            }

            if (!string.IsNullOrWhiteSpace(requestCharacter.PVPType))
            {
                existingCharacter.PVPType = requestCharacter.PVPType;
            }

            if (!string.IsNullOrWhiteSpace(requestCharacter.World))
            {
                existingCharacter.World = requestCharacter.World;
            }

            if(!string.IsNullOrWhiteSpace(requestCharacter.Guild))
            {
                existingCharacter.Guild = requestCharacter.Guild;
            }

            return existingCharacter;
        }

        private TibiaCharacterDTO GetTibiaCharacterFromDb(int tibiaCharacterId)
        {
            var tibiaCharacter = _context.TibiaCharacter
                .Where(tibiaCharacter => tibiaCharacter.TibiaCharacterId == tibiaCharacterId)
                .Select(tibiaCharacter => TibiaCharacterDTOMapper.MapTibiaCharacterToTibiaCharacterDTO(tibiaCharacter))
                .FirstOrDefault();

            return tibiaCharacter;
        }
    }
}
