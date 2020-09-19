using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1.MockService
{
    public class ErrorService
    {
        public void DoStuff()
        {
            throw new IndexOutOfRangeException("amazing index out of ragne exception");
        }
    }
}
