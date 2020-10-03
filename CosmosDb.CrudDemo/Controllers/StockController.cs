using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CosmosDb.CrudDemo.Dto;
using CosmosDb.CrudDemo.Models;
using CosmosDb.CrudDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CosmosDb.CrudDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        public StockController(IStockService stockService, IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<StockDto>> ListAllStocks()
        {
            return _mapper.Map<IEnumerable<StockDto>>(await _stockService.GetAllAsync());
        }
    }
}
