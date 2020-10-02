using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.OptionsPattern
{
    public class CosmosDbOptions
    {
        public string Uri { get; set; }
        public string ApiKey { get; set; }
        public string CollectionName { get; set; }
    }
}
