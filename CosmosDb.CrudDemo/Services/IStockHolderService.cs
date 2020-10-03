using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Models;

namespace CosmosDb.CrudDemo.Services
{
    public interface IStockHolderService : ICosmosRepository<StockHolder>
    {        
    }
}
