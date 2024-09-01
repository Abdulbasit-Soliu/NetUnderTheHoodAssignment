namespace CsvDataAccess.NewSolution;

public class FastRow
{
    private Dictionary<string, int> _intData = new();
    private Dictionary<string, string> _stringData = new();
    private Dictionary<string, bool> _boolData = new();
    private Dictionary<string, decimal> _decimalData = new();

    public void Assign(string columnName, int value)
    {
        _intData[columnName] = value;
    }
    public void Assign(string columnName, string value)
    {
        _stringData[columnName] = value;
    }
    public void Assign(string columnName, bool value)
    {
        _boolData[columnName] = value;
    }
    public void Assign(string columnName, decimal value)
    {
        _decimalData[columnName] = value;
    }

    public object GetAtColumn(string columnName)
    {
        if (_intData.ContainsKey(columnName))
        {
            return _intData[columnName];
        }
        if (_stringData.ContainsKey(columnName))
        {
            return _stringData[columnName];
        }
        if (_boolData.ContainsKey(columnName))
        {
            return _boolData[columnName];
        }
        if (_decimalData.ContainsKey(columnName))
        {
            return _decimalData[columnName];
        }
        return null;
        
    }
}
