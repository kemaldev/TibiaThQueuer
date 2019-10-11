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
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountRepository _repository;
        public AccountController(IAccountRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            var response = _repository.GetAccount(id);

            if (response.Success)
            {
                return Ok(response.Account);
            }

            return NotFound(response.ErrorMessage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccountAsync(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _repository.CreateAccountAsync(account);

            if (response.Success)
            {
                return Ok();
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountAsync(int id)
        {
            var response = await _repository.DeleteAccountAsync(id);

            if (response.Success)
            {
                return Ok();
            }

            return BadRequest(response.ErrorMessage);
        }

    }
}