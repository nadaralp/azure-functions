using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.DataInteractionFacade
{
    internal class CosmosDbOptions
    {
        public string AccountEndpointUri { get; set; }
        public string ApiKey { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
