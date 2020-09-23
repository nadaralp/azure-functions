using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService.IO
{
    public class AzureCsvReader<T> : AbstractFileIOService<T> where T : new()
    {
        public override Task<IEnumerable<T>> GetData()
        {
            throw new NotImplementedException();
        }

    }
}
