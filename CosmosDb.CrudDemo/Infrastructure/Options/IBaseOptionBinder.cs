using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Infrastructure.Options
{
    public interface IBaseOptionBinder
    {
        string SectionName { get; }
    }
}
