using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PIHelperSample
{
    public class CSVHelper
    {

        public async Task<List<T>> GetDataFileAsync<T>(string path, CsvConfiguration config)
        {
            return await Task.Run(() =>
            {
                List<T> values = new List<T>();
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        using (var csv = new CsvReader(reader, config))
                        {
                            IEnumerable<T> records = csv.GetRecords<T>();
                            values.AddRange(records);
                            return values;
                        }
                    }
                }
            });
        }


        public async Task<string> GetDataFileAsync(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string data = await reader.ReadToEndAsync();
                    return data;
                }
            }
           
        }
   
        public CsvConfiguration GetCsvConfiguration(Encoding encoding, CultureInfo cultureInfo, string delimiter  )
        {
            var config = new CsvConfiguration(cultureInfo)
            {
                Delimiter = delimiter,
                Encoding = encoding
            };
            return config;
        }

        internal string GetDataFileAsync()
        {
            throw new NotImplementedException();
        }
    }
}
