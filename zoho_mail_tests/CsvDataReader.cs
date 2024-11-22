using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class CsvDataReader : IDataReader<DadosLead>
{
    public IEnumerable<DadosLead> ReadData(string source)
    {
        using (var reader = new StreamReader(source))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<DadosLead>().ToList();
        }
    }
}