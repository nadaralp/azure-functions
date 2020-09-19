using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp2.Services
{
    public class TestService : ITestService
    {
        public string DoSomething()
        {
            return "Test service dependency injeetion is working";
        }
    }
}
