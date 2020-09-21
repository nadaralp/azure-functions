using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService
{
    public class ExcelReader<T> : IFileIOService<T> where T : new()
    {
        private string FilePath { get; set; }

        public IEnumerable<T> GetData()
        {
            if (string.IsNullOrEmpty(FilePath))
                throw new InvalidOperationException($"filepath is empty for {nameof(ExcelReader<T>)}");


            using (FileStream stream = File.OpenRead(FilePath))
            using(IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
            {
                while (reader.Read())
                {
                    Console.WriteLine("hello");
                }
            }

            return null;
        }


        // Fluent Design Pattern
        public void LoadFile(string filePath)
        {
            FilePath = filePath;
        }
    }
}
