using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;

namespace NetUnderTheHoodAssignment.NewSolution;

public class FastTableData : ITableData
{
    private IEnumerable<string> _columns;

    public IEnumerable<string> Columns
    {
        get { return _columns; }
        init { _columns = value; }
    }


    public int RowCount =>  Rows.Count;
    public List<FastRow> Rows { get; init; } = new List<FastRow>();

    public FastTableData(IEnumerable<string> columns)
    {
        _columns = columns;
    }

    public object GetValue(string columnName, int rowIndex)
    {
        var row = Rows[rowIndex];
        object value = null; 
        
        if(row.IntData.ContainsKey(columnName)) value = row.IntData[columnName];
        if(row.BoolData.ContainsKey(columnName)) value = row.BoolData[columnName];
        if(row.DecimalData.ContainsKey(columnName)) value = row.DecimalData[columnName];
        if(row.StringData.ContainsKey(columnName)) value = row.StringData[columnName];

        return value;
    }
}
