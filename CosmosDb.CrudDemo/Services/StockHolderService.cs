using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Dto;
using CosmosDb.CrudDemo.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<IEnumerable<StockByHolderAggregate>> GetStocksByHolders()
        {
            throw new NotImplementedException();
        }
    }
}
