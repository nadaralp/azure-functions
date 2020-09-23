using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService.IO
{
    public interface IFileIOService<T> where T : new()
    {
        public IFileIOService<T> LoadFile(string filePath);
        public Task<IEnumerable<T>> GetData();
    }
}