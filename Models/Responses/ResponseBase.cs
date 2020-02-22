using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Responses
{
    public class ResponseBase
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }


        public bool Failed => !Success; 

        public static ResponseBase ReturnFailed(string errorMessage)
        {
            return new ResponseBase
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
