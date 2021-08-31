using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace Whoohoo.Helpers
{
    public static class CsvDataHelper
    {
        public static IEnumerable<T> Read<T>(string path, CsvConfiguration csvConfiguration = null)
            where T : class
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            List<T> records;

            try
            {
                var csvConfig = csvConfiguration ?? new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    Delimiter = ";",
                    MissingFieldFound = null
                };

                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, csvConfig);
                records = csv.GetRecords<T>().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return records;
        }
    }
}
