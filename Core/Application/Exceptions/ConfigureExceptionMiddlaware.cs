using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public static class ConfigureExceptionMiddlaware
    {
        public static void ConfigureExceptionHandlingMiddlaware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptonMiddleware>();
        }
    }
}
