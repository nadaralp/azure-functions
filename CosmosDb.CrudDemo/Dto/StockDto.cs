using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Dto
{
    public class StockDto
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
    }
}
