using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs.Mappers
{
    public static class AccountDTOMapper
    {
        public static AccountDTO MapAccountToAccountDTO(Account account)
        {
            var accountDTO = new AccountDTO
            {
                AccountId = account.AccountId,
                Email = account.Email,
                Password = account.Password,
                UserName = account.UserName
            };

            return accountDTO;
        }
    }
}
