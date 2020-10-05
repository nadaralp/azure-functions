using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Infrastructure.Options
{
    public class PermittedUploadTokenOptions
    {
        public static string sectionName = "FileUploadPermissions";

        public string[] Tokens { get; set; }
    }
}
