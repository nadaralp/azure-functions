using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosDb.CrudDemo.Infrastructure.Options;
using CosmosDb.CrudDemo.Infrastructure.Security.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CosmosDb.CrudDemo.Controllers
{
    [Route("api/storage")]
    [ApiController]
    public class StorageInteractionController : ControllerBase
    {
        private readonly ILogger<StorageInteractionController> _logger;
        private readonly IOptions<PermittedUploadTokenOptions> _options;

        public StorageInteractionController(ILogger<StorageInteractionController> logger, IOptions<PermittedUploadTokenOptions> options)
        {
            _logger = logger;
            _options = options;
        }


        [HttpPost("upload")]
        //[Authorize(Policy = "StorageUpload")]
        //[UploadPermissionFilter]
        public async Task AddFileToBlobContainer(IFormFile file)
        {
            Console.WriteLine(file);
        }
    }
}
