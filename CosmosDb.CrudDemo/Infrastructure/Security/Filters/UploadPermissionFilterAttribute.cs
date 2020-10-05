using CosmosDb.CrudDemo.Infrastructure.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Infrastructure.Security.Filters
{
    public class UploadPermissionFilterAttribute : ActionFilterAttribute
    {

        public UploadPermissionFilterAttribute()
        {
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IServiceProvider serviceProvider = context.HttpContext.RequestServices;
            var permittedTokensOptions = serviceProvider.GetService<IOptions<PermittedUploadTokenOptions>>();

            context.Result = new UnauthorizedResult();
        }
    }
}
