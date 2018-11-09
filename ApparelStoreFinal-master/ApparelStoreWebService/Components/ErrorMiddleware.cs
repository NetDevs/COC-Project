using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApparelStoreWebService.Components
{
    public class ExceptionHandlingServiceMiddleware
    {
        public RequestDelegate Next;
        ILogger<ExceptionHandlingServiceMiddleware> log;


        public ExceptionHandlingServiceMiddleware(RequestDelegate Next, ILogger<ExceptionHandlingServiceMiddleware> log)
        {
            this.Next = Next;
            this.log=log;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
             catch (Exception e)
            {
                context.Response.ContentType = "application/json";
      
                log.LogCritical(e.Message);
                await context.Response.WriteAsync(e.Message);
            
            
            }
        }
    }
}
