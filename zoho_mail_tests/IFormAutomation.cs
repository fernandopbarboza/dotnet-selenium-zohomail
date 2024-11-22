public interface IFormAutomation
{
    void OpenPage(string url);
    void FillAndSubmitForm(DadosLead data);
    void Close();
}
