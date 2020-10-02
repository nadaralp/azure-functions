using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Repository
{

    //Todo: see how to interact with the interface on dependency injection
    public interface ITodoRepository : ICosmosRepository<Todo>
    {
        
    }
}
