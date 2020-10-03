using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Models;

namespace CosmosDb.CrudDemo.Services
{
    public interface IStockService : ICosmosRepository<Stock>
    {
        
    }
}
