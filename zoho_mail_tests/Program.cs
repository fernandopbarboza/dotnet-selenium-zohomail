using System;

class Program
{
    static void Main(string[] args)
    {
        // Fonte de dados e URL de teste
        string csvFilePath = "dados.csv";
        string formUrl = "https://exemplo.com/formulario";

        // Configuração
        IDataReader<DadosLead> dataReader = new CsvDataReader();
        IFormAutomation formAutomation = new SeleniumFormAutomation();

        try
        {
            var records = dataReader.ReadData(csvFilePath);
            formAutomation.OpenPage(formUrl);

            foreach (var record in records)
            {
                formAutomation.FillAndSubmitForm(record);
                System.Threading.Thread.Sleep(2000); // Aguardar para evitar bloqueios
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        finally
        {
            formAutomation.Close();
        }
    }
}