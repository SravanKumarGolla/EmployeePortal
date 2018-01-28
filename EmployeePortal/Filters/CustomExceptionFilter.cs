using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace EmployeePortal.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                context.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
            }
        }
        
    }
}