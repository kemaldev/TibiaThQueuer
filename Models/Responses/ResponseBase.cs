using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Responses
{
    public class ResponseBase
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
