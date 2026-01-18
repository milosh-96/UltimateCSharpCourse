using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetUnderTheHoodAssignment.NewSolution;
public class FastRow
{
    public Dictionary<string, int> IntData { get; init; } = new Dictionary<string, int>();
    public Dictionary<string, bool> BoolData { get; init; } = new Dictionary<string, bool>();
    public Dictionary<string, decimal> DecimalData { get; init; } = new Dictionary<string, decimal>();
    public Dictionary<string, string> StringData { get; init; } = new Dictionary<string, string>();

    public void AssignCell(string columnName, int value)
    {
        IntData.Add(columnName, value);
    }
    public void AssignCell(string columnName, bool value)
    {
        BoolData.Add(columnName, value);
    }
    public void AssignCell(string columnName, decimal value)
    {
        DecimalData.Add(columnName, value);
    }
    public void AssignCell(string columnName, string value)
    {
        StringData.Add(columnName, value);
    }
}
