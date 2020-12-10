using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectLab
{

    public class MainPage
    {
        private IWebDriver _Driver;
        private WebDriverWait _Wait;
        public MainPage(IWebDriver browser, WebDriverWait wait)
        {
            _Driver = browser;
            _Wait = wait;
        }
        public MainPage Open()
        {
            _Driver.Navigate().GoToUrl("https://htc-online.ru");
            return this;
        }
        public MainPage OpenLoginForm()
        {
            IWebElement EnterButton = _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[text() = 'Регистрация']")));
            EnterButton.Click();
            return this;
        }
        public MainPage EnterLogin(string login)
        {
            IWebElement LoginInput = _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@placeholder = 'Электронная почта']")));
            LoginInput.Clear();
            LoginInput.SendKeys(login);
            return this;
        }
        public MainPage EnterPassword(string password)
        {
            IWebElement PasswordInput = _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@placeholder = '********']")));
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
            return this;
        }
        public MainPage Entering()
        {
            IWebElement EnterButton = _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@value= 'Войти']")));
            EnterButton.Click();
            return this;
        }
        public object GetLoginResult()
        {
            IWebElement LoginResult = _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//font[@class= 'errortext']")));
            return LoginResult.Text;
        }
        public AccessoriesPage OpenAccessoriesPage()
        {
            IWebElement accessoriesForSmartphonesButton = _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[text() = 'Аксессуары для смартфонов']")));
            accessoriesForSmartphonesButton.Click();
            return new AccessoriesPage(_Driver, _Wait);
        }
    }

    public class AccessoriesPage
    {
        private IWebDriver _Driver;
        private WebDriverWait _Wait;
        public AccessoriesPage(IWebDriver browser, WebDriverWait wait)
        {
            _Driver = browser;
            _Wait = wait;
        }
        public AccessoriesPage AudioFilter()
        {
            IWebElement audioButton = _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[text() = 'аудио']")));
            audioButton.Click();
            return this;
        }
        public AccessoriesPage OpenAdapterPage()
        {
            IWebElement originalAdapter = _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text() = 'Оригинальный адаптер с Type C на 3,5 мм (DC M321)']")));
            originalAdapter.Click();
            return this;
        }
        public AccessoriesPage BuyAdapter()
        {
            IWebElement buyButton = _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[text() = 'Купить']")));
            buyButton.Click();
            return this;
        }
        public BusketPage OpenBusketPage()
        {
            IWebElement goToBusketButton = _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text() = 'Перейти в корзину']")));
            goToBusketButton.Click();
            return new BusketPage(_Driver, _Wait);
        }
    }
    public class BusketPage
    {
        private IWebDriver _Driver;
        private WebDriverWait _Wait;
        public BusketPage(IWebDriver browser, WebDriverWait wait)
        {
            _Driver = browser;
            _Wait = wait;
        }
        public object OrderSum()
        {
            IWebElement TotalPrice = _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[@id = 'allSum_FORMATED']")));
            return TotalPrice.Text;
        }
    }
}