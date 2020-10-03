using Cosmos.DataInteractionFacade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Models
{
    public class StockHolder : BaseCosmosEntity
    {
        public class StockHolding
        {
            public int NumberHeld { get; set; }
            public Guid StockId { get; set; }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<StockHolding> Holdings { get; set; }
    }
}
