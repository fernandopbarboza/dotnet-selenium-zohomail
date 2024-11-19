using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace zoho_mail_tests;

    public class ZohoMailTests
    {   
        public static string BaseUrl = "https://accounts.zoho.com/signin";
        public const int Timeout = 10;
        [Test]
        [Category("Selenium")]

        public void LoginZoho()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(BaseUrl);
            
            //E-mail => login_id
            WebElement email = driver.FindElement(By.Id("login_id"));
            email.SendKeys("contato@expertfiscaltributario.com.br");

            //Senha => login_password
            WebElement senha = driver.FindElement(By.Id("login_password"));
            senha.SendKeys("Fernanda123");

            //Botão => login_submit
            WebElement botao = driver.FindElement(By.Id("login_submit"));
            botao.Click();
            
            //Assert.That(driver.Title, Is.EqualTo("Zoho Mail (contato@expertfiscaltributario.com.br)"));
            Assert.That(driver.Title, Is.EqualTo("Email profissional | Email corporativo seguro para sua empresa - Zoho Mail"));

            driver.Quit();
        }
    
    }
