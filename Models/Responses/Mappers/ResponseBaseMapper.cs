using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Responses.Mappers
{
    public static class ResponseBaseMapper
    {
        public static async Task<ResponseBase> SaveDbChangesAndMapResponse(string errorMessage, DbContext context)
        {
            try
            {
                await context.SaveChangesAsync();

                return new ResponseBase
                {
                    Success = true
                };
            }
            catch (DbUpdateException ex)
            {
                //log exception

                return ResponseBase.ReturnFailed(errorMessage);
            }
        }
    }
}
