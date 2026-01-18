using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using NetUnderTheHoodAssignment.NewSolution;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var data = new FastTableData(csvData.Columns);

        foreach(var row in csvData.Rows)
        {
            var newRow = new FastRow();

            foreach (var column in data.Columns)
            {
                var value = row[Array.IndexOf(data.Columns.ToArray(), column)];
                if (string.IsNullOrEmpty(value)) { continue; }

                else if ((value == "TRUE" || value == "FALSE") && bool.TryParse(value, out var boolResult))
                {
                    newRow.AssignCell(column, boolResult);
                }

                else if (value.Contains(".") && decimal.TryParse(value, out var decimalResult))
                {
                    newRow.AssignCell(column, decimalResult);
                }

                else if (int.TryParse(value, out var intResult))
                {
                    newRow.AssignCell(column, intResult);
                }
                else
                {
                    newRow.AssignCell(column, value);
                }
            }
            data.Rows.Add(newRow);
        }
        return data;
    }
}
