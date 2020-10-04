using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Infrastructure.Helpers
{
    public static class EnvironmentChecker
    {
        public static bool IsDevelopmentEnvironment()
        {
            #if DEBUG
                        return true;
            #else
                    return false;
            #endif
        }
    }
}
