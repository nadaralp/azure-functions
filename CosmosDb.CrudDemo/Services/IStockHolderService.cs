using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Dto;
using CosmosDb.CrudDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Services
{
    public interface IStockHolderService : ICosmosRepository<StockHolder>
    {
        Task<IEnumerable<StockByHolderAggregate>> GetStocksByHolders();
    }
}
