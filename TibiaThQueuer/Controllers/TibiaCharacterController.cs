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
    [Route("api/character")]
    [ApiController]
    public class TibiaCharacterController : ControllerBase
    {
        private ITibiaCharacterRepository _repository;

        public TibiaCharacterController(ITibiaCharacterRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetTibiaCharacter(int id)
        {
            var response = _repository.GetTibiaCharacter(id);

            if(response.Success)
            {
                return Ok(response.tibiaCharacter);
            }

            return NotFound(response.ErrorMessage);
        }

        [HttpPost]
        public async Task<IActionResult> AddTibiaCharacterAsync(TibiaCharacter tibiaCharacter)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _repository.AddTibiaCharacterAsync(tibiaCharacter);

            if(response.Success)
            {
                return Ok();
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTibiaCharacter(int id, TibiaCharacter tibiaCharacter)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _repository.UpdateTibiaCharacterAsync(id, tibiaCharacter);

            if(response.Success)
            {
                return Ok();
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTibiaCharacter(int id)
        {
            var response = await _repository.DeleteTibiaCharacterAsync(id);

            if(response.Success)
            {
                return Ok();
            }

            return BadRequest(response.ErrorMessage);
        }
    }
}