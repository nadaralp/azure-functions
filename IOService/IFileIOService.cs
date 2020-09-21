using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService
{
    public interface IFileIOService<T> where T : new()
    {
        public void LoadFile(string filePath);
        public IEnumerable<T> GetData();
    }
}
