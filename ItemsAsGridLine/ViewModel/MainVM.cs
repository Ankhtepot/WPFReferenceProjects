using ItemsAsGridLine.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemsAsGridLine.ViewModel
{
    public class MainVM
    {
        public List<List<string>> GridData;

        public MainVM()
        {
            GridData = generateGridData(5,5);
        }

        private List<List<string>> generateGridData(int rowCount = 1, int columnCount = 1)
        {
            rowCount = rowCount.Clamp(1,1000);
            columnCount = columnCount.Clamp(1,20);

            var result = new List<List<string>>();

            for (int i = 0; i < rowCount; i++)
            {
                var line = new List<string>();
                for (int j = 0; j < columnCount; j++)
                {
                    line.Add($"Line: {i} Column: {j}");
                }
                result.Add(line);
            }

            return result;
        }
    }
}
