using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System.Text;

namespace LearningWebAPI.Security
{
    public class RequireHttpAttribute : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Scheme.ToLowerInvariant() != "https")
                context.HttpContext.Response.StatusCode = 403;
            context.HttpContext.Response.Body = new MemoryStream(Encoding.UTF8.GetBytes("Https required"));
        }
    }
}
