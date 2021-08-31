using System.Collections.Generic;
using System.Linq;
using Whoohoo.Helpers;

namespace Whoohoo.Repository.RepositoryContext
{
    public abstract class CsvContext<T>
        where T : class
    {
        protected IEnumerable<T> DataSet;

        private readonly string _filePath;

        protected CsvContext(string filePath)
        {
            _filePath = filePath;
            LoadData();
        }

        protected void LoadData()
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                PrintHelper.PrintError("File path can't be empty");
            }

            var data = CsvDataHelper.Read<T>(_filePath).ToList();

            if (data.Any())
            {
                DataSet = data;
                return;
            }

            PrintHelper.PrintError($"Can not load data from file: {_filePath}");

            DataSet = data;
        }
    }
}
