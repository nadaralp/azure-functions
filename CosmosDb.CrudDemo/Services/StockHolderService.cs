using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Models;
using Microsoft.Azure.Cosmos;

namespace CosmosDb.CrudDemo.Services
{
    public class StockHolderService  : GenericCosmosRepository<StockHolder>, IStockHolderService
    {
        public StockHolderService(
           CosmosClient cosmosClient,
           string databaseName,
           string containerName) : base(cosmosClient, databaseName, containerName)
        {
        }
    }
}
