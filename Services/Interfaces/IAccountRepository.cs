using Models;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAccountRepository
    {
        Task<ResponseBase> CreateAccountAsync(Account account);
        GetAccountResponse GetAccount(int accountId);
        Task<ResponseBase> DeleteAccountAsync(int accountId);
        ResponseBase Login(string userName, string passPhrase);
    }
}
