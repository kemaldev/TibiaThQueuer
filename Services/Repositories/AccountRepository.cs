using Data;
using Models;
using Models.Responses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TibiaThContext _context;

        public AccountRepository(TibiaThContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase> CreateAccountAsync(Account account)
        {
            _context.Account.Add(account);

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
                    ErrorMessage = "Error ocurred when trying to create the account"
                };
            }

            return new ResponseBase
            {
                Success = true
            };
        }

        public async Task<ResponseBase> DeleteAccountAsync(int accountId)
        {
            var account = _context.Account.Find(accountId);

            if(account == null)
            {
                return new ResponseBase
                {
                    Success = false,
                    ErrorMessage = "Deletion failed because the account did not exist."
                };
            }

            _context.Account.Remove(account);

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
                    ErrorMessage = "Error ocurred when trying to delete the account."
                };
            }

            return new ResponseBase
            {
                Success = true
            };
        }

        public GetAccountResponse GetAccount(int accountId)
        {
            var account = _context.Account.Find(accountId);

            if(account == null)
            {
                return new GetAccountResponse
                {
                    Success = false,
                    ErrorMessage = "Account did not exist."
                };
            }

            return new GetAccountResponse
            {
                Success = true,
                Account = account
            };
        }

        public ResponseBase Login(string userName, string passPhrase)
        {
            throw new NotImplementedException(); //Need to research how to implement this in the best way.
        }
    }
}
