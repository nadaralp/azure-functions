using CosmosDb.CrudDemo.Infrastructure.Security.Requirements;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Infrastructure.Security.AuthorizationHandlers
{
    public class FileUploadAuthorizationHandler : AuthorizationHandler<FileUploadTokenRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FileUploadTokenRequirement requirement)
        {
            throw new NotImplementedException();
        }
    }
}
