using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService.IO
{
    public abstract class AbstractFileIOService<T> : IFileIOService<T> where T : new()
    {
        public string FilePath { get; set; }

        public abstract Task<IEnumerable<T>> GetData();

        public virtual IFileIOService<T> LoadFile(string filePath)
        {
            FilePath = FilePath;
            return this;
        }
    }
}
