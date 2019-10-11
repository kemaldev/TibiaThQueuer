using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace TibiaThQueuer.Controllers
{
    [Route("api/characterlist")]
    [ApiController]
    public class CharacterListController : ControllerBase
    {
        private ICharacterListRepository _repository;
        public CharacterListController(ICharacterListRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetCharacterList(int id)
        {
            var response = _repository.GetCharacterList(id);

            if (response.Success)
            {
                return Ok(response.CharacterList);
            }

            return NotFound(response.ErrorMessage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacterListAsync([FromBody] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _repository.CreateCharacterListAsync(id);

            if (response.Success)
            {
                return Ok();
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpPost("{id}/character")]
        public async Task<IActionResult> AddTibiaCharacterToListAsync(TibiaCharacter tibiaCharacter, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _repository.AddTibiaCharacterToListAsync(tibiaCharacter, id);

            if (response.Success)
            {
                return Ok();
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCharacterListAsync(int id)
        {
            var response = await _repository.RemoveCharacterListAsync(id);

            if (response.Success)
            {
                return Ok();
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpDelete("{id}/character")]
        public async Task<IActionResult> RemoveTibiaCharacterFromListAsync([FromBody] int tibiaCharacterId, int id)
        {
            var response = await _repository.RemoveTibiaCharacterFromListAsync(tibiaCharacterId, id);

            if (response.Success)
            {
                return Ok();
            }

            return BadRequest(response.ErrorMessage);
        }
    }
}