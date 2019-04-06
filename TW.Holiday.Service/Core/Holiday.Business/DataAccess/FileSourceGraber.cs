using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday.Business.DataAccess
{
    public class FileSourceGraber<T> : ISourceGraber<T>
    {
        private string filePath;

        public FileSourceGraber(string filePath)
        {
            this.filePath = filePath;
        }

        public T GetSource()
        {
            string json = System.IO.File.ReadAllText(filePath);

            T result = JsonConvert.DeserializeObject<T>(json);

            return result;
        }
    }
}
