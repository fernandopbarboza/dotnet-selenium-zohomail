using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class SeleniumFormAutomation : IFormAutomation
{
    private readonly IWebDriver _driver;

    public SeleniumFormAutomation()
    {
        // Conectar a um navegador Chrome já aberto
        var options = new ChromeOptions();

        // Porta padrão usada pelo ChromeDriver para sessões existentes
        options.DebuggerAddress = "127.0.0.1:9222";

        // Inicializar o WebDriver com a conexão remota
        _driver = new ChromeDriver(options);

        // Validar se o título corresponde ao navegador desejado
        if (_driver.Title != "Zoho Mail (contato@expertfiscaltributario.com.br)")
        {
            throw new InvalidOperationException("Título do navegador não corresponde à instância esperada.");
        }
    }

    public void OpenPage(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    public void FillAndSubmitForm(DadosLead data)
    {
        _driver.FindElement(By.Id("campoNome")).SendKeys(data.Nome);
        _driver.FindElement(By.Id("campoEmail")).SendKeys(data.Email);
        _driver.FindElement(By.Id("campoTelefone")).SendKeys(data.Telefone);
        _driver.FindElement(By.Id("botaoEnviar")).Click();
    }

    public void Close()
    {
        _driver.Quit();
    }
}
