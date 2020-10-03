using Cosmos.DataInteractionFacade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Models
{
    public class Stock : BaseCosmosEntity
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
    }
}
