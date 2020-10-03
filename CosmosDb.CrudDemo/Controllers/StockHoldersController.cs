using System.Collections.Generic;
using System.Threading.Tasks;
using CosmosDb.CrudDemo.Models;
using CosmosDb.CrudDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CosmosDb.CrudDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockHoldersController : ControllerBase
    {
        private readonly IStockHolderService _stockHolderService;

        public StockHoldersController(IStockHolderService stockHolderService)
        {
            _stockHolderService = stockHolderService;
        }


        [HttpGet(nameof(GetAllRaw))]
        public async Task<IEnumerable<StockHolder>> GetAllRaw()
        {
            var data = await _stockHolderService.GetAllAsync();
            return data;
        }


    }
}
