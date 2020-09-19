using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp2
{
    // Options pattern give you access to the application settings configuration on runtime.
    public class OptionsPattern
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
    }
}
