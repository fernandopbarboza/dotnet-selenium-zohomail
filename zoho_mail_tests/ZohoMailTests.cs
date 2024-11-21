using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace zoho_mail_tests;

    public class ZohoMailTests
    {   
        public static string BaseUrl = "https://mail.zoho.com/zm/#mail/folder/inbox";
        public const int Timeout = 10;

        [Test]
        [Category("Selenium")]
        public void LoginZoho()
        {
        /*
        cd C:\Program Files\Google\Chrome\Application
        chrome.exe --remote-debugging-port=4444 --user-data-dir="C:\Users\ferna\AppData\Local\Google\Chrome\User Data"
        */

            //IWebDriver driver = new ChromeDriver();
            ChromeOptions options = new ChromeOptions();
            options.AddLocalStatePreference("debuggerAddress", "127.0.0.1:5656");
            ChromeDriver driver = new ChromeDriver(options); 
            
            driver.Navigate().GoToUrl(BaseUrl);

            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(120));
            wait.Until(drv=> drv.FindElement(By.Id("folderbutton-:rf:")));

            //Assert.That(driver.Title, Is.EqualTo("Caixa de entrada - Zoho Mail (contato@expertfiscaltributario.com.br)"));

            //More Options Button => menubutton-:r0:
            driver.FindElement(By.Id("menubutton-:r0:")).Click();            

            wait = new WebDriverWait(driver,TimeSpan.FromSeconds(30));

            //Novo Contato => ul.x4-list-plain li:nth-child(3)            
            wait.Until(drv=> drv.FindElement(By.CssSelector("ul.zmlist__1a1q60m li:nth-child(4)"))).Click();

            //Nome => first_name
            wait.Until(drv=> drv.FindElement(By.Name("first_name")));
            IWebElement nome = driver.FindElement(By.Name("first_name"));
            nome.SendKeys("Fernando");  

            //Email => email_id
            wait.Until(drv=> drv.FindElement(By.Name("email_id")));
            IWebElement email = driver.FindElement(By.Name("email_id"));
            email.SendKeys("teste@expertfiscaltributario.com.br");

            //Salvar => <span class="sel">Salvar</span>
            wait.Until(drv=> drv.FindElement(By.CssSelector("span.sel")));
            IWebElement salvar = driver.FindElement(By.CssSelector("span.sel"));
            salvar.Click();
            
            //Assert.That(driver.Title, Is.EqualTo("Email profissional | Email corporativo seguro para sua empresa - Zoho Mail"));

            driver.Quit();
        }
    
    }
