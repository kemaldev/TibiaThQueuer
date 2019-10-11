using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Responses
{
    public class GetAccountResponse : ResponseBase
    {
        public AccountDTO Account { get; set; }
    }
}
