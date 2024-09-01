using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;
using System.Data.Common;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{

    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<FastRow>();

        foreach (var row in csvData.Rows)
        {
            var fastRow = new FastRow();

            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = row[columnIndex];
                
                if (string.IsNullOrEmpty(valueAsString))
                {
                    continue;
                }
                else if (valueAsString == "TRUE")
                {
                    fastRow.Assign(column, valueAsString);
                }
                else if (valueAsString == "FALSE")
                {
                    fastRow.Assign(column, valueAsString);
                }
                else if (valueAsString.Contains(".") && decimal.TryParse(valueAsString, out var valueAsDecimal))
                {
                    fastRow.Assign(column, valueAsDecimal);
                }
                else if (int.TryParse(valueAsString, out var valueAsInt))
                {
                    fastRow.Assign(column, valueAsInt);
                }
                else
                {
                    fastRow.Assign(column, valueAsString);
                }
            }

            resultRows.Add(fastRow);
        }

        return new FastTableData(csvData.Columns, resultRows);
    }

   
}
