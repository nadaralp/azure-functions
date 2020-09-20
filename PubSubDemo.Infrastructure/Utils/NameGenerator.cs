using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubDemo.Infrastructure.Utils
{
    public class NameGenerator
    {
        public string GenerateName()
        {
            // ASCII 97 - 122 for lower case names
            var random = new Random();
            int until = random.Next(5, 8);

            // Length of name from 5 to 8 characters;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < until; i++)
            {
                char c = (char)random.Next(97, 123);
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
