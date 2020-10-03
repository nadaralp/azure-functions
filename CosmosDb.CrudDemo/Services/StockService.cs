using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Services
{
    public class StockService : GenericCosmosRepository<Stock>, IStockService
    {
        public StockService(
            CosmosClient cosmosClient,
            string databaseName,
            string containerName) : base(cosmosClient, databaseName, containerName)
        {
        }


    }
}
